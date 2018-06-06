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

namespace SortingAlgorithmsGUI
{
    public partial class frmApplication : Form
    {
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

        int[] Arrayy;
        Label[] Arrayyy;
        Label[] Node_B, Node_C;
        int[] b, c;
        int KcNode = 18;
        int spt;
        bool check = true;
        int Kich_thuoc = 50;
        int Canh_le = 30;
        int TocDo = 60;
        bool tang;
        bool KT_tam_dung = false;

        public frmApplication()
        {
            InitializeComponent();
        }

        private void bntBack_Click(object sender, EventArgs e)
        {
            frmIntroduct frm1 = new frmIntroduct();
            frm1.Show();
            this.Close();
        }



        private void bntSourceCode_Click(object sender, EventArgs e)
        {
            listCode.Show();
            listIdea.Hide();
        }

        private void bntIdeaAlgorithm_Click(object sender, EventArgs e)
        {
            listIdea.Show();
            listCode.Hide();
        }

        private void frmApplication_Load(object sender, EventArgs e)
        {
            spt = (int)numArray.Value;
            grpCreateArray.Enabled = false;
            pnlLoaiThuatToan.Enabled = false;
            grpControl.Enabled = false;
            grpDebug.Enabled = false;
            tang = true;
            listIdea.Hide();
            speedTrackBar.Maximum = TocDo;
            speedTrackBar.Minimum = 0;
            speedTrackBar.Value = TocDo / 2;
            speedTrackBar.LargeChange = 1;
            DauMuiTen();
        }

        private void bntCreate_Click(object sender, EventArgs e)
        {
            //pnlChayMau.Controls.Clear();
            if (spt == 0)
            {
                MessageBox.Show("Error", "Vui lòng nhập số phần tử !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; /// > >> >
            }
            else
            {
                Arrayy = new int[spt];
                Arrayyy = new Label[spt];
                for (int i = 0; i < spt; i++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Size = new Size(40, 40);
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    label.Font = new Font("Times New Roman", 14);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Text = "0";
                    label.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * i, 3 * Kich_thuoc);
                    Arrayyy[i] = label;
                    pnlChayMau.Controls.Add(Arrayyy[i]);
                }
            }
            grpCreateArray.Enabled = true;
        }

        private void numArray_ValueChanged(object sender, EventArgs e)
        {
            spt = int.Parse(numArray.Value.ToString());
        }

        private void bntRandom_Click(object sender, EventArgs e)
        {
            pnlLoaiThuatToan.Enabled = true;
            grpControl.Enabled = true;
            grpDebug.Enabled = true;
            Random r = new Random();
            for (int i = 0; i < spt; i++)
            {
                int rd = r.Next(0, 99);

                Arrayyy[i].Text = rd + "";
                Arrayy[i] = rd;
            }



            HienThiCode();
        }

        private void bntByHand_Click(object sender, EventArgs e)
        {
            frmByHand a = new frmByHand();
            a.Message = numArray.Value.ToString();
            a.ShowDialog();


            for (int i = 0; i < spt; i++)
            {

                switch (i + 1)
                {
                    case 1: Arrayyy[i].Text = PT1; Arrayy[i] = Int32.Parse(PT1); break;
                    case 2: Arrayyy[i].Text = PT2; Arrayy[i] = Int32.Parse(PT2); break;
                    case 3: Arrayyy[i].Text = PT3; Arrayy[i] = Int32.Parse(PT3); break;
                    case 4: Arrayyy[i].Text = PT4; Arrayy[i] = Int32.Parse(PT4); break;
                    case 5: Arrayyy[i].Text = PT5; Arrayy[i] = Int32.Parse(PT5); break;
                    case 6: Arrayyy[i].Text = PT6; Arrayy[i] = Int32.Parse(PT6); break;
                    case 7: Arrayyy[i].Text = PT7; Arrayy[i] = Int32.Parse(PT7); break;
                    case 8: Arrayyy[i].Text = PT8; Arrayy[i] = Int32.Parse(PT8); break;
                    case 9: Arrayyy[i].Text = PT9; Arrayy[i] = Int32.Parse(PT9); break;
                    case 10: Arrayyy[i].Text = PT10; Arrayy[i] = Int32.Parse(PT10); break;

                }

            }
            pnlLoaiThuatToan.Enabled = true;
            grpControl.Enabled = true;
        }


