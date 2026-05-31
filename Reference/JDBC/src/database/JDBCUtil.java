package database;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;


public class JDBCUtil {
	public static Connection getConnection() {
		Connection c = null;
		//Dang ky mySql Driver voi driver manager
		try {
			//Cac thong so
			String url = "jdbc:mysql://localhost:3306/nhaSach";
			String username = "root";
			String password = "";
			
			//Tao ket noi
			c = DriverManager.getConnection(url,username,password);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		return c;
	}
	public static void closeConnection (Connection c) {
		if (c!=null) {
			try {
				c.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
	}
}
