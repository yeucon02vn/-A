namespace SortingAlgorithmsGUI
{
    partial class frmExcecutors
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
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcecutors));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bntStudents = new System.Windows.Forms.Button();
            this.bntLecturers = new System.Windows.Forms.Button();
            this.bntHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bntBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tranHome = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.tranLecturers = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.tranStudents = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.userLecturers1 = new ApplicationsGUI.userLecturers();
            this.userStudents1 = new ApplicationsGUI.userStudents();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.bntStudents);
            this.panel1.Controls.Add(this.bntLecturers);
            this.panel1.Controls.Add(this.bntHome);
            this.tranHome.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.tranStudents.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 395);
            this.panel1.TabIndex = 0;
            // 
            // bntStudents
            // 
            this.tranStudents.SetDecoration(this.bntStudents, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.bntStudents, BunifuAnimatorNS.DecorationType.None);
            this.tranHome.SetDecoration(this.bntStudents, BunifuAnimatorNS.DecorationType.None);
            this.bntStudents.FlatAppearance.BorderSize = 0;
            this.bntStudents.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.bntStudents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.bntStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntStudents.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.bntStudents.ForeColor = System.Drawing.SystemColors.Control;
            this.bntStudents.Image = ((System.Drawing.Image)(resources.GetObject("bntStudents.Image")));
            this.bntStudents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntStudents.Location = new System.Drawing.Point(0, 204);
            this.bntStudents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntStudents.Name = "bntStudents";
            this.bntStudents.Size = new System.Drawing.Size(177, 59);
            this.bntStudents.TabIndex = 0;
            this.bntStudents.Text = "     Students";
            this.bntStudents.UseVisualStyleBackColor = true;
            this.bntStudents.Click += new System.EventHandler(this.bntStudent_Click);
            // 
            // bntLecturers
            // 
            this.tranStudents.SetDecoration(this.bntLecturers, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.bntLecturers, BunifuAnimatorNS.DecorationType.None);
            this.tranHome.SetDecoration(this.bntLecturers, BunifuAnimatorNS.DecorationType.None);
            this.bntLecturers.FlatAppearance.BorderSize = 0;
            this.bntLecturers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.bntLecturers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.bntLecturers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntLecturers.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.bntLecturers.ForeColor = System.Drawing.SystemColors.Control;
            this.bntLecturers.Image = ((System.Drawing.Image)(resources.GetObject("bntLecturers.Image")));
            this.bntLecturers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntLecturers.Location = new System.Drawing.Point(0, 145);
            this.bntLecturers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntLecturers.Name = "bntLecturers";
            this.bntLecturers.Size = new System.Drawing.Size(177, 59);
            this.bntLecturers.TabIndex = 0;
            this.bntLecturers.Text = "     Lecturers";
            this.bntLecturers.UseVisualStyleBackColor = true;
            this.bntLecturers.Click += new System.EventHandler(this.bntLecturers_Click);
            // 
            // bntHome
            // 
            this.tranStudents.SetDecoration(this.bntHome, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.bntHome, BunifuAnimatorNS.DecorationType.None);
            this.tranHome.SetDecoration(this.bntHome, BunifuAnimatorNS.DecorationType.None);
            this.bntHome.FlatAppearance.BorderSize = 0;
            this.bntHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.bntHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.bntHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntHome.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.bntHome.ForeColor = System.Drawing.SystemColors.Control;
            this.bntHome.Image = ((System.Drawing.Image)(resources.GetObject("bntHome.Image")));
            this.bntHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntHome.Location = new System.Drawing.Point(0, 86);
            this.bntHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntHome.Name = "bntHome";
            this.bntHome.Size = new System.Drawing.Size(177, 59);
            this.bntHome.TabIndex = 0;
            this.bntHome.Text = "Home";
            this.bntHome.UseVisualStyleBackColor = true;
            this.bntHome.Click += new System.EventHandler(this.bntHome_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(138)))), ((int)(((byte)(7)))));
            this.panel2.Controls.Add(this.bntBack);
            this.tranHome.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.tranStudents.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(176, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 36);
            this.panel2.TabIndex = 0;
            // 
            // bntBack
            // 
            this.tranStudents.SetDecoration(this.bntBack, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.bntBack, BunifuAnimatorNS.DecorationType.None);
            this.tranHome.SetDecoration(this.bntBack, BunifuAnimatorNS.DecorationType.None);
            this.bntBack.FlatAppearance.BorderSize = 0;
            this.bntBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntBack.Image = ((System.Drawing.Image)(resources.GetObject("bntBack.Image")));
            this.bntBack.Location = new System.Drawing.Point(329, 0);
            this.bntBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntBack.Name = "bntBack";
            this.bntBack.Size = new System.Drawing.Size(49, 36);
            this.bntBack.TabIndex = 0;
            this.bntBack.UseVisualStyleBackColor = true;
            this.bntBack.Click += new System.EventHandler(this.bntBack_Click);
            // 
            // pictureBox1
            // 
            this.tranStudents.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.tranHome.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(177, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(378, 359);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tranHome
            // 
            this.tranHome.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.tranHome.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.tranHome.DefaultAnimation = animation3;
            // 
            // tranLecturers
            // 
            this.tranLecturers.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.tranLecturers.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.tranLecturers.DefaultAnimation = animation2;
            // 
            // tranStudents
            // 
            this.tranStudents.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic;
            this.tranStudents.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 20;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.tranStudents.DefaultAnimation = animation1;
            // 
            // userLecturers1
            // 
            this.userLecturers1.BackColor = System.Drawing.Color.White;
            this.tranStudents.SetDecoration(this.userLecturers1, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.userLecturers1, BunifuAnimatorNS.DecorationType.None);
            this.tranHome.SetDecoration(this.userLecturers1, BunifuAnimatorNS.DecorationType.None);
            this.userLecturers1.Location = new System.Drawing.Point(177, 36);
            this.userLecturers1.Name = "userLecturers1";
            this.userLecturers1.Size = new System.Drawing.Size(378, 359);
            this.userLecturers1.TabIndex = 2;
            // 
            // userStudents1
            // 
            this.userStudents1.BackColor = System.Drawing.Color.White;
            this.tranStudents.SetDecoration(this.userStudents1, BunifuAnimatorNS.DecorationType.None);
            this.tranLecturers.SetDecoration(this.userStudents1, BunifuAnimatorNS.DecorationType.None);
            this.tranHome.SetDecoration(this.userStudents1, BunifuAnimatorNS.DecorationType.None);
            this.userStudents1.Location = new System.Drawing.Point(177, 36);
            this.userStudents1.Name = "userStudents1";
            this.userStudents1.Size = new System.Drawing.Size(378, 359);
            this.userStudents1.TabIndex = 1;
            // 
            // frmExcecutors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 395);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userLecturers1);
            this.Controls.Add(this.userStudents1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.tranLecturers.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.tranHome.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.tranStudents.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmExcecutors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExcecutors";    
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bntStudents;
        private System.Windows.Forms.Button bntLecturers;
        private System.Windows.Forms.Button bntHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bntBack;
        private ApplicationsGUI.userStudents userStudents1;
        private ApplicationsGUI.userLecturers userLecturers1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BunifuAnimatorNS.BunifuTransition tranStudents;
        private BunifuAnimatorNS.BunifuTransition tranLecturers;
        private BunifuAnimatorNS.BunifuTransition tranHome;
    }
}