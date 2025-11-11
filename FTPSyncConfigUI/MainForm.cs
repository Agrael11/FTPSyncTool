using FTPSyncLib;

namespace FTPSyncConfigUI
{
    public partial class MainForm : Form
    {
        private static readonly string ConfigurationLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tachi", "FTPSync");
        private static readonly string ConfigurationFile = Path.Combine(ConfigurationLocation, "cofig.json");
        private static readonly string ProfilesFile = Path.Combine(ConfigurationLocation, "profiles.json");

        public MainForm()
        {
            InitializeComponent();
            ResizeColumns();
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(ConfigurationLocation);
            RepopulateListView();
        }

        public void RepopulateListView()
        {
            listView1.Items.Clear();
            if (File.Exists(ProfilesFile))
            {
                ProfileManager.LoadFromFile(ProfilesFile);
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
                ProfileManager.SaveToFile(ProfilesFile);
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
                ProfileManager.SaveToFile(ProfilesFile);
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
                ProfileManager.SaveToFile(ProfilesFile);
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
            ProfileManager.SaveToFile(ProfilesFile);
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
    }
}
