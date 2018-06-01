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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramSetting));
            this.portCombx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.portGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.roomApplyButton = new System.Windows.Forms.Button();
            this.roomGridView = new System.Windows.Forms.DataGridView();
            this.reSetButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.specialFunctionCheckBox = new System.Windows.Forms.CheckBox();
            this.setNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // portCombx
            // 
            this.portCombx.FormattingEnabled = true;
            this.portCombx.Location = new System.Drawing.Point(114, 19);
            this.portCombx.Name = "portCombx";
            this.portCombx.Size = new System.Drawing.Size(85, 19);
            this.portCombx.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 11);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port :";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(141, 416);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "확인";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(222, 416);
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
            this.portGroupBox.Location = new System.Drawing.Point(24, 15);
            this.portGroupBox.Name = "portGroupBox";
            this.portGroupBox.Size = new System.Drawing.Size(280, 48);
            this.portGroupBox.TabIndex = 4;
            this.portGroupBox.TabStop = false;
            this.portGroupBox.Text = "Com Setting";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roomApplyButton);
            this.groupBox1.Controls.Add(this.roomGridView);
            this.groupBox1.Location = new System.Drawing.Point(24, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 300);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room Setting";
            // 
            // roomApplyButton
            // 
            this.roomApplyButton.Location = new System.Drawing.Point(188, 17);
            this.roomApplyButton.Name = "roomApplyButton";
            this.roomApplyButton.Size = new System.Drawing.Size(75, 23);
            this.roomApplyButton.TabIndex = 7;
            this.roomApplyButton.Text = "적용";
            this.roomApplyButton.UseVisualStyleBackColor = true;
            this.roomApplyButton.Click += new System.EventHandler(this.roomApplyButton_Click);
            // 
            // roomGridView
            // 
            this.roomGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.roomGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.setNo,
            this.setID,
            this.setRoomName});
            this.roomGridView.Location = new System.Drawing.Point(19, 46);
            this.roomGridView.Name = "roomGridView";
            this.roomGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.roomGridView.RowTemplate.Height = 23;
            this.roomGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.roomGridView.Size = new System.Drawing.Size(244, 242);
            this.roomGridView.TabIndex = 0;
            this.roomGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomGridView_CellLeave);
            this.roomGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.roomGridView_CellValidating);
            this.roomGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomGridView_CellValueChanged);
            this.roomGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.roomGridView_EditingControlShowing);
            this.roomGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.roomGridView_RowsAdded);
            this.roomGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.roomGridView_KeyDown);
            // 
            // reSetButton
            // 
            this.reSetButton.Location = new System.Drawing.Point(33, 416);
            this.reSetButton.Name = "reSetButton";
            this.reSetButton.Size = new System.Drawing.Size(75, 23);
            this.reSetButton.TabIndex = 8;
            this.reSetButton.Text = "초기화";
            this.reSetButton.UseVisualStyleBackColor = true;
            this.reSetButton.Click += new System.EventHandler(this.reSetButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "특수기능 :";
            // 
            // specialFunctionCheckBox
            // 
            this.specialFunctionCheckBox.AutoSize = true;
            this.specialFunctionCheckBox.Location = new System.Drawing.Point(100, 389);
            this.specialFunctionCheckBox.Name = "specialFunctionCheckBox";
            this.specialFunctionCheckBox.Size = new System.Drawing.Size(15, 14);
            this.specialFunctionCheckBox.TabIndex = 9;
            this.specialFunctionCheckBox.UseVisualStyleBackColor = true;
            // 
            // setNo
            // 
            this.setNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.setNo.HeaderText = "No.";
            this.setNo.MaxInputLength = 4;
            this.setNo.Name = "setNo";
            this.setNo.ReadOnly = true;
            this.setNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.setNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.setNo.Width = 63;
            // 
            // setID
            // 
            this.setID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.setID.DefaultCellStyle = dataGridViewCellStyle1;
            this.setID.HeaderText = "ID";
            this.setID.MaxInputLength = 4;
            this.setID.Name = "setID";
            this.setID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.setID.Width = 63;
            // 
            // setRoomName
            // 
            this.setRoomName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.setRoomName.HeaderText = "방이름";
            this.setRoomName.MaxInputLength = 10;
            this.setRoomName.Name = "setRoomName";
            this.setRoomName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.setRoomName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.setRoomName.Width = 84;
            // 
            // ProgramSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 455);
            this.Controls.Add(this.specialFunctionCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reSetButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.portGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(343, 493);
            this.MinimumSize = new System.Drawing.Size(343, 493);
            this.Name = "ProgramSetting";
            this.Text = " [환경설정]";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProgramSetting_FormClosed);
            this.Load += new System.EventHandler(this.ProgramSetting_Load);
            this.portGroupBox.ResumeLayout(false);
            this.portGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portCombx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox portGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView roomGridView;
        private System.Windows.Forms.Button roomApplyButton;
        private System.Windows.Forms.Button reSetButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox specialFunctionCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn setNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn setID;
        private System.Windows.Forms.DataGridViewTextBoxColumn setRoomName;
    }
}