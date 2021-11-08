using qlnvbt2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Nancy.Json;

namespace qlnvbt2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();

            var kiemtra = File.ReadAllText("NhanVien.js");
            if (kiemtra != "")
            {
                Console.WriteLine("File dang co du lieu");
               /* Console.WriteLine(kiemtra);*/
                // chuyen doi js sang obj
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var obj = jss.Deserialize<dynamic>(kiemtra);

                NhanVien nv = new NhanVien();

                string maNhanVienOBJ = obj["maNhanVien"];
                string hoTenOBJ = obj["hoTen"];
                DateTime ngaySinhOBJ = Convert.ToDateTime(obj["ngaySinh"]);
                string sdtOBJ = obj["sdt"];
                string diaChiOBJ = obj["diaChi"];
                int soNamCongTacOBJ = Convert.ToInt32(obj["soNamCongTac"]);

                nv.maNhanVien = maNhanVienOBJ;
                nv.hoTen = hoTenOBJ;
                nv.ngaySinh = ngaySinhOBJ;
                nv.sdt = sdtOBJ;
                nv.diaChi = diaChiOBJ;
                nv.soNamCongTac = soNamCongTacOBJ;

                listNhanVien.Add(nv);

                /*var convertInfo = JsonConvert.DeserializeObject(kiemtra);*/
                /*Console.WriteLine(convertInfo);*/

                /*listNhanVien.Add(convertInfo);*/

                // JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"c:\movie.json"));
                // using (StreamReader file = File.OpenText(@"c:\movie.json"))
                // {
                //     JsonSerializer serializer = new JsonSerializer();
                //     Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
                // }

            }
            else
            {
                Console.WriteLine("File khong co du lieu");
            }

            
            menu(listNhanVien);
        }
        public static void hienthiNV(List<NhanVien> listNhanVien)
        {   
            Console.WriteLine("Hien thi nhan vien");
            foreach (NhanVien item in listNhanVien)
            {
                Console.Write("MSV: " + item.maNhanVien);
                Console.Write(" hoTen: " + item.hoTen);
                Console.Write(" date: " + item.ngaySinh);
                Console.Write(" sdt: " + item.sdt);
                Console.Write(" diaChi: " + item.diaChi);
                Console.Write(" soNamCongTac: " + item.soNamCongTac);
                Console.WriteLine();
            }
        }
        public static void themNV(List<NhanVien> listNhanVien)
        {
            // nhap thong tin nhan vien
            NhanVien nv = new NhanVien();

            nv.maNhanVien = nv.getMaNhanVien(listNhanVien);
            // Console.WriteLine("Nhap mnv: ");
            // nv.maNhanVien = Console.ReadLine();

            for (; ; )
            {
                Console.WriteLine("Nhap ho ten: ");
                nv.hoTen = Console.ReadLine();
                if (nv.hoTen == "")
                {
                    Console.WriteLine("Bat buoc nhap ho ten");
                }
                else
                {
                    break;
                }
            }
            for (; ; )
            {
                Console.WriteLine("Nhap ngay sinh: ");
                string ngaySinhString = Console.ReadLine();
                nv.ngaySinh = DateTime.Parse(ngaySinhString);
                if (ngaySinhString == "")
                {
                    Console.WriteLine("Bat buoc nhap ngay sinh");
                }
                else
                {
                    break;
                }


            }

            Console.WriteLine("Nhap sdt: ");
            nv.sdt = Console.ReadLine();
            Console.WriteLine("Nhap dia chi: ");
            nv.diaChi = Console.ReadLine();
            Console.WriteLine("Nhap chuc vu: ");
            nv.chucVu = Console.ReadLine();
            for (; ; )
            {
                try
                {
                    Console.WriteLine("Nhap so nam cong tac: ");
                    string cvsoNamCongTac = Console.ReadLine();
                    nv.soNamCongTac = int.Parse(cvsoNamCongTac);
                    if (cvsoNamCongTac == "")
                    {
                        Console.WriteLine("Bat buoc nhap so nam cong tac");
                    }
                    else
                    {
                        break;
                    }

                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Ban da nhap sai");
                    throw;
                }

            }

            // kiem tra ho ten va ngay sinh trung nhau

            for (int i = 0; i < listNhanVien.Count; i++)
            {
                if (nv.hoTen == listNhanVien[i].hoTen && nv.ngaySinh == listNhanVien[i].ngaySinh)
                {
                    Console.WriteLine("Ten va ngay sinh trung nhau");
                }
            }
            //add  vao list
            listNhanVien.Add(nv);

        }
        public static void suaNV(List<NhanVien> listNhanVien)
        {
            //nhap ma nhan vien can sua
            Console.WriteLine("Nhap ma nhan vien muon sua");
            string maNhanVienSua = Console.ReadLine();
 
            for (int i = 0; i < listNhanVien.Count; i++)
            {
                if (listNhanVien[i].maNhanVien == maNhanVienSua)
                {
                    Console.Write("MSV: " + listNhanVien[i].maNhanVien);
                    Console.Write(" hoTen: " + listNhanVien[i].hoTen);
                    Console.Write(" date: " + listNhanVien[i].ngaySinh);
                    Console.Write(" sdt: " + listNhanVien[i].sdt);
                    Console.Write(" diaChi: " + listNhanVien[i].diaChi);
                    Console.Write(" soNamCongTac: " + listNhanVien[i].soNamCongTac);
                    Console.WriteLine();
                    //chon thong tin can sua
                    int chonSua;
                    Console.WriteLine("Chon thong tin can sua");
                    Console.WriteLine("1. Chinh sua ho ten");
                    Console.WriteLine("2. Chinh sua ngay sinh");
                    Console.WriteLine("3. Chinh sua sdt");
                    Console.WriteLine("4. Chinh sua dia chi");
                    Console.WriteLine("5. Chinh sua so nam cong tac");
                    Console.WriteLine("6. Thoat");

                    chonSua = int.Parse(Console.ReadLine());
                    switch (chonSua)
                    {
                        case 1:
                            Console.WriteLine("Nhap ho ten: ");
                            string hoTen = Console.ReadLine();
                            Console.WriteLine("Nhan ENTER de in ra kq");
                            var key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {
                                hienthiNV(listNhanVien);
                                Console.WriteLine("Ban co muon luu hay khong?");
                                Console.WriteLine("Nhap \'yes\' de luu,  \'no\' de thoat ");
                                string chon = (Console.ReadLine());

                                if (chon == "yes")
                                {
                                    listNhanVien[i].hoTen = hoTen;
                                }
                                else
                                {
                                    menu(listNhanVien);
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Nhap ngay sinh: ");
                            DateTime ngaySinh = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Nhan ENTER de in ra kq");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {

                                hienthiNV(listNhanVien);
                                Console.WriteLine("Ban co muon luu hay khong?");
                                Console.WriteLine("Nhap \'YES\' de luu,  \'NO\' de thoat ");
                                string chon = (Console.ReadLine());

                                if (chon == "yes")
                                {
                                    listNhanVien[i].ngaySinh = ngaySinh;
                                }
                                else
                                {
                                    menu(listNhanVien);
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine("Nhap sdt: ");
                            string sdt = Console.ReadLine();
                            Console.WriteLine("Nhan ENTER de in ra kq");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {
                                hienthiNV(listNhanVien);
                                Console.WriteLine("Ban co muon luu hay khong?");
                                Console.WriteLine("Nhap \'YES\' de luu,  \'NO\' de thoat ");
                                string chon = (Console.ReadLine());

                                if (chon == "yes")
                                {
                                    listNhanVien[i].sdt = sdt;
                                }
                                else
                                {
                                    menu(listNhanVien);
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Nhap dia chi: ");
                            string diaChi = Console.ReadLine();
                            Console.WriteLine("Nhan ENTER de in ra kq");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {
                                hienthiNV(listNhanVien);
                                Console.WriteLine("Ban co muon luu hay khong?");
                                Console.WriteLine("Nhap \'YES\' de luu,  \'NO\' de thoat ");
                                string chon = (Console.ReadLine());

                                if (chon == "yes")
                                {
                                    listNhanVien[i].diaChi = diaChi;
                                }
                                else
                                {
                                    menu(listNhanVien);
                                }
                            }
                            break;
                        case 5:
                            Console.WriteLine("Nhap so nam cong tac: ");
                            int soNamCongTac = int.Parse(Console.ReadLine());
                            Console.WriteLine("Nhan ENTER de in ra kq");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {
                                hienthiNV(listNhanVien);
                                Console.WriteLine("Ban co muon luu hay khong?");
                                Console.WriteLine("Nhap \'YES\' de luu,  \'NO\' de thoat ");
                                string chon = (Console.ReadLine());

                                if (chon == "yes")
                                {
                                    listNhanVien[i].soNamCongTac = soNamCongTac;
                                }
                                else
                                {
                                    menu(listNhanVien);
                                }
                            }
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Nhap sai");
                            break;
                            // nhan ENTER de in ra kq
                    }
                }
            }

        }
        public static void xoaNV(List<NhanVien> listNhanVien)
        {
            Console.WriteLine("Nhap ma nhan vien muon xoa: ");
            string maNhanVien = Console.ReadLine();
            for (int i = 0; i < listNhanVien.Count; i++)
            {
                if (listNhanVien[i].maNhanVien == maNhanVien)
                {
                    Console.WriteLine("Ban chac chan muon xoa");
                    Console.WriteLine("Nhap \'yes\' de xoa, \'no\' de thoat ");
                    string xoaNhanVien = Console.ReadLine();
                    if (xoaNhanVien == "yes")
                    {
                        listNhanVien.RemoveAt(i);
                    }
                    else if (xoaNhanVien == "no")
                    {
                        menu(listNhanVien);
                    }
                    else
                    {
                        Console.WriteLine("Ban da nhap sai");
                    }

                }
                else
                {
                    Console.WriteLine("Khong ton tai nhan vien nay");
                }
            }
        }
        public static void timKiem(List<NhanVien> listNhanVien)
        {

            Console.WriteLine("Nhap tu khoa muon tim kiem");
            string timKiemKey = Console.ReadLine();

            // string pos = SequencePosition(listNhanVien, timKiemKey);
            // Console.WriteLine("Gia tri duoc tim thay tai vi tri:{0}", pos);
            foreach (var item in listNhanVien)
            {
                if (item.maNhanVien.Contains(timKiemKey) || item.hoTen.Contains(timKiemKey) || item.ngaySinh.Equals(timKiemKey) || item.sdt.Contains(timKiemKey) || item.diaChi.Contains(timKiemKey) || item.soNamCongTac.Equals(timKiemKey))
                {
                    Console.WriteLine($"{item.hoTen} - {item.diaChi}");
                }
            }

            // var timThay = listNhanVien.FindAll(
            //     (p) =>
            //     {
            //         return p.maNhanVien.Contains(timKiemKey);
            //     });

            // foreach (var p in timThay)
            // {
            //     Console.WriteLine($"{p.hoTen} - {p.diaChi}");
            // }

        }

        // private static string SequencePosition(List<NhanVien> listNhanVien, string timKiemKey)
        // {
        //     int found = 0;
        //     int i;
        //     int pos = -1;
        //     for (i = 0; i < listNhanVien.Count && found != 1; i++)
        //         if (listNhanVien[i].maNhanVien == timKiemKey)
        //         {
        //             pos = i;
        //             found = 1;
        //             Console.Write(" hoTen: " + listNhanVien[i].hoTen);
        //             Console.Write(" diaChi: " + listNhanVien[i].diaChi);
        //         }
        //     string pos2 = Convert.ToString(pos);
        //     return pos2;
        // }
        public static void luuFile(List<NhanVien> listNhanVien)
        {
            foreach (var item in listNhanVien)
            {
                var infoConvert = item;

                // Console.WriteLine(infoConvert);
                var convertInfo = JsonConvert.SerializeObject(infoConvert);
                // Console.WriteLine(convertInfo);
                File.AppendAllText("NhanVien.js", convertInfo);
                string docFile = File.ReadAllText("NhanVien.js");
                Console.WriteLine(docFile);
            }




        }
        public static void loadFile(List<NhanVien> listNhanVien)
        {

            var kiemtra = File.ReadAllText("NhanVien.js");
            if (kiemtra != "")
            {
                Console.WriteLine("File dang co du lieu");
                Console.WriteLine(kiemtra);
                // listNhanVien.Add(kiemtra);
                // var convertInfo = JsonConvert.DeserializeObject(info);

                // JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"c:\movie.json"));
                // using (StreamReader file = File.OpenText(@"c:\movie.json"))
                // {
                //     JsonSerializer serializer = new JsonSerializer();
                //     Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
                // }

            }
            else
            {
                Console.WriteLine("File khong co du lieu");
            }


        }
        public static void menu(List<NhanVien> listNhanVien)
        {

            int check;
            do
            {
                Console.WriteLine("1. Hien thi DS nguoi dung");
                Console.WriteLine("2. Them moi nhan vien");
                Console.WriteLine("3. Sua nhan vien");
                Console.WriteLine("4. Xoa nhan vien");
                Console.WriteLine("5. Tim kiem nhan vien");
                Console.WriteLine("6. Luu ra file JSON");
                Console.WriteLine("7. Thoat!");
                check = int.Parse(Console.ReadLine());
                switch (check)
                {
                    case 1:
                        hienthiNV(listNhanVien);
                        break;
                    case 2:
                        themNV(listNhanVien);
                        break;
                    case 3:
                        suaNV(listNhanVien);
                        break;
                    case 4:
                        xoaNV(listNhanVien);
                        break;
                    case 5:
                        timKiem(listNhanVien);
                        break;
                    case 6:
                        luuFile(listNhanVien);
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Nhap sai vui long nhap lai");
                        break;
                }
            } while (check != 7);
        }
    }
}
