using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _Code
{
    class Code
    {
        public void insertionsort(ListBox lst_Code, Boolean tang)
        {

            lst_Code.Items.Add("void InsertionSort(int a[], int n)");
            lst_Code.Items.Add(" {");
            lst_Code.Items.Add("   int i, pos, x;");
            lst_Code.Items.Add("   for (i = 1; i < n; i++)");
            lst_Code.Items.Add("      {");
            lst_Code.Items.Add("         x = a[i];");
            lst_Code.Items.Add("         pos = i - 1;");
            if (tang)
                lst_Code.Items.Add("         while ((pos >= 0) && (a[pos] > x))");
            else
                lst_Code.Items.Add("         while ((pos >= 0) && (a[pos] < x))");
            lst_Code.Items.Add("           {");
            lst_Code.Items.Add("            a[pos + 1] = a[pos];");
            lst_Code.Items.Add("            pos--;");
            lst_Code.Items.Add("           }");
            lst_Code.Items.Add("         a[pos + 1] = x;");
            lst_Code.Items.Add("      }");
            lst_Code.Items.Add(" }");

        }

        public void selectionsort(ListBox lst_Code, Boolean tang)
        {

            lst_Code.Items.Add("void SelectionSort(int a[], int n) ");
            lst_Code.Items.Add("  {");
            if (tang)
                lst_Code.Items.Add("    int min, i, j; ");
            else
                lst_Code.Items.Add("    int max, i, j; ");
            lst_Code.Items.Add("    for (i = 0; i < n - 1; i++)");
            lst_Code.Items.Add("       {     ");
            if (tang)
                lst_Code.Items.Add("         min = i;      ");
            else
                lst_Code.Items.Add("         max = i;      ");
            lst_Code.Items.Add("         for (j = i + 1; j < n; j++)    ");
            if (tang)
            {
                lst_Code.Items.Add("           if (a[j] < a[min])     ");
                lst_Code.Items.Add("              min = j;      ");
                lst_Code.Items.Add("         if (min != i)      ");
                lst_Code.Items.Add("           Swap(a[min], a[i]);       ");
                lst_Code.Items.Add("       }          ");
                lst_Code.Items.Add("   }        ");
            }
            else
            {
                lst_Code.Items.Add("           if (a[j] > a[max])     ");
                lst_Code.Items.Add("              max = j;      ");
                lst_Code.Items.Add("         if (max != i)      ");
                lst_Code.Items.Add("           Swap(a[max], a[i]);       ");
                lst_Code.Items.Add("       }          ");
                lst_Code.Items.Add("   }        ");
            }
            lst_Code.Items.Add("  void Swap(int &a,int &b)  {");
            lst_Code.Items.Add("           int temp = a;");
            lst_Code.Items.Add("            a = b;");
            lst_Code.Items.Add("            b=temp;");
            lst_Code.Items.Add(" }");
        }
        public void bubblesort(ListBox lst_Code, Boolean tang)
        {
            lst_Code.Items.Add("void BubbleSort(int a[],int n)");
            lst_Code.Items.Add("  {");
            lst_Code.Items.Add("     int i, j;");
            lst_Code.Items.Add("     for (i = 0 ; i<n-1; i++)");
            lst_Code.Items.Add("         for (j = n-1; j > i ; j --)");
            if (tang)
                lst_Code.Items.Add("            if (a[j] < a[j-1]) ");
            else
                lst_Code.Items.Add("            if (a[j] > a[j-1]) ");
            lst_Code.Items.Add("              Swap(a[j], a[j-1]);");
            lst_Code.Items.Add("  }");
            lst_Code.Items.Add("  void Swap(int &a,int &b)  {");
            lst_Code.Items.Add("           int temp = a;");
            lst_Code.Items.Add("            a = b;");
            lst_Code.Items.Add("            b=temp;");
            lst_Code.Items.Add(" }");
        }

        public void heapsort(ListBox lst_Code, Boolean tang)
        {
            lst_Code.Items.Add("void HeapSort(int a[], int n)");
            lst_Code.Items.Add("     {");
            lst_Code.Items.Add("          int r;");
            lst_Code.Items.Add("          CreateHeap(a, n);");
            lst_Code.Items.Add("          r = n - 1;");
            lst_Code.Items.Add("          while (r > 0)");
            lst_Code.Items.Add("           {");
            lst_Code.Items.Add("              Swap(a[0], a[r]);");
            lst_Code.Items.Add("              r--;");
            lst_Code.Items.Add("              if (r > 0)");
            lst_Code.Items.Add("                 Shift(a, 0, r);");
            lst_Code.Items.Add("           }");
            lst_Code.Items.Add("      }");
            lst_Code.Items.Add("void Shift(int a[], int l, int r)");
            lst_Code.Items.Add("    {");
            lst_Code.Items.Add("         int i, j, x;");
            lst_Code.Items.Add("         i = l;");
            lst_Code.Items.Add("         j = 2 * i + 1;");
            lst_Code.Items.Add("         x = a[i];");
            lst_Code.Items.Add("         while (j <= r)");
            lst_Code.Items.Add("           {");
            lst_Code.Items.Add("               if (j < r)");
            if (tang)
                lst_Code.Items.Add("               if (a[j] < a[j+1])");
            else
                lst_Code.Items.Add("               if (a[j] > a[j+1])");
            lst_Code.Items.Add("                  j++;");
            if (tang)
                lst_Code.Items.Add("               if (a[j] <= x)");
            else
                lst_Code.Items.Add("               if (a[j] >= x)");
            lst_Code.Items.Add("                  return;");
            lst_Code.Items.Add("               else");
            lst_Code.Items.Add("                 {");
            lst_Code.Items.Add("                    a[i] = a[j];");
            lst_Code.Items.Add("                    a[j] = x;");
            lst_Code.Items.Add("                    i = j;");
            lst_Code.Items.Add("                    j = 2 * i + 1;");
            lst_Code.Items.Add("                    x = a[i];");
            lst_Code.Items.Add("                 }");
            lst_Code.Items.Add("            }");
            lst_Code.Items.Add("    }");
            lst_Code.Items.Add("void CreateHeap(int a[], int n)");
            lst_Code.Items.Add("     {");
            lst_Code.Items.Add("          int l = n / 2 - 1;");
            lst_Code.Items.Add("          while (l >= 0)");
            lst_Code.Items.Add("             {");
            lst_Code.Items.Add("                 Shift(a, l, n-1);");
            lst_Code.Items.Add("                  l--;");
            lst_Code.Items.Add("             }");
            lst_Code.Items.Add("     }");
            lst_Code.Items.Add("  void Swap(int &a,int &b)  {");
            lst_Code.Items.Add("           int temp = a;");
            lst_Code.Items.Add("            a = b;");
            lst_Code.Items.Add("            b=temp;");
            lst_Code.Items.Add(" }");



        }
        public void mergesort(ListBox lst_Code, Boolean tang)
        {
            lst_Code.Items.Add("void MergeSort(int a[], int n)");
            lst_Code.Items.Add("{ 	");
            lst_Code.Items.Add("    int	k, nc=0, nb=0;");
            lst_Code.Items.Add("        for (k = 1; k < n; k *= 2) ");
            lst_Code.Items.Add("        {");
            lst_Code.Items.Add("            Dis(a, n, nb, nc, k);");
            lst_Code.Items.Add("            Merge(a, nb, nc, k);");
            lst_Code.Items.Add("        }");
            lst_Code.Items.Add("}");
            lst_Code.Items.Add("void Dis(int a[],int n,int &nb,int &nc,int k)");
            lst_Code.Items.Add("{ 	");
            lst_Code.Items.Add("        int i, pa, pb, pc;");
            lst_Code.Items.Add("        pa = pb = pc = 0;");
            lst_Code.Items.Add("        while (pa < n)");
            lst_Code.Items.Add("        {   ");
            lst_Code.Items.Add("            for (i = 0; (pa < n) && (i < k); i++, pa++, pb++)");
            lst_Code.Items.Add("                b[pb] = a[pa];");
            lst_Code.Items.Add("                for (i = 0; (pa < n) && (i < k); i++, pa++, pc++)");
            lst_Code.Items.Add("                    c[pc] = a[pa];");
            lst_Code.Items.Add("        }");
            lst_Code.Items.Add("        nb = pb;	");
            lst_Code.Items.Add("        nc = pc;");
            lst_Code.Items.Add("}   ");
            lst_Code.Items.Add("int min(int a, int b)");
            lst_Code.Items.Add("{   ");
            lst_Code.Items.Add("    if(a > b)");
            lst_Code.Items.Add("        return b;");
            lst_Code.Items.Add("    else");
            lst_Code.Items.Add("        return a;");
            lst_Code.Items.Add(" }");
            lst_Code.Items.Add("void Merge(int a[],int nb,int nc,int k)");
            lst_Code.Items.Add("{   ");
            lst_Code.Items.Add("    int p, pb, pc, ib, ic, kb, kc;");
            lst_Code.Items.Add("    p = pb = pc = 0; ib = ic = 0;");
            lst_Code.Items.Add("    while((nb > 0) && (nc > 0))");
            lst_Code.Items.Add("    {   ");
            lst_Code.Items.Add("        kb = min(k, nb);");
            lst_Code.Items.Add("        kc = min(k, nc);");
            if (tang)
                lst_Code.Items.Add("        if(b[pb + ib] <= c[pc + ic])");
            else
                lst_Code.Items.Add("        if(b[pb + ib] >= c[pc + ic])");
            lst_Code.Items.Add("        {");
            lst_Code.Items.Add("            a[p++]=b[pb+ib];");
            lst_Code.Items.Add("            ib++;");
            lst_Code.Items.Add("            if(ib == kb)");
            lst_Code.Items.Add("                { ");
            lst_Code.Items.Add("                    for(;ic<kc;ic++)");
            lst_Code.Items.Add("                        a[p++] = c[pc+ic];");
            lst_Code.Items.Add("                        pb += kb; ");
            lst_Code.Items.Add("                        pc += kc; ");
            lst_Code.Items.Add("                        ib = ic = 0;");
            lst_Code.Items.Add("                        nb -= kb; ");
            lst_Code.Items.Add("                        nc -= kc;");
            lst_Code.Items.Add("                }");
            lst_Code.Items.Add("        }");
            lst_Code.Items.Add("        else");
            lst_Code.Items.Add("        {");
            lst_Code.Items.Add("                a[p++] = c[pc+ic];");
            lst_Code.Items.Add("                ic++;");
            lst_Code.Items.Add("                   if(ic == kc)");
            lst_Code.Items.Add("                { 	");
            lst_Code.Items.Add("                    for(; ib < kb; ib++)");
            lst_Code.Items.Add("                        a[p++] = b[pb+ib];");
            lst_Code.Items.Add("                        pb += kb; ");
            lst_Code.Items.Add("                        pc += kc; ");
            lst_Code.Items.Add("                        ib = ic = 0;");
            lst_Code.Items.Add("                        nb -= kb; ");
            lst_Code.Items.Add("                        nc -= kc;");
            lst_Code.Items.Add("               }");
            lst_Code.Items.Add("        }");
            lst_Code.Items.Add("    }");
            lst_Code.Items.Add("}");



        }
        public void quicksort(ListBox lst_Code, Boolean tang)
        {
            lst_Code.Items.Add("void QuickSort(int a[], int left, int right)");
            lst_Code.Items.Add("{");
            lst_Code.Items.Add("            int i, j, x;");
            lst_Code.Items.Add("            x = a[(left + right) / 2]; ");
            lst_Code.Items.Add("            i = left; j = right;");
            lst_Code.Items.Add("               do");
            lst_Code.Items.Add("                  {");
            if (tang)
                lst_Code.Items.Add("                   while(a[i] < x) i++;");
            else
                lst_Code.Items.Add("                   while(a[i] > x) i++;");
            if (tang)
                lst_Code.Items.Add("                   while(a[j] > x) j--;");
            else
                lst_Code.Items.Add("                   while(a[j] < x) j--;");

            lst_Code.Items.Add("                       if(i <= j)");
            lst_Code.Items.Add("                         { ");
            lst_Code.Items.Add("                           Swap(a[i], a[j]);");
            lst_Code.Items.Add("                           i++ ; j--;");
            lst_Code.Items.Add("                         }");
            lst_Code.Items.Add("                   }");
            lst_Code.Items.Add("               while(i <= j);");
            lst_Code.Items.Add("               if(left < j)");
            lst_Code.Items.Add("                   QuickSort(a, left, j);");
            lst_Code.Items.Add("               if(i < right)");
            lst_Code.Items.Add("                   QuickSort(a, i, right);");
            lst_Code.Items.Add("}");
            lst_Code.Items.Add("  void Swap(int &a,int &b)  {");
            lst_Code.Items.Add("           int temp = a;");
            lst_Code.Items.Add("            a = b;");
            lst_Code.Items.Add("            b=temp;");
            lst_Code.Items.Add(" }");


        }
        public void interchangesort(ListBox lst_Code, Boolean tang)
        {
            lst_Code.Items.Add("void InterchangeSort(int a[], int n)");
            lst_Code.Items.Add("{");
            lst_Code.Items.Add(" for (int i = 0; i < n-1; i++)");
            lst_Code.Items.Add("    for (j =i+1; j < N ; j++)");
            if (tang == true)
                lst_Code.Items.Add("        if (a[i] > a[j])");
            else
                lst_Code.Items.Add("        if (a[i] < a[j])");
            lst_Code.Items.Add("        {");
            lst_Code.Items.Add("                Swap(a[i],a[j])");
            lst_Code.Items.Add("        }");
            lst_Code.Items.Add("}");
        }
        public void shellsort(ListBox lst_Code, Boolean tang)
        {
            lst_Code.Items.Add("void ShellSort(int a[], int n)");
            lst_Code.Items.Add("{");
            lst_Code.Items.Add("    for (int i = n / 2; i > 0; i = i / 2)");
            lst_Code.Items.Add("        for (int j = i; j < n; j++)");
            if (tang == true)
                lst_Code.Items.Add("            for (int k = j; k >= i && a[k] < a[k - i]; k -= i)");
            else
                lst_Code.Items.Add("             for (int k = j; k >= i && a[k] > a[k - i]; k -= i)");
            lst_Code.Items.Add("                    Swap(a[k],a[k-i])");
            lst_Code.Items.Add("}");
        }
    }
}
