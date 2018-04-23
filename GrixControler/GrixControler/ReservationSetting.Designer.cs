namespace GrixControler
{
    partial class ReservationSetting
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RoomList = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.on_Hour = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.on_Min = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.off_Min = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.off_Hour = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.on_temp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.apply_Btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.comfirm_Btn = new System.Windows.Forms.Button();
            this.reset_Btn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reset_Btn);
            this.tabPage1.Controls.Add(this.comfirm_Btn);
            this.tabPage1.Controls.Add(this.cancel_btn);
            this.tabPage1.Controls.Add(this.apply_Btn);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.RoomList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "개별예약";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // RoomList
            // 
            this.RoomList.Location = new System.Drawing.Point(8, 45);
            this.RoomList.Name = "RoomList";
            this.RoomList.Size = new System.Drawing.Size(406, 206);
            this.RoomList.TabIndex = 0;
            this.RoomList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(525, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(525, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.on_temp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.on_Min);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.on_Hour);
            this.groupBox1.Location = new System.Drawing.Point(8, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "시작예약";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.off_Min);
            this.groupBox2.Controls.Add(this.off_Hour);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(214, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "꺼짐예약";
            // 
            // on_Hour
            // 
            this.on_Hour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.on_Hour.FormattingEnabled = true;
            this.on_Hour.Location = new System.Drawing.Point(32, 20);
            this.on_Hour.Name = "on_Hour";
            this.on_Hour.Size = new System.Drawing.Size(42, 20);
            this.on_Hour.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "시";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "분";
            // 
            // on_Min
            // 
            this.on_Min.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.on_Min.FormattingEnabled = true;
            this.on_Min.Location = new System.Drawing.Point(103, 20);
            this.on_Min.Name = "on_Min";
            this.on_Min.Size = new System.Drawing.Size(42, 20);
            this.on_Min.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "분";
            // 
            // off_Min
            // 
            this.off_Min.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.off_Min.FormattingEnabled = true;
            this.off_Min.Location = new System.Drawing.Point(103, 23);
            this.off_Min.Name = "off_Min";
            this.off_Min.Size = new System.Drawing.Size(42, 20);
            this.off_Min.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "시";
            // 
            // off_Hour
            // 
            this.off_Hour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.off_Hour.FormattingEnabled = true;
            this.off_Hour.Location = new System.Drawing.Point(32, 23);
            this.off_Hour.Name = "off_Hour";
            this.off_Hour.Size = new System.Drawing.Size(42, 20);
            this.off_Hour.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "\'C";
            // 
            // on_temp
            // 
            this.on_temp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.on_temp.FormattingEnabled = true;
            this.on_temp.Location = new System.Drawing.Point(91, 60);
            this.on_temp.Name = "on_temp";
            this.on_temp.Size = new System.Drawing.Size(54, 20);
            this.on_temp.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "설정온도";
            // 
            // apply_Btn
            // 
            this.apply_Btn.Location = new System.Drawing.Point(339, 343);
            this.apply_Btn.Name = "apply_Btn";
            this.apply_Btn.Size = new System.Drawing.Size(75, 23);
            this.apply_Btn.TabIndex = 3;
            this.apply_Btn.Text = "적용";
            this.apply_Btn.UseVisualStyleBackColor = true;
            this.apply_Btn.Click += new System.EventHandler(this.apply_Btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(317, 391);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "취소";
            this.cancel_btn.UseVisualStyleBackColor = true;
            // 
            // comfirm_Btn
            // 
            this.comfirm_Btn.Location = new System.Drawing.Point(236, 391);
            this.comfirm_Btn.Name = "comfirm_Btn";
            this.comfirm_Btn.Size = new System.Drawing.Size(75, 23);
            this.comfirm_Btn.TabIndex = 5;
            this.comfirm_Btn.Text = "확인";
            this.comfirm_Btn.UseVisualStyleBackColor = true;
            // 
            // reset_Btn
            // 
            this.reset_Btn.Location = new System.Drawing.Point(339, 16);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(75, 23);
            this.reset_Btn.TabIndex = 6;
            this.reset_Btn.Text = "초기화";
            this.reset_Btn.UseVisualStyleBackColor = true;
            // 
            // ReservationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "ReservationSetting";
            this.Text = "ReservationSetting";
            this.Load += new System.EventHandler(this.ReservationSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView RoomList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox on_Hour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox on_Min;
        private System.Windows.Forms.Button comfirm_Btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button apply_Btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox off_Min;
        private System.Windows.Forms.ComboBox off_Hour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox on_temp;
        private System.Windows.Forms.Button reset_Btn;
    }
}