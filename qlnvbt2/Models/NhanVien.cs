using System;
using System.Collections.Generic;
using System.Text;

namespace qlnvbt2.Models
{
    class NhanVien
    {
        public string maNhanVien { get; set; }
        public string hoTen { get; set; }
        public string ngaySinh { get; set; }
        public string sdt { get; set; }
        public string diaChi { get; set; }
        public string chucVu { get; set; }
        public int soNamCongTac { get; set; }

        public string getMaNhanVien(List<NhanVien> listNhanVien)
        {
            double maCount = 0.001;
            double ma = (maCount + 1);
            string maNhanVien = Convert.ToString(ma);
            maNhanVien = maNhanVien.Replace(".", "");
            maNhanVien = Convert.ToString(ma);
            maNhanVien = "NV-" + maNhanVien;
            Console.WriteLine(maNhanVien);
            return maNhanVien;
        }
    }
}
