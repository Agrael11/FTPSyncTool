namespace FTPSyncConfigUI
{
    partial class EditDialogue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            groupBox4 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label5 = new Label();
            Activemode_Checkbox = new CheckBox();
            Binarymode_Checkbox = new CheckBox();
            label6 = new Label();
            Protocol_Combobox = new ComboBox();
            Port_NumPick = new NumericUpDown();
            groupBox3 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            HostName_Textbox = new TextBox();
            Password_Textbox = new TextBox();
            RemoteDirectory_Textbox = new TextBox();
            Username_Textbox = new TextBox();
            groupBox2 = new GroupBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            groupBox6 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            label10 = new Label();
            Overwrite_Checkbox = new CheckBox();
            BackupFreq_Textbox = new Label();
            DownMethod_Combobox = new ComboBox();
            BackupFrequency_NumPick = new NumericUpDown();
            groupBox5 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            BackupDir_Textbox = new TextBox();
            Subdir_Textbox = new TextBox();
            DirSettings_Combobox = new ComboBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            button1 = new Button();
            splitContainer2 = new SplitContainer();
            ProfileNameLabel = new Label();
            groupBox1.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            groupBox4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Port_NumPick).BeginInit();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            groupBox6.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackupFrequency_NumPick).BeginInit();
            groupBox5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel6);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1466, 380);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Settings";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(groupBox4, 1, 0);
            tableLayoutPanel6.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 35);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(1460, 342);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tableLayoutPanel2);
            groupBox4.Location = new Point(733, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(724, 336);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Advanced Settings";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(Activemode_Checkbox, 0, 2);
            tableLayoutPanel2.Controls.Add(Binarymode_Checkbox, 0, 3);
            tableLayoutPanel2.Controls.Add(label6, 0, 1);
            tableLayoutPanel2.Controls.Add(Protocol_Combobox, 1, 1);
            tableLayoutPanel2.Controls.Add(Port_NumPick, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 35);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(718, 298);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(75, 32);
            label5.TabIndex = 0;
            label5.Text = "Port : ";
            // 
            // Activemode_Checkbox
            // 
            Activemode_Checkbox.AutoSize = true;
            Activemode_Checkbox.Location = new Point(3, 94);
            Activemode_Checkbox.Name = "Activemode_Checkbox";
            Activemode_Checkbox.Size = new Size(181, 36);
            Activemode_Checkbox.TabIndex = 6;
            Activemode_Checkbox.Text = "Active Mode";
            Activemode_Checkbox.UseVisualStyleBackColor = true;
            // 
            // Binarymode_Checkbox
            // 
            Binarymode_Checkbox.AutoSize = true;
            Binarymode_Checkbox.Checked = true;
            Binarymode_Checkbox.CheckState = CheckState.Checked;
            Binarymode_Checkbox.Location = new Point(3, 136);
            Binarymode_Checkbox.Name = "Binarymode_Checkbox";
            Binarymode_Checkbox.Size = new Size(182, 36);
            Binarymode_Checkbox.TabIndex = 7;
            Binarymode_Checkbox.Text = "Binary Mode";
            Binarymode_Checkbox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 45);
            label6.Name = "label6";
            label6.Size = new Size(121, 32);
            label6.TabIndex = 2;
            label6.Text = "Protocol : ";
            // 
            // Protocol_Combobox
            // 
            Protocol_Combobox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Protocol_Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            Protocol_Combobox.FormattingEnabled = true;
            Protocol_Combobox.Location = new Point(191, 48);
            Protocol_Combobox.Name = "Protocol_Combobox";
            Protocol_Combobox.Size = new Size(524, 40);
            Protocol_Combobox.TabIndex = 5;
            // 
            // Port_NumPick
            // 
            Port_NumPick.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Port_NumPick.AutoSize = true;
            Port_NumPick.Location = new Point(191, 3);
            Port_NumPick.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            Port_NumPick.Name = "Port_NumPick";
            Port_NumPick.Size = new Size(524, 39);
            Port_NumPick.TabIndex = 4;
            Port_NumPick.Value = new decimal(new int[] { 21, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tableLayoutPanel1);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(724, 336);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Basic Settings";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(HostName_Textbox, 1, 0);
            tableLayoutPanel1.Controls.Add(Password_Textbox, 1, 2);
            tableLayoutPanel1.Controls.Add(RemoteDirectory_Textbox, 1, 3);
            tableLayoutPanel1.Controls.Add(Username_Textbox, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 35);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(718, 298);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 32);
            label1.TabIndex = 0;
            label1.Text = "Host : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 45);
            label2.Name = "label2";
            label2.Size = new Size(140, 32);
            label2.TabIndex = 1;
            label2.Text = "Username : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 90);
            label3.Name = "label3";
            label3.Size = new Size(130, 32);
            label3.TabIndex = 2;
            label3.Text = "Password : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 135);
            label4.Name = "label4";
            label4.Size = new Size(200, 32);
            label4.TabIndex = 3;
            label4.Text = "Remote Directory";
            // 
            // HostName_Textbox
            // 
            HostName_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HostName_Textbox.Location = new Point(209, 3);
            HostName_Textbox.Name = "HostName_Textbox";
            HostName_Textbox.Size = new Size(506, 39);
            HostName_Textbox.TabIndex = 0;
            // 
            // Password_Textbox
            // 
            Password_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Password_Textbox.Location = new Point(209, 93);
            Password_Textbox.Name = "Password_Textbox";
            Password_Textbox.PasswordChar = '*';
            Password_Textbox.Size = new Size(506, 39);
            Password_Textbox.TabIndex = 2;
            // 
            // RemoteDirectory_Textbox
            // 
            RemoteDirectory_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RemoteDirectory_Textbox.Location = new Point(209, 138);
            RemoteDirectory_Textbox.Name = "RemoteDirectory_Textbox";
            RemoteDirectory_Textbox.Size = new Size(506, 39);
            RemoteDirectory_Textbox.TabIndex = 3;
            // 
            // Username_Textbox
            // 
            Username_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Username_Textbox.Location = new Point(209, 48);
            Username_Textbox.Name = "Username_Textbox";
            Username_Textbox.Size = new Size(506, 39);
            Username_Textbox.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel7);
            groupBox2.Location = new Point(3, 389);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1466, 381);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Backup Settings";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(groupBox6, 1, 0);
            tableLayoutPanel7.Controls.Add(groupBox5, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 35);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(1460, 343);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(tableLayoutPanel4);
            groupBox6.Location = new Point(733, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(724, 337);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "Synchronization";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(label10, 0, 0);
            tableLayoutPanel4.Controls.Add(Overwrite_Checkbox, 0, 1);
            tableLayoutPanel4.Controls.Add(BackupFreq_Textbox, 0, 2);
            tableLayoutPanel4.Controls.Add(DownMethod_Combobox, 1, 0);
            tableLayoutPanel4.Controls.Add(BackupFrequency_NumPick, 1, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 35);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(718, 299);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(233, 32);
            label10.TabIndex = 0;
            label10.Text = "Download Method : ";
            // 
            // Overwrite_Checkbox
            // 
            Overwrite_Checkbox.AutoSize = true;
            Overwrite_Checkbox.Checked = true;
            Overwrite_Checkbox.CheckState = CheckState.Checked;
            Overwrite_Checkbox.Location = new Point(3, 49);
            Overwrite_Checkbox.Name = "Overwrite_Checkbox";
            Overwrite_Checkbox.Size = new Size(203, 36);
            Overwrite_Checkbox.TabIndex = 12;
            Overwrite_Checkbox.Text = "Overwrite Files";
            Overwrite_Checkbox.UseVisualStyleBackColor = true;
            // 
            // BackupFreq_Textbox
            // 
            BackupFreq_Textbox.AutoSize = true;
            BackupFreq_Textbox.Location = new Point(3, 88);
            BackupFreq_Textbox.Name = "BackupFreq_Textbox";
            BackupFreq_Textbox.Size = new Size(335, 32);
            BackupFreq_Textbox.TabIndex = 1;
            BackupFreq_Textbox.Text = "Backup Frequency (minutes) : ";
            // 
            // DownMethod_Combobox
            // 
            DownMethod_Combobox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DownMethod_Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            DownMethod_Combobox.FormattingEnabled = true;
            DownMethod_Combobox.Location = new Point(344, 3);
            DownMethod_Combobox.Name = "DownMethod_Combobox";
            DownMethod_Combobox.Size = new Size(371, 40);
            DownMethod_Combobox.TabIndex = 11;
            // 
            // BackupFrequency_NumPick
            // 
            BackupFrequency_NumPick.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BackupFrequency_NumPick.Location = new Point(344, 91);
            BackupFrequency_NumPick.Maximum = new decimal(new int[] { 525600, 0, 0, 0 });
            BackupFrequency_NumPick.Name = "BackupFrequency_NumPick";
            BackupFrequency_NumPick.Size = new Size(371, 39);
            BackupFrequency_NumPick.TabIndex = 13;
            BackupFrequency_NumPick.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(tableLayoutPanel3);
            groupBox5.Location = new Point(3, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(724, 337);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Directories";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(label7, 0, 0);
            tableLayoutPanel3.Controls.Add(label8, 0, 1);
            tableLayoutPanel3.Controls.Add(label9, 0, 2);
            tableLayoutPanel3.Controls.Add(BackupDir_Textbox, 1, 0);
            tableLayoutPanel3.Controls.Add(Subdir_Textbox, 1, 2);
            tableLayoutPanel3.Controls.Add(DirSettings_Combobox, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 35);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(718, 299);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(214, 32);
            label7.TabIndex = 0;
            label7.Text = "Backup Directory : ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 45);
            label8.Name = "label8";
            label8.Size = new Size(223, 32);
            label8.TabIndex = 1;
            label8.Text = "Directory Settings : ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 91);
            label9.Name = "label9";
            label9.Size = new Size(260, 32);
            label9.TabIndex = 2;
            label9.Text = "Subdirectory Naming : ";
            // 
            // BackupDir_Textbox
            // 
            BackupDir_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BackupDir_Textbox.Location = new Point(269, 3);
            BackupDir_Textbox.Name = "BackupDir_Textbox";
            BackupDir_Textbox.Size = new Size(446, 39);
            BackupDir_Textbox.TabIndex = 8;
            // 
            // Subdir_Textbox
            // 
            Subdir_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Subdir_Textbox.Location = new Point(269, 94);
            Subdir_Textbox.Name = "Subdir_Textbox";
            Subdir_Textbox.Size = new Size(446, 39);
            Subdir_Textbox.TabIndex = 10;
            // 
            // DirSettings_Combobox
            // 
            DirSettings_Combobox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DirSettings_Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            DirSettings_Combobox.FormattingEnabled = true;
            DirSettings_Combobox.Location = new Point(269, 48);
            DirSettings_Combobox.Name = "DirSettings_Combobox";
            DirSettings_Combobox.Size = new Size(446, 40);
            DirSettings_Combobox.TabIndex = 9;
            DirSettings_Combobox.SelectedIndexChanged += DirSettings_Combobox_SelectedIndexChanged;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel5.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(1472, 773);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel5);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Size = new Size(1472, 852);
            splitContainer1.SplitterDistance = 773;
            splitContainer1.TabIndex = 3;
            splitContainer1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(171, 15);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 15;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Cancel_Click;
            // 
            // button1
            // 
            button1.Location = new Point(15, 15);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 14;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(ProfileNameLabel);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer1);
            splitContainer2.Size = new Size(1472, 906);
            splitContainer2.TabIndex = 4;
            splitContainer2.TabStop = false;
            // 
            // ProfileNameLabel
            // 
            ProfileNameLabel.Dock = DockStyle.Fill;
            ProfileNameLabel.Font = new Font("Segoe UI", 12F);
            ProfileNameLabel.Location = new Point(0, 0);
            ProfileNameLabel.Name = "ProfileNameLabel";
            ProfileNameLabel.Size = new Size(1472, 50);
            ProfileNameLabel.TabIndex = 0;
            ProfileNameLabel.Text = "label11";
            ProfileNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditDialogue
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1472, 906);
            Controls.Add(splitContainer2);
            Name = "EditDialogue";
            Text = "EditDialogue";
            FormClosing += EditDialogue_FormClosing;
            Load += EditDialogue_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Port_NumPick).EndInit();
            groupBox3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BackupFrequency_NumPick).EndInit();
            groupBox5.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
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

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox HostName_Textbox;
        private TextBox Username_Textbox;
        private TextBox Password_Textbox;
        private TextBox RemoteDirectory_Textbox;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private CheckBox Binarymode_Checkbox;
        private CheckBox Activemode_Checkbox;
        private Label label6;
        private ComboBox Protocol_Combobox;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox BackupDir_Textbox;
        private TextBox Subdir_Textbox;
        private ComboBox DirSettings_Combobox;
        private TableLayoutPanel tableLayoutPanel4;
        private Label BackupFreq_Textbox;
        private Label label10;
        private CheckBox Overwrite_Checkbox;
        private ComboBox DownMethod_Combobox;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private NumericUpDown Port_NumPick;
        private NumericUpDown BackupFrequency_NumPick;
        private SplitContainer splitContainer1;
        private Button button2;
        private Button button1;
        private SplitContainer splitContainer2;
        private Label ProfileNameLabel;
    }
}