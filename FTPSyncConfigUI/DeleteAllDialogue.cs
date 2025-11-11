namespace FTPSyncConfigUI
{
    public partial class DeleteAllDialogue : Form
    {
        public enum DeleteAllResult
        {
            Yes,
            YesAll,
            No,
            Cancel
        }

        public DeleteAllResult Result { get; private set; } = DeleteAllResult.Cancel;

        public DeleteAllDialogue()
        {
            InitializeComponent();
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }

        public void SetText(string text)
        {
            label1.Text = text;
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            Result = DeleteAllResult.Yes;
            this.Close();
        }

        private void YesAllButton_Click(object sender, EventArgs e)
        {
            Result = DeleteAllResult.YesAll;
            this.Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            Result = DeleteAllResult.No;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Result = DeleteAllResult.Cancel;
            this.Close();
        }
    }
}
