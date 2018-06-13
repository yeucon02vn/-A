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
using CODE;
using YTUONG;
using THAMSO;

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
        ThamSo ts = new ThamSo();
         
        Color colorMove = Color.LightGreen;
        Color colorComplete = Color.DarkViolet;
        Color colorDefault = Color.Orange;
        Color colorQuickU = Color.AliceBlue;
        Color colorQuickD = Color.Aquamarine;
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
            ts.nOe = (int)numArray.Value;
            Init();
            ts.speed = 60;
            speedTrackBar.Maximum = ts.speed;
            speedTrackBar.Minimum = 0;
            speedTrackBar.Value = ts.speed / 2;
            speedTrackBar.LargeChange = 1;
            AddPanel();
        }

        public void Init()
        {
            grpCreateArray.Enabled = false;
            pnlLoaiThuatToan.Enabled = false;
            grpControl.Enabled = false;
            grpDebug.Enabled = false;
            ts.increase = true;
            bntReset.Enabled = false;
            listIdea.Hide();
        }

        #endregion

        #region Complete Swap
        public void CompleteSwap()
        {
            ts.nOe = (int)numArray.Value;
            for (int i = 0; i < ts.nOe; i++)
                ts.arrLbl[i].BackColor = Color.Aqua;
            Complete();
        }
        #endregion          

        #region numArray_ValueChanged
        private void numArray_ValueChanged(object sender, EventArgs e)
        {
            ts.nOe = int.Parse(numArray.Value.ToString());
        }
        #endregion

        #region Hàm phân phối a cho b và c
        #region functions moving
        public void Node_Right(Control t, int Step)
        {
            Application.DoEvents();

            this.Invoke((MethodInvoker)delegate
            {
                int Loop_Count = ((ts.sizeN + ts.disN)) * Step; //Số lần dịch chuyển
                {
                    while (Loop_Count > 0)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Delay(ts.speed);
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
                int Loop_Count = ((ts.sizeN + ts.disN)) * Step; //Số lần dịch chuyển
                while (Loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Left -= 1;
                    Delay(ts.speed);
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
                    Delay(ts.speed);
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
                    Delay(ts.speed);
                    loop_Count--;
                    t.BackColor = colorMove;
                }
                t.Refresh();
            });
        }
        public void toLocaN(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(ts.firstN + (ts.sizeN + ts.disN) * i, 150);//vị trí của Node i
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
                        Delay(ts.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y + ((p1.Y - p2.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Delay(ts.speed);
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
                        Delay(ts.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Delay(ts.speed);
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
                        Delay(ts.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y)
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Delay(ts.speed);
                        t.Refresh();
                    }
                }
            });
        }
        // Dịch chuyển 1 Node về vị trí bằng với X của Node[i]
        public void Den_tdo_x_node(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(ts.firstN + (ts.sizeN + ts.disN) * i, 150);//vị trí của Node i
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
                        Delay(ts.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Delay(ts.speed);
                        t.Refresh();
                    }
                }

            });
        }
        #endregion
        #region functions conversion
        public void Swap_NodeAn(int a, int b)
        {
            Label temp = ts.arrLbl[a];
            ts.arrLbl[a] = ts.arrLbl[b];
            ts.arrLbl[b] = temp;
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
                    while ((t1.Location.Y > p1.Y - (ts.sizeN + 5)) || (t2.Location.Y < p2.Y + (ts.sizeN + 5)))
                    {
                        Application.DoEvents();
                        t1.Top -= 1;
                        t2.Top += 1;
                        Thread.Sleep(ts.speed);

                    }
                    // t1 dịch phải, t2 dịch trái
                    if (t1.Location.X < t2.Location.X)
                    {

                        while ((t1.Location.X < p2.X) || (t2.Location.X > p1.X))
                        {
                            Application.DoEvents();
                            t1.Left += 1;
                            t2.Left -= 1;
                            Thread.Sleep(ts.speed);


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
                            Thread.Sleep(ts.speed);

                        }

                    }
                    // t1 xuống, t2 lên
                    while ((t1.Location.Y < p2.Y) || (t2.Location.Y > p1.Y))
                    {
                        Application.DoEvents();
                        t1.Top += 1;
                        t2.Top -= 1;
                        Thread.Sleep(ts.speed);

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

            ChonDongChoCodeListBox(2);
            int i = 0, j = 0;
            Mui_ten_xanh_len_1.Text = "i = " + i;
            Mui_ten_xanh_len_1.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * i, pnlChayMau.Height - 50);
            Mui_ten_xanh_len_1.Visible = true;
            Refresh();
            for (i = 0; i < ts.nOe - 1; i++)
            {
                ChonDongChoCodeListBox(3);
                j = i + 1;
                Mui_ten_xanh_len_2.Text = "j = " + j;
                Mui_ten_xanh_len_2.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * j, pnlChayMau.Height - 50);
                Mui_ten_xanh_len_2.Visible = true;
                Refresh();
                for (j = i + 1; j < ts.nOe; j++)
                {
                    ChonDongChoCodeListBox(4);
                    lbl_status_02.Text = "SoSanh(a[" + i + "],a[" + j + "])";
                    lbl_status_02.Visible = true;
                    if (ts.arrNode[j] < ts.arrNode[i])
                    {
                        ChonDongChoCodeListBox(6);
                        lbl_status_02.Text = "HoanVi(a[" + i + "],a[" + j + "])";
                        Swap_Giatri(ref ts.arrNode[j], ref ts.arrNode[i]);
                        Swap_Node(ts.arrLbl[j], ts.arrLbl[i]);
                        Swap_NodeAn(j, i);
                        ts.arrLbl[i].BackColor = colorComplete;
                    }
                    if (j + 1 < ts.nOe)
                    {
                        Mui_ten_xanh_len_2.Text = "j = " + (j + 1);
                        Mui_ten_xanh_len_2.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * (j + 1), pnlChayMau.Height - 50);
                        Refresh();
                    }
                    ts.arrLbl[i].BackColor = colorDefault;
                }
                ChonDongChoCodeListBox(3);
                lbl_status_02.Visible = false;
                Mui_ten_xanh_len_1.Text = "i = " + (i + 1);
                Mui_ten_xanh_len_1.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * (i + 1), pnlChayMau.Height - 50);
                Refresh();
            }
            ChonDongChoCodeListBox(0);
        }

        private void InterchangeSortGiam(int[] arrNode)
        {
            ChonDongChoCodeListBox(2);
            int i = 0, j = 0;
            Mui_ten_xanh_len_1.Text = "i = " + i;
            Mui_ten_xanh_len_1.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * i, pnlChayMau.Height - 50);
            Mui_ten_xanh_len_1.Visible = true;
            for (i = 0; i < ts.nOe - 1; i++)
            {
                ChonDongChoCodeListBox(3);
                j = i + 1;
                Mui_ten_xanh_len_2.Text = "j = " + j;
                Mui_ten_xanh_len_2.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * j, pnlChayMau.Height - 50);
                Mui_ten_xanh_len_2.Visible = true;
                for (j = i + 1; j < ts.nOe; j++)
                {
                    ChonDongChoCodeListBox(4);
                    lbl_status_02.Text = "SoSanh(a[" + i + "],a[" + j + "])";
                    lbl_status_02.Visible = true;
                    if (ts.arrNode[j] > ts.arrNode[i])
                    {
                        ChonDongChoCodeListBox(6);
                        lbl_status_02.Text = "HoanVi(a[" + i + "],a[" + j + "])";
                        Swap_Giatri(ref ts.arrNode[i], ref ts.arrNode[j]);
                        Swap_Node(ts.arrLbl[j], ts.arrLbl[i]);
                        Swap_NodeAn(j, i);
                        ts.arrLbl[i].BackColor = colorComplete;
                    }
                    if (j + 1 < ts.nOe)
                    {
                        Mui_ten_xanh_len_2.Text = "j = " + (j + 1);
                        Mui_ten_xanh_len_2.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * (j + 1), pnlChayMau.Height - 50);
                        Refresh();
                    }
                    ts.arrLbl[i].BackColor = colorDefault;
                }
                ChonDongChoCodeListBox(3);
                lbl_status_02.Visible = false;
                Mui_ten_xanh_len_1.Text = "i = " + (i + 1);
                Mui_ten_xanh_len_1.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * (i + 1), pnlChayMau.Height - 50);
            }
            ChonDongChoCodeListBox(0);
        }
        #endregion
        #region selection
        private void SelectionSortincrease(int[] arrNode)
        {
            int min;
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < ts.nOe - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    ChonDongChoCodeListBox(5);

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    min = i;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Text = "Min=" + min;
                    Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * min) + (ts.sizeN / 2) - 30, ts.arrLbl[min].Location.Y + 2 * ts.sizeN + 5);
                    Mui_ten_xanh_len_1.Refresh();

                    for (int j = i + 1; j < ts.nOe; j++)
                    {
                        ChonDongChoCodeListBox(6);
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "SoSanh( a[min] , a[" + j + "] )";
                        lbl_status_02.Refresh();
                        if (ts.arrNode[j] < ts.arrNode[min])
                        {
                            ChonDongChoCodeListBox(8);
                            min = j;
                            Mui_ten_xanh_len_1.Text = "Min=" + min;
                            Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * min) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y + 2 * ts.sizeN + 5);
                            Mui_ten_xanh_len_1.Refresh();
                        }

                    }
                    if (min != i)
                    {
                        ChonDongChoCodeListBox(10);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "HoanVi( a[i] , a[min] )";
                        Swap_Giatri(ref ts.arrNode[min], ref ts.arrNode[i]);
                        Swap_Node(ts.arrLbl[min], ts.arrLbl[i]);
                        Swap_NodeAn(min, i);
                        ts.arrLbl[i].BackColor = colorComplete;
                        ts.arrLbl[min].BackColor = colorDefault;
                    }
                    else
                        ts.arrLbl[i].BackColor = colorComplete;
                    lbl_status_02.Visible = false;

                }
            });
            ChonDongChoCodeListBox(0);
        }
        private void SelectionSortGiam(int[] arrNode)
        {
            int max;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < ts.nOe - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    ChonDongChoCodeListBox(5);
                    max = i;

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Text = "Max=" + max;
                    Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * max) + (ts.sizeN / 2) - 30, ts.arrLbl[max].Location.Y + 2 * ts.sizeN + 5);
                    Mui_ten_xanh_len_1.Refresh();
                    for (int j = i + 1; j < ts.nOe; j++)
                    {
                        ChonDongChoCodeListBox(6);
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);

                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "SoSanh( a[max] , a[" + j + "] )";
                        if (ts.arrNode[j] > ts.arrNode[max])
                        {
                            max = j;
                            Mui_ten_xanh_len_1.Text = "Max=" + max;
                            Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * max) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y + 2 * ts.sizeN + 5);
                            Mui_ten_xanh_len_1.Refresh();
                        }
                    }
                    if (max != i)
                    {
                        ChonDongChoCodeListBox(10);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "HoanVi( a[i] , a[max] )";
                        Swap_Giatri(ref ts.arrNode[max], ref ts.arrNode[i]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(ts.arrLbl[max], ts.arrLbl[i]);
                        Swap_NodeAn(max, i);
                        ts.arrLbl[i].BackColor = colorComplete;
                        ts.arrLbl[max].BackColor = colorDefault;
                    }
                    else
                        ts.arrLbl[i].BackColor = colorComplete;
                    lbl_status_02.Visible = false;
                }
            });
            ChonDongChoCodeListBox(0);
        }
        #endregion
        #region shell
        private void ShellSortincrease(int[] arrNode)
        {

            for (int i = ts.nOe / 2; i > 0; i /= 2)
            {
                ChonDongChoCodeListBox(2);
                Mui_ten_xanh_xuong_1.Text = "i = " + i;
                Mui_ten_xanh_xuong_1.Location = new Point(ts.firstN - 10 + (ts.sizeN + ts.disN) * 0, 40);
                Mui_ten_xanh_xuong_1.SendToBack();
                Mui_ten_xanh_xuong_1.Visible = true;

                for (int j = i; j < ts.nOe; j++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_len_1.Text = "j = " + j;
                    Mui_ten_xanh_len_1.Location = new Point(ts.firstN - 10 + (ts.sizeN + ts.disN) * j, 40);
                    Mui_ten_xanh_len_1.Visible = true;


                    for (int k = j; k >= i && ts.arrNode[k] < ts.arrNode[k - i]; k -= i)
                    {
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_xuong_2.Text = "k = " + k;
                        Mui_ten_xanh_xuong_2.Location = new Point(ts.firstN - 10 + (ts.sizeN + ts.disN) * k, pnlChayMau.Height - 50);
                        Mui_ten_xanh_xuong_2.SendToBack();
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Text = "HoanVi(a[" + k + "],a[" + (k - 1) + "])";
                        lbl_status_02.Visible = true;
                        Swap_Giatri(ref ts.arrNode[k - i], ref ts.arrNode[k]);
                        Swap_Node(ts.arrLbl[k], ts.arrLbl[k - i]);
                        Swap_NodeAn(k, k - i);
                        ts.arrLbl[k - i].BackColor = colorDefault;
                        ts.arrLbl[k].BackColor = colorDefault;
                    }
                    lbl_status_02.Visible = false;
                    ChonDongChoCodeListBox(3);
                }
            }
            ChonDongChoCodeListBox(0);
        }
        private void ShellSortGiam(int[] arrNode)
        {
            for (int i = ts.nOe / 2; i > 0; i /= 2)
            {
                ChonDongChoCodeListBox(2);
                Mui_ten_xanh_xuong_1.Text = "i = " + i;
                Mui_ten_xanh_xuong_1.Location = new Point(ts.firstN - 10 + (ts.sizeN + ts.disN) * 0, 40);
                Mui_ten_xanh_xuong_1.SendToBack();
                Mui_ten_xanh_xuong_1.Visible = true;
                for (int j = i; j < ts.nOe; j++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_len_1.Text = "j = " + j;
                    Mui_ten_xanh_len_1.Location = new Point(ts.firstN - 10 + (ts.sizeN + ts.disN) * j, 40);
                    Mui_ten_xanh_len_1.Visible = true;
                    for (int k = j; k >= i && ts.arrNode[k] > ts.arrNode[k - i]; k -= i)
                    {
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_xuong_2.Text = "k = " + k;
                        Mui_ten_xanh_xuong_2.Location = new Point(ts.firstN - 10 + (ts.sizeN + ts.disN) * k, pnlChayMau.Height - 50);
                        Mui_ten_xanh_xuong_2.SendToBack();
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Text = "HoanVi(a[" + k + "],a[" + (k - 1) + "])";
                        lbl_status_02.Visible = true;
                        Swap_Giatri(ref ts.arrNode[k - i], ref ts.arrNode[k]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(ts.arrLbl[k], ts.arrLbl[k - i]);
                        Swap_NodeAn(k, k - i);
                        ts.arrLbl[k - i].BackColor = colorDefault;
                        ts.arrLbl[k].BackColor = colorDefault;
                    }
                    lbl_status_02.Visible = false;
                    ChonDongChoCodeListBox(3);
                }
            }
            ChonDongChoCodeListBox(0);
        }
        #endregion
        #region bubble
        private void BubbleSortincrease(int[] arrNode)
        {
            int i, j;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < ts.nOe - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = ts.nOe - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y + 2 * ts.sizeN + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Visible = true;
                        if (ts.arrNode[j] < ts.arrNode[j - 1])
                        {
                            //Hieu ung xem code
                            ChonDongChoCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref ts.arrNode[j], ref ts.arrNode[j - 1]);
                            Swap_Node(ts.arrLbl[j], ts.arrLbl[j - 1]);
                            Swap_NodeAn(j, j - 1);
                            ts.arrLbl[j - 1].BackColor = colorComplete;
                        }
                        ts.arrLbl[j].BackColor = colorDefault;
                    }
                    //Cập nhật Status
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();

                }
                lbl_status_02.Visible = false;
            });
            ChonDongChoCodeListBox(0);
        }
        private void BubbleSortGiam(int[] arrNode)
        {
            int i, j;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < ts.nOe - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = ts.nOe - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y + 2 * ts.sizeN + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Visible = true;
                        if (ts.arrNode[j] > ts.arrNode[j - 1])
                        {
                            //Hieu ung xem code
                            ChonDongChoCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref ts.arrNode[j], ref ts.arrNode[j - 1]);
                            Swap_Node(ts.arrLbl[j], ts.arrLbl[j - 1]);
                            Swap_NodeAn(j, j - 1);
                            ts.arrLbl[j - 1].BackColor = colorComplete;
                        }
                        ts.arrLbl[j].BackColor = colorDefault;
                    }
                    //Cập nhật Status
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();

                }
                lbl_status_02.Visible = false;
            });
            ChonDongChoCodeListBox(0);
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
                for (i = 1; i < ts.nOe; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    Dem_node = 0;
                    ChonDongChoCodeListBox(5);
                    x = ts.arrNode[i];
                    Node_tam = ts.arrLbl[i];
                    Chi_so_tam = i;
                    pos = i - 1;
                    //thiết lập mũi tên đánh dấu nút cần chèn


                    //Di chuyển Node cần chèn lên
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(Node_tam, (ts.sizeN + 5));
                    });

                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i)";

                    //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                    Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * pos) + (ts.sizeN / 2) - 30, ts.arrLbl[pos].Location.Y + ts.sizeN + 5);
                    Mui_ten_xanh_len_1.Text = "POS=" + pos;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Refresh();
                    //lbl_status_02.Visible = false
                    while ((pos >= 0) && (ts.arrNode[pos] > x))
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * pos) + (ts.sizeN / 2) - 30, ts.arrLbl[pos].Location.Y + ts.sizeN + 5);
                        Mui_ten_xanh_len_1.Text = "POS=" + pos;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Refresh();
                        //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        


                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i])";
                        ChonDongChoCodeListBox(9);
                        //Dịch chuyển Node qua phải
                        ts.arrNode[pos + 1] = ts.arrNode[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_Right(ts.arrLbl[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        ChonDongChoCodeListBox(10);
                        pos--;
                        ChonDongChoCodeListBox(12);
                        ts.arrNode[pos + 1] = x;
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
                        ts.arrLbl[pos + 1].BackColor = colorDefault;
                    });

                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(Node_tam, (ts.sizeN + 5));
                        //ts.arrLbl[pos+1].BackColor = colorComplete;
                        ts.arrLbl[pos + 1].BackColor = colorDefault;
                    });
                    lbl_status_02.Visible = false;
                    Mui_ten_xanh_len_1.Visible = false; ;
                    ts.arrLbl[pos + 1] = Node_tam;
                }
            });
            ChonDongChoCodeListBox(0);
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
                for (i = 1; i < ts.nOe; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Application.DoEvents();
                    //Thiết lập Node đầu tiên, là Node đã có thứ tự 
                    //đềm số bước dịch chuyển 1 Node
                    Dem_node = 0;
                    ChonDongChoCodeListBox(5);
                    x = ts.arrNode[i];
                    Node_tam = ts.arrLbl[i];
                    Chi_so_tam = i;
                    pos = i - 1;
                    //thiết lập mũi tên đánh dấu nút cần chèn
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Refresh();

                    //Di chuyển Node cần chèn lên
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(Node_tam, (ts.sizeN + 5));
                    });

                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i])";
                    //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                    Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * pos) + (ts.sizeN / 2) - 30, ts.arrLbl[pos].Location.Y + ts.sizeN + 5);
                    Mui_ten_xanh_len_1.Text = "POS=" + pos;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Refresh();
                    //lbl_status_02.Visible = false;
                    while ((pos >= 0) && (ts.arrNode[pos] < x))
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                        Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * pos) + (ts.sizeN / 2) - 30, ts.arrLbl[pos].Location.Y + ts.sizeN + 5);
                        Mui_ten_xanh_len_1.Text = "POS=" + pos;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Refresh();

                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i])";

                        ChonDongChoCodeListBox(9);
                        //Dịch chuyển Node qua phải
                        ts.arrNode[pos + 1] = ts.arrNode[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_Right(ts.arrLbl[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        ts.arrLbl[pos].BackColor = colorComplete;
                        ChonDongChoCodeListBox(10);
                        pos--;
                        ChonDongChoCodeListBox(12);
                        ts.arrNode[pos + 1] = x;


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
                        ts.arrLbl[pos + 1].BackColor = colorDefault;
                    });

                    Application.DoEvents();
                    Delay(ts.speed * 30);
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(Node_tam, (ts.sizeN + 5));
                        ts.arrLbl[pos + 1].BackColor = colorDefault;
                    });
                    //Ẩn status
                    lbl_status_02.Visible = false;
                    //Ẩn mũi tên POS sau khi đã tìm ra POS
                    Mui_ten_xanh_len_1.Visible = false; ;
                    //Thiết lập node nằm trong nhóm đã có thứ tự
                    ts.arrLbl[pos + 1] = Node_tam;
                    //Tạm dừng sau 1 bước dịch chuyển Node
                }
            });
            ChonDongChoCodeListBox(0);
        }
        #endregion
        #region quick
        private void QuickSortincrease(int[] arrNode, int left, int right)
        {
            if (left < right)
            {
                int pivot = ts.arrNode[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left


                ChonDongChoCodeListBox(2);

                Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * left) + (ts.sizeN / 2) - 30, ts.arrLbl[left].Location.Y + 2 * ts.sizeN + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * right) + (ts.sizeN / 2) - 30, ts.arrLbl[right].Location.Y + 2 * ts.sizeN + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                //

                //doi mau node x


                //Đặt màu nút x                    
                //         
                ChonDongChoCodeListBox(3);
                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * cs_x) + (ts.sizeN / 2) - 30, ts.arrLbl[cs_x].Location.Y + 2 * ts.sizeN + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Thiết lập mũi tên chỉ i

                ChonDongChoCodeListBox(4);
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ChonDongChoCodeListBox(5);

                do
                {

                    ChonDongChoCodeListBox(7);
                    lbl_status_02.Text = "SoSanh(a[" + i + "], a[x])";
                    lbl_status_02.Visible = true;
                    while (ts.arrNode[i] < pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        // lbl_status_02.Text = "SoSanh(a[" + i + "], a[x])";
                    }
                    ChonDongChoCodeListBox(8);
                    lbl_status_02.Text = "SoSanh(a[" + j + "], a[x])";
                    while (ts.arrNode[j] > pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //

                    }
                    ChonDongChoCodeListBox(9);

                    if (i <= j)
                    {
                        ChonDongChoCodeListBox(11);
                        lbl_status_02.Text = "HoanVi(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref ts.arrNode[i], ref ts.arrNode[j]);
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        Swap_Node(ts.arrLbl[j], ts.arrLbl[i]);
                        Swap_NodeAn(j, i);
                        ts.arrLbl[j].BackColor = colorComplete;
                        ts.arrLbl[i].BackColor = colorDefault;
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * cs_x) + (ts.sizeN / 2) - 30, ts.arrLbl[cs_x].Location.Y + 2 * ts.sizeN + 40);
                        Mui_ten_do_len.Text = "X = " + ((left + right) / 2);
                        Mui_ten_do_len.Refresh();
                        ChonDongChoCodeListBox(12);
                        i++;
                        j--;
                    }
                }
                while (i <= j);
                ChonDongChoCodeListBox(16);
                if (left < j)
                {
                    ChonDongChoCodeListBox(17);
                    QuickSortincrease(ts.arrNode, left, j);
                }
                ChonDongChoCodeListBox(18);
                if (i < right)
                {
                    ChonDongChoCodeListBox(19);
                    QuickSortincrease(ts.arrNode, i, right);
                }
            }
        }
        private void QuickSortGiam(int[] arrNode, int left, int right)
        {
            if (left < right)
            {
                int pivot = ts.arrNode[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left
                Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * left) + (ts.sizeN / 2) - 30, ts.arrLbl[left].Location.Y + 2 * ts.sizeN + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * right) + (ts.sizeN / 2) - 30, ts.arrLbl[right].Location.Y + 2 * ts.sizeN + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                //

                //doi mau node x

                ChonDongChoCodeListBox(2);


                cs_x = (left + right) / 2;

                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * cs_x) + (ts.sizeN / 2) - 30, ts.arrLbl[cs_x].Location.Y + 2 * ts.sizeN + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Đặt màu nút x                    
                //
                i = left; j = right;
                ChonDongChoCodeListBox(3);
                //Thiết lập mũi tên chỉ i
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ChonDongChoCodeListBox(5);
                do
                {
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    ChonDongChoCodeListBox(7);
                    while (ts.arrNode[i] > pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    }
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    ChonDongChoCodeListBox(8);
                    while (ts.arrNode[j] < pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    }
                    ChonDongChoCodeListBox(9);
                    if (i <= j)
                    {
                        //status hoán vị             
                        lbl_status_02.Text = "Hoan_Vi(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref ts.arrNode[i], ref ts.arrNode[j]);
                        ChonDongChoCodeListBox(11);
                        //Tìm vị trí mới của x
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        Swap_Node(ts.arrLbl[i], ts.arrLbl[j]);
                        Swap_NodeAn(i, j);
                        ts.arrLbl[i].BackColor = colorComplete;
                        ts.arrLbl[j].BackColor = colorDefault;
                        //Thiết lập vị trí của 
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * cs_x) + (ts.sizeN / 2) - 30, ts.arrLbl[cs_x].Location.Y + 2 * ts.sizeN + 40);
                        Mui_ten_do_len.Text = "X = " + ((left + right) / 2);
                        Mui_ten_do_len.Refresh();
                        ChonDongChoCodeListBox(12);

                        i++; j--;

                    }

                } while (i <= j);
                //Đặt màu nút x
                ChonDongChoCodeListBox(16);
                if (left < j)
                {
                    ChonDongChoCodeListBox(18);
                    QuickSortGiam(ts.arrNode, left, j);
                }
                if (i < right)
                {
                    ChonDongChoCodeListBox(19);
                    QuickSortGiam(ts.arrNode, i, right);
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
            Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
            Mui_ten_xanh_xuong_1.Text = "i=" + i;
            Mui_ten_xanh_xuong_1.Refresh();
            //thiết lập mũi tên chỉ j
            Mui_ten_xanh_xuong_2.Visible = true;
            Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
            Mui_ten_xanh_xuong_2.Text = "j=" + j;
            Mui_ten_xanh_xuong_2.Refresh();
            x = ts.arrNode[i];
            temp = ts.arrLbl[i];
            index_temp = i;

            while (j <= r)
            {

                Application.DoEvents();

                if (j < r)

                    if (ts.arrNode[j] < ts.arrNode[j + 1])

                        j++;
                //thiết lập mũi tên chỉ j

                Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();

                if (ts.arrNode[j] <= x)
                    return;
                else
                {
                    ts.arrNode[i] = ts.arrNode[j];
                    ts.arrNode[j] = x;
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Swap_Node(ts.arrLbl[j], temp);
                    });

                    Swap_NodeAn(j, index_temp);
                    if (ckDebug.Checked == true)
                        Pause();
                    else
                        Delay(5 * ts.speed);
                    i = j;
                    j = 2 * i + 1;
                    if (j <= r)
                    {
                        //Thiết lập mũi tên chỉ i

                        Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //thiết lập mũi tên chỉ j

                        Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                    }
                    x = ts.arrNode[i];
                    temp = ts.arrLbl[i];
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
            Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
            Mui_ten_xanh_xuong_1.Text = "i=" + i;
            Mui_ten_xanh_xuong_1.Refresh();
            //thiết lập mũi tên chỉ j
            Mui_ten_xanh_xuong_2.Visible = true;
            Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
            Mui_ten_xanh_xuong_2.Text = "j=" + j;
            Mui_ten_xanh_xuong_2.Refresh();
            x = ts.arrNode[i];
            temp = ts.arrLbl[i];
            index_temp = i;

            while (j <= r)
            {

                Application.DoEvents();

                if (j < r)

                    if (ts.arrNode[j] > ts.arrNode[j + 1])

                        j++;
                //thiết lập mũi tên chỉ j

                Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();

                if (ts.arrNode[j] >= x)
                    return;
                else
                {
                    ts.arrNode[i] = ts.arrNode[j];
                    ts.arrNode[j] = x;
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Swap_Node(ts.arrLbl[j], temp);
                    });
                    Swap_NodeAn(j, index_temp);
                    if (ckDebug.Checked == true)
                        Pause();
                    else
                        Delay(5 * ts.speed);
                    i = j;
                    j = 2 * i + 1;
                    if (j <= r)
                    {
                        //Thiết lập mũi tên chỉ i

                        Mui_ten_xanh_xuong_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * i) + (ts.sizeN / 2) - 30, ts.arrLbl[i].Location.Y - ts.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //thiết lập mũi tên chỉ j

                        Mui_ten_xanh_xuong_2.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * j) + (ts.sizeN / 2) - 30, ts.arrLbl[j].Location.Y - ts.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                    }
                    x = ts.arrNode[i];
                    temp = ts.arrLbl[i];
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
            Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * r) + (ts.sizeN / 2) - 30, ts.arrLbl[r].Location.Y + 2 * ts.sizeN + 5);
            Mui_ten_xanh_len_1.Text = "r=" + r;
            Mui_ten_xanh_len_1.Visible = true;
            Mui_ten_xanh_len_1.Refresh();
            listCode.SelectedIndex = 5;
            while (r > 0)
            {
                Application.DoEvents();
                Swap_Giatri(ref ts.arrNode[0], ref ts.arrNode[r]);
                Mui_ten_xanh_xuong_1.Visible = false;
                Mui_ten_xanh_xuong_2.Visible = false;
                //
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "HoanVi( a[0] , a[" + r + "] )";

                listCode.SelectedIndex = 7;
                this.Invoke((MethodInvoker)delegate
                {
                    Swap_Node(ts.arrLbl[0], ts.arrLbl[r]);
                });

                lbl_status_02.Visible = false;
                Swap_NodeAn(0, r);
                ts.arrLbl[r].BackColor = colorComplete;
                ts.arrLbl[0].BackColor = colorDefault;
                // Đặt lại màu cho phần tử đã được sắp xếp

                lbl_status_02.Visible = true;
                lbl_status_02.Text = "a[" + r + "] đã đúng thứ tự!";
                if (ckDebug.Checked == true)
                    Pause();
                else
                    Delay(10 * ts.speed);
                lbl_status_02.Visible = false;
                listCode.SelectedIndex = 8;
                r--;
                //Thiết lập mũi tên chỉ r
                Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * r) + (ts.sizeN / 2) - 30, ts.arrLbl[r].Location.Y + 2 * ts.sizeN + 5);
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
            Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * r) + (ts.sizeN / 2) - 30, ts.arrLbl[r].Location.Y + 2 * ts.sizeN + 5);
            Mui_ten_xanh_len_1.Text = "r=" + r;
            Mui_ten_xanh_len_1.Visible = true;
            Mui_ten_xanh_len_1.Refresh();
            listCode.SelectedIndex = 5;
            while (r > 0)
            {
                Application.DoEvents();
                Swap_Giatri(ref ts.arrNode[0], ref ts.arrNode[r]);
                Mui_ten_xanh_xuong_1.Visible = false;
                Mui_ten_xanh_xuong_2.Visible = false;
                //
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "HoanVi( a[0] , a[" + r + "] )";

                listCode.SelectedIndex = 7;
                this.Invoke((MethodInvoker)delegate
                {
                    Swap_Node(ts.arrLbl[0], ts.arrLbl[r]);
                });
                lbl_status_02.Visible = false;
                Swap_NodeAn(0, r);
                ts.arrLbl[r].BackColor = colorComplete;
                ts.arrLbl[0].BackColor = colorDefault;
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "a[" + r + "] đã đúng thứ tự!";
                if (ckDebug.Checked == true)
                    Pause();
                else
                    Delay(10 * ts.speed);
                lbl_status_02.Visible = false;
                listCode.SelectedIndex = 8;
                r--;
                //Thiết lập mũi tên chỉ r
                Mui_ten_xanh_len_1.Location = new Point((ts.firstN + (ts.sizeN + ts.disN) * r) + (ts.sizeN / 2) - 30, ts.arrLbl[r].Location.Y + 2 * ts.sizeN + 5);
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
            // wtf tên như cứt vậy
            while (pa < ts.nOe)
            {
                Application.DoEvents();
                for (i = 0; (pa < ts.nOe) && (i < k); i++, pa++, pb++)
                {
                    ts.b[pb] = ts.arrNode[pa];
                    ts.node_B[pb] = ts.arrLbl[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(ts.node_B[pb], 2 * (ts.sizeN));
                        Den_tdo_x_node(ts.node_B[pb], pb);
                    });
                    ts.arrLbl[pa].BackColor = colorQuickU;  // màu trên
                }
                for (i = 0; (pa < ts.nOe) && (i < k); i++, pa++, pc++)
                {
                    ts.c[pc] = ts.arrNode[pa];
                    ts.node_C[pc] = ts.arrLbl[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(ts.node_C[pc], (ts.sizeN + 80));
                        Den_tdo_x_node(ts.node_C[pc], pc);
                    });
                    ts.arrLbl[pa].BackColor = colorQuickD; // màu dưới
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
                if (ts.b[pb + ib] <= ts.c[pc + ic])
                {
                    ts.arrNode[pa] = ts.b[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(ts.node_B[pb + ib], pa);
                    });
                    ts.arrLbl[pa] = ts.node_B[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            ts.arrNode[pa] = ts.c[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(ts.node_C[pc + ic], pa);
                            });
                            ts.arrLbl[pa] = ts.node_C[pc + ic];
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
                    ts.arrNode[pa] = ts.c[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(ts.node_C[pc + ic], pa);
                    });
                    ts.arrLbl[pa] = ts.node_C[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            ts.arrNode[pa] = ts.b[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(ts.node_B[pb + ib], pa);
                            });
                            ts.arrLbl[pa] = ts.node_B[pb + ib];
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
                    toLocaN(ts.node_B[lennb - nb], pa);

                });
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    toLocaN(ts.node_C[lennc - nc], pa);
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
                if (ts.b[pb + ib] >= ts.c[pc + ic])
                {
                    ts.arrNode[pa] = ts.b[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(ts.node_B[pb + ib], pa);
                    });
                    ts.arrLbl[pa] = ts.node_B[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            ts.arrNode[pa] = ts.c[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(ts.node_C[pc + ic], pa);
                            });
                            ts.arrLbl[pa] = ts.node_C[pc + ic];
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
                    ts.arrNode[pa] = ts.c[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(ts.node_C[pc + ic], pa);
                    });
                    ts.arrLbl[pa] = ts.node_C[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            ts.arrNode[pa] = ts.b[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(ts.node_B[pb + ib], pa);
                            });
                            ts.arrLbl[pa] = ts.node_B[pb + ib];
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
                    toLocaN(ts.node_B[lennb - nb], pa);
                });
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    toLocaN(ts.node_C[lennc - nc], pa);
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
            ts.b = new int[ts.nOe];
            ts.c = new int[ts.nOe];
            ts.node_B = new Label[ts.nOe];
            ts.node_C = new Label[ts.nOe];
            //Dán nhãn mảng b

            int k, nc = 0, nb = 0;
            ChonDongChoCodeListBox(3);
            for (k = 1; k < ts.nOe; k *= 2)
            {
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "k = " + k;
                ChonDongChoCodeListBox(5);
                Distribute(ref nb, ref nc, k);
                Merge_increase(nb, nc, k);
                ChonDongChoCodeListBox(6);
            }
        }
        void MergeSortGiam()
        {
            ts.b = new int[ts.nOe];
            ts.c = new int[ts.nOe];
            ts.node_B = new Label[ts.nOe];
            ts.node_C = new Label[ts.nOe];
            //Dán nhãn mảng b
            int k, nc = 0, nb = 0;
            ChonDongChoCodeListBox(3);
            for (k = 1; k < ts.nOe; k *= 2)
            {
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "k = " + k;
                ChonDongChoCodeListBox(5);
                Distribute(ref nb, ref nc, k);
                Merge_giam(nb, nc, k);
                ChonDongChoCodeListBox(6);
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
            YTuong ytuong = new YTuong();
            CodeC code = new CodeC();

            listCode.Font = new Font("Aril", 12, FontStyle.Regular);
            listIdea.Font = new Font("Aril", 12, FontStyle.Regular);
            listIdea.ForeColor = Color.White;
            if (radQuick.Checked)
            {
                code.quicksort(listCode, ts.increase);
                ytuong.Quicksort(listIdea);
            }
            if (radHeap.Checked)
            {
                code.heapsort(listCode, ts.increase);
                ytuong.Heapsort(listIdea);
            }
            if (radInsertion.Checked)
            {
                code.insertionsort(listCode, ts.increase);
                ytuong.Insertionsort(listIdea);
            }
            if (radMerge.Checked)
            {
                code.mergesort(listCode, ts.increase);
                ytuong.Mergesort(listIdea);
            }
            if (radInterchange.Checked)
            {
                code.interchangesort(listCode, ts.increase);
                ytuong.Interchangesort(listIdea);
            }
            if (radShell.Checked)
            {
                code.shellsort(listCode, ts.increase);
                ytuong.Shellsort(listIdea);
            }
            if (radBubble.Checked)
            {
                code.bubblesort(listCode, ts.increase);
                ytuong.Bubblesort(listIdea);
            }
            if (radSelection.Checked)
            {
                code.selectionsort(listCode, ts.increase);
                ytuong.Selectionsort(listIdea);
            }
        }
        public void ChonDongChoCodeListBox(int viTri)
        {
            Delay(ts.speed * 5);
            listCode.SelectedIndex = viTri;
            // nếu đang trong chế độ Debug thì dừng sau mỗi câu lệnh chạy xong sẽ dừng lại
            if (ckDebug.Checked)
            {
                ts.checkPause = true;
                Play_or_Stop();
            }
        }

        #endregion

        #region Complete
        public void Complete()
        {
            ChonDongChoCodeListBox(0);
            ExTime.Stop();
            pnlExTime.Visible = false;
            Init();
            bntReset.Enabled = true;
            bntCreate.Enabled = false;
            bntExit.Enabled = true;
            bntBack.Enabled = true;
            Hidelbl();
            MessageBox.Show("----------Sắp xếp hoàn tất----------\nThời gian thực thi là: " + lblMinutes.Text + ":" + lblSeconds.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            pnlChayMau.Controls.Add(Mui_ten_xanh_xuong_1);
            pnlChayMau.Controls.Add(Mui_ten_xanh_xuong_2);
            pnlChayMau.Controls.Add(Mui_ten_xanh_len_1);
            pnlChayMau.Controls.Add(Mui_ten_xanh_len_2);
            pnlChayMau.Controls.Add(Mui_ten_do_len);
            pnlChayMau.Controls.Add(lbl_status_02);
            pnlChayMau.Controls.Add(lblA);
            pnlChayMau.Controls.Add(lblB);
            pnlChayMau.Controls.Add(lblC);
        }
        #endregion

        //ToolBox 
        #region Working 
        #region bnt"Initial","Control","Debug","Create Array"_Click
        #region Initial

        public void DeleteArray(Label[] a)
        {   
            
            for (int i = 0; i < ts.nOe; i++)
            {
                this.Controls.Remove(a[i]);
            }
        }
        private void bntCreate_Click(object sender, EventArgs e)
        {
            bntCreate.Enabled = false;
            numArray.Enabled = false;
            bntReset.Enabled = true;
            ts.checkPause = false;
            //DeleteArray(ts.arrLbl);
            if (ts.nOe < 2 && ts.nOe > 10)
            {
                MessageBox.Show("Error", "Vui lòng nhập số phần tử tuwf 2->10 !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; /// > >> >
            }
            else
            {
                switch(ts.nOe)
                {
                    case 10:
                    case 9:
                    case 8:
                    case 7:
                    case 6:
                        ts.disN = 18;
                        ts.sizeN = 50;
                        ts.firstN = (1024 - ts.sizeN - ts.disN * (ts.nOe - 1)) / ts.nOe;
                        break;
                    case 5:
                    case 4:
                    case 3:
                    case 2:
                        ts.sizeN = 50;
                        ts.disN = 30;
                        ts.firstN = (1024 - ts.sizeN - ts.disN * (ts.nOe - 1)) / ts.nOe;
                        break;
                }
                ts.arrNode = new int[ts.nOe];
                ts.arrLbl = new Label[ts.nOe];
                for (int i = 0; i < ts.nOe; i++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Size = new Size(40, 40);
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    label.Font = new Font("Times New Roman", 14);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Text = "0";
                    label.BackColor = colorDefault;
                    label.Location = new Point(ts.firstN + (ts.sizeN + ts.disN) * i, 3 * ts.sizeN);
                    ts.arrLbl[i] = label;
                    
                    pnlChayMau.Controls.Add(ts.arrLbl[i]);
                }
            }
            grpCreateArray.Enabled = true;
        }

        private void bntReset_Click(object sender, EventArgs e)
        {
            numArray.Enabled = true;
            bntCreate.Enabled = true;
            Init();          
            Hidelbl();
            for (int i = 0; i < ts.nOe; i++)
            {
                pnlChayMau.Controls.Remove(ts.arrLbl[i]);
            }
            bntPlay.Show();
            speedTrackBar.Value = 30;
        }
        #endregion

        #region Control
        private void bntPlay_Click(object sender, EventArgs e)
        {
            bntPlay.Hide();
            bntPause.Show();
            pnlExTime.Visible = true;
            ExTime.Start();
            bntBack.Enabled = false;
            bntReset.Enabled = false;
            bntExit.Enabled = false;
            if (ts.checkPause == false)
            {
                if (radSelection.Checked == true && ts.increase == true)
                    SelectionSortincrease(ts.arrNode);
                if (radSelection.Checked == true && ts.increase == false)
                    SelectionSortGiam(ts.arrNode);
                if (radBubble.Checked == true && ts.increase == true)
                    BubbleSortincrease(ts.arrNode);
                if (radBubble.Checked == true && ts.increase == false)
                    BubbleSortGiam(ts.arrNode);
                if (radShell.Checked == true && ts.increase == true)
                    ShellSortincrease(ts.arrNode);
                if (radShell.Checked == true && ts.increase == false)
                    ShellSortGiam(ts.arrNode);
                if (radQuick.Checked == true && ts.increase == true)
                    QuickSortincrease(ts.arrNode, 0, ts.nOe - 1);
                if (radQuick.Checked == true && ts.increase == false)
                    QuickSortGiam(ts.arrNode, 0, ts.nOe - 1);
                if (radHeap.Checked == true && ts.increase == true)
                    HeapSortincrease(ts.nOe);
                if (radHeap.Checked == true && ts.increase == false)
                    HeapSortGiam(ts.nOe);
                if (radInsertion.Checked == true && ts.increase == true)
                    InsertionSortincrease(ts.arrNode);
                if (radInsertion.Checked == true && ts.increase == false)
                    InsertionSortGiam(ts.arrNode);
                if (radInterchange.Checked == true && ts.increase == true)
                    InterchangeSortincrease(ts.arrNode);
                if (radInterchange.Checked == true && ts.increase == false)
                    InterchangeSortGiam(ts.arrNode);
                if (radMerge.Checked == true && ts.increase == true)
                    MergeSortincrease();
                if (radMerge.Checked == true && ts.increase == false)
                    MergeSortGiam();
                CompleteSwap();
            }
            else
            {
                ts.checkPause = false;
            }
        }

        private void bntPause_Click(object sender, EventArgs e)
        {
            bntPlay.Show();
            bntPause.Hide();
            ts.checkPause = true;
            Play_or_Stop();
        }
        public void Pause()
        {
            if (ckDebug.Checked == true)
            {
                ts.checkPause = true;
                Play_or_Stop();
            }
        }
        public void Play_or_Stop()
        {
            while (ts.checkPause == true)
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
                bntPlay.Show();
                bntPause.Hide();
            }
        }
        private void bntDebug_Click(object sender, EventArgs e)
        {
            ts.checkPause = false;
        }
        #endregion

        #region Create Array
        private void bntRandom_Click(object sender, EventArgs e)
        {
            pnlLoaiThuatToan.Enabled = true;
            grpControl.Enabled = true;
            grpDebug.Enabled = true;
            Random r = new Random();
            for (int i = 0; i < ts.nOe; i++)
            {
                int rd = r.Next(0, 99);

                ts.arrLbl[i].Text = rd + "";
                ts.arrNode[i] = rd;
            }
            ShowCode();
        }

        private void bntByHand_Click(object sender, EventArgs e)
        {
            pnlLoaiThuatToan.Enabled = true;
            grpControl.Enabled = true;
            grpDebug.Enabled = true;
            ShowCode();
            frmByHand a = new frmByHand();
            a.Message = numArray.Value.ToString();
            a.ShowDialog();
            for (int i = 0; i < ts.nOe; i++)
            {

                switch (i + 1)
                {
                    case 1: ts.arrLbl[i].Text = PT1; ts.arrNode[i] = Int32.Parse(PT1); break;
                    case 2: ts.arrLbl[i].Text = PT2; ts.arrNode[i] = Int32.Parse(PT2); break;
                    case 3: ts.arrLbl[i].Text = PT3; ts.arrNode[i] = Int32.Parse(PT3); break;
                    case 4: ts.arrLbl[i].Text = PT4; ts.arrNode[i] = Int32.Parse(PT4); break;
                    case 5: ts.arrLbl[i].Text = PT5; ts.arrNode[i] = Int32.Parse(PT5); break;
                    case 6: ts.arrLbl[i].Text = PT6; ts.arrNode[i] = Int32.Parse(PT6); break;
                    case 7: ts.arrLbl[i].Text = PT7; ts.arrNode[i] = Int32.Parse(PT7); break;
                    case 8: ts.arrLbl[i].Text = PT8; ts.arrNode[i] = Int32.Parse(PT8); break;
                    case 9: ts.arrLbl[i].Text = PT9; ts.arrNode[i] = Int32.Parse(PT9); break;
                    case 10: ts.arrLbl[i].Text = PT10; ts.arrNode[i] = Int32.Parse(PT10); break;
                }
            }
            pnlLoaiThuatToan.Enabled = true;
            grpControl.Enabled = true;
        }

        private void radDecrease_CheckedChanged(object sender, EventArgs e)
        {
            ts.increase = false;
            ShowCode();
        }

        private void radIncrease_CheckedChanged(object sender, EventArgs e)
        {
            ts.increase = true;
            ShowCode();
        }
        #endregion

        #endregion

        #region bntBack_Click
        private void bntBack_Click(object sender, EventArgs e)
        {
            frmIntroduct frm1 = new frmIntroduct();
            frm1.Show();
            this.Close();
        }
        #endregion
        #region bntExit_Click
        private void bntExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            ts.speed = speedTrackBar.Maximum - speedTrackBar.Value;
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
    }
}

