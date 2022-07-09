using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DoAnMain
{
    class Admin
    {
        // tạo các field dữ liệu
        public string _username;
        public string _password;
        // Hàm đọc file
        public void docfile(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr1 = new string[] { "+" }; //
            string[] arr2 = line.Split(arr1, StringSplitOptions.RemoveEmptyEntries); //

            _username = arr2[0];
            _password = arr2[1];
        }
        // Hàm ghi file
        public void ghi(StreamWriter sW)
        {
            sW.WriteLine("{0}+{1}", _username, _password);
        }

      
        // Hàm xuất file
        public void xuat()
        {
            Console.WriteLine("***************** Admin ****************");
            Console.WriteLine("{0,-15}:{1,-15}", "Tai khoan:", _username);
            Console.WriteLine("{0,-15}:{1,-15}", "Mat khau:", _password);
            Console.WriteLine("****************************************");
        }
    }
}
