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

        int[] arrNode;
        Label[] ArrLbl;
        Label[] Node_B, Node_C;
        int[] b, c;
        int DisN = 18; // Distance Node
        int nOe; // number of element 
        int SizeN = 50;  // Size Node
        int Canh_le = 30;
        int Speed = 60;
        bool increase;
        bool checkPause = false;
        Color colorMove = Color.LightGreen;
        Color colorComplete = Color.DarkViolet;
        Color colorDefault = Color.Orange;
        Color colorQuickU = Color.AliceBlue;
        Color colorQuickD = Color.Aquamarine;
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
            nOe = (int)numArray.Value;
            grpCreateArray.Enabled = false;
            pnlLoaiThuatToan.Enabled = false;
            grpControl.Enabled = false;
            grpDebug.Enabled = false;
            increase = true;
            listIdea.Hide();
            speedTrackBar.Maximum = Speed;
            speedTrackBar.Minimum = 0;
            speedTrackBar.Value = Speed / 2;
            speedTrackBar.LargeChange = 1;
            SignArrow();
        }
        public void CompleteSwap()
        {
            nOe = (int)numArray.Value;
            for (int i = 0; i < nOe; i++)
                ArrLbl[i].BackColor = Color.Aqua;
            Complete();
        }
        private void btnCCN_Click(object sender, EventArgs e)
        {
            //colorMove     = Color.Red;
            //colorComplete = Color.Yellow;
            //colorDefault  = Color.Green;
            //colorQuickU   = Color.AliceBlue;
            //colorQuickD   = Color.Aquamarine;
        }
        private void bntCreate_Click(object sender, EventArgs e)
        {
            //pnlChayMau.Controls.Clear();
            if (nOe == 0)
            {
                MessageBox.Show("Error", "Vui lòng nhập số phần tử !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; /// > >> >
            }
            else
            {
                arrNode = new int[nOe];
                ArrLbl = new Label[nOe];
                for (int i = 0; i < nOe; i++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Size = new Size(40, 40);
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    label.Font = new Font("Times New Roman", 14);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Text = "0";
                    label.BackColor = colorDefault;
                    label.Location = new Point(Canh_le + (SizeN + DisN) * i, 3 * SizeN);
                    ArrLbl[i] = label;
                    pnlChayMau.Controls.Add(ArrLbl[i]);
                }
            }
            grpCreateArray.Enabled = true;
        }
        private void numArray_ValueChanged(object sender, EventArgs e)
        {
            nOe = int.Parse(numArray.Value.ToString());
        }
        private void bntRandom_Click(object sender, EventArgs e)
        {
            pnlLoaiThuatToan.Enabled = true;
            grpControl.Enabled = true;
            grpDebug.Enabled = true;
            Random r = new Random();
            for (int i = 0; i < nOe; i++)
            {
                int rd = r.Next(0, 99);

                ArrLbl[i].Text = rd + "";
                arrNode[i] = rd;
            }
            ShowCode();
        }
        private void bntByHand_Click(object sender, EventArgs e)
        {
            frmByHand a = new frmByHand();
            a.Message = numArray.Value.ToString();
            a.ShowDialog();
            for (int i = 0; i < nOe; i++)
            {

                switch (i + 1)
                {
                    case 1: ArrLbl[i].Text = PT1; arrNode[i] = Int32.Parse(PT1); break;
                    case 2: ArrLbl[i].Text = PT2; arrNode[i] = Int32.Parse(PT2); break;
                    case 3: ArrLbl[i].Text = PT3; arrNode[i] = Int32.Parse(PT3); break;
                    case 4: ArrLbl[i].Text = PT4; arrNode[i] = Int32.Parse(PT4); break;
                    case 5: ArrLbl[i].Text = PT5; arrNode[i] = Int32.Parse(PT5); break;
                    case 6: ArrLbl[i].Text = PT6; arrNode[i] = Int32.Parse(PT6); break;
                    case 7: ArrLbl[i].Text = PT7; arrNode[i] = Int32.Parse(PT7); break;
                    case 8: ArrLbl[i].Text = PT8; arrNode[i] = Int32.Parse(PT8); break;
                    case 9: ArrLbl[i].Text = PT9; arrNode[i] = Int32.Parse(PT9); break;
                    case 10: ArrLbl[i].Text = PT10; arrNode[i] = Int32.Parse(PT10); break;
                }
            }
            pnlLoaiThuatToan.Enabled = true;
            grpControl.Enabled = true;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
        #region functions moving
        public void Node_Right(Control t, int Step)
        {
            Application.DoEvents();

            this.Invoke((MethodInvoker)delegate
            {
                int Loop_Count = ((SizeN + DisN)) * Step; //Số lần dịch chuyển
                {
                    while (Loop_Count > 0)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Tre(Speed);
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
                int Loop_Count = ((SizeN + DisN)) * Step; //Số lần dịch chuyển
                while (Loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Left -= 1;
                    Tre(Speed);
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
                    Tre(Speed);
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
                    Tre(Speed);
                    loop_Count--;
                    t.BackColor = colorMove;
                }
                t.Refresh();
            });
        }
        public void toLocaN(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(Canh_le + (SizeN + DisN) * i, 150);//vị trí của Node i
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
                        Tre(Speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y + ((p1.Y - p2.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Tre(Speed);
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
                        Tre(Speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Tre(Speed);
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
                        Tre(Speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y)
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Tre(Speed);
                        t.Refresh();
                    }
                }
            });
        }
        // Dịch chuyển 1 Node về vị trí bằng với X của Node[i]
        public void Den_tdo_x_node(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(Canh_le + (SizeN + DisN) * i, 150);//vị trí của Node i
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
                        Tre(Speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Tre(Speed);
                        t.Refresh();
                    }
                }

            });
        }
        #endregion
        #region functions conversion
        public void Swap_NodeAn(int a, int b)
        {
            Label temp = ArrLbl[a];
            ArrLbl[a] = ArrLbl[b];
            ArrLbl[b] = temp;
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
                    while ((t1.Location.Y > p1.Y - (SizeN + 5)) || (t2.Location.Y < p2.Y + (SizeN + 5)))
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
        #region Sort algorithms
        #region interchange
        private void InterchangeSortGiam(int[] arrNode)
        { 
            ChonDongChoCodeListBox(2);
            int i = 0, j = 0;
            Mui_ten_xanh_len_1.Text = "i = " + i;
            Mui_ten_xanh_len_1.Location = new Point(Canh_le + (SizeN + DisN) * i, pnlChayMau.Height -50);
            Mui_ten_xanh_len_1.Visible = true;
            for ( i = 0; i < nOe - 1; i++)
            {
                ChonDongChoCodeListBox(3);
                j = i + 1;
                Mui_ten_xanh_len_2.Text = "j = " + j;
                Mui_ten_xanh_len_2.Location = new Point(Canh_le + (SizeN + DisN) * j, pnlChayMau.Height - 50);
                Mui_ten_xanh_len_2.Visible = true;
                for ( j = i + 1; j < nOe; j++)
                {
                    ChonDongChoCodeListBox(4);
                    lbl_status_02.Text = "SoSanh(a[" + i + "],a[" + j + "])";
                    lbl_status_02.Visible = true;
                    if (arrNode[j] > arrNode[i])
                    {
                        ChonDongChoCodeListBox(6);
                        lbl_status_02.Text = "HoanVi(a[" + i + "],a[" + j + "])";
                        Swap_Giatri(ref arrNode[i], ref arrNode[j]);
                        Swap_Node(ArrLbl[j], ArrLbl[i]);
                        Swap_NodeAn(j, i);
                        ArrLbl[i].BackColor = colorComplete;
                    }
                    if (j + 1 < nOe)
                    {
                        Mui_ten_xanh_len_2.Text = "j = " + (j + 1);
                        Mui_ten_xanh_len_2.Location = new Point(Canh_le + (SizeN + DisN) * (j + 1), pnlChayMau.Height - 50);
                        Refresh();
                    }
                    ArrLbl[i].BackColor = colorDefault;
                }
                ChonDongChoCodeListBox(3);
                lbl_status_02.Visible = false;
                Mui_ten_xanh_len_1.Text = "i = " + (i + 1);
                Mui_ten_xanh_len_1.Location = new Point(Canh_le + (SizeN + DisN) * (i + 1), pnlChayMau.Height - 50);
            }
            ChonDongChoCodeListBox(0);
        }
        private void InterchangeSortincrease(int[] arrNode)
        {

            ChonDongChoCodeListBox(2);
            int i = 0, j = 0;
            Mui_ten_xanh_len_1.Text = "i = " + i;
            Mui_ten_xanh_len_1.Location = new Point(Canh_le + (SizeN + DisN) * i, pnlChayMau.Height - 50);
            Mui_ten_xanh_len_1.Visible = true;
            Refresh();
            for (i = 0; i < nOe - 1; i++)
            {
                ChonDongChoCodeListBox(3);
                j = i + 1;
                Mui_ten_xanh_len_2.Text = "j = " + j;
                Mui_ten_xanh_len_2.Location = new Point(Canh_le + (SizeN + DisN) * j, pnlChayMau.Height - 50);
                Mui_ten_xanh_len_2.Visible = true;
                Refresh();
                for (j = i + 1; j < nOe; j++)
                {
                    ChonDongChoCodeListBox(4);
                    lbl_status_02.Text = "SoSanh(a[" + i + "],a[" + j + "])";
                    lbl_status_02.Visible = true;
                    if (arrNode[j] < arrNode[i])
                    {
                        ChonDongChoCodeListBox(6);
                        lbl_status_02.Text = "HoanVi(a[" + i + "],a[" + j + "])";
                        Swap_Giatri(ref arrNode[j], ref arrNode[i]);
                        Swap_Node(ArrLbl[j], ArrLbl[i]);
                        Swap_NodeAn(j, i);
                        ArrLbl[i].BackColor = colorComplete;
                    }
                    if (j+1 < nOe)
                    {
                        Mui_ten_xanh_len_2.Text = "j = " + (j + 1);
                        Mui_ten_xanh_len_2.Location = new Point(Canh_le + (SizeN + DisN) * (j + 1), pnlChayMau.Height - 50);
                        Refresh();
                    }
                    ArrLbl[i].BackColor = colorDefault;
                }
                ChonDongChoCodeListBox(3);
                lbl_status_02.Visible = false;
                Mui_ten_xanh_len_1.Text = "i = " + (i + 1);
                Mui_ten_xanh_len_1.Location = new Point(Canh_le + (SizeN + DisN) * (i + 1), pnlChayMau.Height - 50);
                Refresh();
            }
            ChonDongChoCodeListBox(0);
        }
        #endregion
        #region selection
        private void SelectionSortincrease(int[] arrNode)
        {
            int min;
            SignArrow();
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < nOe - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    ChonDongChoCodeListBox(5);

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    min = i;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Text = "Min=" + min;
                    Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * min) + (SizeN / 2) - 30, ArrLbl[min].Location.Y + 2 * SizeN + 5);
                    Mui_ten_xanh_len_1.Refresh();

                    for (int j = i + 1; j < nOe; j++)
                    {
                        ChonDongChoCodeListBox(6);
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "SoSanh( a[min] , a[" + j + "] )";
                        lbl_status_02.Refresh();
                        if (arrNode[j] < arrNode[min])
                        {
                            ChonDongChoCodeListBox(8);
                            min = j;
                            Mui_ten_xanh_len_1.Text = "Min=" + min;
                            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * min) + (SizeN / 2) - 30, ArrLbl[j].Location.Y + 2 * SizeN + 5);
                            Mui_ten_xanh_len_1.Refresh();
                        }

                    }
                    if (min != i)
                    {
                        ChonDongChoCodeListBox(10);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "HoanVi( a[i] , a[min] )";
                        Swap_Giatri(ref arrNode[min], ref arrNode[i]);
                        Swap_Node(ArrLbl[min], ArrLbl[i]);
                        Swap_NodeAn(min, i);
                        ArrLbl[i].BackColor = colorComplete;
                        ArrLbl[min].BackColor = colorDefault;
                    }
                    else
                        ArrLbl[i].BackColor = colorComplete;
                    lbl_status_02.Visible = false;

                }
            });
            ChonDongChoCodeListBox(0);
        }
        private void SelectionSortGiam(int[] arrNode)
        {
            SignArrow();
            int max;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < nOe - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    ChonDongChoCodeListBox(5);
                    max = i;

                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Text = "Max=" + max;
                    Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * max) + (SizeN / 2) - 30, ArrLbl[max].Location.Y + 2 * SizeN + 5);
                    Mui_ten_xanh_len_1.Refresh();
                    for (int j = i + 1; j < nOe; j++)
                    {
                        ChonDongChoCodeListBox(6);
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);

                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "SoSanh( a[max] , a[" + j + "] )";
                        if (arrNode[j] > arrNode[max])
                        {
                            max = j;
                            Mui_ten_xanh_len_1.Text = "Max=" + max;
                            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * max) + (SizeN / 2) - 30, ArrLbl[j].Location.Y + 2 * SizeN + 5);
                            Mui_ten_xanh_len_1.Refresh();
                        }
                    }
                    if (max != i)
                    {
                        ChonDongChoCodeListBox(10);
                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "HoanVi( a[i] , a[max] )";
                        Swap_Giatri(ref arrNode[max], ref arrNode[i]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(ArrLbl[max], ArrLbl[i]);
                        Swap_NodeAn(max, i);
                        ArrLbl[i].BackColor = colorComplete;
                        ArrLbl[max].BackColor = colorDefault;
                    }
                    else
                        ArrLbl[i].BackColor = colorComplete;
                    lbl_status_02.Visible = false;
                }
            });
            ChonDongChoCodeListBox(0);
        }
        #endregion
        #region shell
        private void ShellSortincrease(int[] arrNode)
        {

            for (int i = nOe / 2; i > 0; i /= 2)
            {
                ChonDongChoCodeListBox(2);
                Mui_ten_xanh_xuong_1.Text = "i = " + i;
                Mui_ten_xanh_xuong_1.Location = new Point(Canh_le-10 + (SizeN + DisN) * 0, 40);
                Mui_ten_xanh_xuong_1.SendToBack();
                Mui_ten_xanh_xuong_1.Visible = true;

                for (int j = i; j < nOe; j++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_len_1.Text = "j = " + j;
                    Mui_ten_xanh_len_1.Location = new Point(Canh_le-10 + (SizeN + DisN) * j, 40);
                    Mui_ten_xanh_len_1.Visible = true;


                    for (int k = j; k >= i && arrNode[k] < arrNode[k - i]; k -= i)
                    {
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_xuong_2.Text = "k = " + k;
                        Mui_ten_xanh_xuong_2.Location = new Point(Canh_le -10+ (SizeN + DisN) * k, pnlChayMau.Height - 50);
                        Mui_ten_xanh_xuong_2.SendToBack();
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Text = "HoanVi(a[" + k  + "],a[" + (k - 1) + "])";
                        lbl_status_02.Visible = true;
                        Swap_Giatri(ref arrNode[k - i], ref arrNode[k]);
                        Swap_Node(ArrLbl[k], ArrLbl[k - i]);
                        Swap_NodeAn(k, k - i);
                        ArrLbl[k - i].BackColor = colorDefault;
                        ArrLbl[k].BackColor = colorDefault;
                    }
                    lbl_status_02.Visible = false;
                    ChonDongChoCodeListBox(3);
                }
            }
            ChonDongChoCodeListBox(0);
        }
        private void ShellSortGiam(int[] arrNode)
        {
            for (int i = nOe / 2; i > 0; i /= 2)
            {
                ChonDongChoCodeListBox(2);
                Mui_ten_xanh_xuong_1.Text = "i = " + i;
                Mui_ten_xanh_xuong_1.Location = new Point(Canh_le - 10 + (SizeN + DisN) * 0, 40);
                Mui_ten_xanh_xuong_1.SendToBack();
                Mui_ten_xanh_xuong_1.Visible = true;
                for (int j = i; j < nOe; j++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_len_1.Text = "j = " + j;
                    Mui_ten_xanh_len_1.Location = new Point(Canh_le - 10 + (SizeN + DisN) * j, 40);
                    Mui_ten_xanh_len_1.Visible = true;
                    for (int k = j; k >= i && arrNode[k] > arrNode[k - i]; k -= i)
                    {
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_xuong_2.Text = "k = " + k;
                        Mui_ten_xanh_xuong_2.Location = new Point(Canh_le - 10 + (SizeN + DisN) * k, pnlChayMau.Height - 50);
                        Mui_ten_xanh_xuong_2.SendToBack();
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Text = "HoanVi(a[" + k + "],a[" + (k - 1) + "])";
                        lbl_status_02.Visible = true;
                        Swap_Giatri(ref arrNode[k - i], ref arrNode[k]);
                        System.Threading.Thread.Sleep(5);
                        Swap_Node(ArrLbl[k], ArrLbl[k - i]);
                        Swap_NodeAn(k, k - i);
                        ArrLbl[k - i].BackColor = colorDefault;
                        ArrLbl[k].BackColor = colorDefault;
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
                for (i = 0; i < nOe - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = nOe - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox( 4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y + 2 * SizeN + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ChonDongChoCodeListBox (5);
                        lbl_status_02.Visible = true;
                        if (arrNode[j] < arrNode[j - 1])
                        {
                            //Hieu ung xem code
                            ChonDongChoCodeListBox( 6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref arrNode[j], ref arrNode[j - 1]);
                            Swap_Node(ArrLbl[j], ArrLbl[j - 1]);
                            Swap_NodeAn(j, j - 1);
                            ArrLbl[j - 1].BackColor = colorComplete;
                        }
                        ArrLbl[j].BackColor = colorDefault;
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
                for (i = 0; i < nOe - 1; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = nOe - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y + 2 * SizeN + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So_Sanh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ChonDongChoCodeListBox(5);
                        lbl_status_02.Visible = true;
                        if (arrNode[j] > arrNode[j - 1])
                        {
                            //Hieu ung xem code
                            ChonDongChoCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoan_vi(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref arrNode[j], ref arrNode[j - 1]);
                            Swap_Node(ArrLbl[j], ArrLbl[j - 1]);
                            Swap_NodeAn(j, j - 1);
                            ArrLbl[j - 1].BackColor = colorComplete;
                        }
                        ArrLbl[j].BackColor = colorDefault;
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
                for (i = 1; i < nOe; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    Dem_node = 0;
                    ChonDongChoCodeListBox(5);
                    x = arrNode[i];
                    Node_tam = ArrLbl[i];
                    Chi_so_tam = i;
                    pos = i - 1;
                    //thiết lập mũi tên đánh dấu nút cần chèn
 

                    //Di chuyển Node cần chèn lên
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(Node_tam, (SizeN + 5));
                    });

                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i)";

                    //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                    Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * pos) + (SizeN / 2) - 30, ArrLbl[pos].Location.Y + SizeN + 5);
                    Mui_ten_xanh_len_1.Text = "POS=" + pos;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Refresh();
                    //lbl_status_02.Visible = false
                    while ((pos >= 0) && (arrNode[pos] > x))
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * pos) + (SizeN / 2) - 30, ArrLbl[pos].Location.Y + SizeN + 5);
                        Mui_ten_xanh_len_1.Text = "POS=" + pos;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Refresh();
                        //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        


                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" + pos + "],a[i])";
                        ChonDongChoCodeListBox(9);
                        //Dịch chuyển Node qua phải
                        arrNode[pos + 1] = arrNode[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_Right(ArrLbl[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        ChonDongChoCodeListBox(10);
                        pos--;
                        ChonDongChoCodeListBox(12);
                        arrNode[pos + 1] = x;
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
                        ArrLbl[pos + 1].BackColor = colorDefault;
                    });

                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(Node_tam, (SizeN + 5));
                        //ArrLbl[pos+1].BackColor = colorComplete;
                        ArrLbl[pos + 1].BackColor = colorDefault;
                    });
                    lbl_status_02.Visible = false;
                    Mui_ten_xanh_len_1.Visible = false; ;
                    ArrLbl[pos + 1] = Node_tam;
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
                for (i = 1; i < nOe; i++)
                {
                    ChonDongChoCodeListBox(3);
                    Application.DoEvents();
                    //Thiết lập Node đầu tiên, là Node đã có thứ tự 
                    //đềm số bước dịch chuyển 1 Node
                    Dem_node = 0;
                    ChonDongChoCodeListBox(5);
                    x = arrNode[i];
                    Node_tam = ArrLbl[i];
                    Chi_so_tam = i;
                    pos = i - 1;
                    //thiết lập mũi tên đánh dấu nút cần chèn
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Refresh();

                    //Di chuyển Node cần chèn lên
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(Node_tam, (SizeN + 5));
                    });

                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "So_Sanh(a[" + pos+ "],a[i])";
                    //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                    Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * pos) + (SizeN / 2) - 30, ArrLbl[pos].Location.Y + SizeN + 5);
                    Mui_ten_xanh_len_1.Text = "POS=" + pos;
                    Mui_ten_xanh_len_1.Visible = true;
                    Mui_ten_xanh_len_1.Refresh();
                    //lbl_status_02.Visible = false;
                    while ((pos >= 0) && (arrNode[pos] < x))
                    {
                        Application.DoEvents();
                        ChonDongChoCodeListBox(7);
                        //Thiết lập bàn tay chỉ vi trí có phải vị trí cần chèn không                        
                        Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * pos) + (SizeN / 2) - 30, ArrLbl[pos].Location.Y + SizeN + 5);
                        Mui_ten_xanh_len_1.Text = "POS=" + pos;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Refresh();

                        lbl_status_02.Visible = true;
                        lbl_status_02.Text = "So_Sanh(a[" +pos+ "],a[i])";

                        ChonDongChoCodeListBox(9);
                        //Dịch chuyển Node qua phải
                        arrNode[pos + 1] = arrNode[pos];
                        Dem_node++;

                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            Node_Right(ArrLbl[pos], 1);
                        });
                        Swap_NodeAn(pos + 1, pos);
                        ArrLbl[pos].BackColor = colorComplete;
                        ChonDongChoCodeListBox(10);
                        pos--;
                        ChonDongChoCodeListBox(12);
                        arrNode[pos + 1] = x;


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
                        ArrLbl[pos + 1].BackColor = colorDefault;
                    });

                    Application.DoEvents();
                    Tre(Speed * 30);
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(Node_tam, (SizeN + 5));
                        ArrLbl[pos + 1].BackColor = colorDefault;
                    });
                    //Ẩn status
                    lbl_status_02.Visible = false;
                    //Ẩn mũi tên POS sau khi đã tìm ra POS
                    Mui_ten_xanh_len_1.Visible = false; ;
                    //Thiết lập node nằm trong nhóm đã có thứ tự
                    ArrLbl[pos + 1] = Node_tam;
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
                int pivot = arrNode[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left


                ChonDongChoCodeListBox(2);

                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * left) + (SizeN / 2) - 30, ArrLbl[left].Location.Y + 2 * SizeN + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((Canh_le + (SizeN + DisN) * right) + (SizeN / 2) - 30, ArrLbl[right].Location.Y + 2 * SizeN + 5);
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
                Mui_ten_do_len.Location = new Point((Canh_le + (SizeN + DisN) * cs_x) + (SizeN / 2) - 30, ArrLbl[cs_x].Location.Y + 2 * SizeN + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Thiết lập mũi tên chỉ i

                ChonDongChoCodeListBox(4);
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ChonDongChoCodeListBox(5);

                do
                {

                    ChonDongChoCodeListBox(7);
                    lbl_status_02.Text = "SoSanh(a[" + i + "], a[x])";
                    lbl_status_02.Visible = true;
                    while (arrNode[i] < pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                       // lbl_status_02.Text = "SoSanh(a[" + i + "], a[x])";
                    }
                    ChonDongChoCodeListBox(8);
                    lbl_status_02.Text = "SoSanh(a[" + j + "], a[x])";
                    while (arrNode[j] > pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //

                    }
                    ChonDongChoCodeListBox(9);

                    if (i <= j)
                    {
                        ChonDongChoCodeListBox(11);
                        lbl_status_02.Text = "HoanVi(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref arrNode[i], ref arrNode[j]);
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        Swap_Node(ArrLbl[j], ArrLbl[i]);
                        Swap_NodeAn(j, i);
                        ArrLbl[j].BackColor = colorComplete;
                        ArrLbl[i].BackColor = colorDefault;
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((Canh_le + (SizeN + DisN) * cs_x) + (SizeN / 2) - 30, ArrLbl[cs_x].Location.Y + 2 * SizeN + 40);
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
                    QuickSortincrease(arrNode, left, j);
                }
                ChonDongChoCodeListBox(18);
                if (i < right)
                {
                    ChonDongChoCodeListBox(19);
                    QuickSortincrease(arrNode, i, right);
                }
            }
        }
        private void QuickSortGiam(int[] arrNode, int left, int right)
        {
            if (left < right)
            {
                int pivot = arrNode[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left
                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * left) + (SizeN / 2) - 30, ArrLbl[left].Location.Y + 2 * SizeN + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((Canh_le + (SizeN + DisN) * right) + (SizeN / 2) - 30, ArrLbl[right].Location.Y + 2 * SizeN + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                //

                //doi mau node x

                ChonDongChoCodeListBox(2);


                cs_x = (left + right) / 2;

                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((Canh_le + (SizeN + DisN) * cs_x) + (SizeN / 2) - 30, ArrLbl[cs_x].Location.Y + 2 * SizeN + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Đặt màu nút x                    
                //
                i = left; j = right;
                ChonDongChoCodeListBox(3);
                //Thiết lập mũi tên chỉ i
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ChonDongChoCodeListBox(5);
                do
                {
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    ChonDongChoCodeListBox(7);
                    while (arrNode[i] > pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So_Sanh(a[" + i + "], a[x])";
                    }
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So_Sanh(a[" + j + "], a[x])";
                    ChonDongChoCodeListBox(8);
                    while (arrNode[j] < pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
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
                        Swap_Giatri(ref arrNode[i], ref arrNode[j]);
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
                        Swap_Node(ArrLbl[i], ArrLbl[j]);
                        Swap_NodeAn(i, j);
                        ArrLbl[i].BackColor = colorComplete;
                        ArrLbl[j].BackColor = colorDefault;
                        //Thiết lập vị trí của 
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((Canh_le + (SizeN + DisN) * cs_x) + (SizeN / 2) - 30, ArrLbl[cs_x].Location.Y + 2 * SizeN + 40);
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
                    QuickSortGiam(arrNode, left, j);
                }
                if (i < right)
                {
                    ChonDongChoCodeListBox(19);
                    QuickSortGiam(arrNode, i, right);
                }
            }
        }
        #endregion
        #region HEAP SORT
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
            Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
            Mui_ten_xanh_xuong_1.Text = "i=" + i;
            Mui_ten_xanh_xuong_1.Refresh();
            //thiết lập mũi tên chỉ j
            Mui_ten_xanh_xuong_2.Visible = true;
            Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
            Mui_ten_xanh_xuong_2.Text = "j=" + j;
            Mui_ten_xanh_xuong_2.Refresh();
            x = arrNode[i];
            temp = ArrLbl[i];
            index_temp = i;

            while (j <= r)
            {

                Application.DoEvents();

                if (j < r)

                    if (arrNode[j] < arrNode[j + 1])

                        j++;
                //thiết lập mũi tên chỉ j

                Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();

                if (arrNode[j] <= x)
                    return;
                else
                {
                    arrNode[i] = arrNode[j];
                    arrNode[j] = x;
                    Application.DoEvents();                   
                    this.Invoke((MethodInvoker)delegate
                    {
                        Swap_Node(ArrLbl[j], temp);
                    });

                    Swap_NodeAn(j, index_temp);
                    if (ckDebug.Checked == true)
                        Pause();
                    else
                        Tre(5 * Speed);
                    i = j;
                    j = 2 * i + 1;
                    if (j <= r)
                    {
                        //Thiết lập mũi tên chỉ i

                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //thiết lập mũi tên chỉ j

                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                    }
                    x = arrNode[i];
                    temp = ArrLbl[i];
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
            Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
            Mui_ten_xanh_xuong_1.Text = "i=" + i;
            Mui_ten_xanh_xuong_1.Refresh();
            //thiết lập mũi tên chỉ j
            Mui_ten_xanh_xuong_2.Visible = true;
            Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
            Mui_ten_xanh_xuong_2.Text = "j=" + j;
            Mui_ten_xanh_xuong_2.Refresh();
            x = arrNode[i];
            temp = ArrLbl[i];
            index_temp = i;

            while (j <= r)
            {

                Application.DoEvents();

                if (j < r)

                    if (arrNode[j] > arrNode[j + 1])

                        j++;
                //thiết lập mũi tên chỉ j

                Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();

                if (arrNode[j] >= x)
                    return;
                else
                {
                    arrNode[i] = arrNode[j];
                    arrNode[j] = x;
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Swap_Node(ArrLbl[j], temp);
                    });        
                    Swap_NodeAn(j, index_temp);
                    if (ckDebug.Checked == true)
                        Pause();
                    else
                        Tre(5 * Speed);
                    i = j;
                    j = 2 * i + 1;
                    if (j <= r)
                    {
                        //Thiết lập mũi tên chỉ i

                        Mui_ten_xanh_xuong_1.Location = new Point((Canh_le + (SizeN + DisN) * i) + (SizeN / 2) - 30, ArrLbl[i].Location.Y - SizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //thiết lập mũi tên chỉ j

                        Mui_ten_xanh_xuong_2.Location = new Point((Canh_le + (SizeN + DisN) * j) + (SizeN / 2) - 30, ArrLbl[j].Location.Y - SizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                    }
                    x = arrNode[i];
                    temp = ArrLbl[i];
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
            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * r) + (SizeN / 2) - 30, ArrLbl[r].Location.Y + 2 * SizeN + 5);
            Mui_ten_xanh_len_1.Text = "r=" + r;
            Mui_ten_xanh_len_1.Visible = true;
            Mui_ten_xanh_len_1.Refresh();
            listCode.SelectedIndex = 5;
            while (r > 0)
            {
                Application.DoEvents();
                Swap_Giatri(ref arrNode[0], ref arrNode[r]);
                Mui_ten_xanh_xuong_1.Visible = false;
                Mui_ten_xanh_xuong_2.Visible = false;
                //
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "HoanVi( a[0] , a[" + r + "] )";

                listCode.SelectedIndex = 7;
                this.Invoke((MethodInvoker)delegate
                {
                    Swap_Node(ArrLbl[0], ArrLbl[r]);
                });

                lbl_status_02.Visible = false;
                Swap_NodeAn(0, r);
                ArrLbl[r].BackColor = colorComplete;
                ArrLbl[0].BackColor = colorDefault;
                // Đặt lại màu cho phần tử đã được sắp xếp

                lbl_status_02.Visible = true;
                lbl_status_02.Text = "a[" + r + "] đã đúng thứ tự!";
                if(ckDebug.Checked == true)
                    Pause();
                else
                    Tre(10*Speed);
                lbl_status_02.Visible = false;
                listCode.SelectedIndex = 8;
                r--;
                //Thiết lập mũi tên chỉ r
                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * r) + (SizeN / 2) - 30, ArrLbl[r].Location.Y + 2 * SizeN + 5);
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
            Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * r) + (SizeN / 2) - 30, ArrLbl[r].Location.Y + 2 * SizeN + 5);
            Mui_ten_xanh_len_1.Text = "r=" + r;
            Mui_ten_xanh_len_1.Visible = true;
            Mui_ten_xanh_len_1.Refresh();
            listCode.SelectedIndex = 5;
            while (r > 0)
            {
                Application.DoEvents();
                Swap_Giatri(ref arrNode[0], ref arrNode[r]);
                Mui_ten_xanh_xuong_1.Visible = false;
                Mui_ten_xanh_xuong_2.Visible = false;
                //
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "HoanVi( a[0] , a[" + r + "] )";
  
                listCode.SelectedIndex = 7;
                this.Invoke((MethodInvoker)delegate
                {
                    Swap_Node(ArrLbl[0], ArrLbl[r]);
                });
                lbl_status_02.Visible = false;
                Swap_NodeAn(0, r);
                ArrLbl[r].BackColor = colorComplete;
                ArrLbl[0].BackColor = colorDefault;
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "a[" + r + "] đã đúng thứ tự!";
                if (ckDebug.Checked == true)
                    Pause();
                else
                    Tre(10 * Speed);
                lbl_status_02.Visible = false;
                listCode.SelectedIndex = 8;
                r--;
                //Thiết lập mũi tên chỉ r
                Mui_ten_xanh_len_1.Location = new Point((Canh_le + (SizeN + DisN) * r) + (SizeN / 2) - 30, ArrLbl[r].Location.Y + 2 * SizeN + 5);
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
            while (pa < nOe)
            {
                Application.DoEvents();
                for (i = 0; (pa < nOe) && (i < k); i++, pa++, pb++)
                {
                    b[pb] = arrNode[pa];
                    Node_B[pb] = ArrLbl[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Up(Node_B[pb], 2 * (SizeN));
                        Den_tdo_x_node(Node_B[pb], pb);
                    });
                    ArrLbl[pa].BackColor = colorQuickU;  // màu trên
                }
                for (i = 0; (pa < nOe) && (i < k); i++, pa++, pc++)
                {
                    c[pc] = arrNode[pa];
                    Node_C[pc] = ArrLbl[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        Node_Down(Node_C[pc], (SizeN + 80));
                        Den_tdo_x_node(Node_C[pc], pc);
                    });
                    ArrLbl[pa].BackColor = colorQuickD; // màu dưới
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
                if (b[pb + ib] <= c[pc + ic])
                {
                    arrNode[pa] = b[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(Node_B[pb + ib], pa);          
                    });
                    ArrLbl[pa] = Node_B[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            arrNode[pa] = c[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(Node_C[pc + ic], pa);
                            });
                            ArrLbl[pa] = Node_C[pc + ic];
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
                    arrNode[pa] = c[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(Node_C[pc + ic], pa);
                    });
                    ArrLbl[pa] = Node_C[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            arrNode[pa] = b[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(Node_B[pb + ib], pa);
                            });
                            ArrLbl[pa] = Node_B[pb + ib];
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
                    toLocaN(Node_B[lennb - nb], pa);
                    
                });
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    toLocaN(Node_C[lennc - nc], pa);
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
                    arrNode[pa] = b[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(Node_B[pb + ib], pa);
                    });
                    ArrLbl[pa] = Node_B[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            arrNode[pa] = c[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(Node_C[pc + ic], pa);
                            });
                            ArrLbl[pa] = Node_C[pc + ic];
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
                    arrNode[pa] = c[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        toLocaN(Node_C[pc + ic], pa);
                    });
                    ArrLbl[pa] = Node_C[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            arrNode[pa] = b[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                toLocaN(Node_B[pb + ib], pa);
                            });
                            ArrLbl[pa] = Node_B[pb + ib];
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
                    toLocaN(Node_B[lennb - nb], pa);
                });
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    toLocaN(Node_C[lennc - nc], pa);
                });
                pa++;
            }

        }
        //Hàm sắp xếp Merge
        void MergeSortincrease()
        {
            SignArrow();
            lblA.Visible = true;
            lblC.Visible = true;
            lblB.Visible = true;
            b = new int[nOe];
            c = new int[nOe];
            Node_B = new Label[nOe];
            Node_C = new Label[nOe];
            //Dán nhãn mảng b

            int k, nc = 0, nb = 0;
            for (k = 1; k < nOe; k *= 2)
            {
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "k = " + k;
                Distribute(ref nb, ref nc, k);
                Merge_increase(nb, nc, k);
            }
        }
        void MergeSortGiam()
        {
            SignArrow();
            b = new int[nOe];
            c = new int[nOe];
            Node_B = new Label[nOe];
            Node_C = new Label[nOe];
            //Dán nhãn mảng b
            int k, nc = 0, nb = 0;
            for (k = 1; k < nOe; k *= 2)
            {
                lbl_status_02.Visible = true;
                lbl_status_02.Text = "k = " + k;
                Distribute(ref nb, ref nc, k);
                Merge_giam(nb, nc, k);
            }
        }
        #endregion
        #endregion
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
                code.quicksort(listCode, increase);
                ytuong.Quicksort(listIdea);
            }
            if (radHeap.Checked)
            {
                code.heapsort(listCode, increase);
                ytuong.Heapsort(listIdea);
            }
            if (radInsertion.Checked)
            {
                code.insertionsort(listCode, increase);
                ytuong.Insertionsort(listIdea);
            }
            if (radMerge.Checked)
            {
                code.mergesort(listCode, increase);
                ytuong.Mergesort(listIdea);
            }
            if (radInterchange.Checked)
            {
                code.interchangesort(listCode, increase);
                ytuong.Interchangesort(listIdea);
            }
            if (radShell.Checked)
            {
                code.shellsort(listCode, increase);
                ytuong.Shellsort(listIdea);
            }
            if (radBubble.Checked)
            {
                code.bubblesort(listCode, increase);
                ytuong.Bubblesort(listIdea);
            }
            if (radSelection.Checked)
            {
                code.selectionsort(listCode, increase);
                ytuong.Selectionsort(listIdea);
            }
        }
        public void Complete()
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
            increase = false;
            ShowCode();
        }
        public void SignArrow()
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
            Speed = speedTrackBar.Maximum - speedTrackBar.Value;
        }
        private void bntReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nOe; i++)
            {
                ArrLbl[i].Text ="0";
                ArrLbl[i].BackColor = colorDefault ;
            }
            bntPlay.Show();
        }
        private void bntPlay_Click(object sender, EventArgs e)
        {
            bntPlay.Hide();
            bntPause.Show();

            if (checkPause == false)
            {
                if (radSelection.Checked == true && increase == true)
                    SelectionSortincrease(arrNode);
                if (radSelection.Checked == true && increase == false)
                    SelectionSortGiam(arrNode);
                if (radBubble.Checked == true && increase == true)
                    BubbleSortincrease(arrNode);
                if (radBubble.Checked == true && increase == false)
                    BubbleSortGiam(arrNode);
                if (radShell.Checked == true && increase == true)
                    ShellSortincrease(arrNode);
                if (radShell.Checked == true && increase == false)
                    ShellSortGiam(arrNode);
                if (radQuick.Checked == true && increase == true)
                    QuickSortincrease(arrNode, 0, nOe - 1);
                if (radQuick.Checked == true && increase == false)
                    QuickSortGiam(arrNode, 0, nOe - 1);
                if (radHeap.Checked == true && increase == true)
                    HeapSortincrease(nOe);
                if (radHeap.Checked == true && increase == false)
                    HeapSortGiam(nOe);
                if (radInsertion.Checked == true && increase == true)
                    InsertionSortincrease(arrNode);
                if (radInsertion.Checked == true && increase == false)
                    InsertionSortGiam(arrNode);
                if (radInterchange.Checked == true && increase == true)
                    InterchangeSortincrease(arrNode);
                if (radInterchange.Checked == true && increase == false)
                    InterchangeSortGiam(arrNode);
                if (radMerge.Checked == true && increase == true)
                    MergeSortincrease();
                if (radMerge.Checked == true && increase == false)
                    MergeSortGiam();
                CompleteSwap();
            }
            else
            {
                checkPause = false;
            }
        }
        private void bntPause_Click(object sender, EventArgs e)
        {
            bntPlay.Show();
            bntPause.Hide();
            checkPause = true;
            Play_or_Stop();
        }
        public void Pause()
        {
            if (ckDebug.Checked == true)
            {
                checkPause = true;
                Play_or_Stop();
            }
        }
        public void Play_or_Stop()
        {
            while (checkPause == true)
            {
                Application.DoEvents();
            }
        }
        public void ChonDongChoCodeListBox(int viTri)
        {
            Tre(Speed * 30);
            listCode.SelectedIndex = viTri;
            // nếu đang trong chế độ Debug thì dừng sau mỗi câu lệnh chạy xong sẽ dừng lại
            if (ckDebug.Checked)
            {
                checkPause = true;
                Play_or_Stop();
            }
        }
        private void radIncrease_CheckedChanged(object sender, EventArgs e)
        {
            increase = true;
            ShowCode();
        }
        private void bntDebug_Click(object sender, EventArgs e)
        {
            checkPause = false;
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

