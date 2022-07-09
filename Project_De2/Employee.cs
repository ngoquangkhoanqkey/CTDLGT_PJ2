using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DoAnMain
{
    class Employee
    {
        // Tạo các field dữ liệu
        public string _username;
        public string _password;
        public string _HoTen;
        public string _DiaChi;
        public int _SoDienThoai;
        public string _DiaChiEmail;

        // Hàm tạo employee không  tham số
        public Employee()
        {
            _username = "vo danh";
            _password = "khong co";
            _HoTen = "khong ten";
            _DiaChi = "no dia chi";
            _SoDienThoai = 0;
            _DiaChiEmail = "00";
        }
        // Hàm tạo employee đủ tham số
        public Employee(string username,string hoten,string diachi,int sodienthoai,string Email )
        {
            this._username = username;
            _password = "111111";
            this._HoTen = hoten;
            this._DiaChi = diachi;
            this._SoDienThoai = sodienthoai;
            this._DiaChiEmail = Email;
            using (StreamWriter SW = new StreamWriter("Employee.txt",true))
            {
                SW.WriteLine(_username + "+" + _password);
            }
            using (StreamWriter SW = new StreamWriter(username+".txt"))
            {
                SW.WriteLine(_HoTen);
                SW.WriteLine(_DiaChi);
                SW.WriteLine(_SoDienThoai);
                SW.WriteLine(_DiaChiEmail);
            }
        }
        // Hàm đọc file
        public void docfile(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr1 = new string[] { "+" };
            string[] arr2 = line.Split(arr1, StringSplitOptions.RemoveEmptyEntries);
            _username = arr2[0];
            _password = arr2[1];
        }
        // Hàm ghi file
        public void ghi(StreamWriter sW)
        {
            sW.WriteLine("{0}+{1}", _username, _password);
        }
        // Hàm Xuất
        public void xuat()
        {
            Console.WriteLine("***************** Employee ****************");
            Console.WriteLine("{0,-15}:{1,-15}", "Tai khoan:", _username);
            Console.WriteLine("{0,-15}:{1,-15}", "Mat khau:", _password);
            Console.WriteLine("*******************************************");
        }
        //Doc thông tin Employes
        public void Doc(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr1 = new string[] { " " };
            string[] arr2 = line.Split(arr1, StringSplitOptions.RemoveEmptyEntries);

            _username = arr2[0];
            _HoTen = arr2[1];
            _DiaChi = arr2[2];
            int.TryParse(arr2[3], out _SoDienThoai);
            _DiaChiEmail = arr2[4];
        }
        //ham ghi thong tin  một Employees
        public void Ghi(StreamWriter sW)
        {
            sW.WriteLine("{0}", _username);
            sW.WriteLine("\t+{1}", _HoTen);
            sW.WriteLine("\t+{2}", _DiaChi);
            sW.WriteLine("\t+{3}", _SoDienThoai);
            sW.WriteLine("\t+{4}", _DiaChiEmail);
        }
        //In thông tin Employees
        public void print()
        {
            Console.WriteLine("{0,-15}:{1,-15}", "UserName", _username);
            Console.WriteLine("\t+{0,-15}:{1,-15}", "Ho Ten", _HoTen);
            Console.WriteLine("\t+{0,-15}:{1,-15}", "Dia Chi", _DiaChi);
            Console.WriteLine("\t+{0,-15}:{1,-15}", "So Dien Thoai", _SoDienThoai);
            Console.WriteLine("\t+{0,-15}:{1,-15}", "Email", _DiaChiEmail);
            Console.WriteLine("----------*-------*------*----------");
        }
    }
}
