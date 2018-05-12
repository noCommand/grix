﻿namespace GrixControler
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.portGroupBox = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.roomGridView = new System.Windows.Forms.DataGridView();
            this.setNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apply_btn = new System.Windows.Forms.Button();
            this.portGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // portCombx
            // 
            this.portCombx.FormattingEnabled = true;
            this.portCombx.Location = new System.Drawing.Point(92, 18);
            this.portCombx.Name = "portCombx";
            this.portCombx.Size = new System.Drawing.Size(85, 19);
            this.portCombx.TabIndex = 0;
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
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(136, 320);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "확인";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(217, 320);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "취소";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_click);
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
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(217, 27);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "초기화";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roomGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 209);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room Setting";
            // 
            // roomGridView
            // 
            this.roomGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.setNo,
            this.setID,
            this.setRoomName});
            this.roomGridView.Location = new System.Drawing.Point(19, 18);
            this.roomGridView.Name = "roomGridView";
            this.roomGridView.RowTemplate.Height = 23;
            this.roomGridView.Size = new System.Drawing.Size(244, 183);
            this.roomGridView.TabIndex = 0;
            this.roomGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomGridView_CellContentClick);
            this.roomGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomGridView_CellValueChanged);
            this.roomGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.roomGridView_KeyPress);
            // 
            // setNo
            // 
            this.setNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.setNo.HeaderText = "No.";
            this.setNo.MaxInputLength = 4;
            this.setNo.Name = "setNo";
            this.setNo.ReadOnly = true;
            this.setNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.setNo.Width = 63;
            // 
            // setID
            // 
            this.setID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.setID.HeaderText = "ID";
            this.setID.MaxInputLength = 4;
            this.setID.Name = "setID";
            this.setID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.setID.Width = 63;
            // 
            // setRoomName
            // 
            this.setRoomName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.setRoomName.HeaderText = "방이름";
            this.setRoomName.MaxInputLength = 10;
            this.setRoomName.Name = "setRoomName";
            this.setRoomName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.setRoomName.Width = 84;
            // 
            // apply_btn
            // 
            this.apply_btn.Location = new System.Drawing.Point(200, 291);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(75, 23);
            this.apply_btn.TabIndex = 7;
            this.apply_btn.Text = "적용";
            this.apply_btn.UseVisualStyleBackColor = true;
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // ProgramSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 351);
            this.Controls.Add(this.apply_btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.portGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Name = "ProgramSetting";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProgramSetting_FormClosed);
            this.Load += new System.EventHandler(this.ProgramSetting_Load);
            this.portGroupBox.ResumeLayout(false);
            this.portGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox portCombx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox portGroupBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView roomGridView;
        private System.Windows.Forms.Button apply_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn setID;
        private System.Windows.Forms.DataGridViewTextBoxColumn setRoomName;
    }
}