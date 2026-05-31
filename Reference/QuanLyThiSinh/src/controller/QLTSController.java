package controller;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import view.QLTSView;

public class QLTSController implements ActionListener{
	public QLTSView view;
	
	
	public QLTSController(QLTSView view) {
		this.view = view;
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		String cm = e.getActionCommand();
		if(cm.equals("Thêm")) {
			this.view.xoaFormThongTin();
			this.view.model.setLuaChon("Thêm");
		}else if(cm.equals("Lưu")) {
			try {
				this.view.thucHienThemThiSinh();
			} catch (Exception e2) {
				e2.printStackTrace();
			}
		}else if(cm.equals("Cập nhật")) {
			this.view.hienThiThongTinThiSinhDaChon();
		}else if(cm.equals("Xóa")) {
			this.view.thucHienXoa();
		}else if(cm.equals("Hủy bỏ")) {
			this.view.xoaFormThongTin();
		}else if(cm.equals("Tìm")) {
			this.view.thucHienTim();
		}else if(cm.equals("Hủy tìm")) {
			this.view.thucHienTaiLaiDuLieu();
		}else if(cm.equals("About Me")) {
			this.view.hienThiAbout();
		}else if(cm.equals("Exit")) {
			this.view.thoatKhoiChuongTrinh();
		}else if(cm.equals("Save")) {
			this.view.thucHienSaveFile();
		}else if(cm.equals("Open")) {
			this.view.thucHienOpenFile();
		}
	}
}