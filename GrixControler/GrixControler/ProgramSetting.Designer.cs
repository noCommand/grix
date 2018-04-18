namespace GrixControler
{
    partial class ProgramSetting
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
            this.portCombx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.portGroupBox = new System.Windows.Forms.GroupBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // portCombx
            // 
            this.portCombx.FormattingEnabled = true;
            this.portCombx.Location = new System.Drawing.Point(92, 18);
            this.portCombx.Name = "portCombx";
            this.portCombx.Size = new System.Drawing.Size(85, 19);
            this.portCombx.TabIndex = 0;
            this.portCombx.SelectedIndexChanged += new System.EventHandler(this.portCombx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 11);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // portGroupBox
            // 
            this.portGroupBox.Controls.Add(this.portCombx);
            this.portGroupBox.Controls.Add(this.label1);
            this.portGroupBox.Font = new System.Drawing.Font("돋움체", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.portGroupBox.Location = new System.Drawing.Point(12, 12);
            this.portGroupBox.Name = "portGroupBox";
            this.portGroupBox.Size = new System.Drawing.Size(187, 48);
            this.portGroupBox.TabIndex = 4;
            this.portGroupBox.TabStop = false;
            this.portGroupBox.Text = "Com Setting";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(217, 27);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.Text = "초기화";
            this.ResetButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 209);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room Setting";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ID,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(19, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(244, 183);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // No
            // 
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 70;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "방이름";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // ProgramSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 338);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.portGroupBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ProgramSetting";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ProgramSetting_Load);
            this.portGroupBox.ResumeLayout(false);
            this.portGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox portCombx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox portGroupBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}