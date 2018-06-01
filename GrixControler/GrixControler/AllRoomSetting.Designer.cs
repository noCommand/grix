namespace GrixControler
{
    partial class AllRoomSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllRoomSetting));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setTempControl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.setStepControl = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lockOffBtn = new System.Windows.Forms.RadioButton();
            this.LockOnBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.powerOffBtn = new System.Windows.Forms.RadioButton();
            this.powerOnBtn = new System.Windows.Forms.RadioButton();
            this.GroupRoomList = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setTempControl)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setStepControl)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(169, 266);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "취소";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click_1);
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(77, 266);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 24;
            this.ConfirmBtn.Text = "적용";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.setTempControl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(20, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 40);
            this.panel1.TabIndex = 23;
            // 
            // setTempControl
            // 
            this.setTempControl.Location = new System.Drawing.Point(113, 10);
            this.setTempControl.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.setTempControl.Name = "setTempControl";
            this.setTempControl.Size = new System.Drawing.Size(76, 21);
            this.setTempControl.TabIndex = 8;
            this.setTempControl.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "\'C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "설정온도";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.setStepControl);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(20, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 40);
            this.panel2.TabIndex = 22;
            // 
            // setStepControl
            // 
            this.setStepControl.Location = new System.Drawing.Point(113, 10);
            this.setStepControl.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.setStepControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.setStepControl.Name = "setStepControl";
            this.setStepControl.Size = new System.Drawing.Size(76, 21);
            this.setStepControl.TabIndex = 9;
            this.setStepControl.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "단계";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "설정단계";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lockOffBtn);
            this.groupBox2.Controls.Add(this.LockOnBtn);
            this.groupBox2.Location = new System.Drawing.Point(20, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 49);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "잠금";
            // 
            // lockOffBtn
            // 
            this.lockOffBtn.AutoSize = true;
            this.lockOffBtn.Location = new System.Drawing.Point(121, 20);
            this.lockOffBtn.Name = "lockOffBtn";
            this.lockOffBtn.Size = new System.Drawing.Size(47, 16);
            this.lockOffBtn.TabIndex = 1;
            this.lockOffBtn.TabStop = true;
            this.lockOffBtn.Text = "해제";
            this.lockOffBtn.UseVisualStyleBackColor = true;
            // 
            // LockOnBtn
            // 
            this.LockOnBtn.AutoSize = true;
            this.LockOnBtn.Location = new System.Drawing.Point(53, 20);
            this.LockOnBtn.Name = "LockOnBtn";
            this.LockOnBtn.Size = new System.Drawing.Size(47, 16);
            this.LockOnBtn.TabIndex = 0;
            this.LockOnBtn.TabStop = true;
            this.LockOnBtn.Text = "잠금";
            this.LockOnBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.powerOffBtn);
            this.groupBox1.Controls.Add(this.powerOnBtn);
            this.groupBox1.Location = new System.Drawing.Point(20, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 49);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "전원";
            // 
            // powerOffBtn
            // 
            this.powerOffBtn.AutoSize = true;
            this.powerOffBtn.Location = new System.Drawing.Point(121, 20);
            this.powerOffBtn.Name = "powerOffBtn";
            this.powerOffBtn.Size = new System.Drawing.Size(47, 16);
            this.powerOffBtn.TabIndex = 1;
            this.powerOffBtn.TabStop = true;
            this.powerOffBtn.Text = "꺼짐";
            this.powerOffBtn.UseVisualStyleBackColor = true;
            // 
            // powerOnBtn
            // 
            this.powerOnBtn.AutoSize = true;
            this.powerOnBtn.Location = new System.Drawing.Point(53, 20);
            this.powerOnBtn.Name = "powerOnBtn";
            this.powerOnBtn.Size = new System.Drawing.Size(47, 16);
            this.powerOnBtn.TabIndex = 0;
            this.powerOnBtn.TabStop = true;
            this.powerOnBtn.Text = "켜짐";
            this.powerOnBtn.UseVisualStyleBackColor = true;
            // 
            // GroupRoomList
            // 
            this.GroupRoomList.Location = new System.Drawing.Point(301, 51);
            this.GroupRoomList.Name = "GroupRoomList";
            this.GroupRoomList.Size = new System.Drawing.Size(74, 228);
            this.GroupRoomList.TabIndex = 91;
            this.GroupRoomList.UseCompatibleStateImageBehavior = false;
            this.GroupRoomList.Visible = false;
            // 
            // AllRoomSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 310);
            this.Controls.Add(this.GroupRoomList);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(290, 348);
            this.MinimumSize = new System.Drawing.Size(290, 348);
            this.Name = "AllRoomSetting";
            this.Text = "[전체 설정]";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AllRoomSetting_FormClosed);
            this.Load += new System.EventHandler(this.AllRoomSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setTempControl)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setStepControl)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown setTempControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown setStepControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton lockOffBtn;
        private System.Windows.Forms.RadioButton LockOnBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton powerOffBtn;
        private System.Windows.Forms.RadioButton powerOnBtn;
        private System.Windows.Forms.ListView GroupRoomList;
    }
}