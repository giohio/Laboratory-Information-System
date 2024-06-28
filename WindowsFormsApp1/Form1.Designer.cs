namespace WindowsFormsApp1
{
    partial class hex_kq
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
            this.components = new System.ComponentModel.Container();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.cbBits = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbBit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btKetNoi = new System.Windows.Forms.Button();
            this.btNgat = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.txtkq = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbHandshake = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.hexkq = new System.Windows.Forms.TextBox();
            this.Dtr = new System.Windows.Forms.CheckBox();
            this.Rts = new System.Windows.Forms.CheckBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CTSStatus = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.DSRStatus = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CDStatus = new System.Windows.Forms.PictureBox();
            this.txtSendHex = new System.Windows.Forms.TextBox();
            this.btSendHex = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btXem = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNtn = new System.Windows.Forms.TextBox();
            this.txtGt = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btHt = new System.Windows.Forms.Button();
            this.bt_sendack = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CTSStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSRStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CDStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(169, 63);
            this.cbCom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(121, 24);
            this.cbCom.TabIndex = 0;
            this.cbCom.Text = " ";
            this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
            // 
            // cbRate
            // 
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Location = new System.Drawing.Point(169, 108);
            this.cbRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(121, 24);
            this.cbRate.TabIndex = 1;
            this.cbRate.SelectedIndexChanged += new System.EventHandler(this.cbRate_SelectedIndexChanged);
            // 
            // cbBits
            // 
            this.cbBits.FormattingEnabled = true;
            this.cbBits.Location = new System.Drawing.Point(169, 154);
            this.cbBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBits.Name = "cbBits";
            this.cbBits.Size = new System.Drawing.Size(121, 24);
            this.cbBits.TabIndex = 2;
            this.cbBits.SelectedIndexChanged += new System.EventHandler(this.cbBits_SelectedIndexChanged);
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(169, 199);
            this.cbParity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(121, 24);
            this.cbParity.TabIndex = 3;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.cbParity_SelectedIndexChanged);
            // 
            // cbBit
            // 
            this.cbBit.FormattingEnabled = true;
            this.cbBit.Location = new System.Drawing.Point(169, 246);
            this.cbBit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBit.Name = "cbBit";
            this.cbBit.Size = new System.Drawing.Size(121, 24);
            this.cbBit.TabIndex = 4;
            this.cbBit.SelectedIndexChanged += new System.EventHandler(this.cbBit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Baud Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Parity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Stop Bit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bảng điều khiển";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btKetNoi
            // 
            this.btKetNoi.Location = new System.Drawing.Point(79, 342);
            this.btKetNoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btKetNoi.Name = "btKetNoi";
            this.btKetNoi.Size = new System.Drawing.Size(75, 23);
            this.btKetNoi.TabIndex = 11;
            this.btKetNoi.Text = "Kết Nối";
            this.btKetNoi.UseVisualStyleBackColor = true;
            this.btKetNoi.Click += new System.EventHandler(this.btKetNoi_Click);
            // 
            // btNgat
            // 
            this.btNgat.Location = new System.Drawing.Point(199, 342);
            this.btNgat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btNgat.Name = "btNgat";
            this.btNgat.Size = new System.Drawing.Size(75, 23);
            this.btNgat.TabIndex = 12;
            this.btNgat.Text = "Ngắt";
            this.btNgat.UseVisualStyleBackColor = true;
            this.btNgat.Click += new System.EventHandler(this.btNgat_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(79, 382);
            this.btXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 23);
            this.btXoa.TabIndex = 13;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(199, 382);
            this.btThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 14;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // txtkq
            // 
            this.txtkq.Location = new System.Drawing.Point(360, 41);
            this.txtkq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtkq.Multiline = true;
            this.txtkq.Name = "txtkq";
            this.txtkq.Size = new System.Drawing.Size(409, 137);
            this.txtkq.TabIndex = 15;
            this.txtkq.TextChanged += new System.EventHandler(this.txtkq_TextChanged);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(360, 311);
            this.txtSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(335, 42);
            this.txtSend.TabIndex = 16;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(701, 316);
            this.btSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(87, 30);
            this.btSend.TabIndex = 17;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1335, 26);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(49, 20);
            this.status.Text = "Status";
            // 
            // cbHandshake
            // 
            this.cbHandshake.FormattingEnabled = true;
            this.cbHandshake.Location = new System.Drawing.Point(169, 292);
            this.cbHandshake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbHandshake.Name = "cbHandshake";
            this.cbHandshake.Size = new System.Drawing.Size(121, 24);
            this.cbHandshake.TabIndex = 19;
            this.cbHandshake.SelectedIndexChanged += new System.EventHandler(this.cbHandshake_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Hand Shake";
            // 
            // hexkq
            // 
            this.hexkq.Location = new System.Drawing.Point(360, 185);
            this.hexkq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hexkq.Multiline = true;
            this.hexkq.Name = "hexkq";
            this.hexkq.Size = new System.Drawing.Size(409, 121);
            this.hexkq.TabIndex = 21;
            this.hexkq.TextChanged += new System.EventHandler(this.hexkq_TextChanged);
            // 
            // Dtr
            // 
            this.Dtr.AutoSize = true;
            this.Dtr.Location = new System.Drawing.Point(625, 445);
            this.Dtr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dtr.Name = "Dtr";
            this.Dtr.Size = new System.Drawing.Size(58, 20);
            this.Dtr.TabIndex = 22;
            this.Dtr.Text = "DTR";
            this.Dtr.UseVisualStyleBackColor = true;
            this.Dtr.CheckedChanged += new System.EventHandler(this.Dtr_CheckedChanged);
            // 
            // Rts
            // 
            this.Rts.AutoSize = true;
            this.Rts.Location = new System.Drawing.Point(701, 445);
            this.Rts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rts.Name = "Rts";
            this.Rts.Size = new System.Drawing.Size(57, 20);
            this.Rts.TabIndex = 23;
            this.Rts.Text = "RTS";
            this.Rts.UseVisualStyleBackColor = true;
            this.Rts.CheckedChanged += new System.EventHandler(this.Rts_CheckedChanged);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(421, 14);
            this.txtDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(147, 22);
            this.txtDate.TabIndex = 24;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(659, 15);
            this.txtTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 22);
            this.txtTime.TabIndex = 25;
            this.txtTime.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(613, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(542, 407);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Folder";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(600, 404);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(169, 22);
            this.txtFolder.TabIndex = 29;
            this.txtFolder.Text = "C:\\savefile";
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(581, 446);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 16);
            this.label11.TabIndex = 30;
            this.label11.Text = "CTS";
            // 
            // CTSStatus
            // 
            this.CTSStatus.Location = new System.Drawing.Point(555, 444);
            this.CTSStatus.Margin = new System.Windows.Forms.Padding(4);
            this.CTSStatus.Name = "CTSStatus";
            this.CTSStatus.Size = new System.Drawing.Size(19, 17);
            this.CTSStatus.TabIndex = 31;
            this.CTSStatus.TabStop = false;
            this.CTSStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.CTSStatus_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(497, 445);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "DSR";
            // 
            // DSRStatus
            // 
            this.DSRStatus.Location = new System.Drawing.Point(467, 444);
            this.DSRStatus.Margin = new System.Windows.Forms.Padding(4);
            this.DSRStatus.Name = "DSRStatus";
            this.DSRStatus.Size = new System.Drawing.Size(19, 17);
            this.DSRStatus.TabIndex = 33;
            this.DSRStatus.TabStop = false;
            this.DSRStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.DSRStatus_Paint_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(422, 444);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 16);
            this.label13.TabIndex = 34;
            this.label13.Text = "CD";
            // 
            // CDStatus
            // 
            this.CDStatus.Location = new System.Drawing.Point(395, 442);
            this.CDStatus.Margin = new System.Windows.Forms.Padding(4);
            this.CDStatus.Name = "CDStatus";
            this.CDStatus.Size = new System.Drawing.Size(19, 17);
            this.CDStatus.TabIndex = 35;
            this.CDStatus.TabStop = false;
            this.CDStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.CDStatus_Paint);
            // 
            // txtSendHex
            // 
            this.txtSendHex.Location = new System.Drawing.Point(360, 358);
            this.txtSendHex.Multiline = true;
            this.txtSendHex.Name = "txtSendHex";
            this.txtSendHex.Size = new System.Drawing.Size(335, 42);
            this.txtSendHex.TabIndex = 36;
            this.txtSendHex.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btSendHex
            // 
            this.btSendHex.Location = new System.Drawing.Point(703, 363);
            this.btSendHex.Name = "btSendHex";
            this.btSendHex.Size = new System.Drawing.Size(85, 30);
            this.btSendHex.TabIndex = 37;
            this.btSendHex.Text = "Send Hex";
            this.btSendHex.UseVisualStyleBackColor = true;
            this.btSendHex.Click += new System.EventHandler(this.btSendHex_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(801, 197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(186, 23);
            this.label14.TabIndex = 51;
            this.label14.Text = "Thông tin khám bệnh";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(801, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(223, 23);
            this.label15.TabIndex = 50;
            this.label15.Text = "Nhập thông tin bệnh nhân";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // btXem
            // 
            this.btXem.Location = new System.Drawing.Point(1020, 291);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(75, 29);
            this.btXem.TabIndex = 49;
            this.btXem.Text = "Xem";
            this.btXem.UseVisualStyleBackColor = true;
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(855, 295);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(137, 19);
            this.label16.TabIndex = 48;
            this.label16.Text = "Kết quả khám bệnh";
            // 
            // cbKhoa
            // 
            this.cbKhoa.FormattingEnabled = true;
            this.cbKhoa.Items.AddRange(new object[] {
            "Cứu thương",
            "Tâm thần",
            "Tâm thần trẻ em",
            "Phục hồi chức năng",
            "Phục hồi chức năng nhi khoa",
            "Cách ly",
            "Sản, phụ Khoa",
            "Sơ sinh",
            "Hồi sức tích cực",
            "Phẫu thuật",
            "Hồi sức tâm thần cấp cứu",
            "Giáo dục",
            "Tim mạch",
            "Chăm sóc Sơ sinh",
            "Chăm sóc cấp cứu",
            "Nhi",
            "Cấp cứu",
            "Theo dõi",
            "Khám không cần hẹn trước",
            "Phòng khám đa khoa",
            "Di ứng",
            "Kế hoạch hóa gia đình",
            "Chấn thương chỉnh hình",
            "Ung thư",
            "Y học cổ truyền",
            "Khác"});
            this.cbKhoa.Location = new System.Drawing.Point(937, 238);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(294, 24);
            this.cbKhoa.TabIndex = 47;
            this.cbKhoa.SelectedIndexChanged += new System.EventHandler(this.cbKhoa_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(855, 243);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 19);
            this.label17.TabIndex = 46;
            this.label17.Text = "Khoa";
            // 
            // txtNtn
            // 
            this.txtNtn.Location = new System.Drawing.Point(1027, 85);
            this.txtNtn.Name = "txtNtn";
            this.txtNtn.Size = new System.Drawing.Size(172, 22);
            this.txtNtn.TabIndex = 45;
            // 
            // txtGt
            // 
            this.txtGt.Location = new System.Drawing.Point(1027, 117);
            this.txtGt.Name = "txtGt";
            this.txtGt.Size = new System.Drawing.Size(68, 22);
            this.txtGt.TabIndex = 44;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(1027, 147);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(172, 22);
            this.txtCCCD.TabIndex = 43;
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(1027, 50);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(226, 22);
            this.txtHoten.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(855, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(160, 19);
            this.label18.TabIndex = 41;
            this.label18.Text = "Ngày/Tháng/Năm Sinh";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(855, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 19);
            this.label19.TabIndex = 40;
            this.label19.Text = "Giới Tính";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(855, 147);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(137, 19);
            this.label20.TabIndex = 39;
            this.label20.Text = "Căn cước công dân";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(855, 50);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 19);
            this.label21.TabIndex = 38;
            this.label21.Text = "Họ và tên";
            // 
            // btHt
            // 
            this.btHt.Location = new System.Drawing.Point(1151, 371);
            this.btHt.Name = "btHt";
            this.btHt.Size = new System.Drawing.Size(120, 45);
            this.btHt.TabIndex = 52;
            this.btHt.Text = "Hoàn thành";
            this.btHt.UseVisualStyleBackColor = true;
            this.btHt.Click += new System.EventHandler(this.btHt_Click);
            // 
            // bt_sendack
            // 
            this.bt_sendack.Location = new System.Drawing.Point(937, 373);
            this.bt_sendack.Name = "bt_sendack";
            this.bt_sendack.Size = new System.Drawing.Size(109, 43);
            this.bt_sendack.TabIndex = 53;
            this.bt_sendack.Text = "SendACK";
            this.bt_sendack.UseVisualStyleBackColor = true;
            this.bt_sendack.Click += new System.EventHandler(this.bt_sendack_Click);
            // 
            // hex_kq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 501);
            this.Controls.Add(this.bt_sendack);
            this.Controls.Add(this.btHt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btXem);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbKhoa);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtNtn);
            this.Controls.Add(this.txtGt);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.txtHoten);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btSendHex);
            this.Controls.Add(this.txtSendHex);
            this.Controls.Add(this.CDStatus);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DSRStatus);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CTSStatus);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.Rts);
            this.Controls.Add(this.Dtr);
            this.Controls.Add(this.hexkq);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbHandshake);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtkq);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btNgat);
            this.Controls.Add(this.btKetNoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBit);
            this.Controls.Add(this.cbParity);
            this.Controls.Add(this.cbBits);
            this.Controls.Add(this.cbRate);
            this.Controls.Add(this.cbCom);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "hex_kq";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CTSStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSRStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CDStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.ComboBox cbBits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbBit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btKetNoi;
        private System.Windows.Forms.Button btNgat;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ComboBox cbHandshake;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox hexkq;
        private System.Windows.Forms.CheckBox Dtr;
        private System.Windows.Forms.CheckBox Rts;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox CTSStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox DSRStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox CDStatus;
        private System.Windows.Forms.TextBox txtSendHex;
        private System.Windows.Forms.Button btSendHex;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btXem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbKhoa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNtn;
        private System.Windows.Forms.TextBox txtGt;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btHt;
        private System.Windows.Forms.Button bt_sendack;
        public System.Windows.Forms.TextBox txtkq;
    }
}

