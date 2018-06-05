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

        int[] Arrayy;
        Label[] Arrayyy;
        Label[] Node_B, Node_C;
        int[] b, c;
        int KcNode = 18;
        int spt;
        bool check = true;
        int Kich_thuoc = 50;
        int Canh_le = 30;
        int tocdo = 60;
        bool tang;

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
            pnlBangDieuKhien.Enabled = false;
            grpDebug.Enabled = false;
            tang = true;
            listIdea.Hide();

        }

        private void bntCreate_Click(object sender, EventArgs e)
        {
            pnlChayMau.Controls.Clear();
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
            pnlBangDieuKhien.Enabled = true;
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
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y + ((p1.Y - p2.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top -= 1;
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
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
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
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y)
                    {
                        Application.DoEvents();
                        t.Top -= 1;
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
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
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

        private void bntPlay_Click(object sender, EventArgs e)
        {
            BatDau();
        }
        public void BatDau()
        {
            if (radSelection.Checked == true && radIncrease.Checked == true)
                SelectionSortTang(Arrayy);
            else if (radSelection.Checked == true && radIncrease.Checked == false)
                SelectionSortGiam(Arrayy);
            else if (radBubble.Checked == true && radIncrease.Checked == true)
                BubbleSortTang(Arrayy);
            else if (radBubble.Checked == true && radIncrease.Checked == false)
                BubbleSortGiam(Arrayy);
            else if (radShell.Checked == true && radIncrease.Checked == true)
                ShellSortTang(Arrayy);
            else if (radShell.Checked == true && radIncrease.Checked == false)
                ShellSortGiam(Arrayy);
            else if (radQuick.Checked == true && radIncrease.Checked == true)
                QuickSortTang(Arrayy, 0, Arrayy.Length - 1);
            else if (radQuick.Checked == true && radIncrease.Checked == false)
                QuickSortGiam(Arrayy, 0, Arrayy.Length - 1);
            else if (radHeap.Checked == true && radIncrease.Checked == true)
                HeapSortTang(Arrayy);
            else if (radHeap.Checked == true && radIncrease.Checked == false)
                HeapSortGiam(Arrayy);
            else if (radInsertion.Checked == true && radIncrease.Checked == true)
                InsertionSortTang(Arrayy);
            else if (radInsertion.Checked == true && radIncrease.Checked == false)
                InsertionSortGiam(Arrayy);
            else if (radInterchange.Checked == true && radIncrease.Checked == true)
                InterchangeSortTang(Arrayy);
            else if (radInterchange.Checked == true && radIncrease.Checked == false)
                InterchangeSortGiam(Arrayy);
            else if (radMerge.Checked == true && radIncrease.Checked == true)
                MergeSortTang();
            else MergeSortGiam();
        }

        #region Các thuật toán sắp xếp
        #region interchange
        private void InterchangeSortGiam(int[] Arrayy)
        {
            for (int i = 0; i < spt - 1; i++)
            {
                for (int j = i + 1; j < spt; j++)
                {
                    if (Arrayy[j] > Arrayy[i])
                    {
                        Swap_Giatri(ref Arrayy[i], ref Arrayy[j]);
                        Thread.Sleep(5);
                        Swap_Node(Arrayyy[j], Arrayyy[i]);
                        Swap_NodeAn(j, i);
                    }

                }
            }
            HoanThanh();
        }
        private void InterchangeSortTang(int[] Arrayy)
        {
            for (int i = 0; i < spt - 1; i++)
            {

                for (int j = i + 1; j < spt; j++)
                {

                    if (Arrayy[j] < Arrayy[i])
                    {
                        Swap_Giatri(ref Arrayy[j], ref Arrayy[i]);
                        Swap_Node(Arrayyy[j], Arrayyy[i]);
                        Swap_NodeAn(j, i);
                        Thread.Sleep(5);
                    }

                }
            }
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
                    Thread.Sleep(100);
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
                        Thread.Sleep(100);
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        Thread.Sleep(100);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh( a[min] , a[" + j + "] )";
                        lbl_status_02.Refresh();
                        Thread.Sleep(100);
                        lbl_status_02.Visible = false;
                        if (Arrayy[j] < Arrayy[min])
                        {
                            ChonDongChoCodeListBox(8);
                            min = j;
                            Mui_ten_xanh_len_1.Text = "Min=" + min;
                            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * min) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y + 2 * Kich_thuoc + 5);
                            Mui_ten_xanh_len_1.Refresh();
                            Thread.Sleep(100);
                        }

                    }
                    if (min != i)
                    {
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "Hoan_vi( a[i] , a[min] )";
                        Thread.Sleep(100);
                        lbl_status_02.Visible = false;
                        Swap_Giatri(ref Arrayy[min], ref Arrayy[i]);
                        Swap_Node(Arrayyy[min], Arrayyy[i]);
                        Swap_NodeAn(min, i);
                        System.Threading.Thread.Sleep(15);
                    }
                    ChonDongChoCodeListBox(10);
                }
            });
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
                    Application.DoEvents();
                    ChonDongChoCodeListBox(3);

                    ChonDongChoCodeListBox(5);
                    max = i;

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    //thiết lập mũi tên chỉ vị trí MIN đầu tiên
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
                        lbl_status_02.Text = "So_Sanh( a[Max] , a[" + j + "] )";
                        lbl_status_02.Refresh();
                        //đánh dấu phần tử lúc so sánh với min                       

                        lbl_status_02.Visible = false;
                        // bỏ đánh dấu sau khi đã có kết quả so sánh

                        if (Arrayy[j] > Arrayy[max])
                            max = j;
                    }
                    if (max != i)
                    {
                        Swap_Giatri(ref Arrayy[max], ref Arrayy[i]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(Arrayyy[max], Arrayyy[i]);
                        Swap_NodeAn(max, i);
                    }

                }
            });
            HoanThanh();
        }
        #endregion
        #region shell
        private void ShellSortTang(int[] Arrayy)
        {
            for (int i = spt / 2; i > 0; i /= 2)
            {
                for (int j = i; j < spt; j++)
                {
                    for (int k = j; k >= i && Arrayy[k] < Arrayy[k - i]; k -= i)
                    {
                        Swap_Giatri(ref Arrayy[k - i], ref Arrayy[k]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(Arrayyy[k], Arrayyy[k - i]);
                        Swap_NodeAn(k, k - i);
                    }
                }
            }
            HoanThanh();
        }
        private void ShellSortGiam(int[] Arrayy)
        {
            for (int i = spt / 2; i > 0; i /= 2)
            {
                for (int j = i; j < spt; j++)
                {
                    for (int k = j; k >= i && Arrayy[k] > Arrayy[k - i]; k -= i)
                    {
                        Swap_Giatri(ref Arrayy[k - i], ref Arrayy[k]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(Arrayyy[k], Arrayyy[k - i]);
                        Swap_NodeAn(k, k - i);
                    }
                }
            }
            HoanThanh();
        }
        #endregion
        #region bubble
        private void BubbleSortTang(int[] Arrayy)
        {
            ChonDongChoCodeListBox(0);
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < spt - 1; i++)
                {
                    //Hieu ung xem code
                    ChonDongChoCodeListBox(3);

                    //Thiết lập mũi tên chỉ biến i
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (int j = spt - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        //Hieu ung xem code
                        ChonDongChoCodeListBox(4);
                        //Thiết lập mũi tên chỉ biến j
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y + 2 * Kich_thuoc + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        lbl_status_02.Visible = false;
                        //Hieu ung xem code
                        ChonDongChoCodeListBox(5);
                        if (Arrayy[j] < Arrayy[j - 1])
                        {
                            ChonDongChoCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();
                            Application.DoEvents();
                            Swap_Giatri(ref Arrayy[j - 1], ref Arrayy[j]);
                            System.Threading.Thread.Sleep(5);
                            Swap_Node(Arrayyy[j], Arrayyy[j - i]);
                            Swap_NodeAn(j, j - i);
                            lbl_status_02.Visible = false;
                        }

                    }
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();
                    lbl_status_02.Visible = false;
                }
            });
            HoanThanh();
        }
        private void BubbleSortGiam(int[] Arrayy)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < spt - 1; i++)
                {
                    //Hieu ung xem code
                    ChonDongChoCodeListBox(3);

                    //Thiết lập mũi tên chỉ biến i
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                    Mui_ten_xanh_xuong_1.Refresh();

                    Application.DoEvents();
                    for (int j = spt - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        //Hieu ung xem code
                        ChonDongChoCodeListBox(4);

                        //Thiết lập mũi tên chỉ biến j
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y + 2 * Kich_thuoc + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = true;

                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();

                        lbl_status_02.Visible = false;
                        //Hieu ung xem code
                        ChonDongChoCodeListBox(5);

                        if (Arrayy[j] > Arrayy[j - 1])
                        {
                            ChonDongChoCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref Arrayy[j - 1], ref Arrayy[j]);
                            System.Threading.Thread.Sleep(5);
                            Swap_Node(Arrayyy[j], Arrayyy[j - i]);
                            Swap_NodeAn(j, j - i);
                        }

                        //Cập nhật Status
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                        lbl_status_02.Refresh();

                        lbl_status_02.Visible = false;
                    }
                }
            });
            HoanThanh();
        }
        #endregion
        #region insertion
        private void InsertionSortTang(int[] Arrayy)
        {
            int i, pos, x;
            int Chi_so_tam;
            Label Node_tam;
            int Dem_node;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 1; i < spt; i++)
                {
                    Dem_node = 0;
                    x = Arrayy[i];
                    Node_tam = Arrayyy[i];
                    Chi_so_tam = i;
                    pos = i - 1;

                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_di_len(Node_tam, (Kich_thuoc + 5));
                    });

                    while ((pos >= 0) && (Arrayy[pos] > x))
                    {

                        Application.DoEvents();
                        //Dịch chuyển Node qua phải
                        Arrayy[pos + 1] = Arrayy[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_qua_phai(Arrayyy[pos], 1);
                        });
                        int k = pos + 1;
                        Swap_NodeAn(pos, k);
                        pos--;
                        Arrayy[pos + 1] = x;

                    }
                    //status hoán vị
                    if (Dem_node > 0)
                    {
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

                    Arrayyy[pos + 1] = Node_tam;
                }
            });
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
                    Dem_node = 0;
                    x = Arrayy[i];
                    Node_tam = Arrayyy[i];
                    Chi_so_tam = i;
                    pos = i - 1;

                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_di_len(Node_tam, (Kich_thuoc + 5));
                    });
                    while ((pos >= 0) && (Arrayy[pos] < x))
                    {

                        Arrayy[pos + 1] = Arrayy[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_qua_phai(Arrayyy[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        pos--;
                        Arrayy[pos + 1] = x;
                    }
                    if (Dem_node > 0)
                    {

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
                }
            });
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

                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * cs_x) + (Kich_thuoc / 2) - 30, Arrayyy[cs_x].Location.Y + 2 * Kich_thuoc + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Đặt màu nút x                    
                //         
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
                    lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    ChonDongChoCodeListBox(7);
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
                        lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    }
                    lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    ChonDongChoCodeListBox(8);
                    while (Arrayy[j] > pivot)
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
                        lbl_status_02.Text = "Hoan_Vi(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref Arrayy[i], ref Arrayy[j]);
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        System.Threading.Thread.Sleep(5);
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
                    ChonDongChoCodeListBox(18);
                    QuickSortTang(Arrayy, left, j);
                }
                if (i < right)
                {
                    ChonDongChoCodeListBox(19);
                    QuickSortTang(Arrayy, i, right);
                }
            }
            HoanThanh();
        }
        private void QuickSortGiam(int[] Arrayy, int left, int right)
        {
            if (left < right)
            {
                int pivot = Arrayy[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * left) + (Kich_thuoc / 2) - 30, Arrayyy[left].Location.Y + 2 * Kich_thuoc + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * right) + (Kich_thuoc / 2) - 30, Arrayyy[right].Location.Y + 2 * Kich_thuoc + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                ChonDongChoCodeListBox(3);
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * cs_x) + (Kich_thuoc / 2) - 30, Arrayyy[cs_x].Location.Y + 2 * Kich_thuoc + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                ChonDongChoCodeListBox(4);
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
                do
                {
                    lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    ChonDongChoCodeListBox(8);
                    while (Arrayy[i] > pivot)
                    {
                        i++;
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * i) + (Kich_thuoc / 2) - 30, Arrayyy[i].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    }
                    lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    ChonDongChoCodeListBox(9);
                    while (Arrayy[j] < pivot)
                    {
                        j--;
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * j) + (Kich_thuoc / 2) - 30, Arrayyy[j].Location.Y - Kich_thuoc - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    }
                    if (i <= j)
                    {
                        lbl_status_02.Text = "Hoan_Vi(a[" + i + "], a[" + j + "])";

                        ChonDongChoCodeListBox(12);
                        Swap_Giatri(ref Arrayy[i], ref Arrayy[j]);
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(Arrayyy[i], Arrayyy[j]);
                        Swap_NodeAn(j, i);
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((Canh_le + (Kich_thuoc + KcNode) * cs_x) + (Kich_thuoc / 2) - 30, Arrayyy[cs_x].Location.Y + 2 * Kich_thuoc + 40);
                        Mui_ten_do_len.Text = "X = " + ((left + right) / 2);
                        Mui_ten_do_len.Refresh();
                        ChonDongChoCodeListBox(13);
                        i++;
                        j--;
                    }
                }
                while (i <= j);
                ChonDongChoCodeListBox(16);
                if (left < j)
                {
                    ChonDongChoCodeListBox(18);
                    QuickSortTang(Arrayy, left, j);
                }
                if (i < right)
                {
                    ChonDongChoCodeListBox(19);
                    QuickSortTang(Arrayy, i, right);
                }
            }
            HoanThanh();
        }
        #endregion
        #region heap
        private void HeapSortTang(int[] Arrayy)
        {
            for (int p = (spt - 1) / 2; p >= 0; --p)
                MaxHeapifyTang(Arrayy, spt, p);

            for (int i = spt - 1; i > 0; --i)
            {
                Swap_Giatri(ref Arrayy[0], ref Arrayy[i]);
                Swap_Node(Arrayyy[i], Arrayyy[0]);
                Swap_NodeAn(i, 0);
                --spt;
                MaxHeapifyTang(Arrayy, spt, 0);
            }
            HoanThanh();
        }
        private void MaxHeapifyTang(int[] Arrayy, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && Arrayy[left] > Arrayy[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && Arrayy[right] > Arrayy[largest])
                largest = right;

            if (largest != index)
            {
                Swap_Giatri(ref Arrayy[largest], ref Arrayy[index]);
                Swap_Node(Arrayyy[largest], Arrayyy[index]);
                Swap_NodeAn(largest, index);
                MaxHeapifyTang(Arrayy, heapSize, largest);
            }
        }
        private void HeapSortGiam(int[] Arrayy)
        {
            for (int p = (spt - 1) / 2; p >= 0; --p)
                MaxHeapifyGiam(Arrayy, spt, p);

            for (int i = spt - 1; i > 0; --i)
            {
                Swap_Giatri(ref Arrayy[0], ref Arrayy[i]);
                Swap_Node(Arrayyy[i], Arrayyy[0]);
                Swap_NodeAn(i, 0);
                --spt;
                MaxHeapifyGiam(Arrayy, spt, 0);
            }
            HoanThanh();
        }
        private void MaxHeapifyGiam(int[] Arrayy, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && Arrayy[left] < Arrayy[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && Arrayy[right] < Arrayy[largest])
                largest = right;

            if (largest != index)
            {
                Swap_Giatri(ref Arrayy[index], ref Arrayy[largest]);
                Swap_Node(Arrayyy[largest], Arrayyy[index]);
                Swap_NodeAn(largest, index);
                MaxHeapifyGiam(Arrayy, heapSize, largest);
            }
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
        public static ManualResetEvent codeListBoxPauseStatus = new ManualResetEvent(true);
        public static bool CodeListBoxIsPause = false;
        public void ChonDongChoCodeListBox(int viTri)
        {
            Thread.Sleep(tocdo * 30);
            codeListBoxPauseStatus.WaitOne(Timeout.Infinite); // có thể pause mỗi khi chuyển line
            listCode.SelectedIndex = viTri;

            // nếu đang trong chế độ Debug thì dừng sau mỗi câu lệnh chạy xong sẽ dừng lại
            if (ckDebug.Checked)
            {
                codeListBoxPauseStatus.Reset();
                CodeListBoxIsPause = true;
            }
        }
    }
}
