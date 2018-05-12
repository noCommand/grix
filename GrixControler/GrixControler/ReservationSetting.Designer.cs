﻿namespace GrixControler
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
            this.reset_Btn = new System.Windows.Forms.Button();
            this.comfirm_Btn = new System.Windows.Forms.Button();
            this.apply_Btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.off_Min = new System.Windows.Forms.ComboBox();
            this.off_Hour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.on_temp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.on_Min = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.on_Hour = new System.Windows.Forms.ComboBox();
            this.RoomList = new System.Windows.Forms.ListView();
            this.all_button = new System.Windows.Forms.Button();
            this.group_button = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reset_Btn
            // 
            this.reset_Btn.Location = new System.Drawing.Point(343, 44);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(75, 23);
            this.reset_Btn.TabIndex = 13;
            this.reset_Btn.Text = "초기화";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // comfirm_Btn
            // 
            this.comfirm_Btn.Location = new System.Drawing.Point(288, 415);
            this.comfirm_Btn.Name = "comfirm_Btn";
            this.comfirm_Btn.Size = new System.Drawing.Size(98, 23);
            this.comfirm_Btn.TabIndex = 12;
            this.comfirm_Btn.Text = "확인";
            this.comfirm_Btn.UseVisualStyleBackColor = true;
            // 
            // apply_Btn
            // 
            this.apply_Btn.Location = new System.Drawing.Point(230, 371);
            this.apply_Btn.Name = "apply_Btn";
            this.apply_Btn.Size = new System.Drawing.Size(75, 23);
            this.apply_Btn.TabIndex = 10;
            this.apply_Btn.Text = "예약적용";
            this.apply_Btn.UseVisualStyleBackColor = true;
            this.apply_Btn.Click += new System.EventHandler(this.apply_Btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.off_Min);
            this.groupBox2.Controls.Add(this.off_Hour);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(218, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 57);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "꺼짐예약";
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
            // off_Hour
            // 
            this.off_Hour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.off_Hour.FormattingEnabled = true;
            this.off_Hour.Location = new System.Drawing.Point(32, 23);
            this.off_Hour.Name = "off_Hour";
            this.off_Hour.Size = new System.Drawing.Size(42, 20);
            this.off_Hour.TabIndex = 5;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.on_temp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.on_Min);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.on_Hour);
            this.groupBox1.Location = new System.Drawing.Point(12, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "시작예약";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "시";
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
            // RoomList
            // 
            this.RoomList.Location = new System.Drawing.Point(12, 73);
            this.RoomList.Name = "RoomList";
            this.RoomList.Size = new System.Drawing.Size(406, 206);
            this.RoomList.TabIndex = 7;
            this.RoomList.UseCompatibleStateImageBehavior = false;
            // 
            // all_button
            // 
            this.all_button.Location = new System.Drawing.Point(262, 44);
            this.all_button.Name = "all_button";
            this.all_button.Size = new System.Drawing.Size(75, 23);
            this.all_button.TabIndex = 14;
            this.all_button.Text = "전체선택";
            this.all_button.UseVisualStyleBackColor = true;
            this.all_button.Click += new System.EventHandler(this.all_button_Click);
            // 
            // group_button
            // 
            this.group_button.Location = new System.Drawing.Point(181, 44);
            this.group_button.Name = "group_button";
            this.group_button.Size = new System.Drawing.Size(75, 23);
            this.group_button.TabIndex = 15;
            this.group_button.Text = "그룹관리";
            this.group_button.UseVisualStyleBackColor = true;
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(321, 371);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_btn.TabIndex = 16;
            this.delete_btn.Text = "예약삭제";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // ReservationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.group_button);
            this.Controls.Add(this.all_button);
            this.Controls.Add(this.reset_Btn);
            this.Controls.Add(this.comfirm_Btn);
            this.Controls.Add(this.apply_Btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RoomList);
            this.Name = "ReservationSetting";
            this.Text = "ReservationSetting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReservationSetting_FormClosed);
            this.Load += new System.EventHandler(this.ReservationSetting_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reset_Btn;
        private System.Windows.Forms.Button comfirm_Btn;
        private System.Windows.Forms.Button apply_Btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox off_Min;
        private System.Windows.Forms.ComboBox off_Hour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox on_temp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox on_Min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox on_Hour;
        private System.Windows.Forms.ListView RoomList;
        private System.Windows.Forms.Button all_button;
        private System.Windows.Forms.Button group_button;
        private System.Windows.Forms.Button delete_btn;
    }
}