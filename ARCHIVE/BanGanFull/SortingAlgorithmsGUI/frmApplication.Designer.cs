namespace SortingAlgorithmsGUI
{
    partial class frmApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApplication));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlExTime = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bntExit = new System.Windows.Forms.Button();
            this.bntBack = new System.Windows.Forms.Button();
            this.pnlChayMau = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.lblB = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.Mui_ten_do_len = new System.Windows.Forms.Label();
            this.Mui_ten_xanh_len_2 = new System.Windows.Forms.Label();
            this.Mui_ten_xanh_len_1 = new System.Windows.Forms.Label();
            this.Mui_ten_xanh_xuong_2 = new System.Windows.Forms.Label();
            this.Mui_ten_xanh_xuong_1 = new System.Windows.Forms.Label();
            this.lbl_status_02 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listCode = new System.Windows.Forms.ListBox();
            this.bntSourceCode = new System.Windows.Forms.Button();
            this.listIdea = new System.Windows.Forms.ListBox();
            this.bntIdeaAlgorithm = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.bntPlay = new System.Windows.Forms.Button();
            this.bntPause = new System.Windows.Forms.Button();
            this.grpCreateArray = new System.Windows.Forms.GroupBox();
            this.radDecrease = new System.Windows.Forms.RadioButton();
            this.radIncrease = new System.Windows.Forms.RadioButton();
            this.bntByHand = new System.Windows.Forms.Button();
            this.bntRandom = new System.Windows.Forms.Button();
            this.grpInitial = new System.Windows.Forms.GroupBox();
            this.bntReset = new System.Windows.Forms.Button();
            this.bntCreate = new System.Windows.Forms.Button();
            this.numArray = new System.Windows.Forms.NumericUpDown();
            this.grpDebug = new System.Windows.Forms.GroupBox();
            this.bntDebug = new System.Windows.Forms.Button();
            this.ckDebug = new System.Windows.Forms.CheckBox();
            this.pnlLoaiThuatToan = new System.Windows.Forms.Panel();
            this.radSelection = new System.Windows.Forms.RadioButton();
            this.radInsertion = new System.Windows.Forms.RadioButton();
            this.radShell = new System.Windows.Forms.RadioButton();
            this.radHeap = new System.Windows.Forms.RadioButton();
            this.radInterchange = new System.Windows.Forms.RadioButton();
            this.radMerge = new System.Windows.Forms.RadioButton();
            this.radBubble = new System.Windows.Forms.RadioButton();
            this.radQuick = new System.Windows.Forms.RadioButton();
            this.ExTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlExTime.SuspendLayout();
            this.pnlChayMau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.grpCreateArray.SuspendLayout();
            this.grpInitial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArray)).BeginInit();
            this.grpDebug.SuspendLayout();
            this.pnlLoaiThuatToan.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pnlExTime);
            this.panel1.Controls.Add(this.bntExit);
            this.panel1.Controls.Add(this.bntBack);
            this.panel1.Location = new System.Drawing.Point(0, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 53);
            this.panel1.TabIndex = 0;
            // 
            // pnlExTime
            // 
            this.pnlExTime.BackColor = System.Drawing.Color.Transparent;
            this.pnlExTime.Controls.Add(this.label4);
            this.pnlExTime.Controls.Add(this.lblSeconds);
            this.pnlExTime.Controls.Add(this.lblMinutes);
            this.pnlExTime.Controls.Add(this.label1);
            this.pnlExTime.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlExTime.Location = new System.Drawing.Point(446, 9);
            this.pnlExTime.Name = "pnlExTime";
            this.pnlExTime.Size = new System.Drawing.Size(248, 41);
            this.pnlExTime.TabIndex = 113;
            this.pnlExTime.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(179, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 24);
            this.label4.TabIndex = 112;
            this.label4.Text = ":";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.BackColor = System.Drawing.Color.Transparent;
            this.lblSeconds.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.Yellow;
            this.lblSeconds.Location = new System.Drawing.Point(191, 6);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(32, 24);
            this.lblSeconds.TabIndex = 111;
            this.lblSeconds.Text = "00";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.BackColor = System.Drawing.Color.Transparent;
            this.lblMinutes.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.ForeColor = System.Drawing.Color.Yellow;
            this.lblMinutes.Location = new System.Drawing.Point(153, 6);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(32, 24);
            this.lblMinutes.TabIndex = 110;
            this.lblMinutes.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 24);
            this.label1.TabIndex = 109;
            this.label1.Text = "Execution time :";
            // 
            // bntExit
            // 
            this.bntExit.AutoSize = true;
            this.bntExit.BackColor = System.Drawing.Color.Transparent;
            this.bntExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.bntExit.FlatAppearance.BorderSize = 0;
            this.bntExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.bntExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntExit.Image = ((System.Drawing.Image)(resources.GetObject("bntExit.Image")));
            this.bntExit.Location = new System.Drawing.Point(1109, 0);
            this.bntExit.Margin = new System.Windows.Forms.Padding(2);
            this.bntExit.Name = "bntExit";
            this.bntExit.Size = new System.Drawing.Size(50, 53);
            this.bntExit.TabIndex = 1;
            this.bntExit.UseVisualStyleBackColor = false;
            this.bntExit.Click += new System.EventHandler(this.bntExit_Click);
            // 
            // bntBack
            // 
            this.bntBack.BackColor = System.Drawing.Color.Transparent;
            this.bntBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.bntBack.FlatAppearance.BorderSize = 0;
            this.bntBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.bntBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntBack.Image = ((System.Drawing.Image)(resources.GetObject("bntBack.Image")));
            this.bntBack.Location = new System.Drawing.Point(0, 0);
            this.bntBack.Margin = new System.Windows.Forms.Padding(2);
            this.bntBack.Name = "bntBack";
            this.bntBack.Size = new System.Drawing.Size(52, 53);
            this.bntBack.TabIndex = 0;
            this.bntBack.UseVisualStyleBackColor = false;
            this.bntBack.Click += new System.EventHandler(this.bntBack_Click);
            // 
            // pnlChayMau
            // 
            this.pnlChayMau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.pnlChayMau.Controls.Add(this.label6);
            this.pnlChayMau.Controls.Add(this.label5);
            this.pnlChayMau.Controls.Add(this.label3);
            this.pnlChayMau.Controls.Add(this.label2);
            this.pnlChayMau.Controls.Add(this.speedTrackBar);
            this.pnlChayMau.Controls.Add(this.lblB);
            this.pnlChayMau.Controls.Add(this.lblC);
            this.pnlChayMau.Controls.Add(this.lblA);
            this.pnlChayMau.Controls.Add(this.Mui_ten_do_len);
            this.pnlChayMau.Controls.Add(this.Mui_ten_xanh_len_2);
            this.pnlChayMau.Controls.Add(this.Mui_ten_xanh_len_1);
            this.pnlChayMau.Controls.Add(this.Mui_ten_xanh_xuong_2);
            this.pnlChayMau.Controls.Add(this.Mui_ten_xanh_xuong_1);
            this.pnlChayMau.Controls.Add(this.lbl_status_02);
            this.pnlChayMau.Location = new System.Drawing.Point(0, 72);
            this.pnlChayMau.Margin = new System.Windows.Forms.Padding(2);
            this.pnlChayMau.Name = "pnlChayMau";
            this.pnlChayMau.Size = new System.Drawing.Size(790, 353);
            this.pnlChayMau.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(721, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 104;
            this.label6.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(721, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 104;
            this.label5.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(721, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 16);
            this.label3.TabIndex = 104;
            this.label3.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(741, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 103;
            this.label2.Text = "Speed";
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.speedTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.speedTrackBar.LargeChange = 1;
            this.speedTrackBar.Location = new System.Drawing.Point(745, 27);
            this.speedTrackBar.Maximum = 100;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.speedTrackBar.Size = new System.Drawing.Size(45, 323);
            this.speedTrackBar.SmallChange = 6;
            this.speedTrackBar.TabIndex = 102;
            this.speedTrackBar.TickFrequency = 10;
            this.speedTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.speedTrackBar.Value = 30;
            this.speedTrackBar.ValueChanged += new System.EventHandler(this.speedTrackBar_ValueChanged);
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblB.Location = new System.Drawing.Point(5, 175);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(21, 20);
            this.lblB.TabIndex = 9;
            this.lblB.Text = "A";
            this.lblB.Visible = false;
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblC.ForeColor = System.Drawing.Color.Red;
            this.lblC.Location = new System.Drawing.Point(5, 283);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(21, 20);
            this.lblC.TabIndex = 8;
            this.lblC.Text = "C";
            this.lblC.Visible = false;
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblA.Location = new System.Drawing.Point(5, 67);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(21, 20);
            this.lblA.TabIndex = 7;
            this.lblA.Text = "B";
            this.lblA.Visible = false;
            // 
            // Mui_ten_do_len
            // 
            this.Mui_ten_do_len.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Mui_ten_do_len.Image = global::SortingAlgorithmsGUI.Properties.Resources.Red_Up_Arrow;
            this.Mui_ten_do_len.Location = new System.Drawing.Point(363, 290);
            this.Mui_ten_do_len.Name = "Mui_ten_do_len";
            this.Mui_ten_do_len.Size = new System.Drawing.Size(60, 40);
            this.Mui_ten_do_len.TabIndex = 6;
            this.Mui_ten_do_len.Text = "R";
            this.Mui_ten_do_len.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mui_ten_do_len.Visible = false;
            // 
            // Mui_ten_xanh_len_2
            // 
            this.Mui_ten_xanh_len_2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Mui_ten_xanh_len_2.Image = ((System.Drawing.Image)(resources.GetObject("Mui_ten_xanh_len_2.Image")));
            this.Mui_ten_xanh_len_2.Location = new System.Drawing.Point(248, 290);
            this.Mui_ten_xanh_len_2.Name = "Mui_ten_xanh_len_2";
            this.Mui_ten_xanh_len_2.Size = new System.Drawing.Size(60, 40);
            this.Mui_ten_xanh_len_2.TabIndex = 5;
            this.Mui_ten_xanh_len_2.Text = "u2";
            this.Mui_ten_xanh_len_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mui_ten_xanh_len_2.Visible = false;
            // 
            // Mui_ten_xanh_len_1
            // 
            this.Mui_ten_xanh_len_1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Mui_ten_xanh_len_1.Image = ((System.Drawing.Image)(resources.GetObject("Mui_ten_xanh_len_1.Image")));
            this.Mui_ten_xanh_len_1.Location = new System.Drawing.Point(150, 290);
            this.Mui_ten_xanh_len_1.Name = "Mui_ten_xanh_len_1";
            this.Mui_ten_xanh_len_1.Size = new System.Drawing.Size(60, 40);
            this.Mui_ten_xanh_len_1.TabIndex = 4;
            this.Mui_ten_xanh_len_1.Text = "u1";
            this.Mui_ten_xanh_len_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mui_ten_xanh_len_1.Visible = false;
            // 
            // Mui_ten_xanh_xuong_2
            // 
            this.Mui_ten_xanh_xuong_2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Mui_ten_xanh_xuong_2.Image = global::SortingAlgorithmsGUI.Properties.Resources._2;
            this.Mui_ten_xanh_xuong_2.Location = new System.Drawing.Point(291, 58);
            this.Mui_ten_xanh_xuong_2.Name = "Mui_ten_xanh_xuong_2";
            this.Mui_ten_xanh_xuong_2.Size = new System.Drawing.Size(60, 40);
            this.Mui_ten_xanh_xuong_2.TabIndex = 3;
            this.Mui_ten_xanh_xuong_2.Text = "d2";
            this.Mui_ten_xanh_xuong_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mui_ten_xanh_xuong_2.Visible = false;
            // 
            // Mui_ten_xanh_xuong_1
            // 
            this.Mui_ten_xanh_xuong_1.BackColor = System.Drawing.Color.Transparent;
            this.Mui_ten_xanh_xuong_1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Mui_ten_xanh_xuong_1.Image = global::SortingAlgorithmsGUI.Properties.Resources._2;
            this.Mui_ten_xanh_xuong_1.Location = new System.Drawing.Point(164, 58);
            this.Mui_ten_xanh_xuong_1.Name = "Mui_ten_xanh_xuong_1";
            this.Mui_ten_xanh_xuong_1.Size = new System.Drawing.Size(60, 40);
            this.Mui_ten_xanh_xuong_1.TabIndex = 2;
            this.Mui_ten_xanh_xuong_1.Text = "d1";
            this.Mui_ten_xanh_xuong_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mui_ten_xanh_xuong_1.Visible = false;
            // 
            // lbl_status_02
            // 
            this.lbl_status_02.AutoSize = true;
            this.lbl_status_02.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_status_02.Location = new System.Drawing.Point(355, 15);
            this.lbl_status_02.Name = "lbl_status_02";
            this.lbl_status_02.Size = new System.Drawing.Size(57, 20);
            this.lbl_status_02.TabIndex = 1;
            this.lbl_status_02.Text = "label2";
            this.lbl_status_02.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.panel2.Controls.Add(this.listCode);
            this.panel2.Controls.Add(this.bntSourceCode);
            this.panel2.Controls.Add(this.listIdea);
            this.panel2.Controls.Add(this.bntIdeaAlgorithm);
            this.panel2.Location = new System.Drawing.Point(806, 72);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 353);
            this.panel2.TabIndex = 2;
            // 
            // listCode
            // 
            this.listCode.BackColor = System.Drawing.Color.White;
            this.listCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCode.FormattingEnabled = true;
            this.listCode.Location = new System.Drawing.Point(0, 0);
            this.listCode.Margin = new System.Windows.Forms.Padding(2);
            this.listCode.Name = "listCode";
            this.listCode.Size = new System.Drawing.Size(353, 286);
            this.listCode.TabIndex = 2;
            // 
            // bntSourceCode
            // 
            this.bntSourceCode.BackColor = System.Drawing.Color.Gray;
            this.bntSourceCode.FlatAppearance.BorderSize = 0;
            this.bntSourceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntSourceCode.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSourceCode.Image = ((System.Drawing.Image)(resources.GetObject("bntSourceCode.Image")));
            this.bntSourceCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntSourceCode.Location = new System.Drawing.Point(-4, 290);
            this.bntSourceCode.Margin = new System.Windows.Forms.Padding(2);
            this.bntSourceCode.Name = "bntSourceCode";
            this.bntSourceCode.Size = new System.Drawing.Size(166, 63);
            this.bntSourceCode.TabIndex = 0;
            this.bntSourceCode.Text = "Source Code ";
            this.bntSourceCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntSourceCode.UseVisualStyleBackColor = false;
            this.bntSourceCode.Click += new System.EventHandler(this.bntSourceCode_Click);
            // 
            // listIdea
            // 
            this.listIdea.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listIdea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listIdea.Dock = System.Windows.Forms.DockStyle.Top;
            this.listIdea.FormattingEnabled = true;
            this.listIdea.Location = new System.Drawing.Point(0, 0);
            this.listIdea.Margin = new System.Windows.Forms.Padding(2);
            this.listIdea.Name = "listIdea";
            this.listIdea.Size = new System.Drawing.Size(353, 286);
            this.listIdea.TabIndex = 1;
            // 
            // bntIdeaAlgorithm
            // 
            this.bntIdeaAlgorithm.BackColor = System.Drawing.Color.Gray;
            this.bntIdeaAlgorithm.FlatAppearance.BorderSize = 0;
            this.bntIdeaAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntIdeaAlgorithm.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntIdeaAlgorithm.ForeColor = System.Drawing.Color.Gold;
            this.bntIdeaAlgorithm.Image = ((System.Drawing.Image)(resources.GetObject("bntIdeaAlgorithm.Image")));
            this.bntIdeaAlgorithm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntIdeaAlgorithm.Location = new System.Drawing.Point(166, 290);
            this.bntIdeaAlgorithm.Margin = new System.Windows.Forms.Padding(2);
            this.bntIdeaAlgorithm.Name = "bntIdeaAlgorithm";
            this.bntIdeaAlgorithm.Size = new System.Drawing.Size(196, 63);
            this.bntIdeaAlgorithm.TabIndex = 0;
            this.bntIdeaAlgorithm.Text = "Idea Algorithm";
            this.bntIdeaAlgorithm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntIdeaAlgorithm.UseVisualStyleBackColor = false;
            this.bntIdeaAlgorithm.Click += new System.EventHandler(this.bntIdeaAlgorithm_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel3.Controls.Add(this.grpControl);
            this.panel3.Controls.Add(this.grpCreateArray);
            this.panel3.Controls.Add(this.grpInitial);
            this.panel3.Controls.Add(this.grpDebug);
            this.panel3.Location = new System.Drawing.Point(0, 439);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(790, 147);
            this.panel3.TabIndex = 3;
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.bntPlay);
            this.grpControl.Controls.Add(this.bntPause);
            this.grpControl.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpControl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grpControl.Location = new System.Drawing.Point(234, 2);
            this.grpControl.Margin = new System.Windows.Forms.Padding(2);
            this.grpControl.Name = "grpControl";
            this.grpControl.Padding = new System.Windows.Forms.Padding(2);
            this.grpControl.Size = new System.Drawing.Size(153, 145);
            this.grpControl.TabIndex = 3;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Control";
            // 
            // bntPlay
            // 
            this.bntPlay.FlatAppearance.BorderSize = 0;
            this.bntPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntPlay.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntPlay.ForeColor = System.Drawing.Color.MistyRose;
            this.bntPlay.Image = ((System.Drawing.Image)(resources.GetObject("bntPlay.Image")));
            this.bntPlay.Location = new System.Drawing.Point(23, 27);
            this.bntPlay.Margin = new System.Windows.Forms.Padding(2);
            this.bntPlay.Name = "bntPlay";
            this.bntPlay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bntPlay.Size = new System.Drawing.Size(111, 112);
            this.bntPlay.TabIndex = 1;
            this.bntPlay.Text = "Play";
            this.bntPlay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntPlay.UseVisualStyleBackColor = true;
            this.bntPlay.Click += new System.EventHandler(this.bntPlay_Click);
            // 
            // bntPause
            // 
            this.bntPause.FlatAppearance.BorderSize = 0;
            this.bntPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic);
            this.bntPause.ForeColor = System.Drawing.Color.MistyRose;
            this.bntPause.Image = ((System.Drawing.Image)(resources.GetObject("bntPause.Image")));
            this.bntPause.Location = new System.Drawing.Point(23, 27);
            this.bntPause.Margin = new System.Windows.Forms.Padding(2);
            this.bntPause.Name = "bntPause";
            this.bntPause.Size = new System.Drawing.Size(100, 112);
            this.bntPause.TabIndex = 1;
            this.bntPause.Text = "Pause";
            this.bntPause.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntPause.UseVisualStyleBackColor = true;
            this.bntPause.Click += new System.EventHandler(this.bntPause_Click);
            // 
            // grpCreateArray
            // 
            this.grpCreateArray.Controls.Add(this.radDecrease);
            this.grpCreateArray.Controls.Add(this.radIncrease);
            this.grpCreateArray.Controls.Add(this.bntByHand);
            this.grpCreateArray.Controls.Add(this.bntRandom);
            this.grpCreateArray.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCreateArray.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grpCreateArray.Location = new System.Drawing.Point(558, 2);
            this.grpCreateArray.Margin = new System.Windows.Forms.Padding(2);
            this.grpCreateArray.Name = "grpCreateArray";
            this.grpCreateArray.Padding = new System.Windows.Forms.Padding(2);
            this.grpCreateArray.Size = new System.Drawing.Size(230, 145);
            this.grpCreateArray.TabIndex = 0;
            this.grpCreateArray.TabStop = false;
            this.grpCreateArray.Text = "Create Array";
            // 
            // radDecrease
            // 
            this.radDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radDecrease.ForeColor = System.Drawing.SystemColors.Control;
            this.radDecrease.Image = ((System.Drawing.Image)(resources.GetObject("radDecrease.Image")));
            this.radDecrease.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radDecrease.Location = new System.Drawing.Point(41, 59);
            this.radDecrease.Margin = new System.Windows.Forms.Padding(2);
            this.radDecrease.Name = "radDecrease";
            this.radDecrease.Size = new System.Drawing.Size(116, 28);
            this.radDecrease.TabIndex = 2;
            this.radDecrease.Text = "Decrease";
            this.radDecrease.UseVisualStyleBackColor = true;
            this.radDecrease.CheckedChanged += new System.EventHandler(this.radDecrease_CheckedChanged);
            // 
            // radIncrease
            // 
            this.radIncrease.Checked = true;
            this.radIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radIncrease.ForeColor = System.Drawing.SystemColors.Control;
            this.radIncrease.Image = ((System.Drawing.Image)(resources.GetObject("radIncrease.Image")));
            this.radIncrease.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radIncrease.Location = new System.Drawing.Point(41, 27);
            this.radIncrease.Margin = new System.Windows.Forms.Padding(2);
            this.radIncrease.Name = "radIncrease";
            this.radIncrease.Size = new System.Drawing.Size(116, 28);
            this.radIncrease.TabIndex = 2;
            this.radIncrease.TabStop = true;
            this.radIncrease.Text = "Increase";
            this.radIncrease.UseVisualStyleBackColor = true;
            this.radIncrease.CheckedChanged += new System.EventHandler(this.radIncrease_CheckedChanged);
            // 
            // bntByHand
            // 
            this.bntByHand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(115)))), ((int)(((byte)(134)))));
            this.bntByHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Italic);
            this.bntByHand.ForeColor = System.Drawing.SystemColors.Window;
            this.bntByHand.Image = ((System.Drawing.Image)(resources.GetObject("bntByHand.Image")));
            this.bntByHand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntByHand.Location = new System.Drawing.Point(118, 91);
            this.bntByHand.Margin = new System.Windows.Forms.Padding(2);
            this.bntByHand.Name = "bntByHand";
            this.bntByHand.Size = new System.Drawing.Size(103, 39);
            this.bntByHand.TabIndex = 1;
            this.bntByHand.Text = "By Hand";
            this.bntByHand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntByHand.UseVisualStyleBackColor = false;
            this.bntByHand.Click += new System.EventHandler(this.bntByHand_Click);
            // 
            // bntRandom
            // 
            this.bntRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(115)))), ((int)(((byte)(134)))));
            this.bntRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Italic);
            this.bntRandom.ForeColor = System.Drawing.SystemColors.Window;
            this.bntRandom.Image = ((System.Drawing.Image)(resources.GetObject("bntRandom.Image")));
            this.bntRandom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntRandom.Location = new System.Drawing.Point(4, 92);
            this.bntRandom.Margin = new System.Windows.Forms.Padding(2);
            this.bntRandom.Name = "bntRandom";
            this.bntRandom.Size = new System.Drawing.Size(107, 39);
            this.bntRandom.TabIndex = 1;
            this.bntRandom.Text = "Random";
            this.bntRandom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntRandom.UseVisualStyleBackColor = false;
            this.bntRandom.Click += new System.EventHandler(this.bntRandom_Click);
            // 
            // grpInitial
            // 
            this.grpInitial.Controls.Add(this.bntReset);
            this.grpInitial.Controls.Add(this.bntCreate);
            this.grpInitial.Controls.Add(this.numArray);
            this.grpInitial.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInitial.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grpInitial.Location = new System.Drawing.Point(9, 2);
            this.grpInitial.Margin = new System.Windows.Forms.Padding(2);
            this.grpInitial.Name = "grpInitial";
            this.grpInitial.Padding = new System.Windows.Forms.Padding(2);
            this.grpInitial.Size = new System.Drawing.Size(215, 145);
            this.grpInitial.TabIndex = 0;
            this.grpInitial.TabStop = false;
            this.grpInitial.Text = "Initial";
            // 
            // bntReset
            // 
            this.bntReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(115)))), ((int)(((byte)(134)))));
            this.bntReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Italic);
            this.bntReset.ForeColor = System.Drawing.SystemColors.Window;
            this.bntReset.Image = ((System.Drawing.Image)(resources.GetObject("bntReset.Image")));
            this.bntReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntReset.Location = new System.Drawing.Point(114, 92);
            this.bntReset.Margin = new System.Windows.Forms.Padding(2);
            this.bntReset.Name = "bntReset";
            this.bntReset.Size = new System.Drawing.Size(87, 39);
            this.bntReset.TabIndex = 1;
            this.bntReset.Text = "Reset";
            this.bntReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntReset.UseVisualStyleBackColor = false;
            this.bntReset.Click += new System.EventHandler(this.bntReset_Click);
            // 
            // bntCreate
            // 
            this.bntCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(115)))), ((int)(((byte)(134)))));
            this.bntCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Italic);
            this.bntCreate.ForeColor = System.Drawing.SystemColors.Window;
            this.bntCreate.Image = ((System.Drawing.Image)(resources.GetObject("bntCreate.Image")));
            this.bntCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntCreate.Location = new System.Drawing.Point(14, 92);
            this.bntCreate.Margin = new System.Windows.Forms.Padding(2);
            this.bntCreate.Name = "bntCreate";
            this.bntCreate.Size = new System.Drawing.Size(87, 39);
            this.bntCreate.TabIndex = 1;
            this.bntCreate.Text = "Create";
            this.bntCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntCreate.UseVisualStyleBackColor = false;
            this.bntCreate.Click += new System.EventHandler(this.bntCreate_Click);
            // 
            // numArray
            // 
            this.numArray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numArray.Location = new System.Drawing.Point(47, 43);
            this.numArray.Margin = new System.Windows.Forms.Padding(2);
            this.numArray.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numArray.Name = "numArray";
            this.numArray.Size = new System.Drawing.Size(120, 26);
            this.numArray.TabIndex = 0;
            this.numArray.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numArray.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numArray.ValueChanged += new System.EventHandler(this.numArray_ValueChanged);
            // 
            // grpDebug
            // 
            this.grpDebug.Controls.Add(this.bntDebug);
            this.grpDebug.Controls.Add(this.ckDebug);
            this.grpDebug.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDebug.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grpDebug.Location = new System.Drawing.Point(396, 2);
            this.grpDebug.Margin = new System.Windows.Forms.Padding(2);
            this.grpDebug.Name = "grpDebug";
            this.grpDebug.Padding = new System.Windows.Forms.Padding(2);
            this.grpDebug.Size = new System.Drawing.Size(149, 145);
            this.grpDebug.TabIndex = 3;
            this.grpDebug.TabStop = false;
            this.grpDebug.Text = "Debug";
            // 
            // bntDebug
            // 
            this.bntDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(115)))), ((int)(((byte)(134)))));
            this.bntDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Italic);
            this.bntDebug.ForeColor = System.Drawing.SystemColors.Window;
            this.bntDebug.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntDebug.Location = new System.Drawing.Point(30, 92);
            this.bntDebug.Margin = new System.Windows.Forms.Padding(2);
            this.bntDebug.Name = "bntDebug";
            this.bntDebug.Size = new System.Drawing.Size(92, 39);
            this.bntDebug.TabIndex = 4;
            this.bntDebug.Text = "Debug";
            this.bntDebug.UseVisualStyleBackColor = false;
            this.bntDebug.Click += new System.EventHandler(this.bntDebug_Click);
            // 
            // ckDebug
            // 
            this.ckDebug.AutoSize = true;
            this.ckDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ckDebug.Location = new System.Drawing.Point(14, 48);
            this.ckDebug.Name = "ckDebug";
            this.ckDebug.Size = new System.Drawing.Size(116, 22);
            this.ckDebug.TabIndex = 3;
            this.ckDebug.Text = "Run each line";
            this.ckDebug.UseVisualStyleBackColor = true;
            this.ckDebug.CheckedChanged += new System.EventHandler(this.ckDebug_CheckedChanged);
            // 
            // pnlLoaiThuatToan
            // 
            this.pnlLoaiThuatToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.pnlLoaiThuatToan.Controls.Add(this.radSelection);
            this.pnlLoaiThuatToan.Controls.Add(this.radInsertion);
            this.pnlLoaiThuatToan.Controls.Add(this.radShell);
            this.pnlLoaiThuatToan.Controls.Add(this.radHeap);
            this.pnlLoaiThuatToan.Controls.Add(this.radInterchange);
            this.pnlLoaiThuatToan.Controls.Add(this.radMerge);
            this.pnlLoaiThuatToan.Controls.Add(this.radBubble);
            this.pnlLoaiThuatToan.Controls.Add(this.radQuick);
            this.pnlLoaiThuatToan.Location = new System.Drawing.Point(806, 439);
            this.pnlLoaiThuatToan.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLoaiThuatToan.Name = "pnlLoaiThuatToan";
            this.pnlLoaiThuatToan.Size = new System.Drawing.Size(353, 147);
            this.pnlLoaiThuatToan.TabIndex = 4;
            // 
            // radSelection
            // 
            this.radSelection.AutoSize = true;
            this.radSelection.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSelection.ForeColor = System.Drawing.Color.AliceBlue;
            this.radSelection.Location = new System.Drawing.Point(206, 110);
            this.radSelection.Margin = new System.Windows.Forms.Padding(2);
            this.radSelection.Name = "radSelection";
            this.radSelection.Size = new System.Drawing.Size(148, 28);
            this.radSelection.TabIndex = 0;
            this.radSelection.Text = "Selection Sort";
            this.radSelection.UseVisualStyleBackColor = true;
            this.radSelection.CheckedChanged += new System.EventHandler(this.radSelection_CheckedChanged);
            // 
            // radInsertion
            // 
            this.radInsertion.AutoSize = true;
            this.radInsertion.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInsertion.ForeColor = System.Drawing.Color.AliceBlue;
            this.radInsertion.Location = new System.Drawing.Point(206, 78);
            this.radInsertion.Margin = new System.Windows.Forms.Padding(2);
            this.radInsertion.Name = "radInsertion";
            this.radInsertion.Size = new System.Drawing.Size(148, 28);
            this.radInsertion.TabIndex = 0;
            this.radInsertion.Text = "Insertion Sort";
            this.radInsertion.UseVisualStyleBackColor = true;
            this.radInsertion.CheckedChanged += new System.EventHandler(this.radInsertion_CheckedChanged);
            // 
            // radShell
            // 
            this.radShell.AutoSize = true;
            this.radShell.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radShell.ForeColor = System.Drawing.Color.AliceBlue;
            this.radShell.Location = new System.Drawing.Point(206, 45);
            this.radShell.Margin = new System.Windows.Forms.Padding(2);
            this.radShell.Name = "radShell";
            this.radShell.Size = new System.Drawing.Size(114, 28);
            this.radShell.TabIndex = 0;
            this.radShell.Text = "Shell Sort";
            this.radShell.UseVisualStyleBackColor = true;
            this.radShell.CheckedChanged += new System.EventHandler(this.radShell_CheckedChanged);
            // 
            // radHeap
            // 
            this.radHeap.AutoSize = true;
            this.radHeap.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHeap.ForeColor = System.Drawing.Color.AliceBlue;
            this.radHeap.Location = new System.Drawing.Point(206, 11);
            this.radHeap.Margin = new System.Windows.Forms.Padding(2);
            this.radHeap.Name = "radHeap";
            this.radHeap.Size = new System.Drawing.Size(116, 28);
            this.radHeap.TabIndex = 0;
            this.radHeap.Text = "Heap Sort";
            this.radHeap.UseVisualStyleBackColor = true;
            this.radHeap.CheckedChanged += new System.EventHandler(this.radHeap_CheckedChanged);
            // 
            // radInterchange
            // 
            this.radInterchange.AutoSize = true;
            this.radInterchange.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInterchange.ForeColor = System.Drawing.Color.AliceBlue;
            this.radInterchange.Location = new System.Drawing.Point(14, 110);
            this.radInterchange.Margin = new System.Windows.Forms.Padding(2);
            this.radInterchange.Name = "radInterchange";
            this.radInterchange.Size = new System.Drawing.Size(176, 28);
            this.radInterchange.TabIndex = 0;
            this.radInterchange.Text = "Interchange Sort";
            this.radInterchange.UseVisualStyleBackColor = true;
            this.radInterchange.CheckedChanged += new System.EventHandler(this.radInterchange_CheckedChanged);
            // 
            // radMerge
            // 
            this.radMerge.AutoSize = true;
            this.radMerge.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMerge.ForeColor = System.Drawing.Color.AliceBlue;
            this.radMerge.Location = new System.Drawing.Point(14, 78);
            this.radMerge.Margin = new System.Windows.Forms.Padding(2);
            this.radMerge.Name = "radMerge";
            this.radMerge.Size = new System.Drawing.Size(125, 28);
            this.radMerge.TabIndex = 0;
            this.radMerge.Text = "Merge Sort";
            this.radMerge.UseVisualStyleBackColor = true;
            this.radMerge.CheckedChanged += new System.EventHandler(this.radMerge_CheckedChanged);
            // 
            // radBubble
            // 
            this.radBubble.AutoSize = true;
            this.radBubble.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBubble.ForeColor = System.Drawing.Color.AliceBlue;
            this.radBubble.Location = new System.Drawing.Point(14, 45);
            this.radBubble.Margin = new System.Windows.Forms.Padding(2);
            this.radBubble.Name = "radBubble";
            this.radBubble.Size = new System.Drawing.Size(132, 28);
            this.radBubble.TabIndex = 0;
            this.radBubble.Text = "Bubble Sort";
            this.radBubble.UseVisualStyleBackColor = true;
            this.radBubble.CheckedChanged += new System.EventHandler(this.radBubble_CheckedChanged);
            // 
            // radQuick
            // 
            this.radQuick.AutoSize = true;
            this.radQuick.Checked = true;
            this.radQuick.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radQuick.ForeColor = System.Drawing.Color.AliceBlue;
            this.radQuick.Location = new System.Drawing.Point(14, 11);
            this.radQuick.Margin = new System.Windows.Forms.Padding(2);
            this.radQuick.Name = "radQuick";
            this.radQuick.Size = new System.Drawing.Size(122, 28);
            this.radQuick.TabIndex = 0;
            this.radQuick.TabStop = true;
            this.radQuick.Text = "Quick Sort";
            this.radQuick.UseVisualStyleBackColor = true;
            this.radQuick.CheckedChanged += new System.EventHandler(this.radQuick_CheckedChanged);
            // 
            // ExTime
            // 
            this.ExTime.Interval = 1000;
            this.ExTime.Tick += new System.EventHandler(this.ExTime_Tick);
            // 
            // frmApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1159, 586);
            this.Controls.Add(this.pnlLoaiThuatToan);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlChayMau);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmApplication";
            this.Load += new System.EventHandler(this.frmApplication_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlExTime.ResumeLayout(false);
            this.pnlExTime.PerformLayout();
            this.pnlChayMau.ResumeLayout(false);
            this.pnlChayMau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grpControl.ResumeLayout(false);
            this.grpCreateArray.ResumeLayout(false);
            this.grpInitial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numArray)).EndInit();
            this.grpDebug.ResumeLayout(false);
            this.grpDebug.PerformLayout();
            this.pnlLoaiThuatToan.ResumeLayout(false);
            this.pnlLoaiThuatToan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bntExit;
        private System.Windows.Forms.Button bntBack;
        private System.Windows.Forms.Panel pnlChayMau;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bntIdeaAlgorithm;
        private System.Windows.Forms.Button bntSourceCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grpCreateArray;
        private System.Windows.Forms.RadioButton radDecrease;
        private System.Windows.Forms.RadioButton radIncrease;
        private System.Windows.Forms.Button bntByHand;
        private System.Windows.Forms.Button bntRandom;
        private System.Windows.Forms.GroupBox grpInitial;
        private System.Windows.Forms.Button bntReset;
        private System.Windows.Forms.Button bntCreate;
        private System.Windows.Forms.NumericUpDown numArray;
        private System.Windows.Forms.Panel pnlLoaiThuatToan;
        private System.Windows.Forms.RadioButton radSelection;
        private System.Windows.Forms.RadioButton radInsertion;
        private System.Windows.Forms.RadioButton radShell;
        private System.Windows.Forms.RadioButton radHeap;
        private System.Windows.Forms.RadioButton radInterchange;
        private System.Windows.Forms.RadioButton radMerge;
        private System.Windows.Forms.RadioButton radBubble;
        private System.Windows.Forms.RadioButton radQuick;
        private System.Windows.Forms.ListBox listIdea;
        private System.Windows.Forms.GroupBox grpDebug;
        private System.Windows.Forms.CheckBox ckDebug;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntDebug;
        private System.Windows.Forms.Panel pnlExTime;
        private System.Windows.Forms.ListBox listCode;
        private System.Windows.Forms.Label lbl_status_02;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label Mui_ten_do_len;
        private System.Windows.Forms.Label Mui_ten_xanh_len_2;
        private System.Windows.Forms.Label Mui_ten_xanh_len_1;
        private System.Windows.Forms.Label Mui_ten_xanh_xuong_2;
        private System.Windows.Forms.Label Mui_ten_xanh_xuong_1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button bntPlay;
        private System.Windows.Forms.Button bntPause;
        private System.Windows.Forms.Timer ExTime;
    }
}