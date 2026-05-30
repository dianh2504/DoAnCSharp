package view;
import java.awt.EventQueue;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import model.QLTSModel;
import model.ThiSinh;
import model.Tinh;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JSeparator;
import java.awt.Font;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.time.DateTimeException;
import java.time.LocalDate;
import java.util.ArrayList;
import javax.swing.Box;
import javax.swing.ButtonGroup;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFileChooser;
import javax.swing.JTable;
import javax.swing.JScrollPane;
import javax.swing.table.DefaultTableModel;
import controller.QLTSController;
import javax.swing.JRadioButton;
public class QLTSView extends JFrame {
	private static final long serialVersionUID = 6285027590867755020L;
	private JPanel contentPane;
	public QLTSModel model;
	public JTextField textFieldMaThiSinh;
	public JTable table;
	public JTextField textFieldMaThiSinhThongTin;
	public JTextField textFieldHoVaTen;
	public JTextField textFieldMon1;
	public JTextField textFieldMon2;
	public JTextField textFieldMon3;
	public ButtonGroup buttonGioiTinh;
	public JComboBox<String> comboBoxQueQuanThongTin;
	public JRadioButton radioButtonNam;
	public JRadioButton radioButtonNu;
	public JComboBox<String> comboBoxQueQuan;
	private JTextField textFieldNgay;
	private JTextField textFieldThang;
	private JTextField textFieldNam;

	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					QLTSView frame = new QLTSView();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	
	public QLTSView() {
		this.model = new QLTSModel();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 774, 751);

		ActionListener action = new QLTSController(this);

		JMenuBar menuBar = new JMenuBar();
		setJMenuBar(menuBar);

		JMenu menuFile = new JMenu("File");
		menuFile.setFont(new Font("Segoe UI", Font.PLAIN, 20));
		menuBar.add(menuFile);

		JMenuItem menuOpen = new JMenuItem("Open");
		menuOpen.addActionListener(action);
		menuOpen.setFont(new Font("Segoe UI", Font.PLAIN, 18));
		menuFile.add(menuOpen);

		JMenuItem menuSave = new JMenuItem("Save");
		menuSave.addActionListener(action);
		menuSave.setFont(new Font("Segoe UI", Font.PLAIN, 18));
		menuFile.add(menuSave);

		JSeparator separator = new JSeparator();
		menuFile.add(separator);

		JMenuItem menuExit = new JMenuItem("Exit");
		menuExit.addActionListener(action);
		menuExit.setFont(new Font("Segoe UI", Font.PLAIN, 18));
		menuFile.add(menuExit);

		JMenu menuAbout = new JMenu("About");
		menuAbout.addActionListener(action);
		menuAbout.setFont(new Font("Segoe UI", Font.PLAIN, 20));
		menuBar.add(menuAbout);

