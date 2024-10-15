namespace LookR
{
    partial class Form1
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
            btnSignIn = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            btnRefreshData = new Button();
            dataGridView1 = new DataGridView();
            lblTotalCount = new Label();
            comboBoxMailFolder = new ComboBox();
            lblMailFolder = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnSignIn
            // 
            btnSignIn.AccessibleName = "btnSignIn";
            btnSignIn.Location = new Point(496, 280);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(289, 100);
            btnSignIn.TabIndex = 0;
            btnSignIn.Text = "Log in";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // comboBox1
            // 
            comboBox1.AccessibleName = "mailboxComboBox";
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(42, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.Visible = false;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 60);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 2;
            label1.Text = "Mailbox";
            label1.Visible = false;
            // 
            // comboBox2
            // 
            comboBox2.AccessibleName = "timeFrameComboBox";
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(42, 189);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 3;
            comboBox2.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 171);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 4;
            label2.Text = "Time Frame";
            label2.Visible = false;
            // 
            // btnRefreshData
            // 
            btnRefreshData.AccessibleName = "btnRefreshData";
            btnRefreshData.Location = new Point(42, 226);
            btnRefreshData.Name = "btnRefreshData";
            btnRefreshData.Size = new Size(121, 23);
            btnRefreshData.TabIndex = 5;
            btnRefreshData.Text = "Refresh Data";
            btnRefreshData.UseVisualStyleBackColor = true;
            btnRefreshData.Visible = false;
            btnRefreshData.Click += btnRefreshData_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(203, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1010, 556);
            dataGridView1.TabIndex = 6;
            dataGridView1.Visible = false;
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Location = new Point(203, 619);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(84, 15);
            lblTotalCount.TabIndex = 7;
            // 
            // comboBoxMailFolder
            // 
            comboBoxMailFolder.FormattingEnabled = true;
            comboBoxMailFolder.Location = new Point(42, 132);
            comboBoxMailFolder.Name = "comboBoxMailFolder";
            comboBoxMailFolder.Size = new Size(121, 23);
            comboBoxMailFolder.TabIndex = 8;
            comboBoxMailFolder.Visible = false;
            // 
            // lblMailFolder
            // 
            lblMailFolder.AutoSize = true;
            lblMailFolder.Location = new Point(42, 114);
            lblMailFolder.Name = "lblMailFolder";
            lblMailFolder.Size = new Size(66, 15);
            lblMailFolder.TabIndex = 9;
            lblMailFolder.Text = "Mail Folder";
            lblMailFolder.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(lblMailFolder);
            Controls.Add(comboBoxMailFolder);
            Controls.Add(lblTotalCount);
            Controls.Add(dataGridView1);
            Controls.Add(btnRefreshData);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(btnSignIn);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSignIn;
        private ComboBox comboBox1;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private Button btnRefreshData;
        private DataGridView dataGridView1;
        private Label lblTotalCount;
        private ComboBox comboBoxMailFolder;
        private Label lblMailFolder;
    }
}
