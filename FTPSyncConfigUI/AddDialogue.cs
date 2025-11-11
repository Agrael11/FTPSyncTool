using FTPSyncLib;

namespace FTPSyncConfigUI
{
    public partial class AddDialogue : Form
    {
        public string GetProfileName()
        {
            return textBox1.Text;
        }

        public AddDialogue()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
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

            var emptyProfile = new FTPProfile
            {
                ProfileName = textBox1.Text
            };
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
                    ProfileManager.AddProfile(emptyProfile);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                ProfileManager.AddProfile(emptyProfile);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
