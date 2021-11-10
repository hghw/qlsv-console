using qlnvbt2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace qlnvbt2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();
            loadFile(listNhanVien);
            menu(listNhanVien);
        }
        public static void hienthiNV(List<NhanVien> listNhanVien)
        {
            Console.WriteLine("Ban da lua chon hien thi nhan vien");
            Console.WriteLine("+==================================+");

            do
            {
                foreach (NhanVien item in listNhanVien)
                {
                    Console.WriteLine($" | MSV: {item.maNhanVien}");
                    Console.WriteLine($" | hoTen: {item.hoTen} ");
                    Console.WriteLine($" | Date:  {item.ngaySinh.Day}/{item.ngaySinh.Month}/{item.ngaySinh.Year} ");
                    Console.WriteLine($" | sdt: {item.sdt} ");
                    Console.WriteLine($" | diaChi: {item.diaChi} ");
                    Console.WriteLine($" | soNamCongTac: {item.soNamCongTac} ");
                    Console.WriteLine("  ====================");
                }
                

                while (!Console.KeyAvailable)
                {
                    Console.WriteLine(" Nhan ESC tro ve menu ");
                    Console.WriteLine("+======================+");
                    break;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        }
        public static void themNV(List<NhanVien> listNhanVien)
        {
            Console.WriteLine("Ban da lua chon them nhan vien");
                    Console.WriteLine("+============================+");
    
            Console.WriteLine();

                // nhap thong tin nhan vien
                NhanVien nv = new NhanVien();

                nv.maNhanVien = nv.getMaNhanVien(listNhanVien);

                do
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
                } while (true);


                do
                {
                    Console.WriteLine("Nhap ngay thang nam sinh: ");
                    Console.WriteLine("VD: 08-08-2008 ");

                    string ngaySinhString = Console.ReadLine();
                    try
                    {
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
                    catch (FormatException)
                    {
                        Console.WriteLine(" Sai dinh dang nhap lai");
                    Console.WriteLine("+============================+");

                }

            } while (true);

                Console.WriteLine("Nhap sdt: ");
                nv.sdt = Console.ReadLine();
                Console.WriteLine("Nhap dia chi: ");
                nv.diaChi = Console.ReadLine();
                Console.WriteLine("Nhap chuc vu: ");
                nv.chucVu = Console.ReadLine();

                do
                {
                    try
                    {
                        Console.WriteLine("Nhap so nam cong tac: ");
                        string cvsoNamCongTac = Console.ReadLine();
                        nv.soNamCongTac = int.Parse(cvsoNamCongTac);
                        if (cvsoNamCongTac == "")
                        {
                            Console.WriteLine("Bat buoc nhap so nam cong tac");
                        Console.WriteLine("+============================+");
                    }
                    else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ban da nhap sai");
                    Console.WriteLine("+============================+");
                }

            } while (true);

   

            //add  vao list
            listNhanVien.Add(nv);

            // kiem tra ho ten va ngay sinh trung nhau
            for (int i = 0; i < listNhanVien.Count -1; i++)
            {
                if (nv.hoTen == listNhanVien[i].hoTen && nv.ngaySinh == listNhanVien[i].ngaySinh)
                {
                    Console.WriteLine(" Ten va ngay sinh trung nhau");
                    Console.WriteLine("+============================+");
                    listNhanVien.RemoveAt(listNhanVien.Count -1);
                    break;
                }
            }
        }
        public static void suaNV(List<NhanVien> listNhanVien)
        {
            Console.WriteLine("Ban da lua chon sua nhan vien");
            Console.WriteLine("+============================+");

                //nhap ma nhan vien can sua
                Console.WriteLine("Nhap ma nhan vien muon sua");
                string maNhanVienSua = Console.ReadLine();
            Console.WriteLine("+============================+");
            if (maNhanVienSua.StartsWith("NV-") && maNhanVienSua.Length == 7 || maNhanVienSua.EndsWith($"{listNhanVien.Count}"))
            {
                for (int i = 0; i < listNhanVien.Count; i++)
                {
                    if (listNhanVien[i].maNhanVien == maNhanVienSua)
                    {
                        Console.WriteLine("MSV: " + listNhanVien[i].maNhanVien);
                        Console.WriteLine("hoTen: " + listNhanVien[i].hoTen);
                        Console.WriteLine($"Date:  {listNhanVien[i].ngaySinh.Day}/{listNhanVien[i].ngaySinh.Month}/{listNhanVien[i].ngaySinh.Year} ");
                        Console.WriteLine("sdt: " + listNhanVien[i].sdt);
                        Console.WriteLine("diaChi: " + listNhanVien[i].diaChi);
                        Console.WriteLine("soNamCongTac: " + listNhanVien[i].soNamCongTac);
                        Console.WriteLine("+============================+");
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
                                    //hien thi ra nhan vien sua
                                    Console.WriteLine("MSV: " + listNhanVien[i].maNhanVien);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("hoTen: " + hoTen);
                                    Console.ResetColor();
                                    Console.WriteLine($"Date:  {listNhanVien[i].ngaySinh.Day}/{listNhanVien[i].ngaySinh.Month}/{listNhanVien[i].ngaySinh.Year} ");
                                    Console.WriteLine("sdt: " + listNhanVien[i].sdt);
                                    Console.WriteLine("diaChi: " + listNhanVien[i].diaChi);
                                    Console.WriteLine("soNamCongTac: " + listNhanVien[i].soNamCongTac);
                                    Console.WriteLine();

                                    Console.WriteLine("Ban co muon luu hay khong?");
                                    Console.WriteLine("Nhap \'yes\' de luu,  \'no\' de thoat ");
                                    string chon = (Console.ReadLine());

                                    if (chon == "yes")
                                    {
                                        listNhanVien[i].hoTen = hoTen;
                                    }
                                    else
                                    {
                                        break;
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

                                    //hien thi ra nhan vien sua
                                    Console.WriteLine("MSV: " + listNhanVien[i].maNhanVien);
                                    Console.WriteLine("hoTen: " + listNhanVien[i].hoTen);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Date:  {ngaySinh.Day}/{ngaySinh.Month}/{ngaySinh.Year} ");
                                    Console.ResetColor();
                                    Console.WriteLine("sdt: " + listNhanVien[i].sdt);
                                    Console.WriteLine("diaChi: " + listNhanVien[i].diaChi);
                                    Console.WriteLine("soNamCongTac: " + listNhanVien[i].soNamCongTac);
                                    Console.WriteLine();

                                    Console.WriteLine("Ban co muon luu hay khong?");
                                    Console.WriteLine("Nhap \'yes\' de luu,  \'no\' de thoat ");
                                    string chon = (Console.ReadLine());

                                    if (chon == "yes")
                                    {
                                        listNhanVien[i].ngaySinh = ngaySinh;
                                    }
                                    else
                                    {
                                        break;
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
                                    //hien thi ra nhan vien sua
                                    Console.WriteLine("MSV: " + listNhanVien[i].maNhanVien);
                                    Console.WriteLine("hoTen: " + listNhanVien[i].hoTen);
                                    Console.Write($"Date:  {listNhanVien[i].ngaySinh.Day}/{listNhanVien[i].ngaySinh.Month}/{listNhanVien[i].ngaySinh.Year} ");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("sdt: " + sdt);
                                    Console.ResetColor();
                                    Console.WriteLine("diaChi: " + listNhanVien[i].diaChi);
                                    Console.WriteLine("soNamCongTac: " + listNhanVien[i].soNamCongTac);
                                    Console.WriteLine();

                                    Console.WriteLine("Ban co muon luu hay khong?");
                                    Console.WriteLine("Nhap \'yes\' de luu,  \'no\' de thoat ");
                                    string chon = (Console.ReadLine());

                                    if (chon == "yes")
                                    {
                                        listNhanVien[i].sdt = sdt;
                                    }
                                    else
                                    {
                                        break;
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
                                    //hien thi ra nhan vien sua
                                    Console.WriteLine("MSV: " + listNhanVien[i].maNhanVien);
                                    Console.WriteLine("hoTen: " + listNhanVien[i].hoTen);
                                    Console.WriteLine($"Date:  {listNhanVien[i].ngaySinh.Day}/{listNhanVien[i].ngaySinh.Month}/{listNhanVien[i].ngaySinh.Year} ");
                                    Console.WriteLine("sdt: " + listNhanVien[i].sdt);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("diaChi: " + diaChi);
                                    Console.ResetColor();
                                    Console.WriteLine("soNamCongTac: " + listNhanVien[i].soNamCongTac);
                                    Console.WriteLine();

                                    Console.WriteLine("Ban co muon luu hay khong?");
                                    Console.WriteLine("Nhap \'yes\' de luu,  \'no\' de thoat ");
                                    string chon = (Console.ReadLine());

                                    if (chon == "yes")
                                    {
                                        listNhanVien[i].diaChi = diaChi;
                                    }
                                    else
                                    {
                                        break;
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
                                    //hien thi ra nhan vien sua
                                    Console.WriteLine("MSV: " + listNhanVien[i].maNhanVien);
                                    Console.WriteLine("hoTen: " + listNhanVien[i].hoTen);
                                    Console.WriteLine($"Date:  {listNhanVien[i].ngaySinh.Day}/{listNhanVien[i].ngaySinh.Month}/{listNhanVien[i].ngaySinh.Year} ");
                                    Console.WriteLine("sdt: " + listNhanVien[i].sdt);
                                    Console.WriteLine("diaChi: " + listNhanVien[i].diaChi);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("soNamCongTac: " + soNamCongTac);
                                    Console.ResetColor();
                                    Console.WriteLine();

                                    Console.WriteLine("Ban co muon luu hay khong?");
                                    Console.WriteLine("Nhap \'yes\' de luu,  \'no\' de thoat ");
                                    string chon = (Console.ReadLine());

                                    if (chon == "yes")
                                    {
                                        listNhanVien[i].soNamCongTac = soNamCongTac;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case 6:
                                break;
                            default:
                                Console.WriteLine("Nhap sai");
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Ban da nhap sai ma nhan vien");
            }
            Console.WriteLine("+============================+");
        }

        public static void xoaNV(List<NhanVien> listNhanVien)
        {
            Console.WriteLine("Ban da lua chon xoa nhan vien");
                Console.WriteLine();
                Console.WriteLine("Nhap ma nhan vien muon xoa: ");
                string maNhanVien = Console.ReadLine();
            if (maNhanVien.StartsWith("NV-") && maNhanVien.Length == 7 || maNhanVien.EndsWith($"{listNhanVien.Count}"))
            {
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
                            Console.WriteLine("Da xoa thanh cong");
                        }
                        else if (xoaNhanVien == "no")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ban da nhap sai");
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("Ban da nhap sai ma nhan vien");
            }



            Console.WriteLine("+============================+");
        }

        public static void timKiem(List<NhanVien> listNhanVien)
        {
                Console.WriteLine();
                Console.WriteLine("Ban da lua chon tim kiem nhan vien");

                Console.WriteLine("Nhap tu khoa muon tim kiem");
                string timKiemKey = Console.ReadLine();

            Console.WriteLine("Ket qua tim kiem!");
            Console.WriteLine("+============================+");

            foreach (var item in listNhanVien)
                {
                    if (item.maNhanVien.ToLower().ToUpper().Contains(timKiemKey) || item.hoTen.ToLower().ToUpper().Contains(timKiemKey)
                        || item.ngaySinh.Equals(timKiemKey) || item.sdt.ToLower().ToUpper().Contains(timKiemKey)
                        || item.diaChi.ToLower().ToUpper().Contains(timKiemKey) || item.soNamCongTac.Equals(timKiemKey)
                        || item.maNhanVien.ToLower().Contains(timKiemKey) || item.hoTen.ToLower().Contains(timKiemKey)
                        || item.sdt.ToLower().Contains(timKiemKey) || item.diaChi.ToLower().Contains(timKiemKey)
                        || item.maNhanVien.ToUpper().Contains(timKiemKey) || item.hoTen.ToUpper().Contains(timKiemKey)
                        || item.sdt.ToUpper().Contains(timKiemKey) || item.diaChi.ToUpper().Contains(timKiemKey)
                        )
                    {
                    
                        Console.WriteLine($"hoTen: {item.hoTen} - diaChi: {item.diaChi}");
                    }
                }
            Console.WriteLine("+============================+");
        }


        public static void luuFile(List<NhanVien> listNhanVien)
        {

                Console.WriteLine();
                Console.WriteLine("Ban da lua chon luu file");
                var convertInfo = JsonConvert.SerializeObject(listNhanVien);
                File.WriteAllText("NhanVien.json", convertInfo);



            Console.WriteLine("+============================+");
        }

        public static void loadFile(List<NhanVien> listNhanVien)
        {
            var convertInfo = JsonConvert.SerializeObject(listNhanVien);
            convertInfo = File.ReadAllText("NhanVien.json");
            List<NhanVien> result = JsonConvert.DeserializeObject<List<NhanVien>>(convertInfo);

            foreach (NhanVien item in result)
            {
               /* Console.WriteLine($"maNhanVien: {item.maNhanVien}, ngaySinh: {item.ngaySinh}, sdt: {item.sdt}, diaChi: {item.diaChi}, soNamCongTac: {item.soNamCongTac}");*/
                listNhanVien.Add(item);
            }
        }
        public static void menu(List<NhanVien> listNhanVien)
        {

            int check;
            do
            {
                Console.WriteLine("+===================MENU==============+");
                Console.WriteLine("|  1. Hien thi DS nguoi dung          |");
                Console.WriteLine("|  2. Them moi nhan vien              |");
                Console.WriteLine("|  3. Sua nhan vien                   |");
                Console.WriteLine("|  4. Xoa nhan vien                   |");
                Console.WriteLine("|  5. Tim kiem nhan vien              |");
                Console.WriteLine("|  6. Luu ra file JSON                |");
                Console.WriteLine("|  7. Thoat!                          |");
                Console.WriteLine("+=====================================+");
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
        public static void exitESC(List<NhanVien> listNhanVien)
        {
            // Nhan nut ESC ra menu
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                menu(listNhanVien);
            }
        }


    }
}
