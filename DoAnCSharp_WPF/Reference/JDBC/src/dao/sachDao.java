package dao;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import database.JDBCUtil;
import model.sach;
public class sachDao implements DAOInterface<sach>{
	public static sachDao getInstance() {
		return new sachDao();
	}
	@Override
	public int insert(sach t) {
		int ketQua = 0;
		try {
			//Buoc 1 Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			
			//Buoc 2 Thuc thi lenh sql
			String sql = "INSERT INTO sach (id, tenSach, giaBan, namXuatBan) VALUES (?, ?, ?, ?)";
			PreparedStatement pst = con.prepareStatement(sql);
			    // Thiết lập các giá trị dựa trên thứ tự dấu hỏi (?)
			    pst.setString(1, t.getId());
			    pst.setString(2, t.getTenSach());
			    pst.setDouble(3, t.getGiaBan());
			    pst.setInt(4, t.getNamXuatBan());

			    // Thực thi
			    ketQua = pst.executeUpdate();
			    
			    System.out.println("Bạn đã thực thi: " + sql);
			    System.out.println("Số dòng bị ảnh hưởng: " + ketQua);
			    
			ketQua = pst.executeUpdate(sql);
			
			//Buoc 3 In ra thay doi
			System.out.println("Ban da thuc thi"+sql);
			System.out.println("So dong bi thay doi: "+ketQua);
			
			//Buoc 4 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

	@Override
	public int update(sach t) {
		int ketQua = 0;
		try {
			//Buoc 1 Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
		
			//Buoc 2 Thuc thi lenh sql
			String sql = "UPDATE sach SET tenSach = ?, giaBan = ?, namXuatBan = ? WHERE id = ? ";
			PreparedStatement pst = con.prepareStatement(sql);
			pst.setString(1, t.getTenSach());
			pst.setDouble(2, t.getGiaBan());
			pst.setInt(3, t.getNamXuatBan());
			pst.setString(4, t.getId());
			
			ketQua = pst.executeUpdate();
		
			//Buoc 3 in cau lenh ra man hinh
			System.out.println("Ban da thuc thi: "+sql);
			System.out.println("So dong bi thay doi: "+ketQua);
			//Buoc 5 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

	@Override
	public int delete(sach t) {
		int ketQua = 0;
		try {
			//Buoc 1 Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			
			//Buoc 2 Thuc thi lenh sql
			String sql = "DELETE FROM sach WHERE id = ?";
			PreparedStatement pst = con.prepareStatement(sql);
			pst.setString(1, t.getId());
			ketQua = pst.executeUpdate();
			
			//Buoc 3 Chay lenh thong bao
			System.out.println("Ban da thuc thi: "+sql);
			System.out.println("So dong bi thay doi: "+ketQua);
			
			//Buoc 4 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

	@Override
	public ArrayList<sach> selectAll() {
		ArrayList<sach> ketQua = new ArrayList<sach>();
		try {
			//Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			//tao ra doi tuong statement
			Statement st = con.createStatement();
			//Thuc thi lenh sql
			String sql = "SELECT * FROM sach";
			ResultSet rs = st.executeQuery(sql);
			//Buoc 4
			while (rs.next()) {
				String id = rs.getString("id");
				String tenSach = rs.getString("tenSach");
				float giaBan = rs.getFloat("giaBan");
				int namXuatBan = rs.getInt("namXuatBan");
				
				sach sach = new sach(id, tenSach, giaBan, namXuatBan);
				ketQua.add(sach);
			}
			//Buoc 5 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}

	@Override
	public sach selectById(int ID) {
		sach sach = new sach();
		try {
			//Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			//tao ra doi tuong statement
			Statement st = con.createStatement();
			//Thuc thi lenh sql
			String sql = "SELECT * FROM sach WHERE id = '"+ID+"'";
			System.out.println("Cau lenh da thuc thi: "+sql);
			ResultSet rs = st.executeQuery(sql);
			//Buoc 4
			while (rs.next()) {
				String id = rs.getString("id");
				String tenSach = rs.getString("tenSach");
				float giaBan = rs.getFloat("giaBan");
				int namXuatBan = rs.getInt("namXuatBan");
				
				sach = new sach(id, tenSach, giaBan, namXuatBan);
			}
			//Buoc 5 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return sach;
	}

	@Override
	public ArrayList<sach> selectByCondition(String condition) {
		ArrayList<sach> ketQua = new ArrayList<sach>();
		try {
			//Tao ket noi den co so du lieu
			Connection con = JDBCUtil.getConnection();
			//tao ra doi tuong statement
			Statement st = con.createStatement();
			//Thuc thi lenh sql
			String sql = "SELECT * FROM sach WHERE  "+condition;
			System.out.println("Cau lenh da thuc thi: "+sql);
			ResultSet rs = st.executeQuery(sql);
			//Buoc 4
			while (rs.next()) {
				String id = rs.getString("id");
				String tenSach = rs.getString("tenSach");
				float giaBan = rs.getFloat("giaBan");
				int namXuatBan = rs.getInt("namXuatBan");
				
				sach sach = new sach(id, tenSach, giaBan, namXuatBan);
				ketQua.add(sach);
			}
			//Buoc 5 ngat ket noi
			JDBCUtil.closeConnection(con);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return ketQua;
	}
	
}
