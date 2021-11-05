using qlnvbt2.Models;
using System;
using System.Collections.Generic;

namespace qlnvbt2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();

            int check;
            do
            {
                Console.WriteLine("1. Hien thi DS nguoi dung");
                Console.WriteLine("2. Them moi nhan vien");
                Console.WriteLine("3. Sua nhan vien");
                Console.WriteLine("4. Xoa nhan vien");
                Console.WriteLine("5. Thoat!");
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
                        break;
                    default:
                        Console.WriteLine("Nhap sai vui long nhap lai");
                        break;
                }
            } while (check != 5);

            {

            }
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
            do
            {
                Console.WriteLine("Nhap ho ten: ");
                nv.hoTen = Console.ReadLine();
            } while (nv.hoTen == "");

            do
            {
                Console.WriteLine("Nhap ngay sinh: ");
                nv.ngaySinh = (Console.ReadLine());
            } while (nv.ngaySinh == "");

            Console.WriteLine("Nhap sdt: ");
            nv.sdt = Console.ReadLine();
            Console.WriteLine("Nhap dia chi: ");
            nv.diaChi = Console.ReadLine();
            Console.WriteLine("Nhap chuc vu: ");
            nv.chucVu = Console.ReadLine();
            do
            {
                Console.WriteLine("Nhap so nam cong tac: ");
                nv.soNamCongTac = int.Parse(Console.ReadLine());
            } while (nv.soNamCongTac < 0);


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
            Console.WriteLine("Nhap ma nhan vien");
            string maNhanVien = Console.ReadLine();
            for (int i = 0; i < listNhanVien.Count; i++)
            {
                if (listNhanVien[i].maNhanVien == maNhanVien)
                {
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
            }
            //nhap ma nhan vien can sua
            Console.WriteLine("Nhap ma nhan vien muon sua");
            string maNhanVienSua = Console.ReadLine();
            for (int i = 0; i < listNhanVien.Count; i++)
            {
                if (listNhanVien[i].maNhanVien == maNhanVienSua)
                {
                    //sua thong tin
                    Console.WriteLine("Nhap ho ten: ");
                    listNhanVien[i].hoTen = Console.ReadLine();
                    Console.WriteLine("Nhap ngay sinh: ");
                    listNhanVien[i].ngaySinh = (Console.ReadLine());
                    Console.WriteLine("Nhap sdt: ");
                    listNhanVien[i].sdt = Console.ReadLine();
                    Console.WriteLine("Nhap dia chi: ");
                    listNhanVien[i].diaChi = Console.ReadLine();
                    Console.WriteLine("Nhap so nam cong tac: ");
                    listNhanVien[i].soNamCongTac = int.Parse(Console.ReadLine());
                }
            }
            // nhan ENTER de in ra kq

            Console.WriteLine("Nhan ENTER de in ra kq");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
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
        }
        public static void xoaNV(List<NhanVien> listNhanVien)
        {
            Console.WriteLine("Ban da chon xoa nhan vien");
            Console.WriteLine("Nhap ma nhan vien muon xoa: ");
            string maNhanVien = Console.ReadLine();
            for (int i = 0; i < listNhanVien.Count; i++)
            {
                if (listNhanVien[i].maNhanVien == maNhanVien)
                {
                    listNhanVien.RemoveAt(i);
                }
                else
                {
                    Console.WriteLine("Khong ton tai ma nhan vien nay");
                }
            }
        }
    }
}
