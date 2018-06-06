using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YTUONG
{
    class YTuong
    {
        public void Selectionsort(ListBox lst_Code)
        {

            lst_Code.Items.Add("-Chọn phần tử nhỏ nhất(Lớn nhất) trong N phần tử trong dãy hiện hành ban đầu");
            lst_Code.Items.Add("-Đưa phần tử này về vị trí đầu dãy hiện hành");
            lst_Code.Items.Add("-Xem dãy hiện hành chỉ còn lại N-1 phần tử của dãy hiện hành ban đầu");
            lst_Code.Items.Add("    +Bắt đầu từ vị trí thứ 2");
            lst_Code.Items.Add("    +Lặp lại quá trình trên dãy cho hiện hành... đến khi dãy hiện hành chỉ còn 1 phần tử");
        }

        public void Insertionsort(ListBox lst_Code)
        {
            lst_Code.Items.Add("Xét danh sách con gồm k phần tử đầu a1 … ak. Với k = 1, danh sách gồm một phần tử đã được sắp xếp thành dãy tăng dần.");
            lst_Code.Items.Add("Giả sử trong danh sách k-1 phần tử đầu a1 … ak-1 đã được sắp xếp. Để sắp xếp phần tử ak = xta tìm vị trí thích hợp của nó trong dãy a1 … ak-1.");
            lst_Code.Items.Add("Vị trí thích hợp cần tìm là vị trí đứng trước phần tử lớn hơn nó và sau phần tử nhỏ hơn hoặc bằng nó.");
        }

        public void Bubblesort(ListBox lst_Code)
        {
            lst_Code.Items.Add("-Xuất phát từ cuối dãy, đổi chỗ các cặp phần tử kế cận để đưa phần tử nhỏ hơn trong cặp phần tử đó về vị trí đúng dãy hiện hành, sau đó sẽ không xét đến nó ở bước tiếp theo, do vậy ở lần xử lý thứ i sẽ có vị trí đầu dãy là i.");
            lst_Code.Items.Add("-Lặp lại xử lý trên cho đến khi không còn cặp phần tử nào để xét.");

        }

        public void Heapsort(ListBox lst_Code)
        {
            lst_Code.Items.Add("-Heapsort tận dụng được các phép so sánh ở bước i-1, mà thuật toán selectionsort không làm được");
            lst_Code.Items.Add("-Để làm được điều này heap sort thao tác dựa trên cây");
        }
        public void Mergesort(ListBox lst_Code)
        {
            lst_Code.Items.Add("Giải thuật Merge sort sắp xếp dãy a1, a2, ..., aN dựa trên nhận xét sau:");
            lst_Code.Items.Add("    Mỗi dãy a1, a2, ..., an bất kỳ là một tập hợp các dãy con liên tiếp mà mỗi dãy con đều đã có thứ tự.");
            lst_Code.Items.Add("    Dãy đã có thứ tự coi như có 1 dãy con");
            lst_Code.Items.Add("=> Hướng tiếp cận: tìm cách làm giảm số dãy con không giảm của dãy ban đầu");
        }
        public void Quicksort(ListBox lst_Code)
        {
            lst_Code.Items.Add("-Giải thuật Quicksort sắp xếp dãy a1,a2,...,aN dựa trên việc phân hoạch dãy ban đầu thành 3 phần");
            lst_Code.Items.Add("+Phần 1: Gồm các phần tử có giá trị bé hơn x");
            lst_Code.Items.Add("+Phần 2: Gồm các phần tử có giá trị bằng x");
            lst_Code.Items.Add("+Phần 3: Gồm các phần tử có giá trị lớn hơn x");
            lst_Code.Items.Add("\n\n\tvới x là giá trị một phần tử tùy ý trong dãy ban đầu");
            lst_Code.Items.Add("\n-Sau khi phân hoạch xong ta đã có 3 dãy:");
            lst_Code.Items.Add("Dãy 1 có giá trị bé hơn x => chưa được sắp xếp");
            lst_Code.Items.Add("Dãy 2 có giá trị bằng x => đã sắp xếp");
            lst_Code.Items.Add("Dãy 3 có giá trị lớn hơn x => chưa được sắp xếp");
            lst_Code.Items.Add("\n-Cuối cùng ta chỉ cần thực hiện sắp xếp tương tự cho dãy 1 và dãy 3 đến khi tất cả các dãy con đều đã sắp xếp xong chúng ta ghép lần lượt các dãy lại với nhau theo thứ tự");

        }
        public void Interchangesort(ListBox lst_Code)
        {
            lst_Code.Items.Add("-Xuất phát từ đầu dãy, tìm tất cả các nghịch thế chứa phần từ này,triệt tiêu chúng bằng cách đổi chỗ 2 phần tử trong cặp nghịch thế. Lặp lại xử lý trên với phần tử kế tiếp trong dãy đến cuối dãy");
        }
        public void Shellsort(ListBox lst_Code)
        {
            lst_Code.Items.Add("Là cải tiến của phương pháp insertionsort");
            lst_Code.Items.Add("Ý tưởng:");
            lst_Code.Items.Add("-Phân hoạch dãy thành các dãy con");
            lst_Code.Items.Add("-Sắp xếp các dãy con theo phương pháp chèn trực tiếp");
            lst_Code.Items.Add("-Dùng phương pháp chèn trực tiếp sắp xếp lại cả dãy");
        }
    }
}