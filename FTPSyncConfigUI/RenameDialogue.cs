using FTPSyncLib;

namespace FTPSyncConfigUI
{
    public partial class RenameDialogue : Form
    {
        public RenameDialogue()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }
        public void SetTitle(string title)
        {
            this.Text = title;
        }

        private string OriginalProfileName = "";

        public void SetOriginalProfileName(string text)
        {
            OriginalProfileName = text;
        }

        public void SetText(string text, string originalProfileName)
        {
            SetOriginalProfileName(originalProfileName);
            label1.Text = text;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (ProfileManager.IsProfileNameValid(textBox1.Text) == false)
            {
                MessageBox.Show("The profile name is not valid. It must be at least 5 characters long and not empty.", "Invalid Profile Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ProfileManager.ProfileExists(textBox1.Text))
            {
                var result = MessageBox.Show("A profile with that name already exists. Do you want to overwrite it?", "Confirm Rename", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    ProfileManager.RemoveProfile(textBox1.Text);
                    ProfileManager.RenameProfile(OriginalProfileName, textBox1.Text);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                ProfileManager.RenameProfile(OriginalProfileName, textBox1.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void RenameDialogue_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OK_Click(sender, e);
            }
        }
    }
}
