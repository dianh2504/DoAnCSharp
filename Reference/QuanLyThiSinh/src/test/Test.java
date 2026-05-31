package test;

import javax.swing.UIManager;

import view.QLTSView;

public class Test {
	public static void main(String[] args) {
		try {
			UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
			new QLTSView();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}