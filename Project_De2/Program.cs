using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DoAnMain
{
    class Program
    {
        static void Main(string[] args)
        {
            // đọc dữ liệu và đưa vào linked list
            Console.OutputEncoding = Encoding.UTF8;
            LinkedList<Admin> ad = new LinkedList<Admin>();
            LinkedList<Employee> em = new LinkedList<Employee>();
            ReadListad(ad);
            ReadListem(em);
            string sTK = "";
            string mk = "";
            int iN = 0, iC;
            MeNuDN:
            // Menu đăng nhập
            do
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*****************************************");
                Console.Write("*\t\t");
                taikhoan();
                Console.Write("\t\t*");
                Console.WriteLine();
                Console.WriteLine("*****************************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Username:\t");
                sTK = Console.ReadLine();
                Console.Write("Password:\t");
                mk = Console.ReadLine(); //ReadPassword();

                Console.Clear();
                iN++;
            } while (iN < 3 && !Ktraad(sTK, mk, ad) && !Ktraem(sTK, mk, em));


            if (Ktraad(sTK, mk, ad))
            {
                // Đổi mật khẩu nếu là 1111111
                if (mk == "111111")
                {
                    DoiPassWord(em, sTK);
                    Console.WriteLine(" Cảm ơn bạn đã đổi mật khẩu  ");
                    Console.ReadKey();
                    Console.Clear();
                }
                MenuAD:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("************* MENU **************");
                Console.WriteLine("1.Thêm employee");
                Console.WriteLine("2.Xóa employee");
                Console.WriteLine("3.Tìm employee");
                Console.WriteLine("4.Cập nhật employee");
                Console.WriteLine("5.Hiển thị thông tin employee");
                Console.WriteLine("6.Thoát!");
                Console.WriteLine("*********************************");
                Console.Write("Chọn chức năng:");

                int.TryParse(Console.ReadLine(), out iC);
                Console.Clear();
                do
                {
                    // Menu chức năng của Admin
                    switch (iC)
                    {
                        case 1:


                            AddEmployee(em, em.Count);

                            Console.WriteLine(" Bạn đã thêm 1 Employee  ");

                            Console.ReadKey();
                            Console.Clear();
                            goto MenuAD;


                        case 2:

                            XoaEmp(em, em.Count);


                            Console.ReadKey();
                            Console.Clear();
                            goto MenuAD;


                        case 3:
                            Console.WriteLine("Mời nhập username cần tìm");

                            string UserName = Console.ReadLine();
                            if (FindUser(em, UserName) == true)
                            {
                                Console.WriteLine("Có username đó trong danh sách");
                            }
                            else
                            {
                                Console.WriteLine("Không có username đó trong danh sách");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            goto MenuAD;

                        case 4:
                            Console.WriteLine("Mời bạn nhập username muốn cập nhật ");
                            string user = Console.ReadLine();
                            UpDate(user, em);
                            break;
                        case 5:
                            Console.WriteLine("Xuất hết thông tin Employee");
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Xuất hết thông tin Employee");
                            FindUserEmployes(em);
                            Console.ReadKey();
                            goto MenuAD;

                        case 6:
                            Console.WriteLine(" Tạm biệt bạn  ");
                            Console.ReadKey();
                            Console.Clear();
                            goto MeNuDN;



                    }
                } while (iC < 1 || iC > 6);
            }
            else if (Ktraem(sTK, mk, em))
            {
                // đổi mật khẩu trước 1 phát rồi vào 
                if (mk == "111111")
                {
                    DoiPassWord(em, sTK);
                    Console.WriteLine(" Cảm ơn bạn đã đổi mật khẩu  ");
                    Console.ReadKey();
                    Console.Clear();
                }


                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("*************** MENU EMPLOYEE **************");
                Console.WriteLine("1.Xem thông tin tài khoản");
                Console.WriteLine("2.Đổi mật khẩu.");
                Console.WriteLine("3.Thoát!");
                Console.WriteLine("********************************************");
                Console.Write("Chọn chức năng:");
                int.TryParse(Console.ReadLine(), out iC);
                Console.Clear();
                do
                {
                    switch (iC)
                    {
                        case 1:
                            Console.WriteLine("Hiển thị hết thông tin của user đó");
                            Console.ReadKey();
                            HienThiThongTin(sTK);

                            goto MeNuDN;
                        case 2:
                            DoiPassWord(em, sTK);
                            Console.WriteLine("đã đổi mật khẩu ");
                            Console.ReadKey();
                            Console.Clear();

                            goto MeNuDN;
                        //break;
                        case 3:
                            goto MeNuDN;

                    }
                } while (iC > 3 || iC < 1);
            }
            else
            {
                Console.WriteLine("Đăng nhập sai quá 3 lần!");
            }
            Console.ReadKey();

        }

        // Số điện thoại phải là 10 số
        static bool CheckSDT(int SDT)
        {
            string SDT1 = Convert.ToString(SDT);
            if (SDT1.Length == 10)
            {
                return true;
            }
            return false;
        }
        // hàm CheckUserName 
        // 1 độ dài nhỏ hơn 10
        // 2 không được chữ cái đầu tiên là số 
        // 3 Không được ghi in hoa chữ cái 
        static bool CheckUserName(string Username)
        {

            if (Username[0] >= 97 && Username[0] <= 122)
            {
                if (Username.Length > 10)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < Username.Length; i++)
                    {
                        if (Username[i] >= 97 && Username[i] <= 123 || Username[i] >= 48 && Username[i] <= 57) ;

                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;




        }


        // Hàm check email co dấu @ hay không
        static bool CheckEmail(string Email)
        {
            if (Email.Contains("@") == true)
            {
                return true;
            }
            return false;
        }

        //Hàm tìm thông tin Employes theo username
        static void FindUserEmployes(LinkedList<Employee> L)
        {
            for (LinkedListNode<Employee> p = L.First; p != null; p = p.Next)
            {
                int idem = 0;
                string Find = p.Value._username;
                using (StreamWriter sW = new StreamWriter(Find + "username.txt", false))
                {

                    for (LinkedListNode<Employee> q = L.First; q != null; q = q.Next)
                    {
                        if (p.Value._username == Find)
                        {
                            p.Value.ghi(sW);
                            p.Value.xuat();
                            idem++;
                        }
                    }
                    sW.WriteLine(idem);
                    Console.WriteLine("succesFull");
                }
            }

        }
        //Tim UserName
        static bool FindUser(LinkedList<Employee> L, string Sfind)
        {
            for (LinkedListNode<Employee> p = L.First; p != null; p = p.Next)
            {
                if (p.Value._username == Sfind)
                {
                    return true;
                }
            }
            return false;
        }
        // Hàm Hiển thị thông tin của username đó
        static void HienThiThongTin(string sUserName)
        {
            try
            {
                if (File.Exists(sUserName + ".txt") == true)
                {
                    string[] DuLieu = File.ReadAllLines(sUserName + ".txt");
                    Console.WriteLine("Họ tên:\t{0}", DuLieu[0]);
                    Console.WriteLine("địa chỉ:\t{0}", DuLieu[1]);
                    Console.WriteLine("Số điện thoại:\t{0}", DuLieu[2]);
                    Console.WriteLine("Email:\t{0}", DuLieu[3]);

                }
            }
            catch
            {
                Console.WriteLine(" File không tồn tại  ");
            }

        }
        // Hàm Update Thông Tin Employee
        static void UpDate(string sUser, LinkedList<Employee> em)
        {
            bool bCheck = false; ;
            for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
            {
                if (i.Value._username == sUser)
                {

                    bCheck = true;
                }

            }
            if (bCheck == false)
            {
                Console.WriteLine(" Không có user cần update ");
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Mời bạn lựa chọn thứ bạn muốn update ");
            Console.WriteLine("*************** Menu UpDate **************");
            Console.WriteLine("1. Họ tên  ");
            Console.WriteLine("2. Địa chỉ .");
            Console.WriteLine("3. Số điện thoại  ");
            Console.WriteLine("4. Địa chỉ email .");
            Console.WriteLine("********************************************");

            string Update1 = "";
            int luachon;
            do
            {
                Console.Write("Chọn chức năng:");
                int.TryParse(Console.ReadLine(), out luachon);
            } while (luachon < 1 || luachon > 4);
            string[] TempAr = File.ReadAllLines(sUser + ".txt");
            switch (luachon)
            {
                case 1:
                    {
                        Console.Write(" Mời nhập họ tên muốn update ");
                        string temp = Console.ReadLine();
                        TempAr[0] = temp;
                        Update1 = "Họ tên";
                    }
                    break;
                case 2:
                    {
                        Console.Write(" Mời nhập địa chỉ muốn update ");
                        string temp = Console.ReadLine();
                        TempAr[1] = temp;
                        Update1 = "địa chỉ";
                    }
                    break;
                case 3:
                    {
                        int temp;
                        do
                        {
                            Console.Write(" Mời nhập Số điện thoại muốn update ");
                            int.TryParse(Console.ReadLine(), out temp);
                            if(CheckSDT(temp) == false)
                            {
                                Console.Write("Số điện thoại phải là 10 số");
                            }
                        } while (CheckSDT(temp) == false);
                        TempAr[2] = Convert.ToString(temp);
                        Update1 = "Số điện thoại ";
                    }
                    break;
                case 4:
                    {
                        Console.Write(" Mời nhập địa chỉ email muốn update ");
                        string temp = Console.ReadLine();
                        TempAr[3] = temp;
                        Update1 = "Địa chỉ email";
                    }
                    break;
            }
            using (StreamWriter SW = new StreamWriter(sUser + ".txt"))
            {
                for (int i = 0; i < TempAr.Length; i++)
                {
                    SW.WriteLine(TempAr[i]);
                }
            }
            Console.WriteLine(" Đã update" + Update1 + "thành công  ");
        }

        // Hàm đổi password của Employee đó
        static void DoiPassWord(LinkedList<Employee> em, string tk)
        {
            string sMkChange;

            Console.Write(" Nhập mật khẩu muốn đổi:");
            sMkChange = Console.ReadLine();

            string[] TempAr = File.ReadAllLines("Employee.txt");
            for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
            {
                if (i.Value._username == tk)
                {
                    i.Value._password = sMkChange;
                    using (StreamWriter Sw = new StreamWriter("Employee.txt"))
                    {
                        Sw.WriteLine(TempAr[0]);
                        for (LinkedListNode<Employee> j = em.First; j != null; j = j.Next)
                        {
                            Sw.WriteLine(j.Value._username + '+' + j.Value._password);
                        }


                    }
                    break;
                }
            }




        }

        // Hàm tách nội dung đọc từ file
        static string[] Tach(string s)
        {

            string[] sUserName = s.Split('+');

            return sUserName;
        }
        // hàm xóa Employee
        static void XoaEmp(LinkedList<Employee> em, int size)
        {
            string username;
            do
            {
                Console.Write(" Bạn muốn xóa username nào : ");
                username = Console.ReadLine();
                if (username == "admin" || username == "Employee")
                {
                    Console.WriteLine(" Bạn đã nhập sai Employee cần xóa  ");
                }
                else
                {
                    // Xóa trong Linkedlist
                    for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
                    {
                        if (i.Value._username == username)
                        {
                            em.Remove(i);
                            break;
                        }
                        else if (i == em.Last)
                        {
                            Console.WriteLine(" Không có username cần xóa  ");

                            return;
                        }
                    }
                }
            } while (username == "admin" || username == "Employee");
            string[] TempAr = File.ReadAllLines("Employee.txt");

            string[] MangTV = new string[2];


            // xóa file username
            File.Delete(username + ".txt");
            File.Delete("Employee.txt");

            TempAr[0] = Convert.ToString(--size);
            //xóa trong file Txt
            using (StreamWriter SW = new StreamWriter("Employee.txt"))
            {
                for (int p = 0; p < TempAr.Length; p++)
                {
                    MangTV = Tach(TempAr[p]);
                    if (MangTV[0] == username)
                    {
                        continue;
                    }
                    SW.WriteLine(TempAr[p]);
                }
            }
            Console.WriteLine(" Đã xóa Employee ");

        }

        // Hàm thêm employee Nhập đủ thông số và sau đó lưu lại vào file
        static void AddEmployee(LinkedList<Employee> em, int size)
        {
            string sUserName, sEmail, sHoTen, sDiachi;
            int iSoDienThoai;
            do
            {
                Console.Write(" Nhập UserName: ");
                sUserName = Console.ReadLine();
                if (File.Exists(sUserName + ".txt") == true)
                {
                    Console.WriteLine(" Tên đăng nhập đã có mời tạo tên khác  ");
                }
                if (CheckUserName(sUserName) == false)
                {
                    Console.WriteLine("Tên đăng nhập không thể ghi in hoa");
                }
                if (sUserName.Length > 10)
                {
                    Console.WriteLine("Tên đăng nhập quá dài ");
                }
                if(sUserName[0] >= 97 && sUserName[0] <= 122)
                {
                    Console.WriteLine("Chữ cái đầu tiên không thể là số");
                }

            } while (File.Exists(sUserName + ".txt") == true || CheckUserName(sUserName) == false);

            do
            {
                Console.Write(" Nhập Họ Tên: ");
                sHoTen = Console.ReadLine();
            } while (sHoTen.Contains(" ") == false || (sHoTen[0] < 'A' || sHoTen[0] > 'Z'));
            Console.Write(" Nhập địa chỉ  ");
            sDiachi = Console.ReadLine();
            do
            {
                Console.Write(" Nhập Số Điện Thoại: ");
                int.TryParse(Console.ReadLine(), out iSoDienThoai);
                if (CheckSDT(iSoDienThoai) == false)
                {
                    Console.WriteLine("Số điện thoại phải có 10 số ");
                }
            } while (CheckSDT(iSoDienThoai) == false);
            do
            {
                Console.Write(" Nhập Địa chỉ email: ");
                sEmail = Console.ReadLine();
                if (CheckEmail(sEmail) == false)
                {
                    Console.WriteLine("Bạn đã nhập thiếu @ ");
                }
            } while (CheckEmail(sEmail) == false);
            Employee NewEm = new Employee(sUserName, sHoTen, sDiachi, iSoDienThoai, sEmail);
            em.AddLast(NewEm);

            size++;
            string[] tempAr = File.ReadAllLines("Employee.txt");
            File.Delete("Employee.txt");

            tempAr[0] = Convert.ToString(size);
            using (StreamWriter SW = new StreamWriter("Employee.txt"))
            {
                for (int p = 0; p < tempAr.Length; p++)
                {
                    SW.WriteLine(tempAr[p]);
                }
            }



        }



        //hàm Đọc danh sách employee trong file .txt
        static void ReadListem(LinkedList<Employee> ListEm)
        {
            int n = 0;
            using (StreamReader sR = new StreamReader("Employee.txt"))
            {
                int.TryParse(sR.ReadLine(), out n);
                for (int i = 0; i < n; i++)
                {
                    Employee l = new Employee();
                    l.docfile(sR);
                    ListEm.AddLast(l);
                }

            }
        }
        //hàm Đọc danh sách admin trong file .txt
        static void ReadListad(LinkedList<Admin> ListAD)
        {
            int n = 0;
            using (StreamReader sR = new StreamReader("Admin.txt"))
            {
                int.TryParse(sR.ReadLine(), out n);
                for (int i = 0; i < n; i++)
                {
                    Admin l = new Admin();
                    l.docfile(sR);
                    ListAD.AddLast(l);
                }

            }
        }
        //hàm Kiểm tra có trong danh sách employee 
        static bool Ktraem(string us, string pas, LinkedList<Employee> em)
        {

            for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
            {
                if (us == i.Value._username)
                {
                    if (pas == i.Value._password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //hàm Kiểm tra có trong danh sách admin 
        static bool Ktraad(string us, string pas, LinkedList<Admin> ad)
        {
            for (LinkedListNode<Admin> i = ad.First; i != null; i = i.Next)
            {
                if (us == i.Value._username)
                {
                    if (pas == i.Value._password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //hàm Trang trí tài khoản
        static void taikhoan()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Đăng Nhập");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}