		JMenuItem menuAboutMe = new JMenuItem("About Me");
		menuAboutMe.addActionListener(action);
		menuAboutMe.setFont(new Font("Segoe UI", Font.PLAIN, 18));
		menuAbout.add(menuAboutMe);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);

		Box verticalBox_1 = Box.createVerticalBox();
		verticalBox_1.setBounds(44, 144, -28, -35);
		contentPane.add(verticalBox_1);

		JLabel labelQueQuan = new JLabel("Quê quán");
		labelQueQuan.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelQueQuan.setBounds(31, 11, 92, 54);
		contentPane.add(labelQueQuan);

		JLabel labelMaThiSinh = new JLabel("Mã thí sinh");
		labelMaThiSinh.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelMaThiSinh.setBounds(285, 11, 155, 54);
		contentPane.add(labelMaThiSinh);

		textFieldMaThiSinh = new JTextField();
		textFieldMaThiSinh.setFont(new Font("Tahoma", Font.PLAIN, 19));
		textFieldMaThiSinh.setColumns(10);
		textFieldMaThiSinh.setBounds(393, 12, 123, 54);
		contentPane.add(textFieldMaThiSinh);

		JButton buttonTim = new JButton("Tìm");
		buttonTim.addActionListener(action);
		buttonTim.setFont(new Font("Tahoma", Font.PLAIN, 18));
		buttonTim.setBounds(526, 12, 89, 54);
		contentPane.add(buttonTim);

		comboBoxQueQuan = new JComboBox<String>();
		ArrayList<Tinh> listTinh = Tinh.getDSTinh();
		comboBoxQueQuan.addItem("");
		for (Tinh tinh : listTinh) {
			comboBoxQueQuan.addItem(tinh.getTenTinh());
		}
		comboBoxQueQuan.setBounds(120, 11, 155, 54);
		contentPane.add(comboBoxQueQuan);

		JSeparator separator1 = new JSeparator();
		separator1.setBounds(10, 92, 738, 2);
		contentPane.add(separator1);

		JLabel labelDanhSachThiSinh = new JLabel("Danh sách thí sinh");
		labelDanhSachThiSinh.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelDanhSachThiSinh.setBounds(10, 97, 251, 54);
		contentPane.add(labelDanhSachThiSinh);

		table = new JTable();
		table.setFont(new Font("Tahoma", Font.PLAIN, 18));
		table.setModel(new DefaultTableModel(new Object[][] {},
		new String[] { "Mã thí sinh", "Họ tên", "Quê quán", "Ngày sinh","Giới tính", "Điểm môn 1", "Điểm môn 2", "Điểm môn 3" }));
		table.setRowHeight(25);
		
		JScrollPane scrollPane = new JScrollPane(table);
		scrollPane.setBounds(10, 144, 738, 214);
		contentPane.add(scrollPane);

		JSeparator separator2 = new JSeparator();
		separator2.setBounds(10, 369, 738, 2);
		contentPane.add(separator2);

		JLabel labelThongTinThiSinh = new JLabel("Thông tin thí sinh");
		labelThongTinThiSinh.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelThongTinThiSinh.setBounds(10, 369, 233, 54);
		contentPane.add(labelThongTinThiSinh);

		JLabel labelMaThiSinhThongTin = new JLabel("Mã thí sinh");
		labelMaThiSinhThongTin.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelMaThiSinhThongTin.setBounds(10, 412, 102, 54);
		contentPane.add(labelMaThiSinhThongTin);

		textFieldMaThiSinhThongTin = new JTextField();
		textFieldMaThiSinhThongTin.setFont(new Font("Tahoma", Font.PLAIN, 19));
		textFieldMaThiSinhThongTin.setColumns(10);
		textFieldMaThiSinhThongTin.setBounds(127, 422, 166, 35);
		contentPane.add(textFieldMaThiSinhThongTin);

		JLabel labelHoVaTen = new JLabel("Họ và tên");
		labelHoVaTen.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelHoVaTen.setBounds(10, 457, 102, 54);
		contentPane.add(labelHoVaTen);

		textFieldHoVaTen = new JTextField();
		textFieldHoVaTen.setFont(new Font("Tahoma", Font.PLAIN, 19));
		textFieldHoVaTen.setColumns(10);
		textFieldHoVaTen.setBounds(127, 467, 166, 35);
		contentPane.add(textFieldHoVaTen);

		JLabel labelQueQuanThongTin = new JLabel("Quê quán");
		labelQueQuanThongTin.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelQueQuanThongTin.setBounds(10, 502, 102, 54);
		contentPane.add(labelQueQuanThongTin);

		comboBoxQueQuanThongTin = new JComboBox<String>();
		comboBoxQueQuanThongTin.setFont(new Font("Tahoma", Font.PLAIN, 19));
		comboBoxQueQuanThongTin.addItem("");
		for (Tinh tinh : listTinh) {
			comboBoxQueQuanThongTin.addItem(tinh.getTenTinh());
		}

		comboBoxQueQuanThongTin.setBounds(127, 512, 166, 35);
		contentPane.add(comboBoxQueQuanThongTin);

		JLabel labelNgaySinh = new JLabel("Ngày sinh");
		labelNgaySinh.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelNgaySinh.setBounds(10, 557, 92, 54);
		contentPane.add(labelNgaySinh);

		JLabel labelGioiTinh = new JLabel("Giới tính");
		labelGioiTinh.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelGioiTinh.setBounds(324, 412, 102, 54);
		contentPane.add(labelGioiTinh);

		radioButtonNam = new JRadioButton("Nam");
		radioButtonNam.setFont(new Font("Tahoma", Font.PLAIN, 19));
		radioButtonNam.setBounds(432, 429, 72, 23);
		contentPane.add(radioButtonNam);

		radioButtonNu = new JRadioButton("Nữ");
		radioButtonNu.setFont(new Font("Tahoma", Font.PLAIN, 19));
		radioButtonNu.setBounds(506, 429, 61, 23);
		contentPane.add(radioButtonNu);

		buttonGioiTinh = new ButtonGroup();
		buttonGioiTinh.add(radioButtonNam);
		buttonGioiTinh.add(radioButtonNu);

		JLabel labelMon1 = new JLabel("Môn 1");
		labelMon1.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelMon1.setBounds(324, 467, 75, 35);
		contentPane.add(labelMon1);

		textFieldMon1 = new JTextField();
		textFieldMon1.setFont(new Font("Tahoma", Font.PLAIN, 19));
		textFieldMon1.setColumns(10);
		textFieldMon1.setBounds(393, 467, 166, 35);
		contentPane.add(textFieldMon1);

		JLabel labelMon2 = new JLabel("Môn 2");
		labelMon2.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelMon2.setBounds(324, 513, 75, 35);
		contentPane.add(labelMon2);

		textFieldMon2 = new JTextField();
		textFieldMon2.setFont(new Font("Tahoma", Font.PLAIN, 19));
		textFieldMon2.setColumns(10);
		textFieldMon2.setBounds(393, 512, 166, 35);
		contentPane.add(textFieldMon2);

		JLabel labelMon3 = new JLabel("Môn 3");
		labelMon3.setFont(new Font("Tahoma", Font.PLAIN, 19));
		labelMon3.setBounds(324, 557, 75, 35);
		contentPane.add(labelMon3);

		textFieldMon3 = new JTextField();
		textFieldMon3.setFont(new Font("Tahoma", Font.PLAIN, 19));
		textFieldMon3.setColumns(10);
		textFieldMon3.setBounds(393, 557, 166, 35);
		contentPane.add(textFieldMon3);

		JButton buttonThem = new JButton("Thêm");
		buttonThem.addActionListener(action);
		buttonThem.setFont(new Font("Tahoma", Font.PLAIN, 18));
		buttonThem.setBounds(31, 628, 89, 42);
		contentPane.add(buttonThem);

		JButton buttonXoa = new JButton("Xóa");
		buttonXoa.addActionListener(action);
		buttonXoa.setFont(new Font("Tahoma", Font.PLAIN, 18));
		buttonXoa.setBounds(151, 628, 89, 42);
		contentPane.add(buttonXoa);

		JButton buttonCapNhat = new JButton("Cập nhật");
		buttonCapNhat.addActionListener(action);
		buttonCapNhat.setFont(new Font("Tahoma", Font.PLAIN, 18));
		buttonCapNhat.setBounds(264, 628, 135, 42);
		contentPane.add(buttonCapNhat);

		JButton buttonLuu = new JButton("Lưu");
		buttonLuu.addActionListener(action);
		buttonLuu.setFont(new Font("Tahoma", Font.PLAIN, 18));
		buttonLuu.setBounds(421, 628, 135, 42);
		contentPane.add(buttonLuu);

		JButton buttonHuyBo = new JButton("Hủy bỏ");
		buttonHuyBo.addActionListener(action);
		buttonHuyBo.setFont(new Font("Tahoma", Font.PLAIN, 18));
		buttonHuyBo.setBounds(585, 628, 135, 42);
		contentPane.add(buttonHuyBo);

		JSeparator separator3 = new JSeparator();
		separator3.setBounds(15, 628, 733, -22);
		contentPane.add(separator3);

		JSeparator separator4 = new JSeparator();
		separator4.setBounds(10, 616, 738, 2);
		contentPane.add(separator4);

		JButton buttonHuyTim = new JButton("Hủy tìm");
		buttonHuyTim.addActionListener(action);
		buttonHuyTim.setFont(new Font("Tahoma", Font.PLAIN, 18));
		buttonHuyTim.setBounds(631, 11, 117, 54);
		contentPane.add(buttonHuyTim);
		
		JLabel labelSetNgay = new JLabel("/");
		labelSetNgay.setFont(new Font("Tahoma", Font.PLAIN, 18));
		labelSetNgay.setBounds(165, 568, 12, 35);
		contentPane.add(labelSetNgay);
		
		textFieldNgay = new JTextField();
		textFieldNgay.setFont(new Font("Tahoma", Font.PLAIN, 18));
		textFieldNgay.setBounds(131, 568, 35, 35);
		contentPane.add(textFieldNgay);
		textFieldNgay.setColumns(10);
		
		textFieldThang = new JTextField();
		textFieldThang.setFont(new Font("Tahoma", Font.PLAIN, 18));
		textFieldThang.setColumns(10);
		textFieldThang.setBounds(176, 568, 35, 35);
		contentPane.add(textFieldThang);
		
		JLabel labelSetThang = new JLabel("/");
		labelSetThang.setFont(new Font("Tahoma", Font.PLAIN, 18));
		labelSetThang.setBounds(210, 568, 12, 35);
		contentPane.add(labelSetThang);
		
		textFieldNam = new JTextField();
		textFieldNam.setFont(new Font("Tahoma", Font.PLAIN, 18));
		textFieldNam.setColumns(10);
		textFieldNam.setBounds(221, 568, 72, 35);
		contentPane.add(textFieldNam);
		
		this.setVisible(true);
	}

	public void xoaFormThongTin() {
		textFieldMaThiSinhThongTin.setText("");
		textFieldHoVaTen.setText("");
		comboBoxQueQuanThongTin.setSelectedIndex(-1);
		textFieldNgay.setText("");
		textFieldThang.setText("");
		textFieldNam.setText("");
		textFieldMon1.setText("");
		textFieldMon2.setText("");
		textFieldMon3.setText("");
		buttonGioiTinh.clearSelection();
	}
	public void xoaFormTinKiem() {
		textFieldMaThiSinh.setText("");
		comboBoxQueQuan.setSelectedIndex(-1);
	}

	public void themThiSinhVaoTable(ThiSinh ts) {
		DefaultTableModel model_table = (DefaultTableModel) table.getModel();
		model_table.addRow(new Object[] 
				{ 
				ts.getMaThiSinh() + "",
				ts.getTenThiSinh(), 
				ts.getQueQuan().getTenTinh(),
				ts.getNgaySinh().getDayOfMonth() + "/" + ts.getNgaySinh().getMonthValue() + "/"+ ts.getNgaySinh().getYear(),
				(ts.isGioiTinh() ? "Nam" : "Nữ"),
				ts.getDiemMon1() + "",
				ts.getDiemMon2() + "",
				ts.getDiemMon3() + "", 
				});
	}

	public void themHoacCapNhatThiSinh(ThiSinh ts) {
		DefaultTableModel model_table = (DefaultTableModel) table.getModel();
		if (!this.model.kiemTraTonTai(ts)) {
			this.model.insert(ts);
			this.themThiSinhVaoTable(ts);
		} else {
			this.model.update(ts);
			int soLuongDong = model_table.getRowCount();
			for (int i = 0; i < soLuongDong; i++) {
				String id = model_table.getValueAt(i, 0) + "";
				if (id.equals(ts.getMaThiSinh() + "")) 
				{
					model_table.setValueAt(ts.getMaThiSinh() + "", i, 0);
					model_table.setValueAt(ts.getTenThiSinh() + "", i, 1);
					model_table.setValueAt(ts.getQueQuan().getTenTinh() + "", i, 2);
					model_table.setValueAt(ts.getNgaySinh().getDayOfMonth() + "/" + ts.getNgaySinh().getMonthValue() + "/"+ ts.getNgaySinh().getYear() + "", i, 3);
					model_table.setValueAt((ts.isGioiTinh() ? "Nam" : "Nữ"), i, 4);
					model_table.setValueAt(ts.getDiemMon1() + "", i, 5);
					model_table.setValueAt(ts.getDiemMon2() + "", i, 6);
					model_table.setValueAt(ts.getDiemMon3() + "", i, 7);
				}
			}
		}
	}

	public ThiSinh getThiSinhDangChon() {
		DefaultTableModel model_table = (DefaultTableModel) table.getModel();
		int i_row = table.getSelectedRow();
		int maThiSinh = Integer.valueOf(model_table.getValueAt(i_row, 0) + "");
		String tenThiSinh = model_table.getValueAt(i_row, 1) + "";
		Tinh tinh = Tinh.getTinhByTen(model_table.getValueAt(i_row, 2) + "");
		Object chuoiNgaySinh = model_table.getValueAt(i_row, 3) + "";
		LocalDate ngaySinh = (LocalDate) chuoiNgaySinh;
		String textGioiTinh = model_table.getValueAt(i_row, 4) + "";
		boolean gioiTinh = textGioiTinh.equals("Nam");
		float diemMon1 = Float.valueOf(model_table.getValueAt(i_row, 5) + "");
		float diemMon2 = Float.valueOf(model_table.getValueAt(i_row, 6) + "");
		float diemMon3 = Float.valueOf(model_table.getValueAt(i_row, 7) + "");
		ThiSinh ts = new ThiSinh(maThiSinh, tenThiSinh, tinh, ngaySinh, gioiTinh, diemMon1, diemMon2, diemMon3);
		return ts;
	}

	public void hienThiThongTinThiSinhDaChon() {
		ThiSinh ts = getThiSinhDangChon();
		this.textFieldMaThiSinhThongTin.setText(ts.getMaThiSinh() + "");
		this.textFieldHoVaTen.setText(ts.getTenThiSinh() + "");
		this.comboBoxQueQuanThongTin.setSelectedItem(ts.getQueQuan().getTenTinh());
		this.textFieldNgay.setText(ts.getNgaySinh().getDayOfMonth()+"");
		this.textFieldThang.setText(ts.getNgaySinh().getMonthValue()+"");
		this.textFieldNam.setText(ts.getNgaySinh().getYear()+"");
		if (ts.isGioiTinh()) {
			radioButtonNam.setSelected(true);
		} else {
			radioButtonNu.setSelected(true);
		}
		this.textFieldMon1.setText(ts.getDiemMon1() + "");
		this.textFieldMon2.setText(ts.getDiemMon2() + "");
		this.textFieldMon3.setText(ts.getDiemMon3() + "");
	}

	public void thucHienXoa() {
		DefaultTableModel model_table = (DefaultTableModel) table.getModel();
		int i_row = table.getSelectedRow();
		int luaChon = JOptionPane.showConfirmDialog(this, "Bạn có chắn chắn xóa dòng đã chọn?");
		if (luaChon == JOptionPane.YES_OPTION) {
			ThiSinh ts = getThiSinhDangChon();
			this.model.delete(ts);
			model_table.removeRow(i_row);
		}

	}

	public void thucHienThemThiSinh() {
		int maThiSinh = Integer.valueOf(this.textFieldMaThiSinhThongTin.getText().trim());
		String tenThiSinh = this.textFieldHoVaTen.getText().trim();
		int queQuan = this.comboBoxQueQuanThongTin.getSelectedIndex() - 1;
		Tinh tinh = Tinh.getTinhById(queQuan);
		this.checkNgaySinh();
		LocalDate ngaySinh = LocalDate.of(Integer.valueOf(this.textFieldNam.getText().trim()),Integer.valueOf(this.textFieldThang.getText().trim()),Integer.valueOf(this.textFieldNgay.getText().trim()));
		boolean gioiTinh = true;
		if (this.radioButtonNam.isSelected()) {
			gioiTinh = true;
		} else if (this.radioButtonNu.isSelected()) {
			gioiTinh = false;
		}
		float diemMon1 = Float.valueOf(this.textFieldMon1.getText().trim());
		float diemMon2 = Float.valueOf(this.textFieldMon2.getText().trim());
		float diemMon3 = Float.valueOf(this.textFieldMon3.getText().trim());
		ThiSinh ts = new ThiSinh(maThiSinh, tenThiSinh, tinh, ngaySinh, gioiTinh, diemMon1, diemMon2, diemMon3);
		this.themHoacCapNhatThiSinh(ts);
	}

	public void thucHienTim() {
	    this.thucHienTaiLaiDuLieu();
	    int queQuanIndex = this.comboBoxQueQuan.getSelectedIndex() - 1;
	    String maThiSinhTimKiem = this.textFieldMaThiSinh.getText().trim();
	    DefaultTableModel model_table = (DefaultTableModel) table.getModel();
	    int soLuongDong = model_table.getRowCount();
	    // Duyệt ngược từ cuối bảng lên đầu để việc xóa không làm thay đổi index của các dòng chưa xét
	    for (int i = soLuongDong - 1; i >= 0; i--) {
	        String idTrongTable = model_table.getValueAt(i, 0) + "";
	        String tenTinhTrongTable = model_table.getValueAt(i, 2) + "";
	        boolean matchQueQuan = true;
	        boolean matchMa = true;
	        // Kiểm tra điều kiện Quê quán
	        if (queQuanIndex >= 0) {
	            Tinh tinhDaChon = Tinh.getTinhById(queQuanIndex);
	            if (!tenTinhTrongTable.equals(tinhDaChon.getTenTinh())) {
	                matchQueQuan = false;
	            }
	        }
	        // Kiểm tra điều kiện Mã thí sinh
	        if (maThiSinhTimKiem.length() > 0) {
	            if (!idTrongTable.equals(maThiSinhTimKiem)) {
	                matchMa = false;
	            }
	        }
	        // Nếu KHÔNG thỏa mãn một trong các điều kiện đang lọc -> Xóa dòng
	        if (!matchQueQuan || !matchMa) {
	            model_table.removeRow(i);
	        }
	    }
	}
	public void thucHienTaiLaiDuLieu() {
		while (true) {
			DefaultTableModel model_table = (DefaultTableModel) table.getModel();
			int soLuongDong = model_table.getRowCount();
			if(soLuongDong==0)
				break;
			else
				try {
					model_table.removeRow(0);
				} catch (Exception e) {
					e.printStackTrace();
				}
		}
		for (ThiSinh ts : this.model.getDsThiSinh()) {
			this.themThiSinhVaoTable(ts);
		}
	}

	public void hienThiAbout() {
		JOptionPane.showMessageDialog(this, "Phần mềm quản lý thí sinh 1.0!");
	}

	public void thoatKhoiChuongTrinh() {
		int luaChon = JOptionPane.showConfirmDialog(
			    this,
			    "Bạn có muốn thoải khỏi chương trình?",
			    "Exit",
			    JOptionPane.YES_NO_OPTION);
		if (luaChon == JOptionPane.YES_OPTION) {
			System.exit(0);
		}
	}

	public void saveFile(String path) {
		try {
			this.model.setTenFile(path);
			FileOutputStream fos = new FileOutputStream(path);
			ObjectOutputStream oos = new ObjectOutputStream(fos);
			for (ThiSinh ts : this.model.getDsThiSinh()) {
				oos.writeObject(ts);
			}
			oos.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	public void thucHienSaveFile() {
		if(this.model.getTenFile().length()>0) {
			saveFile(this.model.getTenFile());
		}else {
			JFileChooser fc = new JFileChooser();
			int returnVal = fc.showSaveDialog(this);
			if (returnVal == JFileChooser.APPROVE_OPTION) {
				File file = fc.getSelectedFile();
				saveFile(file.getAbsolutePath());
			} 
		}
	}
	public void openFile(File file) {
		ArrayList<ThiSinh> ds = new ArrayList<ThiSinh>();
		try {
			this.model.setTenFile(file.getAbsolutePath());
			FileInputStream fis = new FileInputStream(file);
			ObjectInputStream ois = new ObjectInputStream(fis);
			ThiSinh ts = null;
			while((ts = (ThiSinh) ois.readObject())!=null) {
				ds.add(ts);
			}
			ois.close();
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}
		this.model.setDsThiSinh(ds);
	}
	public void thucHienOpenFile() {
		JFileChooser fc = new JFileChooser();
		int returnVal = fc.showOpenDialog(this);
		if (returnVal == JFileChooser.APPROVE_OPTION) {
			File file = fc.getSelectedFile();
			openFile(file);
			thucHienTaiLaiDuLieu();
		} 
	}
	public void checkNgaySinh() {
	    try {
	        int ngay = Integer.parseInt(this.textFieldNgay.getText().trim());
	        int thang = Integer.parseInt(this.textFieldThang.getText().trim());
	        int nam = Integer.parseInt(this.textFieldNam.getText().trim());
	        @SuppressWarnings("unused")
			LocalDate nS = LocalDate.of(nam, thang, ngay);
	    } catch (NumberFormatException e) {
	        JOptionPane.showMessageDialog(this, "Lỗi: Vui lòng chỉ nhập số nguyên!", "Lỗi nhập liệu", JOptionPane.ERROR_MESSAGE);
	    } catch (DateTimeException e) {
	        JOptionPane.showMessageDialog(this, "Lỗi: Ngày tháng năm không hợp lệ!", "Lỗi định dạng thời gian", JOptionPane.WARNING_MESSAGE);
	    }
	}
}