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
    public partial class frmExcecutors : Form
    {
        public frmExcecutors()
        {
            InitializeComponent();
        }

        private void bntBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            tranStudents.HideSync(userStudents1);
            tranLecturers.HideSync(userLecturers1);
            tranHome.ShowSync(pictureBox1);
        }

        private void bntLecturers_Click(object sender, EventArgs e)
        {
            tranStudents.HideSync(userStudents1);
            tranHome.HideSync(pictureBox1);
            tranLecturers.ShowSync(userLecturers1);
        }

        private void bntStudent_Click(object sender, EventArgs e)
        {
            tranHome.HideSync(pictureBox1);
            tranLecturers.HideSync(userLecturers1);
            tranStudents.ShowSync(userStudents1);
        }
    }
}
