using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingAlgorithmsGUI
{
    public partial class frmIntroduct : Form
    {
        public frmIntroduct()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bntApplication_Click(object sender, EventArgs e)
        {
            frmApplication app = new frmApplication();
            app.ShowDialog();
            this.Hide();
        }

        private void bntExcecutors_Click(object sender, EventArgs e)
        {
            frmExcecutors ex = new frmExcecutors();
            ex.ShowDialog();
            this.Hide();
            this.Show();
        }

        private void frmIntroduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bntApplication.PerformClick();
            }
            else if (e.KeyCode == Keys.Left)
            {
                bntExcecutors.PerformClick();
            }
        }
    }
}
