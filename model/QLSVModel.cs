using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnCSharp_WPF.Models
{
    internal class QLSVModel
    {
        public List<SinhVien> DsSinhVien { get; set; } = new List<SinhVien>();
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

        //Constructor
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

        //Cac ham chuc nang tuong tac voi List
        public void themSinhVien(SinhVien sv)
        {
            this.DsSinhVien.Add(sv);
        }
        public void chinhSuaSinhVien(SinhVien sv)
        {
            this.DsSinhVien.Remove(sv);
            this.DsSinhVien.Add(sv);
        }
        public void xoaSinhVien(SinhVien sv)
        {
            this.DsSinhVien.Remove(sv);
        }
        //Cac ham tuong tac voi listener va view
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