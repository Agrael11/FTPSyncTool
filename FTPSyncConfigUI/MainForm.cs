using FTPSyncLib;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.ServiceProcess;

namespace FTPSyncConfigUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ResizeColumns();
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(PathInfo.ConfigurationLocation);
            RepopulateListView();
            UpdateLabel();
        }

        public void UpdateLabel()
        {
            Install_Button.Text = "Install Service";
            Start_Button.Enabled = false;
            Start_Button.Text = "Start Service";
            if (!IsServiceInstalled())
            {
                return;
            }
            Install_Button.Text = "Uninstall Service";
            Start_Button.Enabled = true;
            if (!IsServiceRunning())
            {
                return;
            }
            Start_Button.Text = "Stop Service";
        }

        public void RepopulateListView()
        {
            listView1.Items.Clear();
            if (File.Exists(PathInfo.ProfilesFile))
            {
                ProfileManager.LoadFromFile(PathInfo.ProfilesFile);
            }
            foreach (var profileName in ProfileManager.GetAllProfileNames())
            {
                var profile = ProfileManager.GetProfile(profileName);
                var listViewItem = new ListViewItem(
                [
                    profile.ProfileName,
                    profile.Host,
                    profile.RemoteDirectory,
                    profile.LastSynced?.ToString("g") ?? "Never"
                ]);
                listView1.Items.Add(listViewItem);
            }
            ResizeColumns();
        }

        public void ResizeColumns()
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            var columnSizes = new int[listView1.Columns.Count];
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                columnSizes[i] = listView1.Columns[i].Width;
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                if (listView1.Columns[i].Width < columnSizes[i])
                {
                    listView1.Columns[i].Width = columnSizes[i];
                }
            }
        }

        private void AddP_Button_Click(object sender, EventArgs e)
        {
            var addDialogue = new AddDialogue();
            if (addDialogue.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var newProfileName = addDialogue.GetProfileName();
            var editDialogue = new EditDialogue();
            editDialogue.SetProfileName(newProfileName);
            editDialogue.SetTitle($"Configure New Profile ({newProfileName})");
            if (editDialogue.ShowDialog() == DialogResult.OK)
            {
                ProfileManager.SaveToFile(PathInfo.ProfilesFile);
                RepopulateListView();
            }
            else
            {
                DeleteProfile(newProfileName, true);
            }
        }

        private void EditP_Button_Click(object sender, EventArgs e)
        {
            var selectedProfiles = GetSelectedProfiles();
            if (selectedProfiles.Length == 0)
            {
                return;
            }
            var profile = selectedProfiles[0];
            var editDialogue = new EditDialogue();
            editDialogue.SetProfileName(profile);
            editDialogue.SetTitle($"Editing Profile {profile}");
            if (editDialogue.ShowDialog() == DialogResult.OK)
            {
                ProfileManager.SaveToFile(PathInfo.ProfilesFile);
                RepopulateListView();
            }
        }

        private void RenameP_Button_Click(object sender, EventArgs e)
        {
            var selectedProfiles = GetSelectedProfiles();
            if (selectedProfiles.Length == 0)
            {
                return;
            }
            var profile = selectedProfiles[0];
            var dialogue = new RenameDialogue();
            dialogue.SetText("Enter the new profile name:", profile);
            dialogue.SetTitle("Rename Profile");
            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                ProfileManager.SaveToFile(PathInfo.ProfilesFile);
                RepopulateListView();
            }
        }

        private void RemoveP_Button_Click(object sender, EventArgs e)
        {
            var selectedProfiles = GetSelectedProfiles();
            if (selectedProfiles.Length == 0)
            {
                return;
            }
            if (selectedProfiles.Length == 1)
            {
                DeleteProfile(selectedProfiles[0]);
            }
            else
            {
                var allConfirmed = false;
                foreach (var selected in selectedProfiles)
                {
                    var safe = allConfirmed;
                    if (!allConfirmed)
                    {
                        var dialogue = new DeleteAllDialogue();
                        dialogue.SetTitle("Delete Multiple Profiles");
                        dialogue.SetText($"Are you sure you want to delete the profile '{selected}'?\n\nYou have {selectedProfiles.Length} profiles selected.");
                        dialogue.ShowDialog();
                        if (dialogue.Result == DeleteAllDialogue.DeleteAllResult.YesAll)
                        {
                            allConfirmed = true;
                            safe = true;
                        }
                        else if (dialogue.Result == DeleteAllDialogue.DeleteAllResult.Yes)
                        {
                            safe = true;
                        }
                        else if (dialogue.Result == DeleteAllDialogue.DeleteAllResult.Cancel)
                        {
                            break;
                        }
                        else
                        {
                            safe = false;
                        }
                    }
                    if (safe) DeleteProfile(selected, true);
                }
            }
            ProfileManager.SaveToFile(PathInfo.ProfilesFile);
            RepopulateListView();
        }

        private static void DeleteProfile(string item, bool deleteAsked = false)
        {
            if (!deleteAsked)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the profile '{item}'?", "Deleting Profile", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            ProfileManager.RemoveProfile(item);
        }

        private string[] GetSelectedProfiles()
        {
            var selectedProfiles = new string[listView1.SelectedIndices.Count];
            var items = listView1.SelectedItems;
            for (var i = 0; i < items.Count; i++)
            {
                selectedProfiles[i] = items[i].SubItems[0].Text;
            }
            return selectedProfiles;
        }

        private static bool IsServiceRunning()
        {
            return TryGetService(out var service)
                && (service is not null)
                && (service.Status == ServiceControllerStatus.Running);
        }

        private static bool TryGetService(out ServiceController? service)
        {
            var services = ServiceController.GetServices();
            service = services.FirstOrDefault();
            return services.Any(t => t.ServiceName == PathInfo.ServiceName);
        }

        private static bool IsServiceInstalled()
        {
            return TryGetService(out _);
        }

        private static void RunSc(string arguments)
        {
            var info = new ProcessStartInfo
            {
                FileName = "sc.exe",
                Arguments = arguments,
                Verb = "runas",
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private static bool InstallService()
        {
            var thisDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (thisDirectory is null) return false;
            var serviceFileName = "FTPSyncService.exe";
            var servicePath = Path.Combine(thisDirectory, serviceFileName);
            var arguments = $"create \"{PathInfo.ServiceName}\" binPath=\"{servicePath}\" start= auto";
            RunSc(arguments);
            return true;
        }

        private static void UninstallService()
        {
            var arguments = $"delete \"{PathInfo.ServiceName}\"";
            RunSc(arguments);
        }

        private static void StartService()
        {
            TryGetService(out var service);
            service?.Start();
        }

        private static void StopService()
        {
            TryGetService(out var service);
            service?.Stop();
        }

        private void Install_Button_Click(object sender, EventArgs e)
        {
            if (!IsServiceInstalled())
            {
                InstallService();
                UpdateLabel();
                return;
            }

            if (IsServiceRunning())
            {
                StopService();
            }

            UninstallService();
            UpdateLabel();

            return;
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (!IsServiceInstalled())
            {
                return;
            }

            if (IsServiceRunning())
            {
                StopService();
            }
            else
            {
                StartService();
            }

            UpdateLabel();
            return;
        }
    }
}
