namespace FTPSyncConfigUI
{
    partial class ConfigDialogue
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
            label5 = new Label();
            Binarymode_Checkbox = new CheckBox();
            Port_NumPick = new NumericUpDown();
            groupBox3 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            Username_Textbox = new TextBox();
            Password_Textbox = new TextBox();
            label3 = new Label();
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)Port_NumPick).BeginInit();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 90);
            label5.Name = "label5";
            label5.Size = new Size(75, 32);
            label5.TabIndex = 0;
            label5.Text = "Port : ";
            // 
            // Binarymode_Checkbox
            // 
            Binarymode_Checkbox.AutoSize = true;
            Binarymode_Checkbox.Checked = true;
            Binarymode_Checkbox.CheckState = CheckState.Checked;
            Binarymode_Checkbox.Location = new Point(3, 138);
            Binarymode_Checkbox.Name = "Binarymode_Checkbox";
            Binarymode_Checkbox.Size = new Size(194, 36);
            Binarymode_Checkbox.TabIndex = 7;
            Binarymode_Checkbox.Text = "Web Interface";
            Binarymode_Checkbox.UseVisualStyleBackColor = true;
            // 
            // Port_NumPick
            // 
            Port_NumPick.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Port_NumPick.AutoSize = true;
            Port_NumPick.Location = new Point(203, 93);
            Port_NumPick.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            Port_NumPick.Name = "Port_NumPick";
            Port_NumPick.Size = new Size(492, 39);
            Port_NumPick.TabIndex = 4;
            Port_NumPick.Value = new decimal(new int[] { 5050, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tableLayoutPanel1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(704, 419);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Basic Settings";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(Binarymode_Checkbox, 0, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(Username_Textbox, 1, 0);
            tableLayoutPanel1.Controls.Add(Password_Textbox, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(Port_NumPick, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 35);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(698, 381);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(140, 32);
            label2.TabIndex = 1;
            label2.Text = "Username : ";
            // 
            // Username_Textbox
            // 
            Username_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Username_Textbox.Location = new Point(203, 3);
            Username_Textbox.Name = "Username_Textbox";
            Username_Textbox.Size = new Size(492, 39);
            Username_Textbox.TabIndex = 1;
            // 
            // Password_Textbox
            // 
            Password_Textbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Password_Textbox.Location = new Point(203, 48);
            Password_Textbox.Name = "Password_Textbox";
            Password_Textbox.PasswordChar = '*';
            Password_Textbox.Size = new Size(492, 39);
            Password_Textbox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 45);
            label3.Name = "label3";
            label3.Size = new Size(130, 32);
            label3.TabIndex = 2;
            label3.Text = "Password : ";
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
            splitContainer1.Panel1.Controls.Add(groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Size = new Size(704, 498);
            splitContainer1.SplitterDistance = 419;
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
            // ConfigDialogue
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 498);
            Controls.Add(splitContainer1);
            Name = "ConfigDialogue";
            Text = "ConfigDIalogue";
            FormClosing += EditDialogue_FormClosing;
            Load += EditDialogue_Load;
            ((System.ComponentModel.ISupportInitialize)Port_NumPick).EndInit();
            groupBox3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private TextBox Username_Textbox;
        private TextBox Password_Textbox;
        private Label label5;
        private CheckBox Binarymode_Checkbox;
        private NumericUpDown Port_NumPick;
        private SplitContainer splitContainer1;
        private Button button2;
        private Button button1;
    }
}