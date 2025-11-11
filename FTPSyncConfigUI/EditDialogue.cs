using FTPSyncLib;

namespace FTPSyncConfigUI
{
    public partial class EditDialogue : Form
    {
        public string ProfileName = "";
        
        private bool _manualclose = false;

        public EditDialogue()
        {
            InitializeComponent();

            foreach (var protocolName in Enum.GetNames<FTPProtocol>())
            {
                Protocol_Combobox.Items.Add(protocolName);
            }
            Protocol_Combobox.SelectedIndex = 0;
            foreach (var directorySetting in Enum.GetNames<BackupMethod>())
            {
                DirSettings_Combobox.Items.Add(directorySetting);
            }
            DirSettings_Combobox.SelectedIndex = 0;
            foreach (var downloadMethod in Enum.GetNames<DownloadMethod>())
            {
                DownMethod_Combobox.Items.Add(downloadMethod);
            }
            DownMethod_Combobox.SelectedIndex = 0;
        }

        public void SetProfileName(string profileName)
        {
            ProfileName = profileName;
        }

        public void SetTitle(string text)
        {
            this.Text = text;
        }

        private void EditDialogue_Load(object sender, EventArgs e)
        {
            LoadProfile();

            EnableOrDisableSubdirTextbox();
        }

        private void LoadProfile()
        {
            var profile = ProfileManager.GetProfile(ProfileName);

            ProfileNameLabel.Text = profile.ProfileName;

            HostName_Textbox.Text = profile.Host;
            Username_Textbox.Text = profile.Username;
            Password_Textbox.Text = profile.Password;
            RemoteDirectory_Textbox.Text = profile.RemoteDirectory;

            Port_NumPick.Value = profile.Port;
            Protocol_Combobox.SelectedItem = profile.Protocol.ToString();
            Activemode_Checkbox.Checked = !profile.PassiveMode;
            Binarymode_Checkbox.Checked = (profile.TransferMode == FTPTransferMode.Binary);

            BackupDir_Textbox.Text = profile.LocalDirectory;
            DirSettings_Combobox.SelectedItem = profile.DirectoryBackupMethod.ToString();
            Subdir_Textbox.Text = profile.RemoteSubDirectoryNameFormat;

            DownMethod_Combobox.SelectedItem = profile.DownloadMethod.ToString();
            Overwrite_Checkbox.Checked = profile.OverwriteLocalFiles;
            BackupFrequency_NumPick.Value = (decimal)profile.SyncFrequency.TotalMinutes;
        }

        private void SaveProfile()
        {
            var profile = ProfileManager.GetProfile(ProfileName);

            profile.Host = HostName_Textbox.Text;
            profile.Username = Username_Textbox.Text;
            profile.Password = Password_Textbox.Text;
            profile.RemoteDirectory = RemoteDirectory_Textbox.Text;

            profile.Port = (int)Port_NumPick.Value;
            profile.Protocol = Enum.Parse<FTPProtocol>(Protocol_Combobox.SelectedItem?.ToString() ?? FTPProtocol.FTP.ToString());
            profile.PassiveMode = !Activemode_Checkbox.Checked;
            profile.TransferMode = Binarymode_Checkbox.Checked ? FTPTransferMode.Binary : FTPTransferMode.ASCII;

            profile.LocalDirectory = BackupDir_Textbox.Text;
            profile.DirectoryBackupMethod = Enum.Parse<BackupMethod>(DirSettings_Combobox.SelectedItem?.ToString() ?? BackupMethod.SingleFolder.ToString());
            profile.RemoteSubDirectoryNameFormat = Subdir_Textbox.Text;

            profile.DownloadMethod = Enum.Parse<DownloadMethod>(DownMethod_Combobox.SelectedItem?.ToString() ?? DownloadMethod.Mirror.ToString());
            profile.OverwriteLocalFiles = Overwrite_Checkbox.Checked;
            profile.SyncFrequency = TimeSpan.FromMinutes((double)BackupFrequency_NumPick.Value);
        }

        public void EnableOrDisableSubdirTextbox()
        {
            var enable = (DirSettings_Combobox.SelectedItem?.ToString() != BackupMethod.SingleFolder.ToString());
            Subdir_Textbox.Enabled = enable;
        }

        private void DirSettings_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableOrDisableSubdirTextbox();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveProfile();
            _manualclose = true;
            this.Close();
        }

        private void EditDialogue_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_manualclose)
            {
                return;
            }
            var result = MessageBox.Show("Are you sure you want to close without saving?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                DialogResult = DialogResult.Cancel;
                e.Cancel = true;
            }
        }
    }
}
