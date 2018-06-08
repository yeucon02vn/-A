﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THAMSO
{
    class ThamSo
    {
        public int[] arrNode;
        public Label[] arrLbl;
        public Label[] node_B, node_C;
        public int[] b, c;
        public int disN = 18; // Distance Node
        public int nOe; // number of element 
        public int sizeN = 50;  // Size Node
        public int canh_le = 30;
        public int speed = 60;
        public bool increase;
        public bool checkPause = false;

        public ThamSo(int[] iArr, Label[] lbArr, Label[] lbNb, Label[] lbNc, int[] ib, int[] ic, bool bIncre)
        {
            arrNode = iArr;
            arrLbl = lbArr;
            node_B = lbNb;
            node_C = lbNc; ;
            b = ib;
            c = ic;
            increase = bIncre;
        }

        public ThamSo() { }
    }
}
