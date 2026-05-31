using DoAnCSharp_WPF.Models;
using System;
using System.Windows;
using System.Windows.Controls;
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
        private void table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table.SelectedItem == null) return;

            this.xoaFormThongTin();

            var rowData = table.SelectedItem as DoAnCSharp_WPF.Models.SinhVien;

            if (rowData != null)
            {
                this.textBoxMaSinhVienThem.Text = rowData.MaSinhVien.ToString();
                this.textBoxHoVaTen.Text = rowData.TenSinhVien; 

                if (rowData.GioiTinhText == "Nam")
                {
                    this.radioButtonNam.IsChecked = true;
                }
                else
                {
                    this.radioButtonNu.IsChecked = true;
                }

                if (rowData.QueQuan != null)
                {
                    this.comboBoxQueQuanThem.Text = rowData.QueQuan.TenTinh;
                }

                string ngaySinhFull = rowData.NgaySinh.ToString("dd/MM/yyyy");
                string[] mangNgaySinh = ngaySinhFull.Split('/');

                if (mangNgaySinh.Length == 3)
                {
                    this.textBoxNgay.Text = mangNgaySinh[0];
                    this.textBoxThang.Text = mangNgaySinh[1];
                    this.textBoxNam.Text = mangNgaySinh[2];
                }

                this.textBoxDiemThuongXuyen1.Text = rowData.DiemThuongXuyen1.ToString();
                this.textBoxDiemThuongXuyen2.Text = rowData.DiemThuongXuyen2.ToString();
                this.textBoxDiemThuongXuyen3.Text = rowData.DiemThuongXuyen3.ToString();
                this.textBoxDiemGiuaKi.Text = rowData.DiemGiuaKi.ToString();
                this.textBoxDiemCuoiKi.Text = rowData.DiemCuoiKi.ToString();
            }
        }
    }
}