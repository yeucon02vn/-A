using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using _Code;
using _Idea;
using _Parameters;

namespace SortingAlgorithmsGUI
{
    public partial class frmApplication : Form
    {
        #region Public Variables
        public static string PT1 = string.Empty;
        public static string PT2 = string.Empty;
        public static string PT3 = string.Empty;
        public static string PT4 = string.Empty;
        public static string PT5 = string.Empty;
        public static string PT6 = string.Empty;
        public static string PT7 = string.Empty;
        public static string PT8 = string.Empty;
        public static string PT9 = string.Empty;
        public static string PT10 = string.Empty;
        #endregion

        #region Variables
        Parameters thamSo = new Parameters();

        Color colorMove = Color.FromArgb(9, 132, 227);
        Color colorComplete = Color.FromArgb(232, 67, 147);
        Color colorDefault = Color.FromArgb(253, 203, 110);
        Color colorMergeU = Color.AliceBlue;
        Color colorMergeD = Color.FromArgb(214, 48, 49);
        #endregion

        #region Initialize
        public frmApplication()
        {
            InitializeComponent();
        }
        #endregion        

        #region Load
        private void frmApplication_Load(object sender, EventArgs e)
        {
            thamSo.nOe = (int)numArray.Value;
            Init();
            thamSo.speed = 60;
            speedTrackBar.Maximum = thamSo.speed;
            speedTrackBar.Minimum = 0;
            speedTrackBar.Value = thamSo.speed / 2;
            speedTrackBar.LargeChange = 1;
            AddPanel();
        }

        public void Init()
        {
            grpCreateArray.Enabled = false;
            pnlChosesAlgorithms.Enabled = false;
            grpControl.Enabled = false;
            grpDebug.Enabled = false;
            thamSo.increase = true;
            bntReset.Enabled = false;
            listIdea.Hide();
        }

        #endregion

        #region Complete Swap
        public void CompleteSwap()
        {
            thamSo.nOe = (int)numArray.Value;
            for (int i = 0; i < thamSo.nOe; i++)
                thamSo.arrLbl[i].BackColor = Color.Aqua;
            Complete();
        }
        #endregion          

        #region numArray_ValueChanged
        private void numArray_ValueChanged(object sender, EventArgs e)
        {
            thamSo.nOe = int.Parse(numArray.Value.ToString());
        }
        #endregion

