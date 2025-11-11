
namespace FTPSyncConfigUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            splitContainer2 = new SplitContainer();
            Edit_Button = new Button();
            RemoveP_Button = new Button();
            AddP_Button = new Button();
            RenameP_Button = new Button();
            Settings_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1168, 966);
            splitContainer1.SplitterDistance = 920;
            splitContainer1.TabIndex = 999;
            splitContainer1.TabStop = false;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(920, 966);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Profile Name";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Remote Server";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Remote Directory";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Last Time Synced";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel2;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(Edit_Button);
            splitContainer2.Panel1.Controls.Add(RemoveP_Button);
            splitContainer2.Panel1.Controls.Add(AddP_Button);
            splitContainer2.Panel1.Controls.Add(RenameP_Button);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(Settings_Button);
            splitContainer2.Size = new Size(244, 966);
            splitContainer2.SplitterDistance = 873;
            splitContainer2.TabIndex = 998;
            splitContainer2.TabStop = false;
            // 
            // Edit_Button
            // 
            Edit_Button.Location = new Point(18, 116);
            Edit_Button.Name = "Edit_Button";
            Edit_Button.Size = new Size(214, 46);
            Edit_Button.TabIndex = 2;
            Edit_Button.Text = "Edit Profile";
            Edit_Button.UseVisualStyleBackColor = true;
            Edit_Button.Click += EditP_Button_Click;
            // 
            // RemoveP_Button
            // 
            RemoveP_Button.Location = new Point(18, 168);
            RemoveP_Button.Name = "RemoveP_Button";
            RemoveP_Button.Size = new Size(214, 46);
            RemoveP_Button.TabIndex = 3;
            RemoveP_Button.Text = "Remove Profile";
            RemoveP_Button.UseVisualStyleBackColor = true;
            RemoveP_Button.Click += RemoveP_Button_Click;
            // 
            // AddP_Button
            // 
            AddP_Button.Location = new Point(18, 13);
            AddP_Button.Name = "AddP_Button";
            AddP_Button.Size = new Size(214, 46);
            AddP_Button.TabIndex = 0;
            AddP_Button.Text = "Add Profile";
            AddP_Button.UseVisualStyleBackColor = true;
            AddP_Button.Click += AddP_Button_Click;
            // 
            // RenameP_Button
            // 
            RenameP_Button.Location = new Point(18, 64);
            RenameP_Button.Name = "RenameP_Button";
            RenameP_Button.Size = new Size(214, 46);
            RenameP_Button.TabIndex = 1;
            RenameP_Button.Text = "Rename Profile";
            RenameP_Button.UseVisualStyleBackColor = true;
            RenameP_Button.Click += RenameP_Button_Click;
            // 
            // Settings_Button
            // 
            Settings_Button.Enabled = false;
            Settings_Button.Location = new Point(18, 15);
            Settings_Button.Name = "Settings_Button";
            Settings_Button.Size = new Size(214, 46);
            Settings_Button.TabIndex = 4;
            Settings_Button.Text = "Settings";
            Settings_Button.UseVisualStyleBackColor = true;
            Settings_Button.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 966);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            Text = "S";
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button RemoveP_Button;
        private Button AddP_Button;
        private Button RenameP_Button;
        private Button Settings_Button;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button Edit_Button;
    }
}
