namespace GrixControler
{
    partial class RoomView
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.desired_Temp = new System.Windows.Forms.Label();
            this.current_Temp = new System.Windows.Forms.Label();
            this.picture_Lock = new System.Windows.Forms.PictureBox();
            this.picture_Heat = new System.Windows.Forms.PictureBox();
            this.roomName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Lock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Heat)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // desired_Temp
            // 
            this.desired_Temp.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.desired_Temp.Location = new System.Drawing.Point(7, 73);
            this.desired_Temp.Name = "desired_Temp";
            this.desired_Temp.Size = new System.Drawing.Size(56, 23);
            this.desired_Temp.TabIndex = 27;
            this.desired_Temp.Text = "30";
            this.desired_Temp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.desired_Temp.Click += new System.EventHandler(this.label3_Click);
            // 
            // current_Temp
            // 
            this.current_Temp.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.current_Temp.Location = new System.Drawing.Point(3, 50);
            this.current_Temp.Name = "current_Temp";
            this.current_Temp.Size = new System.Drawing.Size(76, 23);
            this.current_Temp.TabIndex = 26;
            this.current_Temp.Text = "23";
            this.current_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.current_Temp.Click += new System.EventHandler(this.label2_Click);
            // 
            // picture_Lock
            // 
            this.picture_Lock.Image = global::GrixControler.Properties.Resources.Lock;
            this.picture_Lock.Location = new System.Drawing.Point(23, 31);
            this.picture_Lock.Name = "picture_Lock";
            this.picture_Lock.Size = new System.Drawing.Size(15, 16);
            this.picture_Lock.TabIndex = 25;
            this.picture_Lock.TabStop = false;
            this.picture_Lock.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // picture_Heat
            // 
            this.picture_Heat.Image = global::GrixControler.Properties.Resources.Hot;
            this.picture_Heat.Location = new System.Drawing.Point(7, 31);
            this.picture_Heat.Name = "picture_Heat";
            this.picture_Heat.Size = new System.Drawing.Size(15, 16);
            this.picture_Heat.TabIndex = 24;
            this.picture_Heat.TabStop = false;
            this.picture_Heat.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // roomName
            // 
            this.roomName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(129)))), ((int)(((byte)(128)))));
            this.roomName.ForeColor = System.Drawing.Color.White;
            this.roomName.Location = new System.Drawing.Point(0, 0);
            this.roomName.Margin = new System.Windows.Forms.Padding(0);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(76, 29);
            this.roomName.TabIndex = 23;
            this.roomName.Text = "label1";
            this.roomName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.roomName.Click += new System.EventHandler(this.roomName_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.roomName);
            this.panel1.Controls.Add(this.desired_Temp);
            this.panel1.Controls.Add(this.picture_Heat);
            this.panel1.Controls.Add(this.current_Temp);
            this.panel1.Controls.Add(this.picture_Lock);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(76, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 103);
            this.panel1.TabIndex = 28;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // RoomView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "RoomView";
            this.Size = new System.Drawing.Size(76, 103);
            this.Load += new System.EventHandler(this.RoomView_Load);
            this.Click += new System.EventHandler(this.RoomView_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picture_Lock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Heat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label current_Temp;
        public System.Windows.Forms.Label desired_Temp;
        public System.Windows.Forms.PictureBox picture_Lock;
        public System.Windows.Forms.PictureBox picture_Heat;
        public System.Windows.Forms.Label roomName;
    }
}
