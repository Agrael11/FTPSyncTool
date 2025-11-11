using FTPSyncLib;

namespace FTPSyncConfigUI
{
    public partial class ConfigDialogue : Form
    {
        public string ProfileName = "";
        
        private bool _manualclose = false;

        public ConfigDialogue()
        {
            InitializeComponent();
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
            LoadConfig();
        }

        private void LoadConfig()
        {
            var config = CommonConfigFile.Config.LoadFromFile(PathInfo.ConfigurationFile);
            config ??= new CommonConfigFile.Config();
            Username_Textbox.Text = config.UserName;
            Password_Textbox.Text = config.Password;
            Port_NumPick.Value = config.Port;
            Binarymode_Checkbox.Checked = config.WebAPI;
        }

        private void SaveConfig()
        {
            var config = CommonConfigFile.Config.LoadFromFile(PathInfo.ConfigurationFile);
            config ??= new CommonConfigFile.Config();
            config.UserName = Username_Textbox.Text;
            config.WebAPI = Binarymode_Checkbox.Checked;
            config.Password = Password_Textbox.Text;
            config.Port = (int)Port_NumPick.Value;
            CommonConfigFile.Config.SaveToFile(config, PathInfo.ConfigurationFile);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveConfig();
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
