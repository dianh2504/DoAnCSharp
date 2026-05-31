package Test;

import java.sql.Date;
import java.util.ArrayList;
import dao.khachHangDAO;
import model.khachHang;

public class TestKhachHangDao {
	public static void main(String[] args) {
		Date ngaySinh1 = Date.valueOf("2020-12-25");
		Date ngaySinh2 = Date.valueOf("2020-3-14");
		khachHang k1 = new khachHang(8, "le minh hoang", ngaySinh1, "Hue");
		khachHang k2 = new khachHang(10, "le thi minh hue", ngaySinh2, "Nghe an");
		khachHangDAO.getInstance().delete(k1);
		khachHangDAO.getInstance().update(k2);
	}
}
