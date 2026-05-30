package Test;

import dao.sachDao;
import model.sach;

public class TestSachDAO {
	public static void main(String[] args) {
		sach sach1 = new sach("4", "hoa mat", 500000, 2020);
		sach sach2 = new sach("5", "boahan", 180000, 2024);
		sachDao.getInstance().delete(sach1);
	}
	
}
