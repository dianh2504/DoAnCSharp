using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnCSharp_WPF.Models
{
    internal class QLSVModel
    {
        private string chucNang = "";
        private bool trangThaiSQL = false;

        public string ChucNang
        {
            get { return chucNang; }
            set { chucNang = value; }
        }
        public bool TrangThaiSQL
        {
            get { return trangThaiSQL; }
            set { trangThaiSQL = value; }
        }

        // Sử dụng DUY NHẤT một danh sách này để đồng bộ toàn bộ logic
        public List<SinhVien> DsSinhVien { get; set; } = new List<SinhVien>();

        // Các Constructor
        public QLSVModel(List<SinhVien> dsSinhVien)
        {
            this.DsSinhVien = dsSinhVien;
            this.chucNang = "";
            this.trangThaiSQL = false;
        }
        public QLSVModel()
        {
            this.DsSinhVien = new List<SinhVien>();
        }

        // Đồng bộ các hàm nghiệp vụ theo danh sách DsSinhVien mới
        public void themSinhVien(SinhVien sv)
        {
            this.DsSinhVien.Add(sv);
        }

        public SinhVien getSinhVienTuMaSinhVien(int maSinhVien)
        {
            foreach (SinhVien sv in this.DsSinhVien)
            {
                if (sv.MaSinhVien == maSinhVien)
                {
                    return sv;
                }
            }
            return null;
        }

        public void kiemTraTrungMaSinhVien(int maSinhVien)
        {
            foreach (SinhVien sv in this.DsSinhVien)
            {
                if (maSinhVien == sv.MaSinhVien)
                {
                    throw new Exception("Mã sinh viên đã tồn tại trong hệ thống!");
                }
            }
        }
    }
}