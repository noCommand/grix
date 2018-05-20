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
            this.reset_Btn = new System.Windows.Forms.Button();
            this.comfirm_Btn = new System.Windows.Forms.Button();
            this.apply_Btn = new System.Windows.Forms.Button();
            this.RoomList = new System.Windows.Forms.ListView();
            this.all_button = new System.Windows.Forms.Button();
            this.group_button = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.MondayStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.MondayEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TuesdayStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TuesdayEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.WednesdayStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.WednesdayEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ThursdayStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ThursdayEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FridayStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FridayEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SaturdayStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SaturdayEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SundayStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SundayEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.MondayTempUpDown = new System.Windows.Forms.NumericUpDown();
            this.TuesdayTempUpDown = new System.Windows.Forms.NumericUpDown();
            this.WednesdayTempUpDown = new System.Windows.Forms.NumericUpDown();
            this.ThursdayTempUpDown = new System.Windows.Forms.NumericUpDown();
            this.FridayTempUpDown = new System.Windows.Forms.NumericUpDown();
            this.SaturdayTempUpDown = new System.Windows.Forms.NumericUpDown();
            this.SundayTempUpDown = new System.Windows.Forms.NumericUpDown();
            this.MondayStartRadBtn = new System.Windows.Forms.RadioButton();
            this.TuesdayStartRadBtn = new System.Windows.Forms.RadioButton();
            this.WednesdayStartRadBtn = new System.Windows.Forms.RadioButton();
            this.ThursdayStartRadBtn = new System.Windows.Forms.RadioButton();
            this.FridayStartRadBtn = new System.Windows.Forms.RadioButton();
            this.SaturdayStartRadBtn = new System.Windows.Forms.RadioButton();
            this.SundayStartRadBtn = new System.Windows.Forms.RadioButton();
            this.SundayEndRadBtn = new System.Windows.Forms.RadioButton();
            this.SaturdayEndRadBtn = new System.Windows.Forms.RadioButton();
            this.FridayEndRadBtn = new System.Windows.Forms.RadioButton();
            this.ThursdayEndRadBtn = new System.Windows.Forms.RadioButton();
            this.WednesdayEndRadBtn = new System.Windows.Forms.RadioButton();
            this.TuesdayEndRadBtn = new System.Windows.Forms.RadioButton();
            this.MondayEndRadBtn = new System.Windows.Forms.RadioButton();
            this.StartGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.MondayTempUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayTempUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayTempUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayTempUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FridayTempUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturdayTempUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SundayTempUpDown)).BeginInit();
            this.StartGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reset_Btn
            // 
            this.reset_Btn.Location = new System.Drawing.Point(384, 28);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(75, 23);
            this.reset_Btn.TabIndex = 13;
            this.reset_Btn.Text = "초기화";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // comfirm_Btn
            // 
            this.comfirm_Btn.Location = new System.Drawing.Point(374, 324);
            this.comfirm_Btn.Name = "comfirm_Btn";
            this.comfirm_Btn.Size = new System.Drawing.Size(98, 23);
            this.comfirm_Btn.TabIndex = 12;
            this.comfirm_Btn.Text = "확인";
            this.comfirm_Btn.UseVisualStyleBackColor = true;
            // 
            // apply_Btn
            // 
            this.apply_Btn.Location = new System.Drawing.Point(306, 295);
            this.apply_Btn.Name = "apply_Btn";
            this.apply_Btn.Size = new System.Drawing.Size(75, 23);
            this.apply_Btn.TabIndex = 10;
            this.apply_Btn.Text = "예약적용";
            this.apply_Btn.UseVisualStyleBackColor = true;
            this.apply_Btn.Click += new System.EventHandler(this.apply_Btn_Click);
            // 
            // RoomList
            // 
            this.RoomList.Location = new System.Drawing.Point(12, 73);
            this.RoomList.Name = "RoomList";
            this.RoomList.Size = new System.Drawing.Size(74, 206);
            this.RoomList.TabIndex = 7;
            this.RoomList.UseCompatibleStateImageBehavior = false;
            this.RoomList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.RoomList_ItemSelectionChanged);
            // 
            // all_button
            // 
            this.all_button.Location = new System.Drawing.Point(303, 28);
            this.all_button.Name = "all_button";
            this.all_button.Size = new System.Drawing.Size(75, 23);
            this.all_button.TabIndex = 14;
            this.all_button.Text = "전체선택";
            this.all_button.UseVisualStyleBackColor = true;
            this.all_button.Click += new System.EventHandler(this.all_button_Click);
            // 
            // group_button
            // 
            this.group_button.Location = new System.Drawing.Point(222, 28);
            this.group_button.Name = "group_button";
            this.group_button.Size = new System.Drawing.Size(75, 23);
            this.group_button.TabIndex = 15;
            this.group_button.Text = "그룹관리";
            this.group_button.UseVisualStyleBackColor = true;
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(397, 295);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_btn.TabIndex = 16;
            this.delete_btn.Text = "예약삭제";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // MondayStartTimePicker
            // 
            this.MondayStartTimePicker.CustomFormat = "tt hh:mm";
            this.MondayStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MondayStartTimePicker.Location = new System.Drawing.Point(175, 89);
            this.MondayStartTimePicker.Name = "MondayStartTimePicker";
            this.MondayStartTimePicker.ShowUpDown = true;
            this.MondayStartTimePicker.Size = new System.Drawing.Size(81, 21);
            this.MondayStartTimePicker.TabIndex = 18;
            this.MondayStartTimePicker.Value = new System.DateTime(2018, 5, 20, 8, 0, 0, 0);
            // 
            // MondayEndTimePicker
            // 
            this.MondayEndTimePicker.CustomFormat = "tt hh:mm";
            this.MondayEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MondayEndTimePicker.Location = new System.Drawing.Point(391, 85);
            this.MondayEndTimePicker.Name = "MondayEndTimePicker";
            this.MondayEndTimePicker.ShowUpDown = true;
            this.MondayEndTimePicker.Size = new System.Drawing.Size(81, 21);
            this.MondayEndTimePicker.TabIndex = 19;
            this.MondayEndTimePicker.Value = new System.DateTime(2018, 5, 20, 20, 0, 0, 0);
            // 
            // TuesdayStartTimePicker
            // 
            this.TuesdayStartTimePicker.CustomFormat = "tt hh:mm";
            this.TuesdayStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TuesdayStartTimePicker.Location = new System.Drawing.Point(175, 117);
            this.TuesdayStartTimePicker.Name = "TuesdayStartTimePicker";
            this.TuesdayStartTimePicker.ShowUpDown = true;
            this.TuesdayStartTimePicker.Size = new System.Drawing.Size(81, 21);
            this.TuesdayStartTimePicker.TabIndex = 20;
            this.TuesdayStartTimePicker.Value = new System.DateTime(2018, 5, 20, 8, 0, 0, 0);
            // 
            // TuesdayEndTimePicker
            // 
            this.TuesdayEndTimePicker.CustomFormat = "tt hh:mm";
            this.TuesdayEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TuesdayEndTimePicker.Location = new System.Drawing.Point(391, 112);
            this.TuesdayEndTimePicker.Name = "TuesdayEndTimePicker";
            this.TuesdayEndTimePicker.ShowUpDown = true;
            this.TuesdayEndTimePicker.Size = new System.Drawing.Size(81, 21);
            this.TuesdayEndTimePicker.TabIndex = 21;
            this.TuesdayEndTimePicker.Value = new System.DateTime(2018, 5, 20, 20, 0, 0, 0);
            // 
            // WednesdayStartTimePicker
            // 
            this.WednesdayStartTimePicker.CustomFormat = "tt hh:mm";
            this.WednesdayStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.WednesdayStartTimePicker.Location = new System.Drawing.Point(175, 144);
            this.WednesdayStartTimePicker.Name = "WednesdayStartTimePicker";
            this.WednesdayStartTimePicker.ShowUpDown = true;
            this.WednesdayStartTimePicker.Size = new System.Drawing.Size(81, 21);
            this.WednesdayStartTimePicker.TabIndex = 22;
            this.WednesdayStartTimePicker.Value = new System.DateTime(2018, 5, 20, 8, 0, 0, 0);
            // 
            // WednesdayEndTimePicker
            // 
            this.WednesdayEndTimePicker.CustomFormat = "tt hh:mm";
            this.WednesdayEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.WednesdayEndTimePicker.Location = new System.Drawing.Point(391, 139);
            this.WednesdayEndTimePicker.Name = "WednesdayEndTimePicker";
            this.WednesdayEndTimePicker.ShowUpDown = true;
            this.WednesdayEndTimePicker.Size = new System.Drawing.Size(81, 21);
            this.WednesdayEndTimePicker.TabIndex = 23;
            this.WednesdayEndTimePicker.Value = new System.DateTime(2018, 5, 20, 20, 0, 0, 0);
            this.WednesdayEndTimePicker.ValueChanged += new System.EventHandler(this.WednesdayEndTimePicker_ValueChanged);
            // 
            // ThursdayStartTimePicker
            // 
            this.ThursdayStartTimePicker.CustomFormat = "tt hh:mm";
            this.ThursdayStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ThursdayStartTimePicker.Location = new System.Drawing.Point(175, 171);
            this.ThursdayStartTimePicker.Name = "ThursdayStartTimePicker";
            this.ThursdayStartTimePicker.ShowUpDown = true;
            this.ThursdayStartTimePicker.Size = new System.Drawing.Size(81, 21);
            this.ThursdayStartTimePicker.TabIndex = 24;
            this.ThursdayStartTimePicker.Value = new System.DateTime(2018, 5, 20, 8, 0, 0, 0);
            // 
            // ThursdayEndTimePicker
            // 
            this.ThursdayEndTimePicker.CustomFormat = "tt hh:mm";
            this.ThursdayEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ThursdayEndTimePicker.Location = new System.Drawing.Point(391, 166);
            this.ThursdayEndTimePicker.Name = "ThursdayEndTimePicker";
            this.ThursdayEndTimePicker.ShowUpDown = true;
            this.ThursdayEndTimePicker.Size = new System.Drawing.Size(81, 21);
            this.ThursdayEndTimePicker.TabIndex = 25;
            this.ThursdayEndTimePicker.Value = new System.DateTime(2018, 5, 20, 20, 0, 0, 0);
            // 
            // FridayStartTimePicker
            // 
            this.FridayStartTimePicker.CustomFormat = "tt hh:mm";
            this.FridayStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FridayStartTimePicker.Location = new System.Drawing.Point(175, 198);
            this.FridayStartTimePicker.Name = "FridayStartTimePicker";
            this.FridayStartTimePicker.ShowUpDown = true;
            this.FridayStartTimePicker.Size = new System.Drawing.Size(81, 21);
            this.FridayStartTimePicker.TabIndex = 26;
            this.FridayStartTimePicker.Value = new System.DateTime(2018, 5, 20, 8, 0, 0, 0);
            // 
            // FridayEndTimePicker
            // 
            this.FridayEndTimePicker.CustomFormat = "tt hh:mm";
            this.FridayEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FridayEndTimePicker.Location = new System.Drawing.Point(391, 193);
            this.FridayEndTimePicker.Name = "FridayEndTimePicker";
            this.FridayEndTimePicker.ShowUpDown = true;
            this.FridayEndTimePicker.Size = new System.Drawing.Size(81, 21);
            this.FridayEndTimePicker.TabIndex = 27;
            this.FridayEndTimePicker.Value = new System.DateTime(2018, 5, 20, 20, 0, 0, 0);
            // 
            // SaturdayStartTimePicker
            // 
            this.SaturdayStartTimePicker.CustomFormat = "tt hh:mm";
            this.SaturdayStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SaturdayStartTimePicker.Location = new System.Drawing.Point(175, 225);
            this.SaturdayStartTimePicker.Name = "SaturdayStartTimePicker";
            this.SaturdayStartTimePicker.ShowUpDown = true;
            this.SaturdayStartTimePicker.Size = new System.Drawing.Size(81, 21);
            this.SaturdayStartTimePicker.TabIndex = 28;
            this.SaturdayStartTimePicker.Value = new System.DateTime(2018, 5, 20, 8, 0, 0, 0);
            // 
            // SaturdayEndTimePicker
            // 
            this.SaturdayEndTimePicker.CustomFormat = "tt hh:mm";
            this.SaturdayEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SaturdayEndTimePicker.Location = new System.Drawing.Point(391, 220);
            this.SaturdayEndTimePicker.Name = "SaturdayEndTimePicker";
            this.SaturdayEndTimePicker.ShowUpDown = true;
            this.SaturdayEndTimePicker.Size = new System.Drawing.Size(81, 21);
            this.SaturdayEndTimePicker.TabIndex = 29;
            this.SaturdayEndTimePicker.Value = new System.DateTime(2018, 5, 20, 20, 0, 0, 0);
            // 
            // SundayStartTimePicker
            // 
            this.SundayStartTimePicker.CustomFormat = "tt hh:mm";
            this.SundayStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SundayStartTimePicker.Location = new System.Drawing.Point(175, 252);
            this.SundayStartTimePicker.Name = "SundayStartTimePicker";
            this.SundayStartTimePicker.ShowUpDown = true;
            this.SundayStartTimePicker.Size = new System.Drawing.Size(81, 21);
            this.SundayStartTimePicker.TabIndex = 30;
            this.SundayStartTimePicker.Value = new System.DateTime(2018, 5, 20, 8, 0, 0, 0);
            this.SundayStartTimePicker.ValueChanged += new System.EventHandler(this.SundayStartTimePicker_ValueChanged);
            // 
            // SundayEndTimePicker
            // 
            this.SundayEndTimePicker.CustomFormat = "tt hh:mm";
            this.SundayEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SundayEndTimePicker.Location = new System.Drawing.Point(391, 247);
            this.SundayEndTimePicker.Name = "SundayEndTimePicker";
            this.SundayEndTimePicker.ShowUpDown = true;
            this.SundayEndTimePicker.Size = new System.Drawing.Size(81, 21);
            this.SundayEndTimePicker.TabIndex = 31;
            this.SundayEndTimePicker.Value = new System.DateTime(2018, 5, 20, 20, 0, 0, 0);
            // 
            // MondayTempUpDown
            // 
            this.MondayTempUpDown.Location = new System.Drawing.Point(262, 89);
            this.MondayTempUpDown.Name = "MondayTempUpDown";
            this.MondayTempUpDown.Size = new System.Drawing.Size(44, 21);
            this.MondayTempUpDown.TabIndex = 32;
            this.MondayTempUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // TuesdayTempUpDown
            // 
            this.TuesdayTempUpDown.Location = new System.Drawing.Point(262, 116);
            this.TuesdayTempUpDown.Name = "TuesdayTempUpDown";
            this.TuesdayTempUpDown.Size = new System.Drawing.Size(44, 21);
            this.TuesdayTempUpDown.TabIndex = 33;
            this.TuesdayTempUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // WednesdayTempUpDown
            // 
            this.WednesdayTempUpDown.Location = new System.Drawing.Point(262, 143);
            this.WednesdayTempUpDown.Name = "WednesdayTempUpDown";
            this.WednesdayTempUpDown.Size = new System.Drawing.Size(44, 21);
            this.WednesdayTempUpDown.TabIndex = 34;
            this.WednesdayTempUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // ThursdayTempUpDown
            // 
            this.ThursdayTempUpDown.Location = new System.Drawing.Point(262, 170);
            this.ThursdayTempUpDown.Name = "ThursdayTempUpDown";
            this.ThursdayTempUpDown.Size = new System.Drawing.Size(44, 21);
            this.ThursdayTempUpDown.TabIndex = 35;
            this.ThursdayTempUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // FridayTempUpDown
            // 
            this.FridayTempUpDown.Location = new System.Drawing.Point(262, 197);
            this.FridayTempUpDown.Name = "FridayTempUpDown";
            this.FridayTempUpDown.Size = new System.Drawing.Size(44, 21);
            this.FridayTempUpDown.TabIndex = 36;
            this.FridayTempUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // SaturdayTempUpDown
            // 
            this.SaturdayTempUpDown.Location = new System.Drawing.Point(262, 225);
            this.SaturdayTempUpDown.Name = "SaturdayTempUpDown";
            this.SaturdayTempUpDown.Size = new System.Drawing.Size(44, 21);
            this.SaturdayTempUpDown.TabIndex = 37;
            this.SaturdayTempUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // SundayTempUpDown
            // 
            this.SundayTempUpDown.Location = new System.Drawing.Point(262, 252);
            this.SundayTempUpDown.Name = "SundayTempUpDown";
            this.SundayTempUpDown.Size = new System.Drawing.Size(44, 21);
            this.SundayTempUpDown.TabIndex = 38;
            this.SundayTempUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // MondayStartRadBtn
            // 
            this.MondayStartRadBtn.AutoSize = true;
            this.MondayStartRadBtn.Location = new System.Drawing.Point(11, 20);
            this.MondayStartRadBtn.Name = "MondayStartRadBtn";
            this.MondayStartRadBtn.Size = new System.Drawing.Size(59, 16);
            this.MondayStartRadBtn.TabIndex = 39;
            this.MondayStartRadBtn.TabStop = true;
            this.MondayStartRadBtn.Text = "월요일";
            this.MondayStartRadBtn.UseVisualStyleBackColor = true;
            this.MondayStartRadBtn.Click += new System.EventHandler(this.MondayRadBtn_Click);
            // 
            // TuesdayStartRadBtn
            // 
            this.TuesdayStartRadBtn.AutoSize = true;
            this.TuesdayStartRadBtn.Location = new System.Drawing.Point(11, 47);
            this.TuesdayStartRadBtn.Name = "TuesdayStartRadBtn";
            this.TuesdayStartRadBtn.Size = new System.Drawing.Size(59, 16);
            this.TuesdayStartRadBtn.TabIndex = 40;
            this.TuesdayStartRadBtn.TabStop = true;
            this.TuesdayStartRadBtn.Text = "화요일";
            this.TuesdayStartRadBtn.UseVisualStyleBackColor = true;
            this.TuesdayStartRadBtn.Click += new System.EventHandler(this.TuesdayRadBtn_Click);
            // 
            // WednesdayStartRadBtn
            // 
            this.WednesdayStartRadBtn.AutoSize = true;
            this.WednesdayStartRadBtn.Location = new System.Drawing.Point(11, 74);
            this.WednesdayStartRadBtn.Name = "WednesdayStartRadBtn";
            this.WednesdayStartRadBtn.Size = new System.Drawing.Size(59, 16);
            this.WednesdayStartRadBtn.TabIndex = 41;
            this.WednesdayStartRadBtn.TabStop = true;
            this.WednesdayStartRadBtn.Text = "수요일";
            this.WednesdayStartRadBtn.UseVisualStyleBackColor = true;
            this.WednesdayStartRadBtn.CheckedChanged += new System.EventHandler(this.WednesdayRadBtn_CheckedChanged);
            this.WednesdayStartRadBtn.Click += new System.EventHandler(this.WednesdayRadBtn_Click);
            // 
            // ThursdayStartRadBtn
            // 
            this.ThursdayStartRadBtn.AutoSize = true;
            this.ThursdayStartRadBtn.Location = new System.Drawing.Point(11, 101);
            this.ThursdayStartRadBtn.Name = "ThursdayStartRadBtn";
            this.ThursdayStartRadBtn.Size = new System.Drawing.Size(59, 16);
            this.ThursdayStartRadBtn.TabIndex = 42;
            this.ThursdayStartRadBtn.TabStop = true;
            this.ThursdayStartRadBtn.Text = "목요일";
            this.ThursdayStartRadBtn.UseVisualStyleBackColor = true;
            this.ThursdayStartRadBtn.Click += new System.EventHandler(this.ThursdayRadBtn_Click);
            // 
            // FridayStartRadBtn
            // 
            this.FridayStartRadBtn.AutoSize = true;
            this.FridayStartRadBtn.Location = new System.Drawing.Point(11, 128);
            this.FridayStartRadBtn.Name = "FridayStartRadBtn";
            this.FridayStartRadBtn.Size = new System.Drawing.Size(59, 16);
            this.FridayStartRadBtn.TabIndex = 43;
            this.FridayStartRadBtn.TabStop = true;
            this.FridayStartRadBtn.Text = "금요일";
            this.FridayStartRadBtn.UseVisualStyleBackColor = true;
            this.FridayStartRadBtn.Click += new System.EventHandler(this.FridayRadBtn_Click);
            // 
            // SaturdayStartRadBtn
            // 
            this.SaturdayStartRadBtn.AutoSize = true;
            this.SaturdayStartRadBtn.Location = new System.Drawing.Point(11, 155);
            this.SaturdayStartRadBtn.Name = "SaturdayStartRadBtn";
            this.SaturdayStartRadBtn.Size = new System.Drawing.Size(59, 16);
            this.SaturdayStartRadBtn.TabIndex = 44;
            this.SaturdayStartRadBtn.TabStop = true;
            this.SaturdayStartRadBtn.Text = "토요일";
            this.SaturdayStartRadBtn.UseVisualStyleBackColor = true;
            this.SaturdayStartRadBtn.Click += new System.EventHandler(this.SaturdayRadBtn_Click);
            // 
            // SundayStartRadBtn
            // 
            this.SundayStartRadBtn.AutoSize = true;
            this.SundayStartRadBtn.Location = new System.Drawing.Point(11, 182);
            this.SundayStartRadBtn.Name = "SundayStartRadBtn";
            this.SundayStartRadBtn.Size = new System.Drawing.Size(59, 16);
            this.SundayStartRadBtn.TabIndex = 45;
            this.SundayStartRadBtn.TabStop = true;
            this.SundayStartRadBtn.Text = "일요일";
            this.SundayStartRadBtn.UseVisualStyleBackColor = true;
            this.SundayStartRadBtn.Click += new System.EventHandler(this.SundayRadBtn_Click);
            // 
            // SundayEndRadBtn
            // 
            this.SundayEndRadBtn.AutoSize = true;
            this.SundayEndRadBtn.Location = new System.Drawing.Point(7, 182);
            this.SundayEndRadBtn.Name = "SundayEndRadBtn";
            this.SundayEndRadBtn.Size = new System.Drawing.Size(14, 13);
            this.SundayEndRadBtn.TabIndex = 52;
            this.SundayEndRadBtn.TabStop = true;
            this.SundayEndRadBtn.UseVisualStyleBackColor = true;
            this.SundayEndRadBtn.Click += new System.EventHandler(this.SundayEndRadBtn_Click);
            // 
            // SaturdayEndRadBtn
            // 
            this.SaturdayEndRadBtn.AutoSize = true;
            this.SaturdayEndRadBtn.Location = new System.Drawing.Point(7, 155);
            this.SaturdayEndRadBtn.Name = "SaturdayEndRadBtn";
            this.SaturdayEndRadBtn.Size = new System.Drawing.Size(14, 13);
            this.SaturdayEndRadBtn.TabIndex = 51;
            this.SaturdayEndRadBtn.TabStop = true;
            this.SaturdayEndRadBtn.UseVisualStyleBackColor = true;
            this.SaturdayEndRadBtn.Click += new System.EventHandler(this.SaturdayEndRadBtn_Click);
            // 
            // FridayEndRadBtn
            // 
            this.FridayEndRadBtn.AutoSize = true;
            this.FridayEndRadBtn.Location = new System.Drawing.Point(7, 128);
            this.FridayEndRadBtn.Name = "FridayEndRadBtn";
            this.FridayEndRadBtn.Size = new System.Drawing.Size(14, 13);
            this.FridayEndRadBtn.TabIndex = 50;
            this.FridayEndRadBtn.TabStop = true;
            this.FridayEndRadBtn.UseVisualStyleBackColor = true;
            this.FridayEndRadBtn.Click += new System.EventHandler(this.FridayEndRadBtn_Click);
            // 
            // ThursdayEndRadBtn
            // 
            this.ThursdayEndRadBtn.AutoSize = true;
            this.ThursdayEndRadBtn.Location = new System.Drawing.Point(7, 101);
            this.ThursdayEndRadBtn.Name = "ThursdayEndRadBtn";
            this.ThursdayEndRadBtn.Size = new System.Drawing.Size(14, 13);
            this.ThursdayEndRadBtn.TabIndex = 49;
            this.ThursdayEndRadBtn.TabStop = true;
            this.ThursdayEndRadBtn.UseVisualStyleBackColor = true;
            this.ThursdayEndRadBtn.Click += new System.EventHandler(this.ThursdayEndRadBtn_Click);
            // 
            // WednesdayEndRadBtn
            // 
            this.WednesdayEndRadBtn.AutoSize = true;
            this.WednesdayEndRadBtn.Location = new System.Drawing.Point(7, 74);
            this.WednesdayEndRadBtn.Name = "WednesdayEndRadBtn";
            this.WednesdayEndRadBtn.Size = new System.Drawing.Size(14, 13);
            this.WednesdayEndRadBtn.TabIndex = 48;
            this.WednesdayEndRadBtn.TabStop = true;
            this.WednesdayEndRadBtn.UseVisualStyleBackColor = true;
            this.WednesdayEndRadBtn.Click += new System.EventHandler(this.WednesdayEndRadBtn_Click);
            // 
            // TuesdayEndRadBtn
            // 
            this.TuesdayEndRadBtn.AutoSize = true;
            this.TuesdayEndRadBtn.Location = new System.Drawing.Point(7, 47);
            this.TuesdayEndRadBtn.Name = "TuesdayEndRadBtn";
            this.TuesdayEndRadBtn.Size = new System.Drawing.Size(14, 13);
            this.TuesdayEndRadBtn.TabIndex = 47;
            this.TuesdayEndRadBtn.TabStop = true;
            this.TuesdayEndRadBtn.UseVisualStyleBackColor = true;
            this.TuesdayEndRadBtn.Click += new System.EventHandler(this.TuesdayEndRadBtn_Click);
            // 
            // MondayEndRadBtn
            // 
            this.MondayEndRadBtn.AutoSize = true;
            this.MondayEndRadBtn.Location = new System.Drawing.Point(7, 20);
            this.MondayEndRadBtn.Name = "MondayEndRadBtn";
            this.MondayEndRadBtn.Size = new System.Drawing.Size(14, 13);
            this.MondayEndRadBtn.TabIndex = 46;
            this.MondayEndRadBtn.TabStop = true;
            this.MondayEndRadBtn.UseVisualStyleBackColor = true;
            this.MondayEndRadBtn.Click += new System.EventHandler(this.MondayEndRadBtn_Click);
            // 
            // StartGroupBox
            // 
            this.StartGroupBox.Controls.Add(this.MondayStartRadBtn);
            this.StartGroupBox.Controls.Add(this.TuesdayStartRadBtn);
            this.StartGroupBox.Controls.Add(this.WednesdayStartRadBtn);
            this.StartGroupBox.Controls.Add(this.ThursdayStartRadBtn);
            this.StartGroupBox.Controls.Add(this.FridayStartRadBtn);
            this.StartGroupBox.Controls.Add(this.SaturdayStartRadBtn);
            this.StartGroupBox.Controls.Add(this.SundayStartRadBtn);
            this.StartGroupBox.Location = new System.Drawing.Point(92, 73);
            this.StartGroupBox.Name = "StartGroupBox";
            this.StartGroupBox.Size = new System.Drawing.Size(77, 206);
            this.StartGroupBox.TabIndex = 53;
            this.StartGroupBox.TabStop = false;
            this.StartGroupBox.Text = "요일";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SundayEndRadBtn);
            this.groupBox1.Controls.Add(this.MondayEndRadBtn);
            this.groupBox1.Controls.Add(this.TuesdayEndRadBtn);
            this.groupBox1.Controls.Add(this.SaturdayEndRadBtn);
            this.groupBox1.Controls.Add(this.WednesdayEndRadBtn);
            this.groupBox1.Controls.Add(this.FridayEndRadBtn);
            this.groupBox1.Controls.Add(this.ThursdayEndRadBtn);
            this.groupBox1.Location = new System.Drawing.Point(312, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(73, 206);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "요일";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // ReservationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 359);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartGroupBox);
            this.Controls.Add(this.SundayTempUpDown);
            this.Controls.Add(this.SaturdayTempUpDown);
            this.Controls.Add(this.FridayTempUpDown);
            this.Controls.Add(this.ThursdayTempUpDown);
            this.Controls.Add(this.WednesdayTempUpDown);
            this.Controls.Add(this.TuesdayTempUpDown);
            this.Controls.Add(this.MondayTempUpDown);
            this.Controls.Add(this.SundayEndTimePicker);
            this.Controls.Add(this.SundayStartTimePicker);
            this.Controls.Add(this.SaturdayEndTimePicker);
            this.Controls.Add(this.SaturdayStartTimePicker);
            this.Controls.Add(this.FridayEndTimePicker);
            this.Controls.Add(this.FridayStartTimePicker);
            this.Controls.Add(this.ThursdayEndTimePicker);
            this.Controls.Add(this.ThursdayStartTimePicker);
            this.Controls.Add(this.WednesdayEndTimePicker);
            this.Controls.Add(this.WednesdayStartTimePicker);
            this.Controls.Add(this.TuesdayEndTimePicker);
            this.Controls.Add(this.TuesdayStartTimePicker);
            this.Controls.Add(this.MondayEndTimePicker);
            this.Controls.Add(this.MondayStartTimePicker);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.group_button);
            this.Controls.Add(this.all_button);
            this.Controls.Add(this.reset_Btn);
            this.Controls.Add(this.comfirm_Btn);
            this.Controls.Add(this.apply_Btn);
            this.Controls.Add(this.RoomList);
            this.Name = "ReservationSetting";
            this.Text = "ReservationSetting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReservationSetting_FormClosed);
            this.Load += new System.EventHandler(this.ReservationSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MondayTempUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuesdayTempUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WednesdayTempUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThursdayTempUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FridayTempUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturdayTempUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SundayTempUpDown)).EndInit();
            this.StartGroupBox.ResumeLayout(false);
            this.StartGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reset_Btn;
        private System.Windows.Forms.Button comfirm_Btn;
        private System.Windows.Forms.Button apply_Btn;
        private System.Windows.Forms.ListView RoomList;
        private System.Windows.Forms.Button all_button;
        private System.Windows.Forms.Button group_button;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.DateTimePicker MondayStartTimePicker;
        private System.Windows.Forms.DateTimePicker MondayEndTimePicker;
        private System.Windows.Forms.DateTimePicker TuesdayStartTimePicker;
        private System.Windows.Forms.DateTimePicker TuesdayEndTimePicker;
        private System.Windows.Forms.DateTimePicker WednesdayStartTimePicker;
        private System.Windows.Forms.DateTimePicker WednesdayEndTimePicker;
        private System.Windows.Forms.DateTimePicker ThursdayStartTimePicker;
        private System.Windows.Forms.DateTimePicker ThursdayEndTimePicker;
        private System.Windows.Forms.DateTimePicker FridayStartTimePicker;
        private System.Windows.Forms.DateTimePicker FridayEndTimePicker;
        private System.Windows.Forms.DateTimePicker SaturdayStartTimePicker;
        private System.Windows.Forms.DateTimePicker SaturdayEndTimePicker;
        private System.Windows.Forms.DateTimePicker SundayStartTimePicker;
        private System.Windows.Forms.DateTimePicker SundayEndTimePicker;
        private System.Windows.Forms.NumericUpDown MondayTempUpDown;
        private System.Windows.Forms.NumericUpDown TuesdayTempUpDown;
        private System.Windows.Forms.NumericUpDown WednesdayTempUpDown;
        private System.Windows.Forms.NumericUpDown ThursdayTempUpDown;
        private System.Windows.Forms.NumericUpDown FridayTempUpDown;
        private System.Windows.Forms.NumericUpDown SaturdayTempUpDown;
        private System.Windows.Forms.NumericUpDown SundayTempUpDown;
        private System.Windows.Forms.RadioButton MondayStartRadBtn;
        private System.Windows.Forms.RadioButton TuesdayStartRadBtn;
        private System.Windows.Forms.RadioButton WednesdayStartRadBtn;
        private System.Windows.Forms.RadioButton ThursdayStartRadBtn;
        private System.Windows.Forms.RadioButton FridayStartRadBtn;
        private System.Windows.Forms.RadioButton SaturdayStartRadBtn;
        private System.Windows.Forms.RadioButton SundayStartRadBtn;
        private System.Windows.Forms.RadioButton SundayEndRadBtn;
        private System.Windows.Forms.RadioButton SaturdayEndRadBtn;
        private System.Windows.Forms.RadioButton FridayEndRadBtn;
        private System.Windows.Forms.RadioButton ThursdayEndRadBtn;
        private System.Windows.Forms.RadioButton WednesdayEndRadBtn;
        private System.Windows.Forms.RadioButton TuesdayEndRadBtn;
        private System.Windows.Forms.RadioButton MondayEndRadBtn;
        private System.Windows.Forms.GroupBox StartGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}