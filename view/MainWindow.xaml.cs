using System;
using System.Windows;
using System.Windows.Media;

namespace DoAnCSharp_WPF
{
    public partial class MainWindow : Window
    {
        private QLSVController controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new QLSVController(this);
        }
        public void xoaFormThongTin()
        {
            textBoxMaSinhVienThem.Text = string.Empty;
            textBoxHoVaTen.Text = string.Empty;
            if (comboBoxQueQuanThem.Items.Count > 0) comboBoxQueQuanThem.SelectedIndex = 0;
            textBoxNgay.Text = string.Empty;
            textBoxThang.Text = string.Empty;
            textBoxNam.Text = string.Empty;
            radioButtonNam.IsChecked = false;
            radioButtonNu.IsChecked = false;
            textBoxDiemThuongXuyen1.Text = string.Empty;
            textBoxDiemThuongXuyen2.Text = string.Empty;
            textBoxDiemThuongXuyen3.Text = string.Empty;
            textBoxDiemGiuaKi.Text = string.Empty;
            textBoxDiemCuoiKi.Text = string.Empty;
        }
        public void xoaFormTimKiem()
        {
            textBoxMaSinhVien.Text = string.Empty;
            if (comboBoxQueQuan.Items.Count > 0) comboBoxQueQuan.SelectedIndex = 0;
        }
        public void batButtonThem()
        {
            buttonThem.Background = Brushes.LightGreen;
            buttonChinhSua.Background = SystemColors.ControlBrush;
            buttonXoa.Background = SystemColors.ControlBrush;
        }

        public void batButtonChinhSua()
        {
            buttonChinhSua.Background = Brushes.LightGreen;
            buttonThem.Background = SystemColors.ControlBrush;
            buttonXoa.Background = SystemColors.ControlBrush;
        }

        public void batButtonXoa()
        {
            buttonXoa.Background = Brushes.LightGreen;
            buttonThem.Background = SystemColors.ControlBrush;
            buttonChinhSua.Background = SystemColors.ControlBrush;
        }

        public void batButtonLuu()
        {
            buttonThem.Background = SystemColors.ControlBrush;
            buttonChinhSua.Background = SystemColors.ControlBrush;
            buttonXoa.Background = SystemColors.ControlBrush;
        }

        public void batButtonHuyBo()
        {
            buttonChinhSua.Background = SystemColors.ControlBrush;
            buttonThem.Background = SystemColors.ControlBrush;
            buttonXoa.Background = SystemColors.ControlBrush;
        }

        public void batButtonTimKiem()
        {
            buttonTim.Background = Brushes.LightGreen;
        }

        public void batButtonHuyTim()
        {
            buttonTim.Background = SystemColors.ControlBrush;
        }
        public void kiemTraCheckedGioiTinh()
        {
            if (radioButtonNam.IsChecked == false && radioButtonNu.IsChecked == false)
            {
                throw new Exception("Chưa chọn giới tính cho sinh viên!");
            }
        }
    }
}