        private void Thoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình không?","Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes )
                Application.Exit();
        }


        int min(int a, int b)
        {
            if (a > b)
                return b;
            else
                return a;
        }
        //Hàm phân phối a cho b và c
        #region Các hàm di chuyển node
        public void Node_qua_phai(Control t, int Step)
        {
            Application.DoEvents();

            this.Invoke((MethodInvoker)delegate
            {
                int Loop_Count = ((Kich_thuoc + KcNode)) * Step; //Số lần dịch chuyển
                {
                    while (Loop_Count > 0)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Tre(TocDo);
                        Loop_Count--;
                    }
                }
                t.Refresh();
            });
        }
        // t dịch chuyển sang trai Step Node
        public void Node_qua_trai(Control t, int Step)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int Loop_Count = ((Kich_thuoc + KcNode)) * Step; //Số lần dịch chuyển
                while (Loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Left -= 1;
                    Tre(TocDo);
                    Loop_Count--;
                }
                t.Refresh();
            });
        }
        // t dịch chuyển lên với quãng đường S
        public void Node_di_len(Control t, int S)
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
                    Tre(TocDo);
                    loop_Count--;
                }
                t.Refresh();
            });
        }
        // t dịch chuyển xuống với quãng đường S
        public void Node_di_xuong(Control t, int S)
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
                    Tre(TocDo);
                    loop_Count--;
                }
                t.Refresh();
            });
        }

        public void Den_vtri_node(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(Canh_le + (Kich_thuoc + KcNode) * i, 150);//vị trí của Node i
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                // Di chuyển nút lên hoặc xuống nữa đường
                if (p1.Y < p2.Y)
                {
                    while (t.Location.Y < p2.Y - ((p2.Y - p1.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top += 1;
                        Tre(TocDo);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y + ((p1.Y - p2.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Tre(TocDo);
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
                        Tre(TocDo);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Tre(TocDo);
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
                        Tre(TocDo);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y)
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Tre(TocDo);
                        t.Refresh();
                    }
                }
            });
        }
        // Dịch chuyển 1 Node về vị trí bằng với X của Node[i]
        public void Den_tdo_x_node(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(Canh_le + (Kich_thuoc + KcNode) * i, 150);//vị trí của Node i
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                // Di chuyển nút qua phải hoặc trái
                if (p1.X < p2.X)
                {
                    while (t.Location.X < p2.X)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Tre(TocDo);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Tre(TocDo);
                        t.Refresh();
                    }
                }

            });
        }


        #endregion
        #region Các hàm hoán vị 
        public void Swap_NodeAn(int a, int b)
        {
            Label temp = Arrayyy[a];
            Arrayyy[a] = Arrayyy[b];
            Arrayyy[b] = temp;
        }

        public void Swap_Node(Control t1, Control t2)
        {
            Application.DoEvents();

            this.Invoke((MethodInvoker)delegate
            {
                Point p1 = t1.Location; //lưu vị trí ban đầu của t1
                Point p2 = t2.Location; //lưu vị trí ban đầu của t2
                if (p1 != p2)
                {
                    // t1 lên, t2 xuống
                    while ((t1.Location.Y > p1.Y - (Kich_thuoc + 5)) || (t2.Location.Y < p2.Y + (Kich_thuoc + 5)))
                    {
                        Application.DoEvents();
                        t1.Top -= 1;
                        t2.Top += 1;
                        Thread.Sleep(5);

                    }
                    // t1 dịch phải, t2 dịch trái
                    if (t1.Location.X < t2.Location.X)
                    {

                        while ((t1.Location.X < p2.X) || (t2.Location.X > p1.X))
                        {
                            Application.DoEvents();
                            t1.Left += 1;
                            t2.Left -= 1;
                            Thread.Sleep(5);


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
                            Thread.Sleep(5);

                        }

                    }
                    // t1 xuống, t2 lên
                    while ((t1.Location.Y < p2.Y) || (t2.Location.Y > p1.Y))
                    {
                        Application.DoEvents();
                        t1.Top += 1;
                        t2.Top -= 1;
                        Thread.Sleep(5);

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
        #region Xử lí căn lề
        private void CanLe()
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

        private void radQuick_CheckedChanged(object sender, EventArgs e)
        {
            HienThiCode();
        }

        private void radHeap_CheckedChanged(object sender, EventArgs e)
        {
            HienThiCode();
        }

        private void radBubble_CheckedChanged(object sender, EventArgs e)
        {
            HienThiCode();
        }

        private void radShell_CheckedChanged(object sender, EventArgs e)
        {
            HienThiCode();
        }

        private void radMerge_CheckedChanged(object sender, EventArgs e)
        {
            HienThiCode();
        }

        private void radInsertion_CheckedChanged(object sender, EventArgs e)
        {
            HienThiCode();
        }

        private void radInterchange_CheckedChanged(object sender, EventArgs e)
        {
            HienThiCode();
        }

        private void radSelection_CheckedChanged(object sender, EventArgs e)
        {
            HienThiCode();
        }



        #region Các thuật toán sắp xếp
        #region interchange
        private void InterchangeSortGiam(int[] Arrayy)
        { 
            ChonDongChoCodeListBox(2);
            int i = 0, j = 0;
            Mui_ten_xanh_len_1.Text = "i = " + i;
            Mui_ten_xanh_len_1.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * i, pnlChayMau.Height -50);
            Mui_ten_xanh_len_1.Visible = true;
            for ( i = 0; i < spt - 1; i++)
            {
                ChonDongChoCodeListBox(3);
                j = i + 1;
                Mui_ten_xanh_len_2.Text = "j = " + j;
                Mui_ten_xanh_len_2.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * j, pnlChayMau.Height - 50);
                Mui_ten_xanh_len_2.Visible = true;
                for ( j = i + 1; j < spt; j++)
                {
                    ChonDongChoCodeListBox(4);
                    lbl_status_02.Text = "SoSanh(a[" + i + "],a[" + j + "])";
                    lbl_status_02.Visible = true;
                    if (Arrayy[j] > Arrayy[i])
                    {
                        ChonDongChoCodeListBox(6);
                        lbl_status_02.Text = "HoanVi(a[" + i + "],a[" + j + "])";
                        Swap_Giatri(ref Arrayy[i], ref Arrayy[j]);
                        Swap_Node(Arrayyy[j], Arrayyy[i]);
                        Swap_NodeAn(j, i);
                    }
                    if (j + 1 < spt)
                    {
                        Mui_ten_xanh_len_2.Text = "j = " + (j + 1);
                        Mui_ten_xanh_len_2.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * (j + 1), pnlChayMau.Height - 50);
                        Refresh();
                    }
                }
                ChonDongChoCodeListBox(3);
                lbl_status_02.Visible = false;
                Mui_ten_xanh_len_1.Text = "i = " + (i + 1);
                Mui_ten_xanh_len_1.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * (i + 1), pnlChayMau.Height - 50);
            }
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        private void InterchangeSortTang(int[] Arrayy)
        {

            ChonDongChoCodeListBox(2);
            int i = 0, j = 0;
            Mui_ten_xanh_len_1.Text = "i = " + i;
            Mui_ten_xanh_len_1.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * i, pnlChayMau.Height - 50);
            Mui_ten_xanh_len_1.Visible = true;
            Refresh();
            for (i = 0; i < spt - 1; i++)
            {
                ChonDongChoCodeListBox(3);
                j = i + 1;
                Mui_ten_xanh_len_2.Text = "j = " + j;
                Mui_ten_xanh_len_2.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * j, pnlChayMau.Height - 50);
                Mui_ten_xanh_len_2.Visible = true;
                Refresh();
                for (j = i + 1; j < spt; j++)
                {
                    ChonDongChoCodeListBox(4);
                    lbl_status_02.Text = "SoSanh(a[" + i + "],a[" + j + "])";
                    lbl_status_02.Visible = true;
                    if (Arrayy[j] < Arrayy[i])
                    {
                        ChonDongChoCodeListBox(6);
                        lbl_status_02.Text = "HoanVi(a[" + i + "],a[" + j + "])";
                        Swap_Giatri(ref Arrayy[j], ref Arrayy[i]);
                        Swap_Node(Arrayyy[j], Arrayyy[i]);
                        Swap_NodeAn(j, i);
                    }
                    if (j+1 < spt)
                    {
                        Mui_ten_xanh_len_2.Text = "j = " + (j + 1);
                        Mui_ten_xanh_len_2.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * (j + 1), pnlChayMau.Height - 50);
                        Refresh();
                    }

                }
                ChonDongChoCodeListBox(3);
                lbl_status_02.Visible = false;
                Mui_ten_xanh_len_1.Text = "i = " + (i + 1);
                Mui_ten_xanh_len_1.Location = new Point(Canh_le + (Kich_thuoc + KcNode) * (i + 1), pnlChayMau.Height - 50);
                Refresh();
            }
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        #endregion
        #region selection
        private void SelectionSortTang(int[] Arrayy)
        {
            int min;
            DauMuiTen();
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < spt - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    ChonDongChoCodeListBox(5);

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    min = i;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Text = "Min=" + min;
                    Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * min) + (Kich_thuoc / 2) - 30, Arrayyy[min].Location.Y + 2 * Kich_thuoc + 5);
                    Mui_ten_xanh_len_1.Refresh();

                    for (int j = i + 1; j < spt; j++)
                    {
                        ChonDongChoCodeListBox(6);
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "SoSanh( a[min] , a[" + j + "] )";
                        lbl_status_02.Refresh();
                        if (Arrayy[j] < Arrayy[min])
                        {
                            ChonDongChoCodeListBox(8);
                            min = j;
                            Mui_ten_xanh_len_1.Text = "Min=" + min;
                            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * min) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y + 2 * Kich_thuoc + 5);
                            Mui_ten_xanh_len_1.Refresh();
                        }

                    }
                    if (min != i)
                    {
                        ChonDongChoCodeListBox(10);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "HoanVi( a[i] , a[min] )";
                        Swap_Giatri(ref Arrayy[min], ref Arrayy[i]);
                        Swap_Node(Arrayyy[min], Arrayyy[i]);
                        Swap_NodeAn(min, i);
                    }
                    lbl_status_02.Visible = false;

                }
            });
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        private void SelectionSortGiam(int[] Arrayy)
        {
            DauMuiTen();
            int max;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < spt - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    ChonDongChoCodeListBox(5);
                    max = i;

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Text = "Max=" + max;
                    Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * max) + (Kich_thuoc / 2) - 30, Arrayyy[max].Location.Y + 2 * Kich_thuoc + 5);
                    Mui_ten_xanh_len_1.Refresh();
                    for (int j = i + 1; j < spt; j++)
                    {
                        ChonDongChoCodeListBox(6);
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);

                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "SoSanh( a[max] , a[" + j + "] )";
                        if (Arrayy[j] > Arrayy[max])
                        {
                            max = j;
                            Mui_ten_xanh_len_1.Text = "Max=" + max;
                            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * max) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y + 2 * Kich_thuoc + 5);
                            Mui_ten_xanh_len_1.Refresh();
                        }
                    }
                    if (max != i)
                    {
                        ChonDongChoCodeListBox(10);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "HoanVi( a[i] , a[max] )";
                        Swap_Giatri(ref Arrayy[max], ref Arrayy[i]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(Arrayyy[max], Arrayyy[i]);
                        Swap_NodeAn(max, i);
                    }
                    lbl_status_02.Visible = false;
                }
            });
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        #endregion
        #region shell
        private void ShellSortTang(int[] Arrayy)
        {

            for (int i = spt / 2; i > 0; i /= 2)
            {
                ChonDongChoCodeListBox(2);
                Mui_ten_xanh_xuong_1.Text = "i = " + i;
                Mui_ten_xanh_xuong_1.Location = new Point(Canh_le-10 + (Kich_thuoc + KcNode) * 0, 40);
                Mui_ten_xanh_xuong_1.SendToBack();
                Mui_ten_xanh_xuong_1.Visible = true;

                for (int j = i; j < spt; j++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_len_1.Text = "j = " + j;
                    Mui_ten_xanh_len_1.Location = new Point(Canh_le-10 + (Kich_thuoc + KcNode) * j, 40);
                    Mui_ten_xanh_len_1.Visible = true;


                    for (int k = j; k >= i && Arrayy[k] < Arrayy[k - i]; k -= i)
                    {
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_xuong_2.Text = "k = " + k;
                        Mui_ten_xanh_xuong_2.Location = new Point(Canh_le -10+ (Kich_thuoc + KcNode) * k, pnlChayMau.Height - 50);
                        Mui_ten_xanh_xuong_2.SendToBack();
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Text = "HoanVi(a[" + k  + "],a[" + (k - 1) + "])";
                        lbl_status_02.Visible = true;
                        Swap_Giatri(ref Arrayy[k - i], ref Arrayy[k]);
                        Swap_Node(Arrayyy[k], Arrayyy[k - i]);
                        Swap_NodeAn(k, k - i);
                    }
                    lbl_status_02.Visible = false;
                    ChonDongChoCodeListBox(3);
                }
            }
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        private void ShellSortGiam(int[] Arrayy)
        {
            for (int i = spt / 2; i > 0; i /= 2)
            {
                ChonDongChoCodeListBox(2);
                Mui_ten_xanh_xuong_1.Text = "i = " + i;
                Mui_ten_xanh_xuong_1.Location = new Point(Canh_le - 10 + (Kich_thuoc + KcNode) * 0, 40);
                Mui_ten_xanh_xuong_1.SendToBack();
                Mui_ten_xanh_xuong_1.Visible = true;
                for (int j = i; j < spt; j++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_len_1.Text = "j = " + j;
                    Mui_ten_xanh_len_1.Location = new Point(Canh_le - 10 + (Kich_thuoc + KcNode) * j, 40);
                    Mui_ten_xanh_len_1.Visible = true;
                    for (int k = j; k >= i && Arrayy[k] > Arrayy[k - i]; k -= i)
                    {
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_xuong_2.Text = "k = " + k;
                        Mui_ten_xanh_xuong_2.Location = new Point(Canh_le - 10 + (Kich_thuoc + KcNode) * k, pnlChayMau.Height - 50);
                        Mui_ten_xanh_xuong_2.SendToBack();
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Text = "HoanVi(a[" + k + "],a[" + (k - 1) + "])";
                        lbl_status_02.Visible = true;
                        Swap_Giatri(ref Arrayy[k - i], ref Arrayy[k]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(Arrayyy[k], Arrayyy[k - i]);
                        Swap_NodeAn(k, k - i);
                    }
                    lbl_status_02.Visible = false;
                    ChonDongChoCodeListBox(3);
                }
            }
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        #endregion
        #region bubble
        private void BubbleSortTang(int[] Arrayy)
        {
            int i, j;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < spt - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = spt - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox( 4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y + 2 * Kich_thuoc + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ChonDongChoCodeListBox (5);
                        lbl_status_02.Visible = true;
                        if (Arrayy[j] < Arrayy[j - 1])
                        {
                            //Hieu ung xem code
                            ChonDongChoCodeListBox( 6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref Arrayy[j], ref Arrayy[j - 1]);
                            Swap_Node(Arrayyy[j], Arrayyy[j - 1]);
                            Swap_NodeAn(j, j - 1);
                        }

                    }
                    //Cập nhật Status
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();

                }
                lbl_status_02.Visible = false;
            });
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        private void BubbleSortGiam(int[] Arrayy)
        {
            int i, j;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < spt - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = spt - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y + 2 * Kich_thuoc + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Visible = true;
                        if (Arrayy[j] > Arrayy[j - 1])
                        {
                            //Hieu ung xem code
                            ChonDongChoCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref Arrayy[j], ref Arrayy[j - 1]);
                            Swap_Node(Arrayyy[j], Arrayyy[j - 1]);
                            Swap_NodeAn(j, j - 1);
                        }

                    }
                    //Cập nhật Status
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();

                }
                lbl_status_02.Visible = false;
            });
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        #endregion
        #region insertion
        private void InsertionSortTang(int[] Arrayy)
        {
            int i, pos, x;
            Label Node_tam;
            int Chi_so_tam;
            int Dem_node;

            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 1; i < spt; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    Dem_node = 0;
                    ChonDongChoCodeListBox(5);
                    x = Arrayy[i];
                    Node_tam = Arrayyy[i];
                    Chi_so_tam = i;
                    pos = i - 1;
                    //thiết lập mũi tên đánh dấu nút cần chèn
 

                    //Di chuyển Node cần chèn lên
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_di_len(Node_tam, (Kich_thuoc + 5));
                    });

                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i)";

                    //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                    Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * pos) + (Kich_thuoc / 2) - 30, Arrayyy[pos].Location.Y + Kich_thuoc + 5);
                    Mui_ten_xanh_len_1.Text = "POS=" + pos;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Refresh();
                    //lbl_status_02.Visible = false;
                    while ((pos >= 0) && (Arrayy[pos] > x))
                    {

                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * pos) + (Kich_thuoc / 2) - 30, Arrayyy[pos].Location.Y + Kich_thuoc + 5);
                        Mui_ten_xanh_len_1.Text = "POS=" + pos;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Refresh();
                        //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        


                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i])";
                        ChonDongChoCodeListBox(9);
                        //Dịch chuyển Node qua phải
                        Arrayy[pos + 1] = Arrayy[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_qua_phai(Arrayyy[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        ChonDongChoCodeListBox(10);
                        pos--;
                        ChonDongChoCodeListBox(12);
                        Arrayy[pos + 1] = x;


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
                        Node_qua_trai(Node_tam, Dem_node);
                    });

                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_di_xuong(Node_tam, (Kich_thuoc + 5));
                    });
                    lbl_status_02.Visible = false;
                    Mui_ten_xanh_len_1.Visible = false; ;
                    Arrayyy[pos + 1] = Node_tam;

                }
            });
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        private void InsertionSortGiam(int[] Arrayy)
        {
            int i, pos, x;
            Label Node_tam;
            int Chi_so_tam;
            int Dem_node;

            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 1; i < spt; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Application.DoEvents();
                    //Thiết lập Node đầu tiên, là Node đã có thứ tự 
                    //đềm số bước dịch chuyển 1 Node
                    Dem_node = 0;
                    ChonDongChoCodeListBox(5);
                    x = Arrayy[i];
                    Node_tam = Arrayyy[i];
                    Chi_so_tam = i;
                    pos = i - 1;
                    //thiết lập mũi tên đánh dấu nút cần chèn
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Refresh();

                    //Di chuyển Node cần chèn lên
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_di_len(Node_tam, (Kich_thuoc + 5));
                    });

                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "So_Sanh(a[" + pos+ "],a[i])";
                    //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                    Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * pos) + (Kich_thuoc / 2) - 30, Arrayyy[pos].Location.Y + Kich_thuoc + 5);
                    Mui_ten_xanh_len_1.Text = "POS=" + pos;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Refresh();
                    //lbl_status_02.Visible = false;
                    while ((pos >= 0) && (Arrayy[pos] < x))
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * pos) + (Kich_thuoc / 2) - 30, Arrayyy[pos].Location.Y + Kich_thuoc + 5);
                        Mui_ten_xanh_len_1.Text = "POS=" + pos;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Refresh();

                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" +pos+ "],a[i])";

                        ChonDongChoCodeListBox(9);
                        //Dịch chuyển Node qua phải
                        Arrayy[pos + 1] = Arrayy[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_qua_phai(Arrayyy[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        ChonDongChoCodeListBox(10);
                        pos--;
                        ChonDongChoCodeListBox(12);
                        Arrayy[pos + 1] = x;


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
                        Node_qua_trai(Node_tam, Dem_node);
                    });

                    Application.DoEvents();
                    Tre(TocDo * 30);
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_di_xuong(Node_tam, (Kich_thuoc + 5));
                    });
                    //Ẩn status
                    lbl_status_02.Visible = false;
                    //Ẩn mũi tên POS sau khi đã tìm ra POS
                    Mui_ten_xanh_len_1.Visible = false; ;
                    //Thiết lập node nằm trong nhóm đã có thứ tự
                    Arrayyy[pos + 1] = Node_tam;
                    //Tạm dừng sau 1 bước dịch chuyển Node
                }
            });
            ChonDongChoCodeListBox(0);
            HoanThanh();
        }
        #endregion
        #region quick
        private void QuickSortTang(int[] Arrayy, int left, int right)
        {
            if (left < right)
            {
                int pivot = Arrayy[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left


                ChonDongChoCodeListBox(2);

                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * left) + (Kich_thuoc / 2) - 30, Arrayyy[left].Location.Y + 2 * Kich_thuoc + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * right) + (Kich_thuoc / 2) - 30, Arrayyy[right].Location.Y + 2 * Kich_thuoc + 5);
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
                Mui_ten_do_len.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * cs_x) + (Kich_thuoc / 2) - 30, Arrayyy[cs_x].Location.Y + 2 * Kich_thuoc + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Thiết lập mũi tên chỉ i

                ChonDongChoCodeListBox(4);
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ChonDongChoCodeListBox(5);

                do
                {

                    ChonDongChoCodeListBox(7);
                    lbl_status_02.Text = "SoSanh(a[" + i + "], a[x])";
                    lbl_status_02.Visible = true;
                    while (Arrayy[i] < pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                       // lbl_status_02.Text = "SoSanh(a[" + i + "], a[x])";
                    }
                    ChonDongChoCodeListBox(8);
                    lbl_status_02.Text = "SoSanh(a[" + j + "], a[x])";
                    while (Arrayy[j] > pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //

                    }
                    ChonDongChoCodeListBox(9);

                    if (i <= j)
                    {
                        ChonDongChoCodeListBox(11);
                        lbl_status_02.Text = "HoanVi(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref Arrayy[i], ref Arrayy[j]);
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        Swap_Node(Arrayyy[j], Arrayyy[i]);
                        Swap_NodeAn(j, i);
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * cs_x) + (Kich_thuoc / 2) - 30, Arrayyy[cs_x].Location.Y + 2 * Kich_thuoc + 40);
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
                    QuickSortTang(Arrayy, left, j);
                }
                ChonDongChoCodeListBox(18);
                if (i < right)
                {
                    ChonDongChoCodeListBox(19);
                    QuickSortTang(Arrayy, i, right);
                }
            }
        }
        private void QuickSortGiam(int[] Arrayy, int left, int right)
        {
            if (left < right)
            {
                int pivot = Arrayy[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left
                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * left) + (Kich_thuoc / 2) - 30, Arrayyy[left].Location.Y + 2 * Kich_thuoc + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * right) + (Kich_thuoc / 2) - 30, Arrayyy[right].Location.Y + 2 * Kich_thuoc + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                //

                //doi mau node x

                ChonDongChoCodeListBox(2);


                cs_x = (left + right) / 2;

                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * cs_x) + (Kich_thuoc / 2) - 30, Arrayyy[cs_x].Location.Y + 2 * Kich_thuoc + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Đặt màu nút x                    
                //
                i = left; j = right;
                ChonDongChoCodeListBox(3);
                //Thiết lập mũi tên chỉ i
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ChonDongChoCodeListBox(5);
                do
                {
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    ChonDongChoCodeListBox(7);
                    while (Arrayy[i] > pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    }
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    ChonDongChoCodeListBox(8);
                    while (Arrayy[j] < pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
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
                        Swap_Giatri(ref Arrayy[i], ref Arrayy[j]);
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


                        Swap_Node(Arrayyy[i], Arrayyy[j]);
                        Swap_NodeAn(i, j);
                        //Thiết lập vị trí của 
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * cs_x) + (Kich_thuoc / 2) - 30, Arrayyy[cs_x].Location.Y + 2 * Kich_thuoc + 40);
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
                    QuickSortGiam(Arrayy, left, j);
                }
                if (i < right)
                {
                    ChonDongChoCodeListBox(19);
                    QuickSortGiam(Arrayy, i, right);
                }
            }
        }
        #endregion
        #region HEAP SORT
        void Shift_tang(int l, int r)
        {

            int i, j, index_temp, x;
            Label temp;
            i = l;
            j = 2 * i + 1;
            //Thiết lập mũi tên chỉ i
            lbl_status_02.Text = "Đang shift heap";
            lbl_status_02.Visible = true;
            Mui_ten_xanh_xuong_1.Visible = true;
            Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
            Mui_ten_xanh_xuong_1.Text = "i=" + i;
            Mui_ten_xanh_xuong_1.Refresh();
            //thiết lập mũi tên chỉ j
            Mui_ten_xanh_xuong_2.Visible = true;
            Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
            Mui_ten_xanh_xuong_2.Text = "j=" + j;
            Mui_ten_xanh_xuong_2.Refresh();
            x = Arrayy[i];
            temp = Arrayyy[i];
            index_temp = i;

            while (j <= r)
            {

                Application.DoEvents();

                if (j < r)

                    if (Arrayy[j] < Arrayy[j + 1])

                        j++;
                //thiết lập mũi tên chỉ j

                Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();

                if (Arrayy[j] <= x)
                    return;
                else
                {
                    Arrayy[i] = Arrayy[j];
                    Arrayy[j] = x;
                    Application.DoEvents();                   
                    this.Invoke((MethodInvoker)delegate
                    {
                        Swap_Node(Arrayyy[j], temp);
                    });

                    Swap_NodeAn(j, index_temp);
                    if (ckDebug.Checked == true)
                        Tam_dung();
                    else
                        Tre(5 * TocDo);
                    i = j;
                    j = 2 * i + 1;
                    if (j <= r)
                    {
                        //Thiết lập mũi tên chỉ i

                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //thiết lập mũi tên chỉ j

                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                    }
                    x = Arrayy[i];
                    temp = Arrayyy[i];
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
            Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
            Mui_ten_xanh_xuong_1.Text = "i=" + i;
            Mui_ten_xanh_xuong_1.Refresh();
            //thiết lập mũi tên chỉ j
            Mui_ten_xanh_xuong_2.Visible = true;
            Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
            Mui_ten_xanh_xuong_2.Text = "j=" + j;
            Mui_ten_xanh_xuong_2.Refresh();
            x = Arrayy[i];
            temp = Arrayyy[i];
            index_temp = i;

            while (j <= r)
            {

                Application.DoEvents();

                if (j < r)

                    if (Arrayy[j] > Arrayy[j + 1])

                        j++;
                //thiết lập mũi tên chỉ j

                Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();

                if (Arrayy[j] >= x)
                    return;
                else
                {
                    Arrayy[i] = Arrayy[j];
                    Arrayy[j] = x;
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Swap_Node(Arrayyy[j], temp);
                    });        
                    Swap_NodeAn(j, index_temp);
                    if (ckDebug.Checked == true)
                        Tam_dung();
                    else
                        Tre(5 * TocDo);
                    i = j;
                    j = 2 * i + 1;
                    if (j <= r)
                    {
                        //Thiết lập mũi tên chỉ i

                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //thiết lập mũi tên chỉ j

                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                    }
                    x = Arrayy[i];
                    temp = Arrayyy[i];
                    index_temp = i;
                }
            }   
        }

        void CreateHeap_tang(int n)
        {
            int l = n / 2 - 1;
            while (l >= 0)
            {
                Shift_tang(l, n - 1);
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

        void HeapSortTang(int n)
        {
            listCode.SelectedIndex = 2;
            int r;
            listCode.SelectedIndex = 3;
            CreateHeap_tang(n);
            listCode.SelectedIndex = 4;
            r = n - 1;

            //Thiết lập mũi tên chỉ r
            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * r) + (Kich_thuoc / 2) - 30, Arrayyy[r].Location.Y + 2 * Kich_thuoc + 5);
            Mui_ten_xanh_len_1.Text = "r=" + r;
            Mui_ten_xanh_len_1.Visible = true;
            Mui_ten_xanh_len_1.Refresh();
            listCode.SelectedIndex = 5;
            while (r > 0)
            {
                Application.DoEvents();
                Swap_Giatri(ref Arrayy[0], ref Arrayy[r]);
                Mui_ten_xanh_xuong_1.Visible = false;
                Mui_ten_xanh_xuong_2.Visible = false;
                //
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "HoanVi( a[0] , a[" + r + "] )";

                listCode.SelectedIndex = 7;
                this.Invoke((MethodInvoker)delegate
                {
                    Swap_Node(Arrayyy[0], Arrayyy[r]);
                });

                lbl_status_02.Visible = false;
                Swap_NodeAn(0, r);

                // Đặt lại màu cho phần tử đã được sắp xếp

                lbl_status_02.Visible = true;
                lbl_status_02.Text = "a[" + r + "] đã đúng thứ tự!";
                if(ckDebug.Checked == true)
                    Tam_dung();
                else
                    Tre(10*TocDo);
                lbl_status_02.Visible = false;
                listCode.SelectedIndex = 8;
                r--;
                //Thiết lập mũi tên chỉ r
                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * r) + (Kich_thuoc / 2) - 30, Arrayyy[r].Location.Y + 2 * Kich_thuoc + 5);
                Mui_ten_xanh_len_1.Text = "r=" + r;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                listCode.SelectedIndex = 9;
                if (r > 0)
                {
                    listCode.SelectedIndex = 10;
                    Shift_tang(0, r);
                }
            }
            HoanThanh();
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
            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * r) + (Kich_thuoc / 2) - 30, Arrayyy[r].Location.Y + 2 * Kich_thuoc + 5);
            Mui_ten_xanh_len_1.Text = "r=" + r;
            Mui_ten_xanh_len_1.Visible = true;
            Mui_ten_xanh_len_1.Refresh();
            listCode.SelectedIndex = 5;
            while (r > 0)
            {
                Application.DoEvents();
                Swap_Giatri(ref Arrayy[0], ref Arrayy[r]);
                Mui_ten_xanh_xuong_1.Visible = false;
                Mui_ten_xanh_xuong_2.Visible = false;
                //
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "HoanVi( a[0] , a[" + r + "] )";
  
                listCode.SelectedIndex = 7;
                this.Invoke((MethodInvoker)delegate
                {
                    Swap_Node(Arrayyy[0], Arrayyy[r]);
                });
                lbl_status_02.Visible = false;
                Swap_NodeAn(0, r);
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "a[" + r + "] đã đúng thứ tự!";
                if (ckDebug.Checked == true)
                    Tam_dung();
                else
                    Tre(10 * TocDo);
                lbl_status_02.Visible = false;
                listCode.SelectedIndex = 8;
                r--;
                //Thiết lập mũi tên chỉ r
                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * r) + (Kich_thuoc / 2) - 30, Arrayyy[r].Location.Y + 2 * Kich_thuoc + 5);
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

            HoanThanh();
        }
        #endregion
        #region merge
        void Distribute(ref int nb, ref int nc, int k)
        {

            int i, pa, pb, pc;
            pa = pb = pc = 0;

            while (pa < spt)
            {
                Application.DoEvents();
                for (i = 0; (pa < spt) && (i < k); i++, pa++, pb++)
                {
                    b[pb] = Arrayy[pa];
                    Node_B[pb] = Arrayyy[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_di_len(Node_B[pb], 2 * (Kich_thuoc));
                        Den_tdo_x_node(Node_B[pb], pb);
                    });

                }
                for (i = 0; (pa < spt) && (i < k); i++, pa++, pc++)
                {
                    c[pc] = Arrayy[pa];
                    Node_C[pc] = Arrayyy[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_di_xuong(Node_C[pc], (Kich_thuoc + 80));
                        Den_tdo_x_node(Node_C[pc], pc);
                    });
                }
            }
            nb = pb;
            nc = pc;

            //
        }
        //Hàm kết hợp b và c vào a
        void Merge_tang(int nb, int nc, int k)
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
                if (b[pb + ib] <= c[pc + ic])
                {
                    Arrayy[pa] = b[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Den_vtri_node(Node_B[pb + ib], pa);
                    });
                    Arrayyy[pa] = Node_B[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            Arrayy[pa] = c[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                Den_vtri_node(Node_C[pc + ic], pa);
                            });
                            Arrayyy[pa] = Node_C[pc + ic];
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
                    Arrayy[pa] = c[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Den_vtri_node(Node_C[pc + ic], pa);
                    });
                    Arrayyy[pa] = Node_C[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            Arrayy[pa] = b[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                Den_vtri_node(Node_B[pb + ib], pa);
                            });
                            Arrayyy[pa] = Node_B[pb + ib];
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
                    Den_vtri_node(Node_B[lennb - nb], pa);
                });
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    Den_vtri_node(Node_C[lennc - nc], pa);
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
                if (b[pb + ib] >= c[pc + ic])
                {
                    Arrayy[pa] = b[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Den_vtri_node(Node_B[pb + ib], pa);
                    });
                    Arrayyy[pa] = Node_B[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            Arrayy[pa] = c[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                Den_vtri_node(Node_C[pc + ic], pa);
                            });
                            Arrayyy[pa] = Node_C[pc + ic];
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
                    Arrayy[pa] = c[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Den_vtri_node(Node_C[pc + ic], pa);
                    });
                    Arrayyy[pa] = Node_C[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            Arrayy[pa] = b[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                Den_vtri_node(Node_B[pb + ib], pa);
                            });
                            Arrayyy[pa] = Node_B[pb + ib];
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
                    Den_vtri_node(Node_B[lennb - nb], pa);
                });
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    Den_vtri_node(Node_C[lennc - nc], pa);
                });
                pa++;
            }

        }
        //Hàm sắp xếp Merge

        void MergeSortTang()
        {
            DauMuiTen();
            lblA.Visible = true;
            lblC.Visible = true;
            lblB.Visible = true;
            b = new int[spt];
            c = new int[spt];
            Node_B = new Label[spt];
            Node_C = new Label[spt];
            //Dán nhãn mảng b

            int k, nc = 0, nb = 0;
            for (k = 1; k < spt; k *= 2)
            {
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "k = " + k;
                Distribute(ref nb, ref nc, k);
                Merge_tang(nb, nc, k);
            }
            HoanThanh();
        }
        void MergeSortGiam()
        {
            DauMuiTen();
            b = new int[spt];
            c = new int[spt];
            Node_B = new Label[spt];
            Node_C = new Label[spt];
            //Dán nhãn mảng b

            int k, nc = 0, nb = 0;
            for (k = 1; k < spt; k *= 2)
            {
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "k = " + k;
                Distribute(ref nb, ref nc, k);
                Merge_giam(nb, nc, k);
            }
            HoanThanh();
        }
        #endregion
        #endregion
        private void HienThiCode()
        {
            listCode.Items.Clear();
            listIdea.Items.Clear();
            CanLe();
            YTuong ytuong = new YTuong();
            CodeC code = new CodeC();

            listCode.Font = new Font("Aril", 12, FontStyle.Regular);
            listIdea.Font = new Font("Aril", 12, FontStyle.Regular);
            listIdea.ForeColor = Color.White;

            if (radQuick.Checked)
            {
                code.quicksort(listCode, tang);
                ytuong.Quicksort(listIdea);
            }
            if (radHeap.Checked)
            {
                code.heapsort(listCode, tang);
                ytuong.Heapsort(listIdea);
            }
            if (radInsertion.Checked)
            {
                code.insertionsort(listCode, tang);
                ytuong.Insertionsort(listIdea);
            }
            if (radMerge.Checked)
            {
                code.mergesort(listCode, tang);
                ytuong.Mergesort(listIdea);
            }
            if (radInterchange.Checked)
            {
                code.interchangesort(listCode, tang);
                ytuong.Interchangesort(listIdea);
            }
            if (radShell.Checked)
            {
                code.shellsort(listCode, tang);
                ytuong.Shellsort(listIdea);
            }
            if (radBubble.Checked)
            {
                code.bubblesort(listCode, tang);
                ytuong.Bubblesort(listIdea);
            }
            if (radSelection.Checked)
            {
                code.selectionsort(listCode, tang);
                ytuong.Selectionsort(listIdea);
            }

        }
        public void HoanThanh()
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
            MessageBox.Show("Sắp xếp hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void radDecrease_CheckedChanged(object sender, EventArgs e)
        {
            tang = false;
            HienThiCode();
        }
        public void DauMuiTen()
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

        private void speedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            TocDo = speedTrackBar.Maximum - speedTrackBar.Value;
        }

        private void bntReset_Click(object sender, EventArgs e)
        {
           
        }


        private void bntPlay_Click(object sender, EventArgs e)
        {
            bntPlay.Hide();
            bntPause.Show();

            if (KT_tam_dung == false)
            {
                if (radSelection.Checked == true && tang == true)
                    SelectionSortTang(Arrayy);
                if (radSelection.Checked == true && tang == false)
                    SelectionSortGiam(Arrayy);
                if (radBubble.Checked == true && tang == true)
                    BubbleSortTang(Arrayy);
                if (radBubble.Checked == true && tang == false)
                    BubbleSortGiam(Arrayy);
                if (radShell.Checked == true && tang == true)
                    ShellSortTang(Arrayy);
                if (radShell.Checked == true && tang == false)
                    ShellSortGiam(Arrayy);
                if (radQuick.Checked == true && tang == true)
                {
                    QuickSortTang(Arrayy, 0, spt - 1);
                    HoanThanh();
                }
                if (radQuick.Checked == true && tang == false)
                {
                    QuickSortGiam(Arrayy, 0, spt - 1);
                    HoanThanh();
                }
                if (radHeap.Checked == true && tang == true)
                    HeapSortTang(spt);
                if (radHeap.Checked == true && tang == false)
                    HeapSortGiam(spt);
                if (radInsertion.Checked == true && tang == true)
                    InsertionSortTang(Arrayy);
                if (radInsertion.Checked == true && tang == false)
                    InsertionSortGiam(Arrayy);
                if (radInterchange.Checked == true && tang == true)
                    InterchangeSortTang(Arrayy);
                if (radInterchange.Checked == true && tang == false)
                    InterchangeSortGiam(Arrayy);
                if (radMerge.Checked == true && tang == true)
                    MergeSortTang();
                if (radMerge.Checked == true && tang == false)
                    MergeSortGiam();
            }
            else
            {
                KT_tam_dung = false;
            }


        }



        private void bntPause_Click(object sender, EventArgs e)
        {
            bntPlay.Show();
            bntPause.Hide();
            KT_tam_dung = true;
            Play_or_Stop();
        }

        public void Tam_dung()
        {
            if (ckDebug.Checked == true)
            {
                KT_tam_dung = true;
                Play_or_Stop();
            }
        }

        public void Play_or_Stop()
        {
            while (KT_tam_dung == true)
            {
                Application.DoEvents();
            }
        }


        public void ChonDongChoCodeListBox(int viTri)
        {
            Tre(TocDo * 30);
            listCode.SelectedIndex = viTri;

            // nếu đang trong chế độ Debug thì dừng sau mỗi câu lệnh chạy xong sẽ dừng lại
            if (ckDebug.Checked)
            {
                KT_tam_dung = true;
                Play_or_Stop();
            }
        }

        private void radIncrease_CheckedChanged(object sender, EventArgs e)
        {
            tang = true;
            HienThiCode();
        }

        private void bntDebug_Click(object sender, EventArgs e)
        {
            KT_tam_dung = false;
        }


        //Hàm Trễ
        public void Tre(int milisecond)
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
    }
}

