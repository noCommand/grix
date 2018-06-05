namespace GrixControler
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.eventListView = new System.Windows.Forms.ListView();
            this.시간 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.호실 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.상태 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.timeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.specificFunctionPictureBox = new System.Windows.Forms.PictureBox();
            this.SetAdminButton = new System.Windows.Forms.Button();
            this.SetAllButton = new System.Windows.Forms.Button();
            this.SetReservationButton = new System.Windows.Forms.Button();
            this.SetGroupButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.Setting = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ViewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specificFunctionPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(185, 691);
            this.panel4.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.eventListView);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(185, 664);
            this.panel7.TabIndex = 8;
            // 
            // eventListView
            // 
            this.eventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.시간,
            this.호실,
            this.상태});
            this.eventListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.eventListView.Location = new System.Drawing.Point(0, 26);
            this.eventListView.Name = "eventListView";
            this.eventListView.Size = new System.Drawing.Size(185, 638);
            this.eventListView.TabIndex = 3;
            this.eventListView.UseCompatibleStateImageBehavior = false;
            this.eventListView.View = System.Windows.Forms.View.Details;
            this.eventListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.eventListView_ColumnWidthChanging);
            // 
            // 시간
            // 
            this.시간.Text = "시간";
            this.시간.Width = 46;
            // 
            // 호실
            // 
            this.호실.Text = "호실";
            this.호실.Width = 38;
            // 
            // 상태
            // 
            this.상태.Text = "상태";
            this.상태.Width = 110;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = global::GrixControler.Properties.Resources.Time_Background;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(185, 26);
            this.panel6.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(47, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "이벤트 기록";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::GrixControler.Properties.Resources.Time_Background;
            this.panel5.Controls.Add(this.timeLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 664);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(185, 27);
            this.panel5.TabIndex = 4;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.timeLabel.Location = new System.Drawing.Point(12, 8);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(23, 13);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "10";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.specificFunctionPictureBox);
            this.panel1.Controls.Add(this.SetAdminButton);
            this.panel1.Controls.Add(this.SetAllButton);
            this.panel1.Controls.Add(this.SetReservationButton);
            this.panel1.Controls.Add(this.SetGroupButton);
            this.panel1.Controls.Add(this.testButton);
            this.panel1.Controls.Add(this.Setting);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(185, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 50);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // specificFunctionPictureBox
            // 
            this.specificFunctionPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.specificFunctionPictureBox.ImageLocation = "";
            this.specificFunctionPictureBox.Location = new System.Drawing.Point(644, 18);
            this.specificFunctionPictureBox.Name = "specificFunctionPictureBox";
            this.specificFunctionPictureBox.Size = new System.Drawing.Size(16, 19);
            this.specificFunctionPictureBox.TabIndex = 13;
            this.specificFunctionPictureBox.TabStop = false;
            this.specificFunctionPictureBox.Visible = false;
            // 
            // SetAdminButton
            // 
            this.SetAdminButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.SetAdminButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SetAdminButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SetAdminButton.Location = new System.Drawing.Point(368, 11);
            this.SetAdminButton.Margin = new System.Windows.Forms.Padding(0);
            this.SetAdminButton.Name = "SetAdminButton";
            this.SetAdminButton.Size = new System.Drawing.Size(98, 28);
            this.SetAdminButton.TabIndex = 12;
            this.SetAdminButton.Text = "관리자";
            this.SetAdminButton.UseVisualStyleBackColor = false;
            this.SetAdminButton.Click += new System.EventHandler(this.SetAdminButton_Click);
            // 
            // SetAllButton
            // 
            this.SetAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.SetAllButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SetAllButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SetAllButton.Location = new System.Drawing.Point(23, 11);
            this.SetAllButton.Margin = new System.Windows.Forms.Padding(0);
            this.SetAllButton.Name = "SetAllButton";
            this.SetAllButton.Size = new System.Drawing.Size(98, 28);
            this.SetAllButton.TabIndex = 11;
            this.SetAllButton.Text = "전체";
            this.SetAllButton.UseVisualStyleBackColor = false;
            this.SetAllButton.Click += new System.EventHandler(this.SetAllButton_Click);
            // 
            // SetReservationButton
            // 
            this.SetReservationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.SetReservationButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SetReservationButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SetReservationButton.Location = new System.Drawing.Point(256, 11);
            this.SetReservationButton.Margin = new System.Windows.Forms.Padding(0);
            this.SetReservationButton.Name = "SetReservationButton";
            this.SetReservationButton.Size = new System.Drawing.Size(98, 28);
            this.SetReservationButton.TabIndex = 10;
            this.SetReservationButton.Text = "예약";
            this.SetReservationButton.UseVisualStyleBackColor = false;
            this.SetReservationButton.Click += new System.EventHandler(this.SetReservationButton_Click);
            // 
            // SetGroupButton
            // 
            this.SetGroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.SetGroupButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SetGroupButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SetGroupButton.Location = new System.Drawing.Point(141, 11);
            this.SetGroupButton.Margin = new System.Windows.Forms.Padding(0);
            this.SetGroupButton.Name = "SetGroupButton";
            this.SetGroupButton.Size = new System.Drawing.Size(98, 28);
            this.SetGroupButton.TabIndex = 0;
            this.SetGroupButton.Text = "그룹";
            this.SetGroupButton.UseVisualStyleBackColor = false;
            this.SetGroupButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // testButton
            // 
            this.testButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.testButton.Location = new System.Drawing.Point(750, 14);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 8;
            this.testButton.Text = "도움말";
            this.testButton.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.Setting.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Setting.Location = new System.Drawing.Point(669, 14);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(75, 23);
            this.Setting.TabIndex = 9;
            this.Setting.Text = "환경설정";
            this.Setting.UseVisualStyleBackColor = true;
            this.Setting.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ViewPanel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1022, 741);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GrixControler.Properties.Resources.Logo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ViewPanel
            // 
            this.ViewPanel.AutoScroll = true;
            this.ViewPanel.BackColor = System.Drawing.Color.Thistle;
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewPanel.Location = new System.Drawing.Point(185, 50);
            this.ViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ViewPanel.Size = new System.Drawing.Size(837, 691);
            this.ViewPanel.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1038, 779);
            this.Name = "MainForm";
            this.Text = "온도조절 시스템 PC제어 프로그램";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.specificFunctionPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ColumnHeader 시간;
        private System.Windows.Forms.ColumnHeader 호실;
        private System.Windows.Forms.ColumnHeader 상태;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel ViewPanel;
        private CustomButton customButton2;
        public System.Windows.Forms.ListView eventListView;
        private System.Windows.Forms.Button SetGroupButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button Setting;
        private System.Windows.Forms.Button SetReservationButton;
        private System.Windows.Forms.Button SetAllButton;
        private System.Windows.Forms.Button SetAdminButton;
        private System.Windows.Forms.PictureBox specificFunctionPictureBox;
    }
}

