namespace SortingAlgorithmsGUI
{
    partial class frmIntroduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntroduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bntMinimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.lbApplication = new System.Windows.Forms.Label();
            this.lbSortingAlgorithms = new System.Windows.Forms.Label();
            this.bntExcecutors = new System.Windows.Forms.Button();
            this.bntApplication = new System.Windows.Forms.Button();
            this.elipApplication = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.elipIntroduct = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.bunifuImageButton1);
            this.panel1.Controls.Add(this.bntMinimize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 38);
            this.panel1.TabIndex = 0;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(621, 9);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(20, 18);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton1.TabIndex = 0;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bntMinimize
            // 
            this.bntMinimize.BackColor = System.Drawing.Color.Transparent;
            this.bntMinimize.Image = ((System.Drawing.Image)(resources.GetObject("bntMinimize.Image")));
            this.bntMinimize.ImageActive = null;
            this.bntMinimize.Location = new System.Drawing.Point(600, 9);
            this.bntMinimize.Name = "bntMinimize";
            this.bntMinimize.Size = new System.Drawing.Size(20, 18);
            this.bntMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bntMinimize.TabIndex = 0;
            this.bntMinimize.TabStop = false;
            this.bntMinimize.Zoom = 10;
            this.bntMinimize.Click += new System.EventHandler(this.bntMinimize_Click);
            // 
            // lbApplication
            // 
            this.lbApplication.AutoSize = true;
            this.lbApplication.Font = new System.Drawing.Font("Candara", 38.25F);
            this.lbApplication.ForeColor = System.Drawing.Color.White;
            this.lbApplication.Location = new System.Drawing.Point(75, 85);
            this.lbApplication.Name = "lbApplication";
            this.lbApplication.Size = new System.Drawing.Size(341, 78);
            this.lbApplication.TabIndex = 1;
            this.lbApplication.Text = "Application";
            // 
            // lbSortingAlgorithms
            // 
            this.lbSortingAlgorithms.AutoSize = true;
            this.lbSortingAlgorithms.Font = new System.Drawing.Font("Candara", 24F);
            this.lbSortingAlgorithms.ForeColor = System.Drawing.Color.White;
            this.lbSortingAlgorithms.Location = new System.Drawing.Point(209, 150);
            this.lbSortingAlgorithms.Name = "lbSortingAlgorithms";
            this.lbSortingAlgorithms.Size = new System.Drawing.Size(341, 49);
            this.lbSortingAlgorithms.TabIndex = 2;
            this.lbSortingAlgorithms.Text = "Sorting Algorithms";
            // 
            // bntExcecutors
            // 
            this.bntExcecutors.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bntExcecutors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.bntExcecutors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.bntExcecutors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntExcecutors.Font = new System.Drawing.Font("Perpetua", 12F);
            this.bntExcecutors.ForeColor = System.Drawing.Color.White;
            this.bntExcecutors.Image = ((System.Drawing.Image)(resources.GetObject("bntExcecutors.Image")));
            this.bntExcecutors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntExcecutors.Location = new System.Drawing.Point(155, 265);
            this.bntExcecutors.Name = "bntExcecutors";
            this.bntExcecutors.Size = new System.Drawing.Size(151, 39);
            this.bntExcecutors.TabIndex = 3;
            this.bntExcecutors.Text = "Excecutors";
            this.bntExcecutors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntExcecutors.UseVisualStyleBackColor = true;
            this.bntExcecutors.Click += new System.EventHandler(this.bntExcecutors_Click);
            // 
            // bntApplication
            // 
            this.bntApplication.BackColor = System.Drawing.Color.Tomato;
            this.bntApplication.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bntApplication.FlatAppearance.BorderSize = 0;
            this.bntApplication.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.bntApplication.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.bntApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntApplication.Font = new System.Drawing.Font("Perpetua", 12F);
            this.bntApplication.ForeColor = System.Drawing.Color.White;
            this.bntApplication.Image = ((System.Drawing.Image)(resources.GetObject("bntApplication.Image")));
            this.bntApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntApplication.Location = new System.Drawing.Point(351, 265);
            this.bntApplication.Name = "bntApplication";
            this.bntApplication.Size = new System.Drawing.Size(151, 39);
            this.bntApplication.TabIndex = 3;
            this.bntApplication.Text = "Application";
            this.bntApplication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntApplication.UseVisualStyleBackColor = false;
            this.bntApplication.Click += new System.EventHandler(this.bntApplication_Click);
            // 
            // elipApplication
            // 
            this.elipApplication.ElipseRadius = 2;
            this.elipApplication.TargetControl = this.bntApplication;
            // 
            // elipIntroduct
            // 
            this.elipIntroduct.ElipseRadius = 7;
            this.elipIntroduct.TargetControl = this;
            // 
            // frmIntroduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(649, 334);
            this.Controls.Add(this.bntApplication);
            this.Controls.Add(this.bntExcecutors);
            this.Controls.Add(this.lbSortingAlgorithms);
            this.Controls.Add(this.lbApplication);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIntroduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sorting Algorithms";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbApplication;
        private System.Windows.Forms.Label lbSortingAlgorithms;
        private System.Windows.Forms.Button bntExcecutors;
        private System.Windows.Forms.Button bntApplication;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton bntMinimize;
        private Bunifu.Framework.UI.BunifuElipse elipApplication;
        private Bunifu.Framework.UI.BunifuElipse elipIntroduct;
    }
}

