using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCSharp_WPF.Models
{
    public class sinhVienDao : DAOInterface<SinhVien>
    {
        public static sinhVienDao getInstance()
        {
            return new sinhVienDao();
        }
        //Delete
        public int delete(SinhVien t)
        {
            int ketQua = 0;
            string sql = "DELETE FROM sinhvien WHERE maSinhVien = @ma";

            using (MySqlConnection con = MSCUtil.getConnection())
            {
                if (con == null) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    //Dung Parameter de tranh SQL Injection (loi noi chuoi 1 == 1)
                    cmd.Parameters.AddWithValue("@ma", t.MaSinhVien);
                    
                    // Thuc thi tra ve so dong bi anh huong 
                    ketQua = cmd.ExecuteNonQuery();
                }
            }
            return ketQua;
        }
        //Insert
        public int insert(SinhVien t)
        {
            int ketQua = 0;
            string sql = "INSERT INTO sinhvien (maSinhVien, tenSinhVien, queQuan, ngaySinh, gioiTinh, diemThuongXuyen1, diemThuongXuyen2, diemThuongXuyen3, diemGiuaKi, diemCuoiKi) VALUES (@ma, @ten, @que, @ngay, @gioi, @diem1, @diem2, @diem3, @diemGiua, @diemCuoi)";

            using (MySqlConnection con = MSCUtil.getConnection())
            {
                if (con == null) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    //Dung Parameter de tranh SQL Injection (loi noi chuoi 1 == 1)
                    cmd.Parameters.AddWithValue("@ma", t.MaSinhVien);
                    cmd.Parameters.AddWithValue("@ten", t.TenSinhVien);
                    cmd.Parameters.AddWithValue("@que", t.QueQuan.TenTinh);
                    cmd.Parameters.AddWithValue("@ngay", t.NgaySinh.Date);
                    cmd.Parameters.AddWithValue("@gioi", t.GioiTinhText);
                    cmd.Parameters.AddWithValue("@diem1", t.DiemThuongXuyen1);
                    cmd.Parameters.AddWithValue("@diem2", t.DiemThuongXuyen2);
                    cmd.Parameters.AddWithValue("@diem3", t.DiemThuongXuyen3);
                    cmd.Parameters.AddWithValue("@diemGiua", t.DiemGiuaKi);
                    cmd.Parameters.AddWithValue("@diemCuoi", t.DiemCuoiKi);
                    // Thuc thi tra ve so dong bi anh huong 
                    ketQua = cmd.ExecuteNonQuery();
                }
            }
            return ketQua;
        }
        //Selected all
        public List<SinhVien> selectAll()
        {
            List<SinhVien> ketQua = new List<SinhVien>();
            string sql = "SELECT * FROM sinhvien";
            try
            {
                using (MySqlConnection con = MSCUtil.getConnection())
                {
                    if (con == null) return ketQua;

                    using (MySqlCommand st = new MySqlCommand(sql, con))
                    {
                        //Thuc thi lenh chi doc du lieu
                        using (MySqlDataReader rs = st.ExecuteReader())
                        {
                            
                            
                            //Duyet qua tung dong du lieu
                            while (rs.Read())
                            {
                                int maSinhVien = Convert.ToInt32(rs["maSinhVien"]);
                                string tenSinhVien = Convert.ToString(rs["tenSinhVien"]);
                                Tinh queQuan = Tinh.getTinhByTen(Convert.ToString(rs["queQuan"]));
                                DateTime ngaySinh = Convert.ToDateTime(rs["ngaySinh"]);
                                bool gioiTinh = SinhVien.gioiTinhBool(Convert.ToString(rs["gioiTinh"]));

                                float diemThuongXuyen1 = Convert.ToSingle(rs["diemThuongXuyen1"]);
                                float diemThuongXuyen2 = Convert.ToSingle(rs["diemThuongXuyen2"]);
                                float diemThuongXuyen3 = Convert.ToSingle(rs["diemThuongXuyen3"]);
                                float diemGiuaKi = Convert.ToSingle(rs["diemGiuaKi"]);
                                float diemCuoiKi = Convert.ToSingle(rs["diemCuoiKi"]);
                                SinhVien sv = new SinhVien(maSinhVien, tenSinhVien, queQuan, ngaySinh, gioiTinh, diemThuongXuyen1, diemThuongXuyen2, diemThuongXuyen3, diemGiuaKi, diemCuoiKi);

                                ketQua.Add(sv);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return ketQua;
        }
        //Selected by condition
        public List<SinhVien> selectByCondition(string condition)
        {
            List<SinhVien> ketQua = new List<SinhVien>();

            
            string sql = "SELECT * FROM sinhvien WHERE " + (string.IsNullOrEmpty(condition) ? "1=1" : condition);

            try
            {
                using (MySqlConnection con = MSCUtil.getConnection())
                {
                    if (con == null) return ketQua;

                    using (MySqlCommand st = new MySqlCommand(sql, con))
                    { 
                        using (MySqlDataReader rs = st.ExecuteReader())
                        {
                            //Duyet qua tung dong du lieu
                            while (rs.Read())
                            {
                                int maSinhVien = Convert.ToInt32(rs["maSinhVien"]);
                                string tenSinhVien = Convert.ToString(rs["tenSinhVien"]);
                                Tinh queQuan = Tinh.getTinhByTen(Convert.ToString(rs["queQuan"])); 
                                DateTime ngaySinh = Convert.ToDateTime(rs["ngaySinh"]);
                                bool gioiTinh = SinhVien.gioiTinhBool(Convert.ToString(rs["gioiTinh"]));
                                float diemThuongXuyen1 = Convert.ToSingle(rs["diemThuongXuyen1"]);
                                float diemThuongXuyen2 = Convert.ToSingle(rs["diemThuongXuyen2"]);
                                float diemThuongXuyen3 = Convert.ToSingle(rs["diemThuongXuyen3"]);
                                float diemGiuaKi = Convert.ToSingle(rs["diemGiuaKi"]);
                                float diemCuoiKi = Convert.ToSingle(rs["diemCuoiKi"]);


                                SinhVien sv = new SinhVien(maSinhVien, tenSinhVien, queQuan, ngaySinh, gioiTinh, diemThuongXuyen1, diemThuongXuyen2, diemThuongXuyen3, diemGiuaKi, diemCuoiKi);
                                ketQua.Add(sv);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // In lỗi ra màn hình để bạn dễ debug nếu câu lệnh truyền vào bị sai cú pháp SQL
                Console.WriteLine("Lỗi truy vấn selectByCondition: " + ex.Message);
            }

            return ketQua;
        }
        //Seltected by id
        public SinhVien selectByID(int ID)
        {
            SinhVien sv = null;
            string sql = "SELECT * FROM sinhvien WHERE maSinhVien = @ma";

            try
            {
                using (MySqlConnection con = MSCUtil.getConnection())
                {
                    if (con == null) return null;

                    using (MySqlCommand st = new MySqlCommand(sql, con))
                    {
                        st.Parameters.AddWithValue("@ma", ID);

                        using (MySqlDataReader rs = st.ExecuteReader())
                        {
                            if (rs.Read())
                            {
                                int maSinhVien = Convert.ToInt32(rs["maSinhVien"]);
                                string tenSinhVien = Convert.ToString(rs["tenSinhVien"]);
                                Tinh queQuan = Tinh.getTinhByTen(Convert.ToString(rs["queQuan"]));
                                DateTime ngaySinh = Convert.ToDateTime(rs["ngaySinh"]);
                                bool gioiTinh = SinhVien.gioiTinhBool(Convert.ToString(rs["gioiTinh"]));

                                float diemThuongXuyen1 = Convert.ToSingle(rs["diemThuongXuyen1"]);
                                float diemThuongXuyen2 = Convert.ToSingle(rs["diemThuongXuyen2"]);
                                float diemThuongXuyen3 = Convert.ToSingle(rs["diemThuongXuyen3"]);
                                float diemGiuaKi = Convert.ToSingle(rs["diemGiuaKi"]);
                                float diemCuoiKi = Convert.ToSingle(rs["diemCuoiKi"]);

                                sv = new SinhVien(maSinhVien, tenSinhVien, queQuan, ngaySinh, gioiTinh, diemThuongXuyen1, diemThuongXuyen2, diemThuongXuyen3, diemGiuaKi, diemCuoiKi);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return sv;
        }
        //Update
        public int update(SinhVien t)
        {
            int ketQua = 0;
            string sql = "UPDATE sinhvien SET " +
             "tenSinhVien = @ten, " +
             "queQuan = @que, " +
             "ngaySinh = @ngay, " +
             "gioiTinh = @gioi, " +
             "diemThuongXuyen1 = @diem1, " +
             "diemThuongXuyen2 = @diem2, " +
             "diemThuongXuyen3 = @diem3, " +
             "diemGiuaKi = @diemGiua, " +
             "diemCuoiKi = @diemCuoi " +
             "WHERE maSinhVien = @ma"; 

            using (MySqlConnection con = MSCUtil.getConnection())
            {
                if (con == null) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    //Dung Parameter de tranh SQL Injection (loi noi chuoi 1 == 1)
                    cmd.Parameters.AddWithValue("@ma", t.MaSinhVien);
                    cmd.Parameters.AddWithValue("@ten", t.TenSinhVien);
                    cmd.Parameters.AddWithValue("@que", t.QueQuan.TenTinh);
                    cmd.Parameters.AddWithValue("@ngay", t.NgaySinh.Date);
                    cmd.Parameters.AddWithValue("@gioi", t.GioiTinhText);
                    cmd.Parameters.AddWithValue("@diem1", t.DiemThuongXuyen1);
                    cmd.Parameters.AddWithValue("@diem2", t.DiemThuongXuyen2);
                    cmd.Parameters.AddWithValue("@diem3", t.DiemThuongXuyen3);
                    cmd.Parameters.AddWithValue("@diemGiua", t.DiemGiuaKi);
                    cmd.Parameters.AddWithValue("@diemCuoi", t.DiemCuoiKi);
                    // Thuc thi tra ve so dong bi anh huong 
                    ketQua = cmd.ExecuteNonQuery();
                }
            }
            return ketQua;
        }
    }
}
