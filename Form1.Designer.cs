﻿namespace LookR
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnSignIn
            // 
            btnSignIn.AccessibleName = "btnSignIn";
            btnSignIn.Location = new Point(260, 149);
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
            comboBox2.Location = new Point(42, 131);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 3;
            comboBox2.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 113);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 4;
            label2.Text = "Time Frame";
            label2.Visible = false;
            // 
            // btnRefreshData
            // 
            btnRefreshData.AccessibleName = "btnRefreshData";
            btnRefreshData.Location = new Point(42, 172);
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(214, 78);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(519, 314);
            dataGridView1.TabIndex = 6;
            dataGridView1.Visible = false;
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Location = new Point(214, 395);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(0, 15);
            lblTotalCount.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