        #region Hàm phân phối a cho b và c
        #region functions moving
        public void Node_Right(Control t, int Step)
        {
            Application.DoEvents();

            this.Invoke((MethodInvoker)delegate
            {
                int Loop_Count = ((thamSo.sizeN + thamSo.disN)) * Step;//Số lần dịch chuyển
                {
                    while (Loop_Count > 0)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Delay(thamSo.speed);
                        Loop_Count--;
                        t.BackColor = colorDefault;
                    }
                }
                t.Refresh();
            });
        }
        // t dịch chuyển sang trai Step Node
        public void Node_Left(Control t, int Step)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int Loop_Count = ((thamSo.sizeN + thamSo.disN)) * Step; //Số lần dịch chuyển
                while (Loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Left -= 1;
                    Delay(thamSo.speed);
                    Loop_Count--;
                    t.BackColor = colorMove;
                }
                t.Refresh();
            });
        }
        // t dịch chuyển lên với quãng đường S
        public void Node_Up(Control t, int S)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int loop_Count = S;
                //t xuống
                while (loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Top -= 1;
                    Delay(thamSo.speed);
                    loop_Count--;
                    t.BackColor = colorMove;
                }
                t.Refresh();
            });
        }
        // t dịch chuyển xuống với quãng đường S
        public void Node_Down(Control t, int S)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int loop_Count = S;
                // t lên
                while (loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Top += 1;
                    Delay(thamSo.speed);
                    loop_Count--;
                    t.BackColor = colorMove;
                }
                t.Refresh();
            });
        }
        public void toLocaN(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i, 150);//vị trí của Node i
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                t.BackColor = colorMove;
                // Di chuyển nút lên hoặc xuống nữa đường
                if (p1.Y < p2.Y)
                {
                    while (t.Location.Y < p2.Y - ((p2.Y - p1.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top += 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y + ((p1.Y - p2.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                // Di chuyển nút qua phải hoặc trái
                if (p1.X < p2.X)
                {
                    while (t.Location.X < p2.X)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                // Tiếp tục di chuyển nút lên hoặc xuống nữa đường còn lại
                if (p1.Y < p2.Y)
                {
                    while (t.Location.Y < p2.Y)
                    {
                        Application.DoEvents();
                        t.Top += 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y)
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
            });
        }
        // Dịch chuyển 1 Node về vị trí bằng với X của Node[i]
        public void Den_tdo_x_node(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i, 150);//vị trí của Node i
            Application.DoEvents();
            t.BackColor = colorMove;
            this.Invoke((MethodInvoker)delegate
            {
                // Di chuyển nút qua phải hoặc trái
                if (p1.X < p2.X)
                {
                    while (t.Location.X < p2.X)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }

            });
        }
        #endregion
        #region functions conversion
        public void Swap_NodeAn(int a, int b)
        {
            Label temp = thamSo.arrLbl[a];
            thamSo.arrLbl[a] = thamSo.arrLbl[b];
            thamSo.arrLbl[b] = temp;
        }
        public void Swap_Node(Control t1, Control t2)
        {
            Application.DoEvents();
            t1.BackColor = colorMove;
            t2.BackColor = colorMove;
            this.Invoke((MethodInvoker)delegate
            {
                Point p1 = t1.Location; //lưu vị trí ban đầu của t1
                Point p2 = t2.Location; //lưu vị trí ban đầu của t2
                if (p1 != p2)
                {
                    // t1 lên, t2 xuống
                    while ((t1.Location.Y > p1.Y - (thamSo.sizeN + 5)) || (t2.Location.Y < p2.Y + (thamSo.sizeN + 5)))
                    {
                        Application.DoEvents();
                        t1.Top -= 1;
                        t2.Top += 1;
                        Thread.Sleep(thamSo.speed);
                    }
                    // t1 dịch phải, t2 dịch trái
                    if (t1.Location.X < t2.Location.X)
                    {
                        while ((t1.Location.X < p2.X) || (t2.Location.X > p1.X))
                        {
                            Application.DoEvents();
                            t1.Left += 1;
                            t2.Left -= 1;
                            Thread.Sleep(thamSo.speed);
                        }
                    }
                    // t1 dịch trái, t2 dịch phải
                    else
                    {
                        while ((t1.Location.X > p2.X) || (t2.Location.X < p1.X))
                        {
                            Application.DoEvents();
                            t1.Left -= 1;
                            t2.Left += 1;
                            Thread.Sleep(thamSo.speed);
                        }
                    }
                    // t1 xuống, t2 lên
                    while ((t1.Location.Y < p2.Y) || (t2.Location.Y > p1.Y))
                    {
                        Application.DoEvents();
                        t1.Top += 1;
                        t2.Top -= 1;
                        Thread.Sleep(thamSo.speed);
                    }
                    t1.Refresh();
                    t2.Refresh();
                }
            });

        }

        public void Swap_Giatri(ref int i, ref int j)
        {
            int Temp = i;
            i = j;
            j = Temp;
        }
        #endregion
        #region Handing alignment
        private void Alignment()
        {
            listIdea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            listIdea.MeasureItem += lst_MeasureItem;
            listIdea.DrawItem += lst_DrawItem;
        }
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listIdea.Items[e.Index].ToString(), listIdea.Font, listIdea.Width).Height;
        }
        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(listIdea.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }
        #endregion
        #endregion

        #region Sort Algorithms
        #region interchange

        private void InterchangeSortincrease(int[] arrNode)
        {

            ShowCodeListBox(2);
            int i = 0, j = 0;
            Mui_ten_xanh_len_1.Text = "i = " + i;
            Mui_ten_xanh_len_1.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i, pnlExcution.Height - 50);
            Mui_ten_xanh_len_1.Visible = true;
            Refresh();
            for (i = 0; i < thamSo.nOe - 1; i++)
            {
                ShowCodeListBox(3);
                j = i + 1;
                Mui_ten_xanh_len_2.Text = "j = " + j;
                Mui_ten_xanh_len_2.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j, pnlExcution.Height - 50);
                Mui_ten_xanh_len_2.Visible = true;
                Refresh();
                for (j = i + 1; j < thamSo.nOe; j++)
                {
                    ShowCodeListBox(4);
                    lbl_status_02.Text = "Compare(a[" + i + "],a[" + j + "])";
                    lbl_status_02.Visible = true;
                    if (thamSo.arrNode[j] < thamSo.arrNode[i])
                    {
                        ShowCodeListBox(6);
                        lbl_status_02.Text = "Swap(a[" + i + "],a[" + j + "])";
                        Swap_Giatri(ref thamSo.arrNode[j], ref thamSo.arrNode[i]);
                        Swap_Node(thamSo.arrLbl[j], thamSo.arrLbl[i]);
                        Swap_NodeAn(j, i);
                        thamSo.arrLbl[i].BackColor = colorComplete;
                    }
                    if (j + 1 < thamSo.nOe)
                    {
                        Mui_ten_xanh_len_2.Text = "j = " + (j + 1);
                        Mui_ten_xanh_len_2.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * (j + 1), pnlExcution.Height - 50);
                        Refresh();
                    }
                    thamSo.arrLbl[i].BackColor = colorDefault;
                }
                ShowCodeListBox(3);
                lbl_status_02.Visible = false;
                Mui_ten_xanh_len_1.Text = "i = " + (i + 1);
                Mui_ten_xanh_len_1.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * (i + 1), pnlExcution.Height - 50);
                Refresh();
            }
            ShowCodeListBox(0);
        }

        private void InterchangeSortGiam(int[] arrNode)
        {
            ShowCodeListBox(2);
            int i = 0, j = 0;
            Mui_ten_xanh_len_1.Text = "i = " + i;
            Mui_ten_xanh_len_1.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i, pnlExcution.Height - 50);
            Mui_ten_xanh_len_1.Visible = true;
            for (i = 0; i < thamSo.nOe - 1; i++)
            {
                ShowCodeListBox(3);
                j = i + 1;
                Mui_ten_xanh_len_2.Text = "j = " + j;
                Mui_ten_xanh_len_2.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j, pnlExcution.Height - 50);
                Mui_ten_xanh_len_2.Visible = true;
                for (j = i + 1; j < thamSo.nOe; j++)
                {
                    ShowCodeListBox(4);
                    lbl_status_02.Text = "Compare(a[" + i + "],a[" + j + "])";
                    lbl_status_02.Visible = true;
                    if (thamSo.arrNode[j] > thamSo.arrNode[i])
                    {
                        ShowCodeListBox(6);
                        lbl_status_02.Text = "Swap(a[" + i + "],a[" + j + "])";
                        Swap_Giatri(ref thamSo.arrNode[i], ref thamSo.arrNode[j]);
                        Swap_Node(thamSo.arrLbl[j], thamSo.arrLbl[i]);
                        Swap_NodeAn(j, i);
                        thamSo.arrLbl[i].BackColor = colorComplete;
                    }
                    if (j + 1 < thamSo.nOe)
                    {
                        Mui_ten_xanh_len_2.Text = "j = " + (j + 1);
                        Mui_ten_xanh_len_2.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * (j + 1), pnlExcution.Height - 50);
                        Refresh();
                    }
                    thamSo.arrLbl[i].BackColor = colorDefault;
                }
                ShowCodeListBox(3);
                lbl_status_02.Visible = false;
                Mui_ten_xanh_len_1.Text = "i = " + (i + 1);
                Mui_ten_xanh_len_1.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * (i + 1), pnlExcution.Height - 50);
            }
            ShowCodeListBox(0);
        }
        #endregion
        #region selection
        private void SelectionSortincrease(int[] arrNode)
        {
            int min;
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < thamSo.nOe - 1; i++)
                {
                    ShowCodeListBox(3);
                    ShowCodeListBox(5);

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    min = i;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Text = "Min=" + min;
                    Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * min) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[min].Location.Y + 2 * thamSo.sizeN + 5);
                    Mui_ten_xanh_len_1.Refresh();

                    for (int j = i + 1; j < thamSo.nOe; j++)
                    {
                        ShowCodeListBox(6);
                        Application.DoEvents();
                        ShowCodeListBox(7);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "Compare( a[min] , a[" + j + "] )";
                        lbl_status_02.Refresh();
                        if (thamSo.arrNode[j] < thamSo.arrNode[min])
                        {
                            ShowCodeListBox(8);
                            min = j;
                            Mui_ten_xanh_len_1.Text = "Min=" + min;
                            Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * min) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y + 2 * thamSo.sizeN + 5);
                            Mui_ten_xanh_len_1.Refresh();
                        }

                    }
                    if (min != i)
                    {
                        ShowCodeListBox(10);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "Swap( a[i] , a[min] )";
                        Swap_Giatri(ref thamSo.arrNode[min], ref thamSo.arrNode[i]);
                        Swap_Node(thamSo.arrLbl[min], thamSo.arrLbl[i]);
                        Swap_NodeAn(min, i);
                        thamSo.arrLbl[i].BackColor = colorComplete;
                        thamSo.arrLbl[min].BackColor = colorDefault;
                    }
                    else
                        thamSo.arrLbl[i].BackColor = colorComplete;
                    lbl_status_02.Visible = false;

                }
            });
            ShowCodeListBox(0);
        }
        private void SelectionSortGiam(int[] arrNode)
        {
            int max;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < thamSo.nOe - 1; i++)
                {
                    ShowCodeListBox(3);
                    ShowCodeListBox(5);
                    max = i;

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Text = "Max=" + max;
                    Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * max) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[max].Location.Y + 2 * thamSo.sizeN + 5);
                    Mui_ten_xanh_len_1.Refresh();
                    for (int j = i + 1; j < thamSo.nOe; j++)
                    {
                        ShowCodeListBox(6);
                        Application.DoEvents();
                        ShowCodeListBox(7);

                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "Compare( a[max] , a[" + j + "] )";
                        if (thamSo.arrNode[j] > thamSo.arrNode[max])
                        {
                            max = j;
                            Mui_ten_xanh_len_1.Text = "Max=" + max;
                            Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * max) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y + 2 * thamSo.sizeN + 5);
                            Mui_ten_xanh_len_1.Refresh();
                        }
                    }
                    if (max != i)
                    {
                        ShowCodeListBox(10);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "Swap( a[i] , a[max] )";
                        Swap_Giatri(ref thamSo.arrNode[max], ref thamSo.arrNode[i]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(thamSo.arrLbl[max], thamSo.arrLbl[i]);
                        Swap_NodeAn(max, i);
                        thamSo.arrLbl[i].BackColor = colorComplete;
                        thamSo.arrLbl[max].BackColor = colorDefault;
                    }
                    else
                        thamSo.arrLbl[i].BackColor = colorComplete;
                    lbl_status_02.Visible = false;
                }
            });
            ShowCodeListBox(0);
        }
        #endregion
        #region shell
        private void ShellSortincrease(int[] arrNode)
        {

            for (int i = thamSo.nOe / 2; i > 0; i /= 2)
            {
                ShowCodeListBox(2);
                Mui_ten_xanh_xuong_1.Text = "i = " + i;
                Mui_ten_xanh_xuong_1.Location = new Point(thamSo.firstN - 10 + (thamSo.sizeN + thamSo.disN) * 0, 40);
                Mui_ten_xanh_xuong_1.SendToBack();
                Mui_ten_xanh_xuong_1.Visible = true;

                for (int j = i; j < thamSo.nOe; j++)
                {
                    ShowCodeListBox(3);
                    Mui_ten_xanh_len_1.Text = "j = " + j;
                    Mui_ten_xanh_len_1.Location = new Point(thamSo.firstN - 10 + (thamSo.sizeN + thamSo.disN) * j, 40);
                    Mui_ten_xanh_len_1.Visible = true;


                    for (int k = j; k >= i && thamSo.arrNode[k] < thamSo.arrNode[k - i]; k -= i)
                    {
                        ShowCodeListBox(4);
                        Mui_ten_xanh_xuong_2.Text = "k = " + k;
                        Mui_ten_xanh_xuong_2.Location = new Point(thamSo.firstN - 10 + (thamSo.sizeN + thamSo.disN) * k, pnlExcution.Height - 50);
                        Mui_ten_xanh_xuong_2.SendToBack();
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Refresh();
                        ShowCodeListBox(5);
                        lbl_status_02.Text = "Swap(a[" + k + "],a[" + (k - 1) + "])";
                        lbl_status_02.Visible = true;
                        Swap_Giatri(ref thamSo.arrNode[k - i], ref thamSo.arrNode[k]);
                        Swap_Node(thamSo.arrLbl[k], thamSo.arrLbl[k - i]);
                        Swap_NodeAn(k, k - i);
                        thamSo.arrLbl[k - i].BackColor = colorDefault;
                        thamSo.arrLbl[k].BackColor = colorDefault;
                    }
                    lbl_status_02.Visible = false;
                    ShowCodeListBox(3);
                }
            }
            ShowCodeListBox(0);
        }
        private void ShellSortGiam(int[] arrNode)
        {
            for (int i = thamSo.nOe / 2; i > 0; i /= 2)
            {
                ShowCodeListBox(2);
                Mui_ten_xanh_xuong_1.Text = "i = " + i;
                Mui_ten_xanh_xuong_1.Location = new Point(thamSo.firstN - 10 + (thamSo.sizeN + thamSo.disN) * 0, 40);
                Mui_ten_xanh_xuong_1.SendToBack();
                Mui_ten_xanh_xuong_1.Visible = true;
                for (int j = i; j < thamSo.nOe; j++)
                {
                    ShowCodeListBox(3);
                    Mui_ten_xanh_len_1.Text = "j = " + j;
                    Mui_ten_xanh_len_1.Location = new Point(thamSo.firstN - 10 + (thamSo.sizeN + thamSo.disN) * j, 40);
                    Mui_ten_xanh_len_1.Visible = true;
                    for (int k = j; k >= i && thamSo.arrNode[k] > thamSo.arrNode[k - i]; k -= i)
                    {
                        ShowCodeListBox(4);
                        Mui_ten_xanh_xuong_2.Text = "k = " + k;
                        Mui_ten_xanh_xuong_2.Location = new Point(thamSo.firstN - 10 + (thamSo.sizeN + thamSo.disN) * k, pnlExcution.Height - 50);
                        Mui_ten_xanh_xuong_2.SendToBack();
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Refresh();
                        ShowCodeListBox(5);
                        lbl_status_02.Text = "Swap(a[" + k + "],a[" + (k - 1) + "])";
                        lbl_status_02.Visible = true;
                        Swap_Giatri(ref thamSo.arrNode[k - i], ref thamSo.arrNode[k]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(thamSo.arrLbl[k], thamSo.arrLbl[k - i]);
                        Swap_NodeAn(k, k - i);
                        thamSo.arrLbl[k - i].BackColor = colorDefault;
                        thamSo.arrLbl[k].BackColor = colorDefault;
                    }
                    lbl_status_02.Visible = false;
                    ShowCodeListBox(3);
                }
            }
            ShowCodeListBox(0);
        }
        #endregion
        #region bubble
        private void BubbleSortincrease(int[] arrNode)
        {
            int i, j;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < thamSo.nOe - 1; i++)
                {
                    ShowCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = thamSo.nOe - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ShowCodeListBox(4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y + 2 * thamSo.sizeN + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ShowCodeListBox(5);
                        lbl_status_02.Visible = true;
                        if (thamSo.arrNode[j] < thamSo.arrNode[j - 1])
                        {
                            //Hieu ung xem code
                            ShowCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref thamSo.arrNode[j], ref thamSo.arrNode[j - 1]);
                            Swap_Node(thamSo.arrLbl[j], thamSo.arrLbl[j - 1]);
                            Swap_NodeAn(j, j - 1);
                            thamSo.arrLbl[j - 1].BackColor = colorComplete;
                        }
                        thamSo.arrLbl[j].BackColor = colorDefault;
                    }
                    //Cập nhật Status
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();

                }
                lbl_status_02.Visible = false;
            });
            ShowCodeListBox(0);
        }
        private void BubbleSortGiam(int[] arrNode)
        {
            int i, j;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < thamSo.nOe - 1; i++)
                {
                    ShowCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = thamSo.nOe - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ShowCodeListBox(4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y + 2 * thamSo.sizeN + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ShowCodeListBox(5);
                        lbl_status_02.Visible = true;
                        if (thamSo.arrNode[j] > thamSo.arrNode[j - 1])
                        {
                            //Hieu ung xem code
                            ShowCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref thamSo.arrNode[j], ref thamSo.arrNode[j - 1]);
                            Swap_Node(thamSo.arrLbl[j], thamSo.arrLbl[j - 1]);
                            Swap_NodeAn(j, j - 1);
                            thamSo.arrLbl[j - 1].BackColor = colorComplete;
                        }
                        thamSo.arrLbl[j].BackColor = colorDefault;
                    }
                    //Cập nhật Status
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();

                }
                lbl_status_02.Visible = false;
            });
            ShowCodeListBox(0);
        }
        #endregion
        #region insertion
        private void InsertionSortincrease(int[] arrNode)
        {
            int i, pos, x;
            Label Node_tam;
            int Chi_so_tam;
            int Dem_node;

            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 1; i < thamSo.nOe; i++)
                {
                    ShowCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    Dem_node = 0;
                    ShowCodeListBox(5);
                    x = thamSo.arrNode[i];
                    Node_tam = thamSo.arrLbl[i];
                    Chi_so_tam = i;
                    pos = i - 1;
                    //thiết lập mũi tên đánh dấu nút cần chèn


                    //Di chuyển Node cần chèn lên
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(Node_tam, (thamSo.sizeN + 5));
                    });

                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i)";

                    //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                    Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * pos) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[pos].Location.Y + thamSo.sizeN + 5);
                    Mui_ten_xanh_len_1.Text = "POS=" + pos;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Refresh();
                    //lbl_status_02.Visible = false
                    while ((pos >= 0) && (thamSo.arrNode[pos] > x))
                    {
                        Application.DoEvents();
                        ShowCodeListBox(7);
                        Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * pos) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[pos].Location.Y + thamSo.sizeN + 5);
                        Mui_ten_xanh_len_1.Text = "POS=" + pos;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Refresh();
                        //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        


                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i])";
                        ShowCodeListBox(9);
                        //Dịch chuyển Node qua phải
                        thamSo.arrNode[pos + 1] = thamSo.arrNode[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_Right(thamSo.arrLbl[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        ShowCodeListBox(10);
                        pos--;
                        ShowCodeListBox(12);
                        thamSo.arrNode[pos + 1] = x;
                    }
                    //status hoán vị
                    if (Dem_node > 0)
                    {
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "Hoan_vi(a[pos],a[i])";
                    }
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Left(Node_tam, Dem_node);
                        thamSo.arrLbl[pos + 1].BackColor = colorDefault;
                    });

                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(Node_tam, (thamSo.sizeN + 5));
                        //thamSo.arrLbl[pos+1].BackColor = colorComplete;
                        thamSo.arrLbl[pos + 1].BackColor = colorDefault;
                    });
                    lbl_status_02.Visible = false;
                    Mui_ten_xanh_len_1.Visible = false; ;
                    thamSo.arrLbl[pos + 1] = Node_tam;
                }
            });
            ShowCodeListBox(0);
        }
        private void InsertionSortGiam(int[] arrNode)
        {
            int i, pos, x;
            Label Node_tam;
            int Chi_so_tam;
            int Dem_node;

            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 1; i < thamSo.nOe; i++)
                {
                    ShowCodeListBox(3);
                    Application.DoEvents();
                    //Thiết lập Node đầu tiên, là Node đã có thứ tự 
                    //đềm số bước dịch chuyển 1 Node
                    Dem_node = 0;
                    ShowCodeListBox(5);
                    x = thamSo.arrNode[i];
                    Node_tam = thamSo.arrLbl[i];
                    Chi_so_tam = i;
                    pos = i - 1;
                    //thiết lập mũi tên đánh dấu nút cần chèn
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Refresh();

                    //Di chuyển Node cần chèn lên
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(Node_tam, (thamSo.sizeN + 5));
                    });

                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i])";
                    //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                    Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * pos) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[pos].Location.Y + thamSo.sizeN + 5);
                    Mui_ten_xanh_len_1.Text = "POS=" + pos;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Refresh();
                    //lbl_status_02.Visible = false;
                    while ((pos >= 0) && (thamSo.arrNode[pos] < x))
                    {
                        Application.DoEvents();
                        ShowCodeListBox(7);
                        //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                        Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * pos) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[pos].Location.Y + thamSo.sizeN + 5);
                        Mui_ten_xanh_len_1.Text = "POS=" + pos;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Refresh();

                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i])";

                        ShowCodeListBox(9);
                        //Dịch chuyển Node qua phải
                        thamSo.arrNode[pos + 1] = thamSo.arrNode[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_Right(thamSo.arrLbl[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        thamSo.arrLbl[pos].BackColor = colorComplete;
                        ShowCodeListBox(10);
                        pos--;
                        ShowCodeListBox(12);
                        thamSo.arrNode[pos + 1] = x;


                    }
                    //status hoán vị
                    if (Dem_node > 0)
                    {
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "Hoan_vi(a[pos],a[i])";
                    }
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Left(Node_tam, Dem_node);
                        thamSo.arrLbl[pos + 1].BackColor = colorDefault;
                    });

                    Application.DoEvents();
                    Delay(thamSo.speed * 30);
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(Node_tam, (thamSo.sizeN + 5));
                        thamSo.arrLbl[pos + 1].BackColor = colorDefault;
                    });
                    //Ẩn status
                    lbl_status_02.Visible = false;
                    //Ẩn mũi tên POS sau khi đã tìm ra POS
                    Mui_ten_xanh_len_1.Visible = false; ;
                    //Thiết lập node nằm trong nhóm đã có thứ tự
                    thamSo.arrLbl[pos + 1] = Node_tam;
                    //Tạm dừng sau 1 bước dịch chuyển Node
                }
            });
            ShowCodeListBox(0);
        }
        #endregion
        #region quick
        private void QuickSortincrease(int[] arrNode, int left, int right)
        {
            if (left < right)
            {
                int pivot = thamSo.arrNode[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left


                ShowCodeListBox(2);

                Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * left) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[left].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * right) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[right].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                //

                //doi mau node x


                //Đặt màu nút x                    
                //         
                ShowCodeListBox(3);
                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * cs_x) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[cs_x].Location.Y + 2 * thamSo.sizeN + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Thiết lập mũi tên chỉ i

                ShowCodeListBox(4);
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ShowCodeListBox(5);

                do
                {

                    ShowCodeListBox(7);
                    lbl_status_02.Text = "Compare(a[" + i + "], a[x])";
                    lbl_status_02.Visible = true;
                    while (thamSo.arrNode[i] < pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        // lbl_status_02.Text = "Compare(a[" + i + "], a[x])";
                    }
                    ShowCodeListBox(8);
                    lbl_status_02.Text = "Compare(a[" + j + "], a[x])";
                    while (thamSo.arrNode[j] > pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //

                    }
                    ShowCodeListBox(9);

                    if (i <= j)
                    {
                        ShowCodeListBox(11);
                        lbl_status_02.Text = "Swap(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref thamSo.arrNode[i], ref thamSo.arrNode[j]);
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        Swap_Node(thamSo.arrLbl[j], thamSo.arrLbl[i]);
                        Swap_NodeAn(j, i);
                        thamSo.arrLbl[j].BackColor = colorComplete;
                        thamSo.arrLbl[i].BackColor = colorDefault;
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * cs_x) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[cs_x].Location.Y + 2 * thamSo.sizeN + 40);
                        Mui_ten_do_len.Text = "X = " + ((left + right) / 2);
                        Mui_ten_do_len.Refresh();
                        ShowCodeListBox(12);
                        i++;
                        j--;
                    }
                }
                while (i <= j);
                ShowCodeListBox(16);
                if (left < j)
                {
                    ShowCodeListBox(17);
                    QuickSortincrease(thamSo.arrNode, left, j);
                }
                ShowCodeListBox(18);
                if (i < right)
                {
                    ShowCodeListBox(19);
                    QuickSortincrease(thamSo.arrNode, i, right);
                }
            }
        }
        private void QuickSortGiam(int[] arrNode, int left, int right)
        {
            if (left < right)
            {
                int pivot = thamSo.arrNode[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left
                Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * left) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[left].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * right) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[right].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                //

                //doi mau node x

                ShowCodeListBox(2);


                cs_x = (left + right) / 2;

                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * cs_x) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[cs_x].Location.Y + 2 * thamSo.sizeN + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Đặt màu nút x                    
                //
                i = left; j = right;
                ShowCodeListBox(3);
                //Thiết lập mũi tên chỉ i
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ShowCodeListBox(5);
                do
                {
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    ShowCodeListBox(7);
                    while (thamSo.arrNode[i] > pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    }
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    ShowCodeListBox(8);
                    while (thamSo.arrNode[j] < pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    }
                    ShowCodeListBox(9);
                    if (i <= j)
                    {
                        //status hoán vị             
                        lbl_status_02.Text = "Hoan_Vi(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref thamSo.arrNode[i], ref thamSo.arrNode[j]);
                        ShowCodeListBox(11);
                        //Tìm vị trí mới của x
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        Swap_Node(thamSo.arrLbl[i], thamSo.arrLbl[j]);
                        Swap_NodeAn(i, j);
                        thamSo.arrLbl[i].BackColor = colorComplete;
                        thamSo.arrLbl[j].BackColor = colorDefault;
                        //Thiết lập vị trí của 
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * cs_x) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[cs_x].Location.Y + 2 * thamSo.sizeN + 40);
                        Mui_ten_do_len.Text = "X = " + ((left + right) / 2);
                        Mui_ten_do_len.Refresh();
                        ShowCodeListBox(12);

                        i++; j--;

                    }

                } while (i <= j);
                //Đặt màu nút x
                ShowCodeListBox(16);
                if (left < j)
                {
                    ShowCodeListBox(18);
                    QuickSortGiam(thamSo.arrNode, left, j);
                }
                if (i < right)
                {
                    ShowCodeListBox(19);
                    QuickSortGiam(thamSo.arrNode, i, right);
                }
            }
        }
        #endregion
        #region heap
        void Shift_increase(int l, int r)
        {

            int i, j, index_temp, x;
            Label temp;
            i = l;
            j = 2 * i + 1;
            //Thiết lập mũi tên chỉ i
            lbl_status_02.Text = "Đang shift heap";
            lbl_status_02.Visible = true;
            Mui_ten_xanh_xuong_1.Visible = true;
            Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
            Mui_ten_xanh_xuong_1.Text = "i=" + i;
            Mui_ten_xanh_xuong_1.Refresh();
            //thiết lập mũi tên chỉ j
            Mui_ten_xanh_xuong_2.Visible = true;
            Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
            Mui_ten_xanh_xuong_2.Text = "j=" + j;
            Mui_ten_xanh_xuong_2.Refresh();
            x = thamSo.arrNode[i];
            temp = thamSo.arrLbl[i];
            index_temp = i;

            while (j <= r)
            {

                Application.DoEvents();

                if (j < r)

                    if (thamSo.arrNode[j] < thamSo.arrNode[j + 1])

                        j++;
                //thiết lập mũi tên chỉ j

                Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();

                if (thamSo.arrNode[j] <= x)
                    return;
                else
                {
                    thamSo.arrNode[i] = thamSo.arrNode[j];
                    thamSo.arrNode[j] = x;
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Swap_Node(thamSo.arrLbl[j], temp);
                    });

                    Swap_NodeAn(j, index_temp);
                    if (ckDebug.Checked == true)
                        Pause();
                    else
                        Delay(5 * thamSo.speed);
                    i = j;
                    j = 2 * i + 1;
                    if (j <= r)
                    {
                        //Thiết lập mũi tên chỉ i

                        Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //thiết lập mũi tên chỉ j

                        Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                    }
                    x = thamSo.arrNode[i];
                    temp = thamSo.arrLbl[i];
                    index_temp = i;
                }
            }
        }
        void Shift_giam(int l, int r)
        {
            int i, j, index_temp, x;
            Label temp;
            i = l;
            j = 2 * i + 1;
            lbl_status_02.Text = "Đang shift heap";
            lbl_status_02.Visible = true;
            //Thiết lập mũi tên chỉ i
            Mui_ten_xanh_xuong_1.Visible = true;
            Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
            Mui_ten_xanh_xuong_1.Text = "i=" + i;
            Mui_ten_xanh_xuong_1.Refresh();
            //thiết lập mũi tên chỉ j
            Mui_ten_xanh_xuong_2.Visible = true;
            Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
            Mui_ten_xanh_xuong_2.Text = "j=" + j;
            Mui_ten_xanh_xuong_2.Refresh();
            x = thamSo.arrNode[i];
            temp = thamSo.arrLbl[i];
            index_temp = i;

            while (j <= r)
            {

                Application.DoEvents();

                if (j < r)

                    if (thamSo.arrNode[j] > thamSo.arrNode[j + 1])

                        j++;
                //thiết lập mũi tên chỉ j

                Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();

                if (thamSo.arrNode[j] >= x)
                    return;
                else
                {
                    thamSo.arrNode[i] = thamSo.arrNode[j];
                    thamSo.arrNode[j] = x;
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Swap_Node(thamSo.arrLbl[j], temp);
                    });
                    Swap_NodeAn(j, index_temp);
                    if (ckDebug.Checked == true)
                        Pause();
                    else
                        Delay(5 * thamSo.speed);
                    i = j;
                    j = 2 * i + 1;
                    if (j <= r)
                    {
                        //Thiết lập mũi tên chỉ i

                        Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //thiết lập mũi tên chỉ j

                        Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                    }
                    x = thamSo.arrNode[i];
                    temp = thamSo.arrLbl[i];
                    index_temp = i;
                }
            }
        }

        void CreateHeap_increase(int n)
        {
            int l = n / 2 - 1;
            while (l >= 0)
            {
                Shift_increase(l, n - 1);
                l--;
            }
        }
        void CreateHeap_giam(int n)
        {

            int l = n / 2 - 1;

            while (l >= 0)
            {
                Shift_giam(l, n - 1);
                l--;
            }
        }

        void HeapSortincrease(int n)
        {
            listCode.SelectedIndex = 2;
            int r;
            listCode.SelectedIndex = 3;
            CreateHeap_increase(n);
            listCode.SelectedIndex = 4;
            r = n - 1;

            //Thiết lập mũi tên chỉ r
            Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * r) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[r].Location.Y + 2 * thamSo.sizeN + 5);
            Mui_ten_xanh_len_1.Text = "r=" + r;
            Mui_ten_xanh_len_1.Visible = true;
            Mui_ten_xanh_len_1.Refresh();
            listCode.SelectedIndex = 5;
            while (r > 0)
            {
                Application.DoEvents();
                Swap_Giatri(ref thamSo.arrNode[0], ref thamSo.arrNode[r]);
                Mui_ten_xanh_xuong_1.Visible = false;
                Mui_ten_xanh_xuong_2.Visible = false;
                //
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "Swap( a[0] , a[" + r + "] )";

                listCode.SelectedIndex = 7;
                this.Invoke((MethodInvoker)delegate
                {
                    Swap_Node(thamSo.arrLbl[0], thamSo.arrLbl[r]);
                });

                lbl_status_02.Visible = false;
                Swap_NodeAn(0, r);
                thamSo.arrLbl[r].BackColor = colorComplete;
                thamSo.arrLbl[0].BackColor = colorDefault;
                // Đặt lại màu cho phần tử đã được sắp xếp

                lbl_status_02.Visible = true;
                lbl_status_02.Text = "a[" + r + "] đã đúng thứ tự!";
                if (ckDebug.Checked == true)
                    Pause();
                else
                    Delay(10 * thamSo.speed);
                lbl_status_02.Visible = false;
                listCode.SelectedIndex = 8;
                r--;
                //Thiết lập mũi tên chỉ r
                Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * r) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[r].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_1.Text = "r=" + r;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                listCode.SelectedIndex = 9;
                if (r > 0)
                {
                    listCode.SelectedIndex = 10;
                    Shift_increase(0, r);
                }
            }
        }
        void HeapSortGiam(int n)
        {
            listCode.SelectedIndex = 2;
            int r;
            listCode.SelectedIndex = 3;
            CreateHeap_giam(n);
            listCode.SelectedIndex = 4;
            r = n - 1;

            //Thiết lập mũi tên chỉ r
            Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * r) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[r].Location.Y + 2 * thamSo.sizeN + 5);
            Mui_ten_xanh_len_1.Text = "r=" + r;
            Mui_ten_xanh_len_1.Visible = true;
            Mui_ten_xanh_len_1.Refresh();
            listCode.SelectedIndex = 5;
            while (r > 0)
            {
                Application.DoEvents();
                Swap_Giatri(ref thamSo.arrNode[0], ref thamSo.arrNode[r]);
                Mui_ten_xanh_xuong_1.Visible = false;
                Mui_ten_xanh_xuong_2.Visible = false;
                //
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "Swap( a[0] , a[" + r + "] )";

                listCode.SelectedIndex = 7;
                this.Invoke((MethodInvoker)delegate
                {
                    Swap_Node(thamSo.arrLbl[0], thamSo.arrLbl[r]);
                });
                lbl_status_02.Visible = false;
                Swap_NodeAn(0, r);
                thamSo.arrLbl[r].BackColor = colorComplete;
                thamSo.arrLbl[0].BackColor = colorDefault;
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "a[" + r + "] đã đúng thứ tự!";
                if (ckDebug.Checked == true)
                    Pause();
                else
                    Delay(10 * thamSo.speed);
                lbl_status_02.Visible = false;
                listCode.SelectedIndex = 8;
                r--;
                //Thiết lập mũi tên chỉ r
                Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * r) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[r].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_1.Text = "r=" + r;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                listCode.SelectedIndex = 9;
                if (r > 0)
                {
                    listCode.SelectedIndex = 10;
                    Shift_giam(0, r);
                }
            }
        }
        #endregion
        #region merge
        void Distribute(ref int nb, ref int nc, int k)
        {

            int i, pa, pb, pc;
            pa = pb = pc = 0;
            while (pa < thamSo.nOe)
            {
                Application.DoEvents();
                for (i = 0; (pa < thamSo.nOe) && (i < k); i++, pa++, pb++)
                {
                    thamSo.b[pb] = thamSo.arrNode[pa];
                    thamSo.node_B[pb] = thamSo.arrLbl[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(thamSo.node_B[pb], 2 * (thamSo.sizeN));
                        Den_tdo_x_node(thamSo.node_B[pb], pb);
                    });
                    thamSo.arrLbl[pa].BackColor = colorMergeU;  // màu trên
                }
                for (i = 0; (pa < thamSo.nOe) && (i < k); i++, pa++, pc++)
                {
                    thamSo.c[pc] = thamSo.arrNode[pa];
                    thamSo.node_C[pc] = thamSo.arrLbl[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(thamSo.node_C[pc], (thamSo.sizeN + 80));
                        Den_tdo_x_node(thamSo.node_C[pc], pc);
                    });
                    thamSo.arrLbl[pa].BackColor = colorMergeD; // màu dưới
                }
            }
            nb = pb;
            nc = pc;
        }
        //Hàm kết hợp b và c vào a
        void Merge_increase(int nb, int nc, int k)
        {
            int pa, pb, pc, ib, ic, kb, kc, lennb, lennc;
            //lưu những giá trị để đếm Node dư   
            lennb = nb;
            lennc = nc;
            pa = pb = pc = 0; ib = ic = 0;
            while ((nb > 0) && (nc > 0))
            {
                Application.DoEvents();
                kb = min(k, nb);
                kc = min(k, nc);
                if (thamSo.b[pb + ib] <= thamSo.c[pc + ic])
                {
                    thamSo.arrNode[pa] = thamSo.b[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(thamSo.node_B[pb + ib], pa);
                    });
                    thamSo.arrLbl[pa] = thamSo.node_B[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            thamSo.arrNode[pa] = thamSo.c[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(thamSo.node_C[pc + ic], pa);
                            });
                            thamSo.arrLbl[pa] = thamSo.node_C[pc + ic];
                            pa++;
                        }
                        pb += kb;
                        pc += kc;
                        ib = ic = 0;
                        nb -= kb;
                        nc -= kc;
                    }
                }
                else
                {
                    thamSo.arrNode[pa] = thamSo.c[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(thamSo.node_C[pc + ic], pa);
                    });
                    thamSo.arrLbl[pa] = thamSo.node_C[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            thamSo.arrNode[pa] = thamSo.b[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(thamSo.node_B[pb + ib], pa);
                            });
                            thamSo.arrLbl[pa] = thamSo.node_B[pb + ib];
                            pa++;
                        }
                        pb += kb;
                        pc += kc;
                        ib = ic = 0;
                        nb -= kb;
                        nc -= kc;
                    }
                }
            }
            //Di chuyển các Node dư thừa vào vị trí
            for (; nb > 0; nb--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    toLocaN(thamSo.node_B[lennb - nb], pa);

                });
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    toLocaN(thamSo.node_C[lennc - nc], pa);
                });
                pa++;
            }
        }
        void Merge_giam(int nb, int nc, int k)
        {
            int pa, pb, pc, ib, ic, kb, kc, lennb, lennc;
            //lưu những giá trị để đếm Node dư   
            lennb = nb;
            lennc = nc;
            pa = pb = pc = 0; ib = ic = 0;
            while ((nb > 0) && (nc > 0))
            {
                Application.DoEvents();
                kb = min(k, nb);
                kc = min(k, nc);
                if (thamSo.b[pb + ib] >= thamSo.c[pc + ic])
                {
                    thamSo.arrNode[pa] = thamSo.b[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(thamSo.node_B[pb + ib], pa);
                    });
                    thamSo.arrLbl[pa] = thamSo.node_B[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            thamSo.arrNode[pa] = thamSo.c[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(thamSo.node_C[pc + ic], pa);
                            });
                            thamSo.arrLbl[pa] = thamSo.node_C[pc + ic];
                            pa++;
                        }
                        pb += kb;
                        pc += kc;
                        ib = ic = 0;
                        nb -= kb;
                        nc -= kc;
                    }
                }
                else
                {
                    thamSo.arrNode[pa] = thamSo.c[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(thamSo.node_C[pc + ic], pa);
                    });
                    thamSo.arrLbl[pa] = thamSo.node_C[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            thamSo.arrNode[pa] = thamSo.b[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(thamSo.node_B[pb + ib], pa);
                            });
                            thamSo.arrLbl[pa] = thamSo.node_B[pb + ib];
                            pa++;
                        }
                        pb += kb;
                        pc += kc;
                        ib = ic = 0;
                        nb -= kb;
                        nc -= kc;
                    }
                }
            }
            //Di chuyển các Node dư thừa vào vị trí
            for (; nb > 0; nb--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    toLocaN(thamSo.node_B[lennb - nb], pa);
                });
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    toLocaN(thamSo.node_C[lennc - nc], pa);
                });
                pa++;
            }

        }
        //Hàm sắp xếp Merge
        void MergeSortincrease()
        {
            lblA.Visible = true;
            lblC.Visible = true;
            lblB.Visible = true;
            thamSo.b = new int[thamSo.nOe];
            thamSo.c = new int[thamSo.nOe];
            thamSo.node_B = new Label[thamSo.nOe];
            thamSo.node_C = new Label[thamSo.nOe];
            //Dán nhãn mảng b

            int k, nc = 0, nb = 0;
            ShowCodeListBox(3);
            for (k = 1; k < thamSo.nOe; k *= 2)
            {
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "k = " + k;
                ShowCodeListBox(5);
                Distribute(ref nb, ref nc, k);
                Merge_increase(nb, nc, k);
                ShowCodeListBox(6);
            }
        }
        void MergeSortGiam()
        {
            thamSo.b = new int[thamSo.nOe];
            thamSo.c = new int[thamSo.nOe];
            thamSo.node_B = new Label[thamSo.nOe];
            thamSo.node_C = new Label[thamSo.nOe];
            //Dán nhãn mảng b
            int k, nc = 0, nb = 0;
            ShowCodeListBox(3);
            for (k = 1; k < thamSo.nOe; k *= 2)
            {
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "k = " + k;
                ShowCodeListBox(5);
                Distribute(ref nb, ref nc, k);
                Merge_giam(nb, nc, k);
                ShowCodeListBox(6);
            }
        }
        #endregion
        #endregion

        #region Show Code
        private void ShowCode()
        {
            listCode.Items.Clear();
            listIdea.Items.Clear();
            Alignment();
            Idea idea = new Idea();
            Code code = new Code();

            listCode.Font = new Font("Aril", 12, FontStyle.Regular);
            listIdea.Font = new Font("Aril", 12, FontStyle.Regular);
            listIdea.ForeColor = Color.White;
            if (radQuick.Checked)
            {
                code.quicksort(listCode, thamSo.increase);
                idea.Quicksort(listIdea);
            }
            if (radHeap.Checked)
            {
                code.heapsort(listCode, thamSo.increase);
                idea.Heapsort(listIdea);
            }
            if (radInsertion.Checked)
            {
                code.insertionsort(listCode, thamSo.increase);
                idea.Insertionsort(listIdea);
            }
            if (radMerge.Checked)
            {
                code.mergesort(listCode, thamSo.increase);
                idea.Mergesort(listIdea);
            }
            if (radInterchange.Checked)
            {
                code.interchangesort(listCode, thamSo.increase);
                idea.Interchangesort(listIdea);
            }
            if (radShell.Checked)
            {
                code.shellsort(listCode, thamSo.increase);
                idea.Shellsort(listIdea);
            }
            if (radBubble.Checked)
            {
                code.bubblesort(listCode, thamSo.increase);
                idea.Bubblesort(listIdea);
            }
            if (radSelection.Checked)
            {
                code.selectionsort(listCode, thamSo.increase);
                idea.Selectionsort(listIdea);
            }
        }
        public void ShowCodeListBox(int viTri)
        {
            Delay(thamSo.speed * 5);
            listCode.SelectedIndex = viTri;
            // nếu đang trong chế độ Debug thì dừng sau mỗi câu lệnh chạy xong sẽ dừng lại
            if (ckDebug.Checked)
            {
                thamSo.checkPause = true;
                Play_or_Stop();
            }
        }

        #endregion

        #region Complete
        public void Complete()
        {
            ShowCodeListBox(0);
            ExTime.Stop();
            pnlExTime.Visible = false;
            Init();
            bntReset.Enabled = true;
            bntCreate.Enabled = false;
            bntBack.Enabled = true;
            Hidelbl();
            MessageBox.Show("----------Sorting Algorithms was completed !----------\nTime execution: " + lblMinutes.Text + ":" + lblSeconds.Text, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void Hidelbl()
        {
            Mui_ten_xanh_xuong_1.Visible = false;
            Mui_ten_xanh_xuong_2.Visible = false;
            Mui_ten_xanh_len_1.Visible = false;
            Mui_ten_xanh_len_2.Visible = false;
            Mui_ten_do_len.Visible = false;
            lblA.Visible = false;
            lblB.Visible = false;
            lblC.Visible = false;
            lbl_status_02.Visible = false;
        }
        #endregion

        #region AddPanel
        public void AddPanel()
        {
            pnlExcution.Controls.Add(Mui_ten_xanh_xuong_1);
            pnlExcution.Controls.Add(Mui_ten_xanh_xuong_2);
            pnlExcution.Controls.Add(Mui_ten_xanh_len_1);
            pnlExcution.Controls.Add(Mui_ten_xanh_len_2);
            pnlExcution.Controls.Add(Mui_ten_do_len);
            pnlExcution.Controls.Add(lbl_status_02);
            pnlExcution.Controls.Add(lblA);
            pnlExcution.Controls.Add(lblB);
            pnlExcution.Controls.Add(lblC);
        }
        #endregion
        //ToolBox 
        #region Working 
        #region bnt"Initial","Control","Debug","Create Array"_Click
        #region Initial

        public void DeleteArray(Label[] a)
        {

            for (int i = 0; i < thamSo.nOe; i++)
            {
                this.Controls.Remove(a[i]);
            }
        }
        private void bntCreate_Click(object sender, EventArgs e)
        {
            bntCreate.Enabled = false;
            numArray.Enabled = false;
            bntReset.Enabled = true;
            thamSo.checkPause = false;
            //DeleteArray(thamSo.arrLbl);
            if (numArray.Value < 2 )
            {
                MessageBox.Show("Please input number of elements  2->10 !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; /// > >> >
            }
            else
            {
                switch (thamSo.nOe)
                {
                    case 10:
                    case 9:
                    case 8:
                    case 7:
                    case 6:
                        thamSo.disN = 18;
                        thamSo.sizeN = 50;
                        thamSo.firstN = (1024 - thamSo.sizeN - thamSo.disN * (thamSo.nOe - 1)) / thamSo.nOe;
                        break;
                    case 5:
                    case 4:
                    case 3:
                    case 2:
                        thamSo.sizeN = 50;
                        thamSo.disN = 30;
                        thamSo.firstN = (1024 - thamSo.sizeN - thamSo.disN * (thamSo.nOe - 1)) / thamSo.nOe;
                        break;
                }
                thamSo.arrNode = new int[thamSo.nOe];
                thamSo.arrLbl = new Label[thamSo.nOe];
                for (int i = 0; i < thamSo.nOe; i++)
                {
                    Label label = new Label();   
                    label.AutoSize = false;         // tắt kích thước mặc định ( cho phép thay đổi )
                    label.Size = new Size(40, 40);  // thay đổi kích thước 
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // viền của Node 
                    label.Font = new Font("Times New Roman", 14);  // Kiểu chữ số và kích cỡ
                    label.TextAlign = ContentAlignment.MiddleCenter; // Vị trí của chữ số trong Node
                    label.Text = "0";                               // Hiển thị chữ số Node
                    label.BackColor = colorDefault;                 // màu Node được nói ở phần trước
                    label.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i, 3 * thamSo.sizeN);
                            // Khởi tạo vị trí cho các Node bằng các phép tính
                    thamSo.arrLbl[i] = label;                       // gán giá trị Node vào mảng
                    pnlExcution.Controls.Add(thamSo.arrLbl[i]);     // thêm Node vào background (panel)
                }
            }
            grpCreateArray.Enabled = true;
        }

        private void bntReset_Click(object sender, EventArgs e)
        {
            thamSo.programIsStart = false;   // kiểm tra chương trình có đang chạy không ? 
            // Áp dụng cho hàm Debug và khi reset sẽ cho cho giá trị là chương trình không chạy
            numArray.Enabled = true;
            bntCreate.Enabled = true;
            radSelection.Enabled = true;
            radBubble.Enabled = true;
            radShell.Enabled = true;
            radQuick.Enabled = true;
            radHeap.Enabled = true;
            radInsertion.Enabled = true;
            radInterchange.Enabled = true;
            radMerge.Enabled = true;
            ckDebug.Checked = false;   // tắt dấu tích trên checkBox ( checkBox Debug )
            Init();                     // Khởi tạo, không cho phép sử dụng một vài tool 
            lblSeconds.Text = "00";     // trả lại giá trị Execution ban đầu ( Giây )
            lblMinutes.Text = "00";     // trả lại giá trị Execution ban đầu ( Phút )
            Hidelbl();
            for (int i = 0; i < thamSo.nOe; i++)
            {
                pnlExcution.Controls.Remove(thamSo.arrLbl[i]); // xóa mảng 
            }
            bntPlay.Show();             // Hiển thị nút Play 
            thamSo.checkSpace = true;   
            speedTrackBar.Value = 30;   //Cho trackBar giá trị mặc định khi reset 
        }
        #endregion

        #region Control
        private void bntPlay_Click(object sender, EventArgs e)
        {
            bntPlay.Hide();             // Ẩn nút Play
            bntPause.Show();            // Hiện nút Pause
            thamSo.checkSpace = false;  // Xác nhận nút Play vừa được nhận 
            pnlExTime.Visible = true;   // Hiển thị Execution Time 
            ExTime.Start();             // Timer ExTime bắt đầu or tiếp tục tính

            #region Enabled Control
            bntBack.Enabled = false;
            bntReset.Enabled = false;

            // không cho tích dấu vào các ô của thuật toán vì chưa tạo giá trị phù hợp
            // Nên cho các giá trị nhập bằng tay hoặc Random để có thể lựa chọn thuật toán
            radSelection.Enabled = false;
            radBubble.Enabled = false;
            radShell.Enabled = false;
            radQuick.Enabled = false;
            radHeap.Enabled = false;
            radInsertion.Enabled = false;
            radInterchange.Enabled = false;
            radMerge.Enabled = false;

            // Kiểm tra các dấu tích, nếu vô thuật toán nào thì thực hiện
            #endregion
            if (thamSo.checkPause == false && thamSo.programIsStart == false) 
            {
                thamSo.programIsStart = true;
                if (radSelection.Checked == true && thamSo.increase == true)
                    SelectionSortincrease(thamSo.arrNode);
                if (radSelection.Checked == true && thamSo.increase == false)
                    SelectionSortGiam(thamSo.arrNode);
                if (radBubble.Checked == true && thamSo.increase == true)
                    BubbleSortincrease(thamSo.arrNode);
                if (radBubble.Checked == true && thamSo.increase == false)
                    BubbleSortGiam(thamSo.arrNode);
                if (radShell.Checked == true && thamSo.increase == true)
                    ShellSortincrease(thamSo.arrNode);
                if (radShell.Checked == true && thamSo.increase == false)
                    ShellSortGiam(thamSo.arrNode);
                if (radQuick.Checked == true && thamSo.increase == true)
                    QuickSortincrease(thamSo.arrNode, 0, thamSo.nOe - 1);
                if (radQuick.Checked == true && thamSo.increase == false)
                    QuickSortGiam(thamSo.arrNode, 0, thamSo.nOe - 1);
                if (radHeap.Checked == true && thamSo.increase == true)
                    HeapSortincrease(thamSo.nOe);
                if (radHeap.Checked == true && thamSo.increase == false)
                    HeapSortGiam(thamSo.nOe);
                if (radInsertion.Checked == true && thamSo.increase == true)
                    InsertionSortincrease(thamSo.arrNode);
                if (radInsertion.Checked == true && thamSo.increase == false)
                    InsertionSortGiam(thamSo.arrNode);
                if (radInterchange.Checked == true && thamSo.increase == true)
                    InterchangeSortincrease(thamSo.arrNode);
                if (radInterchange.Checked == true && thamSo.increase == false)
                    InterchangeSortGiam(thamSo.arrNode);
                if (radMerge.Checked == true && thamSo.increase == true)
                    MergeSortincrease();
                if (radMerge.Checked == true && thamSo.increase == false)
                    MergeSortGiam();
                CompleteSwap(); // Hàm xử lí sau khi hoàn thành
            }
            else
            {
                thamSo.checkPause = false; 
            }
            
        }
        private void bntPause_Click(object sender, EventArgs e)
        {
            bntPlay.Show();                 
            bntPause.Hide();
            thamSo.checkSpace = true;   
            thamSo.checkPause = true;
            ExTime.Stop();              // Dừng timer, tạm dưng thời gian tính toán 
            Play_or_Stop();             // Kiểm tra chương trình đang chạy hay dừng
        }
        public void Pause()                 // Hàm này dùng cho Debug
        {
            if (ckDebug.Checked == true)    // Kiểm tra Debug
            {
                thamSo.checkPause = true;   // Nếu đang tích dấu vào ô Debug thì tạm dừng để quan sát
                Play_or_Stop();             // Kiểm tra lại còn dấu tích không
            }
        }
        public void Play_or_Stop()
        {
            while (thamSo.checkPause == true)
            {
                Application.DoEvents();     
            }
        }
        #endregion

        #region Debug

        private void ckDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDebug.Checked == true)
            {
                speedTrackBar.Value = speedTrackBar.Maximum - 7;
            }
            else
            {
                speedTrackBar.Value = speedTrackBar.Maximum / 2;
                thamSo.checkPause = false;
            }
        }
        private void bntDebug_Click(object sender, EventArgs e)
        {
            thamSo.checkPause = false;
        }
        #endregion

        #region Create Array
        private void bntRandom_Click(object sender, EventArgs e)
        {
            pnlChosesAlgorithms.Enabled = true;
            grpControl.Enabled = true;
            grpDebug.Enabled = true;
            Random r = new Random();
            for (int i = 0; i < thamSo.nOe; i++)
            {
                int rd = r.Next(0, 99);

                thamSo.arrLbl[i].Text = rd + "";
                thamSo.arrNode[i] = rd;
            }
            ShowCode();
        }

        private void bntByHand_Click(object sender, EventArgs e)
        {
            pnlChosesAlgorithms.Enabled = true;
            grpControl.Enabled = true;
            grpDebug.Enabled = true;
            ShowCode();
            frmByHand a = new frmByHand();
            a.Message = numArray.Value.ToString();
            a.ShowDialog();
            for (int i = 0; i < thamSo.nOe; i++)
            {

                switch (i + 1)
                {
                    case 1: thamSo.arrLbl[i].Text = PT1; thamSo.arrNode[i] = Int32.Parse(PT1); break;
                    case 2: thamSo.arrLbl[i].Text = PT2; thamSo.arrNode[i] = Int32.Parse(PT2); break;
                    case 3: thamSo.arrLbl[i].Text = PT3; thamSo.arrNode[i] = Int32.Parse(PT3); break;
                    case 4: thamSo.arrLbl[i].Text = PT4; thamSo.arrNode[i] = Int32.Parse(PT4); break;
                    case 5: thamSo.arrLbl[i].Text = PT5; thamSo.arrNode[i] = Int32.Parse(PT5); break;
                    case 6: thamSo.arrLbl[i].Text = PT6; thamSo.arrNode[i] = Int32.Parse(PT6); break;
                    case 7: thamSo.arrLbl[i].Text = PT7; thamSo.arrNode[i] = Int32.Parse(PT7); break;
                    case 8: thamSo.arrLbl[i].Text = PT8; thamSo.arrNode[i] = Int32.Parse(PT8); break;
                    case 9: thamSo.arrLbl[i].Text = PT9; thamSo.arrNode[i] = Int32.Parse(PT9); break;
                    case 10: thamSo.arrLbl[i].Text = PT10; thamSo.arrNode[i] = Int32.Parse(PT10); break;
                }
            }
            pnlChosesAlgorithms.Enabled = true;
            grpControl.Enabled = true;
        }

        private void radDecrease_CheckedChanged(object sender, EventArgs e)
        {
            thamSo.increase = false;
            ShowCode();
        }

        private void radIncrease_CheckedChanged(object sender, EventArgs e)
        {
            thamSo.increase = true;
            ShowCode();
        }
        #endregion

        #endregion

        #region bntBack_Click
        private void bntBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmIntroduct frm1 = new frmIntroduct();
            frm1.Show();

        }
        #endregion
        #region bntExit_Click
        private void bntExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit application, now?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        int min(int a, int b)
        {
            if (a > b)
                return b;
            else
                return a;
        }
        #endregion

        #region bntSourceCode_Click
        private void bntSourceCode_Click(object sender, EventArgs e)
        {
            listCode.Show();
            listIdea.Hide();
        }
        #endregion
        #region bntIdea_Click
        private void bntIdeaAlgorithm_Click(object sender, EventArgs e)
        {
            listIdea.Show();
            listCode.Hide();
        }
        #endregion

        #region ExTime

        private void ExTime_Tick(object sender, EventArgs e)
        {
            if (int.Parse(lblSeconds.Text) == 59)
            {
                lblSeconds.Text = "00";
                lblMinutes.Text = (int.Parse(lblMinutes.Text) + 1).ToString("00");
            }
            else
            {
                lblSeconds.Text = (int.Parse(lblSeconds.Text) + 1).ToString("00");
            }
        }
        #endregion

        #region speedTrackBar_ValueChanged
        private void speedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            thamSo.speed = speedTrackBar.Maximum - speedTrackBar.Value;
        }
        #endregion

        #region rad"Sort"_CheckedChanged
        private void radQuick_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radHeap_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radBubble_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radShell_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radMerge_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radInsertion_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radInterchange_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radSelection_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        #endregion
        #endregion
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
        #region Delay
        //Hàm Delay
        public void Delay(int milisecond)
        {
            //Nếu tốc độ max thì ko sleep
            if (speedTrackBar.Value == speedTrackBar.Maximum)
            {
                Application.DoEvents();
                return;
            }
            Application.DoEvents();
            Thread.Sleep(milisecond);
        }
        #endregion
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                if (thamSo.checkSpace == true)
                    bntPlay.PerformClick();
                else
                    bntPause.PerformClick();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                bntExit.PerformClick();
                return true;
            }
            else if (keyData == Keys.Back)
            {
                bntBack.PerformClick();
                return true;
            }
            else if (keyData == Keys.F10)

            {
                bntDebug.PerformClick();
                return true;
            }
            else if (keyData == Keys.F5)
            {
                bntReset.PerformClick();
                return true;
            }
            else if (keyData == Keys.C)
            {
                bntCreate.PerformClick();
                return true;
            }
            else if (keyData == Keys.R)
            {
                bntRandom.PerformClick();
                return true;
            }
            else if (keyData == Keys.H)
            {
                bntByHand.PerformClick();
                return true;
            }
            else if (keyData == Keys.Up && speedTrackBar.Value < speedTrackBar.Maximum)
            {
                speedTrackBar.Value += 1;
                return true;
            }
            else if (keyData == Keys.Down && speedTrackBar.Value > speedTrackBar.Minimum)
            {
                speedTrackBar.Value -= 1;
                return true;
            }
            else if (keyData == Keys.F1)
            {
                btnHelp.PerformClick();
                return true;
            }
            else if (keyData == Keys.S)
            {
                bntSourceCode.PerformClick();
                return true;
            }
            else if (keyData == Keys.I)
            {
                bntIdeaAlgorithm.PerformClick();
                return true;
            }
            else return false;
        }
        
    }
}

