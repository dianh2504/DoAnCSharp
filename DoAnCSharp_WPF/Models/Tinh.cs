using System;
using System.Xml.Linq;
namespace DoAnCSharp_WPF.Models
{
    public class Tinh
    {
        // Biến của hàm, set và get
        private int maTinh;
        public int MaTinh  
        {
            get
            {
                return maTinh;
            }
            set
            {
                if (value > 0 && value <35)
                {
                    maTinh = value;
                }
            }
        }
        private string tenTinh;
        public string TenTinh
        {
            get
            {
                return tenTinh;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    tenTinh = value;
                }
            }
        }
        //Constructor rỗng và constructor chuẩn
        public Tinh()
        {
        }
        public Tinh(int maTinh, string tenTinh)
        {
            this.MaTinh = maTinh;
            this.TenTinh = tenTinh;
        }
        //toString
        public override string ToString()
        {
            return $"{tenTinh}";
        }
        //Hashcode và Equals
        public override int GetHashCode()
        {
            return HashCode.Combine(maTinh, tenTinh);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            if (this == obj) 
                return true;
            Tinh other = (Tinh)obj;
            return this.maTinh == other.MaTinh;
        }
        public static List<Tinh> getDSTinh()
        {
            String[] arr_tinh = {
                "An Giang",
                "Bắc Ninh",
                "Cà Mau",
                "Cao Bằng",
                "Đắk Lắk",
                "Điện Biên",
                "Đồng Nai",
                "Đồng Tháp",
                "Gia Lai",
                "Hà Tĩnh",
                "Hưng Yên",
                "Khánh Hòa",
                "Lai Châu",
                "Lạng Sơn",
                "Lào Cai",
                "Lâm Đồng",
                "Nghệ An",
                "Ninh Bình",
                "Phú Thọ",
                "Quảng Ngãi",
                "Quảng Ninh",
                "Quảng Trị",
                "Sơn La",
                "Tây Ninh",
                "Thái Nguyên",
                "Thanh Hóa",
                "TP. Cần Thơ",
                "TP. Đà Nẵng",
                "TP. Hà Nội",
                "TP. Hải Phòng",
                "TP. Hồ Chí Minh",
                "TP. Huế",
                "Tuyên Quang",
                "Vĩnh Long"};
            List<Tinh> listTinh = new List<Tinh>();

            int i = 1;
            foreach (String tenTinh in arr_tinh)
            {
                Tinh t = new Tinh(i, tenTinh);
                listTinh.Add(t);
                i++;
            }
            return listTinh;
        }
        public static Tinh getTinhById(int queQuan)
        {
            return Tinh.getDSTinh().FirstOrDefault(t => t.maTinh == queQuan);
        }
        public static Tinh getTinhByTen(string tenTinh)
        {
            return Tinh.getDSTinh().FirstOrDefault(t => t.tenTinh == tenTinh);
        }
    }
}
