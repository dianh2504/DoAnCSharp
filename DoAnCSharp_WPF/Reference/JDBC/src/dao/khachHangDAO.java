package dao;

import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;

import database.JDBCUtil;
import model.khachHang;

public class khachHangDAO implements DAOInterface<khachHang>{
	public static khachHangDAO getInstance() {
		return new khachHangDAO();
	}
	@Override
	public int insert(khachHang t) {
		int ketQua = 0;
		try {
			//Buoc 1: Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			
			//Buoc 2 Thuc thi lenh sql
			String sql = "INSERT INTO khachhang (id, hoVaTen, diaChi, ngaySinh) VALUES ( ?, ?, ?, ?)";
			PreparedStatement pst = con.prepareStatement(sql);
			pst.setInt(1, t.getId());
			pst.setString(2, t.getHoVaTen());
			pst.setString(3, t.getDiaChi());
			pst.setDate(4, t.getNgaySinh());
			ketQua = pst.executeUpdate();
			
			//Buoc 3 In lenh thuc thi ra man hinh
			System.out.println("Ban da thuc thi "+sql);
			System.out.println("So dong bi thay doi: "+ketQua);
			
			//Buoc 4 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

	@Override
	public int update(khachHang t) {
		int ketQua = 0;
		try {
			//Buoc 1: Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			
			//Buoc 2 Thuc thi lenh sql
			String sql = "UPDATE khachhang SET hoVaTen = ?, diaChi = ?, ngaySinh = ? WHERE id = ?";
			PreparedStatement pst = con.prepareStatement(sql);
			pst.setString(1, t.getHoVaTen());
			pst.setString(2, t.getDiaChi());
			pst.setDate(3, t.getNgaySinh());
			pst.setInt(4, t.getId());
			ketQua = pst.executeUpdate();
			
			//Buoc 3 In lenh thuc thi ra man hinh
			System.out.println("Ban da thuc thi "+sql);
			System.out.println("So dong bi thay doi: "+ketQua);
			
			//Buoc 4 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

	@Override
	public int delete(khachHang t) {
		int ketQua = 0;
		try {
			//Buoc 1: Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			
			//Buoc 2 Thuc thi lenh sql
			String sql = "DELETE FROM khachhang WHERE id = ?";
			PreparedStatement pst = con.prepareStatement(sql);
			pst.setInt(1, t.getId());
			ketQua = pst.executeUpdate();
			
			//Buoc 3 In lenh thuc thi ra man hinh
			System.out.println("Ban da thuc thi "+sql);
			System.out.println("So dong bi thay doi: "+ketQua);
			
			//Buoc 4 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

	@Override
	public ArrayList<khachHang> selectAll() {
		ArrayList<khachHang> ketQua = new ArrayList<khachHang>();
		try {
			//Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			//tao ra doi tuong statement
			Statement st = con.createStatement();
			//Thuc thi lenh sql
			String sql = "SELECT * FROM khachhang";
			ResultSet rs = st.executeQuery(sql);
			//Buoc 4
			while (rs.next()) {
				int id = rs.getInt("id");
				String hoVaTen = rs.getString("hoVaTen");
				Date ngaySinh = rs.getDate("ngaySinh");
				String diaChi = rs.getString("diaChi");
				
				khachHang khach = new khachHang(id, hoVaTen, ngaySinh, diaChi);
				ketQua.add(khach);
			}
			//Buoc 5 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

	@Override
	public khachHang selectById(int ID) {
		khachHang khach = new khachHang();
		try {
			//Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			//tao ra doi tuong statement
			Statement st = con.createStatement();
			//Thuc thi lenh sql
			String sql = "SELECT * FROM khachhang WHERE id = '"+ID+"'";
			System.out.println("Cau lenh da thuc thi: "+sql);
			ResultSet rs = st.executeQuery(sql);
			//Buoc 4
			while (rs.next()) {
				int id = rs.getInt("id");
				String hoVaTen = rs.getString("hoVaTen");
				Date ngaySinh = rs.getDate("ngaySinh");
				String diaChi = rs.getString("diaChi");
				
				khach = new khachHang(id, hoVaTen, ngaySinh, diaChi);
			}
			//Buoc 5 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return khach;
	}

	@Override
	public ArrayList<khachHang> selectByCondition(String condition) {
		ArrayList<khachHang> ketQua = new ArrayList<khachHang>();
		try {
			//Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			//tao ra doi tuong statement
			Statement st = con.createStatement();
			//Thuc thi lenh sql
			String sql = "SELECT * FROM khachhang WHERE "+condition;
			ResultSet rs = st.executeQuery(sql);
			//Buoc 4
			while (rs.next()) {
				int id = rs.getInt("id");
				String hoVaTen = rs.getString("hoVaTen");
				Date ngaySinh = rs.getDate("ngaySinh");
				String diaChi = rs.getString("diaChi");
				
				khachHang khach = new khachHang(id, hoVaTen, ngaySinh, diaChi);
				ketQua.add(khach);
			}
			//Buoc 5 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

}
