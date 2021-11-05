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
            int maCount = 10000;
            int ma = (maCount + 1);
            string maNhanVien = Convert.ToString(ma);
            maNhanVien = maNhanVien.Replace("1","");
            maNhanVien = Convert.ToString(ma);
            maNhanVien = "NV-" + maNhanVien;
            // Console.WriteLine(maNhanVien);
            return maNhanVien;
        }
    }
}
