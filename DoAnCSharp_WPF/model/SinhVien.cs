using System;
using System.Text.RegularExpressions;
namespace DoAnCSharp_WPF.Models
{
    public class SinhVien
    {
        private int maSinhVien;
        public int MaSinhVien
        {
            get
            {
                return maSinhVien;
            }
            set
            {
                if (value > 0)
                {
                    maSinhVien = value;
                }
                else
                {
                    throw new ArgumentException("Mã sinh viên phải là số nguyên dương");
                }
            }
        }

        private string tenSinhVien;
        public string TenSinhVien
        {
            get
            {
                return tenSinhVien;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    tenSinhVien = value;
                }
                else
                {
                    throw new ArgumentException("Tên sinh viên không hợp lệ");
                }
            }
        }

        private Tinh queQuan;
        public Tinh QueQuan
        {
            get
            {
                return queQuan;
            }
            set
            {
                if (value != null)
                {
                    queQuan = value;
                }
            }
        }
        private bool gioiTinh;
        public bool GioiTinh
        {
            get
            {
                return gioiTinh;
            }
            set
            {
                if (gioiTinh != value)
                {
                    gioiTinh = value;
                }
            }
        }
        private DateTime ngaySinh;
        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    this.ngaySinh = value;
                }
                else
                {
                    throw new ArgumentException("Ngày sinh không hợp lệ");
                }
            }

        }
        private float diemThuongXuyen1;
        public float DiemThuongXuyen1
        {
            get
            {
                return diemThuongXuyen1;
            }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    diemThuongXuyen1 = value;
                }
                else
                {
                    loiDiem();
                }
            }
        }
        private float diemThuongXuyen2;
        public float DiemThuongXuyen2
        {
            get
            {
                return diemThuongXuyen2;
            }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    diemThuongXuyen2 = value;
                }
                else
                {
                    loiDiem();
                }

            }
        }
        private float diemThuongXuyen3;
        public float DiemThuongXuyen3
        {
            get
            {
                return diemThuongXuyen3;
            }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    diemThuongXuyen3 = value;
                }
                else
                {
                    loiDiem();
                }
            }
        }
        private float diemGiuaKi;
        public float DiemGiuaKi
        {
            get
            {
                return diemGiuaKi;
            }
            set
            {
                if (value >= 0 && value <=10)
                {
                    diemGiuaKi = value;
                }
                else
                {
                    loiDiem();
                }
            }
        }
        private float diemCuoiKi;
        public float DiemCuoiKi
        {
            get
            {
                return diemCuoiKi;
            }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    diemCuoiKi = value;
                }
                else
                {
                    loiDiem();
                }
            }
        }
        //Constructor rỗng và constructor chuẩn
        public SinhVien()
        {
        }
        public SinhVien(int maSinhVien, string tenSinhVien,Tinh queQuan, DateTime ngaySinh,bool gioiTinh, float diemThuongXuyen1, float diemThuongXuyen2, float diemThuongXuyen3, float diemGiuaKi, float diemCuoiKi)
        {
            this.MaSinhVien = maSinhVien;
            this.TenSinhVien =tenSinhVien;
            this.QueQuan = queQuan;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiemThuongXuyen1 = diemThuongXuyen1;
            this.DiemThuongXuyen2 = diemThuongXuyen2;
            this.DiemThuongXuyen3 = diemThuongXuyen3;
            this.DiemGiuaKi = diemGiuaKi;
            this.DiemCuoiKi = diemCuoiKi;
        } 
        //toString
        public override string ToString()
        {
            return $"MSSV: {maSinhVien}, Họ và tên: {tenSinhVien}, Quên quán: {queQuan}";
        }
        //Hashcode và Equals
        public override int GetHashCode()
        {
            return HashCode.Combine(maSinhVien, tenSinhVien);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            if (this == obj)
                return true;
            SinhVien other = (SinhVien)obj;
            return this.maSinhVien == other.maSinhVien;
        }
        //Ham lay gioi tinh text
        public string GioiTinhText
        {
            get { return gioiTinh ? "Nam" : "Nữ"; }
        }
        //Ham lay gioi tinh bool truyen vao chuoi
        public static bool gioiTinhBool(string gioiTinhText)
        {

            if (gioiTinhText.Trim() == "Nam")
            {
                return true;
            }
            return false;
            
        }
        private void loiDiem()
        {
            throw new ArgumentException("Điểm số phải nằm trong khoảng từ 0 đến 10");
        }
    }
}