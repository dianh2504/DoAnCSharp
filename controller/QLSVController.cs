using DoAnCSharp_WPF.Models;
using Microsoft.Win32;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;

namespace DoAnCSharp_WPF
{
    internal class QLSVController
    {
        private MainWindow viewQLSV;
        private QLSVModel modelQLSV;
        private BindingList<SinhVien> bindingListSV;
        private BindingList<SinhVien> bindingListTimKiem;

        public QLSVController(MainWindow view)
        {
            this.viewQLSV = view;
            this.modelQLSV = new QLSVModel();

            LoadInitialData();
            this.viewQLSV.buttonThem.Click += nhanNutThem;
            this.viewQLSV.buttonLuu.Click += nhanNutLuu;
            this.viewQLSV.buttonChinhSua.Click += nhanNutChinhSua;
            this.viewQLSV.buttonXoa.Click += nhanNutXoa;
            this.viewQLSV.buttonHuyBo.Click += nhanNutHuyBo;
            this.viewQLSV.buttonHuyTim.Click += nhanNutHuyTim;
            this.viewQLSV.buttonTim.Click += nhanNutTimKiem;
            this.viewQLSV.saveFileMenu.Click += nhanNutSaveFile;
            this.viewQLSV.openFileMenu.Click += nhanNutOpenFile;
            this.viewQLSV.exportPdfMenu.Click += nhanNutExportPdf;
            this.viewQLSV.closeFileMenu.Click += nhanNutCloseFile;
            this.viewQLSV.openSQLMenu.Click += nhanNutOpenSQLMenu;
            this.viewQLSV.loadSQLMenu.Click += nhanNutLoadSQLMenu;
            this.viewQLSV.closeSQLMenu.Click += nhanNutCloseSQLMenu;
            this.viewQLSV.aboutUsMenu.Click += nhanNutAboutUs;
            this.viewQLSV.Closing += KiemTraTruocKhiThoat;
        }
        private void LoadInitialData()
        {
            List<Tinh> dsTinh = Tinh.getDSTinh();
            viewQLSV.comboBoxQueQuan.ItemsSource = dsTinh;
            viewQLSV.comboBoxQueQuan.DisplayMemberPath = "TenTinh";
            viewQLSV.comboBoxQueQuan.SelectedValuePath = "MaTinh";
            viewQLSV.comboBoxQueQuanThem.ItemsSource = dsTinh;
            viewQLSV.comboBoxQueQuanThem.DisplayMemberPath = "TenTinh";
            viewQLSV.comboBoxQueQuanThem.SelectedValuePath = "MaTinh";
            bindingListSV = new BindingList<SinhVien>(this.modelQLSV.DsSinhVien);
            this.viewQLSV.table.ItemsSource = bindingListSV;
        }

        private void nhanNutThem(object sender, RoutedEventArgs e)
        {
            this.viewQLSV.xoaFormThongTin();
            this.viewQLSV.batButtonThem();
            this.modelQLSV.ChucNang = "Them";
        }

        private void nhanNutChinhSua(object sender, RoutedEventArgs e)
        {
            this.viewQLSV.batButtonChinhSua();
            this.modelQLSV.ChucNang = "ChinhSua";
        }

        private void nhanNutXoa(object sender, RoutedEventArgs e)
        {
            this.viewQLSV.batButtonXoa();
            this.modelQLSV.ChucNang = "Xoa";
        }

        private void nhanNutHuyBo(object sender, RoutedEventArgs e)
        {
            this.viewQLSV.batButtonHuyBo();
            this.modelQLSV.ChucNang = "";
        }

        private void nhanNutLuu(object sender, RoutedEventArgs e)
        {
            if (this.modelQLSV.ChucNang == "Them")
            {
                this.ThucHienThemSinhVien();
                Log.Information($"USER - Thực hiện thêm sinh viên");
            }
            else if (this.modelQLSV.ChucNang == "ChinhSua")
            {
                if (this.viewQLSV.table.SelectedItem != null)
                {
                    SinhVien svCanSua = (SinhVien)this.viewQLSV.table.SelectedItem;
                    this.bindingListSV.Remove(svCanSua);
                    this.ThucHienThemSinhVien();
                    Log.Information($"USER - Thực hiện chỉnh sửa sinh viên");
                }
            }
            else if (this.modelQLSV.ChucNang == "Xoa")
            {
                if (this.viewQLSV.table.SelectedItem != null)
                {
                    SinhVien svCanXoa = (SinhVien)this.viewQLSV.table.SelectedItem;
                    this.bindingListSV.Remove(svCanXoa);
                    if (this.modelQLSV.TrangThaiSQL)
                    {
                        tuongTacSQL(svCanXoa);
                    }
                    Log.Information($"USER - Thực hiện xóa sinh viên");
                }
            }
        }
        private void nhanNutAboutUs(object sender, RoutedEventArgs e)
        {
            AboutUsWindow aboutWindow = new AboutUsWindow();
            aboutWindow.Owner = this.viewQLSV;
            aboutWindow.ShowDialog();
        }
        private void ThucHienThemSinhVien()
        {
            if (string.IsNullOrWhiteSpace(viewQLSV.textBoxMaSinhVienThem.Text) ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxHoVaTen.Text) ||
         viewQLSV.comboBoxQueQuanThem.SelectedItem == null ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxNgay.Text) ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxThang.Text) ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxNam.Text) ||
         (viewQLSV.radioButtonNam.IsChecked == false && viewQLSV.radioButtonNu.IsChecked == false) ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxDiemThuongXuyen1.Text) ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxDiemThuongXuyen2.Text) ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxDiemThuongXuyen3.Text) ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxDiemGiuaKi.Text) ||
         string.IsNullOrWhiteSpace(viewQLSV.textBoxDiemCuoiKi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả thông tin trước khi lưu!", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                int maSinhVien = int.Parse(viewQLSV.textBoxMaSinhVienThem.Text.Trim());
                this.modelQLSV.kiemTraTrungMaSinhVien(maSinhVien);
                string hoVaTen = viewQLSV.textBoxHoVaTen.Text.Trim();
                Tinh queQuan = (Tinh)viewQLSV.comboBoxQueQuanThem.SelectedItem;
                bool gioiTinh = viewQLSV.radioButtonNam.IsChecked == true;
                this.viewQLSV.kiemTraCheckedGioiTinh();
                int ngay = int.Parse(viewQLSV.textBoxNgay.Text.Trim());
                int thang = int.Parse(viewQLSV.textBoxThang.Text.Trim());
                int nam = int.Parse(viewQLSV.textBoxNam.Text.Trim());
                DateTime ngaySinh = new DateTime(nam, thang, ngay);
                float diemtThuongXuyen1 = 0, diemtThuongXuyen2 = 0, diemtThuongXuyen3 = 0, diemGiuaKi = 0, diemCuoiKi = 0;
                float.TryParse(viewQLSV.textBoxDiemThuongXuyen1.Text.Trim(), out diemtThuongXuyen1);
                float.TryParse(viewQLSV.textBoxDiemThuongXuyen2.Text.Trim(), out diemtThuongXuyen2);
                float.TryParse(viewQLSV.textBoxDiemThuongXuyen3.Text.Trim(), out diemtThuongXuyen3);
                float.TryParse(viewQLSV.textBoxDiemGiuaKi.Text.Trim(), out diemGiuaKi);
                float.TryParse(viewQLSV.textBoxDiemCuoiKi.Text.Trim(), out diemCuoiKi);
                SinhVien sv = new SinhVien(maSinhVien, hoVaTen, queQuan, ngaySinh, gioiTinh, diemtThuongXuyen1, diemtThuongXuyen2, diemtThuongXuyen3, diemGiuaKi, diemCuoiKi);
                if (this.bindingListSV != null)
                {
                    this.bindingListSV.Add(sv);
                }

                if (this.modelQLSV.TrangThaiSQL)
                {
                    this.tuongTacSQL(sv);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nhanNutHuyTim(object sender, RoutedEventArgs e)
        {
            this.viewQLSV.xoaFormTimKiem();
            this.viewQLSV.batButtonHuyTim();
            this.viewQLSV.table.ItemsSource = bindingListSV;
        }

        private void nhanNutTimKiem(object sender, RoutedEventArgs e)
        {
            this.viewQLSV.batButtonTimKiem();
            this.bindingListTimKiem = new BindingList<SinhVien>();
            string queQuanCanTim = viewQLSV.comboBoxQueQuan.Text.Trim();
            string maSVText = viewQLSV.textBoxMaSinhVien.Text.Trim();

            var ketQuaLoc = this.modelQLSV.DsSinhVien.AsEnumerable();

            if (!string.IsNullOrEmpty(queQuanCanTim))
            {
                ketQuaLoc = ketQuaLoc.Where(sv => sv.QueQuan != null && sv.QueQuan.TenTinh.Equals(queQuanCanTim, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(maSVText))
            {
                if (int.TryParse(maSVText, out int maSVCanTim))
                {
                    ketQuaLoc = ketQuaLoc.Where(sv => sv.MaSinhVien == maSVCanTim);
                }
                else
                {
                    MessageBox.Show("Mã sinh viên tìm kiếm phải là số!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            this.bindingListTimKiem.Clear();
            foreach (var sv in ketQuaLoc.ToList())
            {
                this.bindingListTimKiem.Add(sv);
            }
            this.viewQLSV.table.ItemsSource = bindingListTimKiem;
        }
        private void nhanNutSaveFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Data File (*.dat)|*.dat";
            saveFileDialog.DefaultExt = "dat";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    string jsonString = JsonSerializer.Serialize(this.modelQLSV.DsSinhVien);
                    File.WriteAllText(saveFileDialog.FileName, jsonString);
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    Log.Information($"USER - Thực hiện lưu file {saveFileDialog.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void nhanNutOpenFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Data File (*.dat)|*.dat";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string jsonString = File.ReadAllText(openFileDialog.FileName);
                    List<SinhVien> dsDocDuoc = JsonSerializer.Deserialize<List<SinhVien>>(jsonString);

                    if (dsDocDuoc != null)
                    {
                        this.bindingListSV.Clear();
                        foreach (SinhVien sv in dsDocDuoc)
                        {
                            this.bindingListSV.Add(sv);
                        }

                        MessageBox.Show("Đọc dữ liệu danh sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    Log.Information($"USER - Thực hiện mở file {openFileDialog.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cấu trúc hoặc không thể mở file: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void nhanNutExportPdf(object sender, RoutedEventArgs e)
        {
            if (this.bindingListSV == null || this.bindingListSV.Count == 0)
            {
                MessageBox.Show("Danh sách sinh viên hiện đang trống, không thể xuất PDF!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "PDF Document (*.pdf)|*.pdf";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.FileName = "DanhSachSinhVien_Export";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 15f, 15f, 25f, 25f);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(document, new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create));
                    document.Open();
                    string sysFontPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Fonts", "Arial.ttf");
                    iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(sysFontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE);
                    iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);
                    iTextSharp.text.Font fontBody = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("DANH SÁCH THÔNG TIN & ĐIỂM SỐ SINH VIÊN", fontTitle);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    title.SpacingAfter = 20f;
                    document.Add(title);
                    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(10);
                    table.WidthPercentage = 100;
                    float[] columnWidths = new float[] { 4f, 8f, 3f, 5f, 5f, 2.5f, 2.5f, 2.5f, 2.5f, 2.5f };
                    table.SetWidths(columnWidths);
                    string[] headers = { "MSSV", "Họ và Tên", "Phái", "Quê Quán", "Ngày Sinh", "TX1", "TX2", "TX3", "GK", "CK" };
                    foreach (string headerText in headers)
                    {
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(headerText, fontHeader));
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(50, 50, 50);
                        cell.Padding = 6;
                        table.AddCell(cell);
                    }
                    foreach (var sv in this.bindingListSV)
                    {
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.MaSinhVien.ToString(), fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.TenSinhVien, fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.GioiTinhText, fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.QueQuan != null ? sv.QueQuan.TenTinh : "", fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.NgaySinh.ToString("dd/MM/yyyy"), fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.DiemThuongXuyen1.ToString("0.#"), fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.DiemThuongXuyen2.ToString("0.#"), fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.DiemThuongXuyen3.ToString("0.#"), fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.DiemGiuaKi.ToString("0.#"), fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                        table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(sv.DiemCuoiKi.ToString("0.#"), fontBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Padding = 4 });
                    }
                    document.Add(table);
                    document.Close();

                    MessageBox.Show("Xuất tệp PDF thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    Log.Information("USER - Xuất file pdf");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xuất tệp PDF: " + ex.Message, "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void nhanNutCloseFile(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn đóng danh sách hiện tại không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.modelQLSV.DsSinhVien.Clear();
                this.bindingListSV.Clear();
                this.viewQLSV.xoaFormThongTin();
                this.modelQLSV.ChucNang = "";
            }
            Log.Information("USER - Thực hiện close file");
        }
        private void KiemTraTruocKhiThoat(object sender, CancelEventArgs e)
        {
            bool dangNhapDo = !string.IsNullOrWhiteSpace(this.viewQLSV.textBoxMaSinhVienThem.Text)
                           || this.modelQLSV.ChucNang == "Them"
                           || this.modelQLSV.ChucNang == "ChinhSua";

            if (dangNhapDo)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Bạn chưa lưu thông tin vừa nhập.\nBạn có chắc chắn muốn thoát phần mềm và những thông tin chưa lưu sẽ bị loại bỏ?",
                    "Cảnh báo dữ liệu chưa lưu",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    this.modelQLSV.ChucNang = "";
                }
            }
        }
        private void nhanNutOpenSQLMenu(object sender, RoutedEventArgs e)
        {
            string xamppFolder = @"D:\Tool\Xampp\Source";
            try
            {
                string apacheScript = Path.Combine(xamppFolder, "apache_start.bat");
                if (File.Exists(apacheScript))
                {
                    Process.Start(new ProcessStartInfo(apacheScript) { WorkingDirectory = xamppFolder, CreateNoWindow = true, UseShellExecute = false });
                }
                string mysqlScript = Path.Combine(xamppFolder, "mysql_start.bat");
                if (File.Exists(mysqlScript))
                {
                    Process.Start(new ProcessStartInfo(mysqlScript) { WorkingDirectory = xamppFolder, CreateNoWindow = true, UseShellExecute = false });
                }

                System.Threading.Thread.Sleep(3000);
                MessageBox.Show("Đã kích hoạt Apache và MySQL", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.modelQLSV.TrangThaiSQL = true;
                Log.Information("USER - Kết nối cơ sở dữ liệu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi mở SQL: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nhanNutLoadSQLMenu(object sender, RoutedEventArgs e)
        {
            List<SinhVien> dsMoi = sinhVienDao.getInstance().selectAll();
            this.modelQLSV.DsSinhVien = dsMoi;
            this.bindingListSV.Clear();
            foreach (SinhVien sv in dsMoi)
            {
                this.bindingListSV.Add(sv);
            }
            Log.Information("USER - Tải dữ liệu từ cơ sở dữ liệu");
        }

        private void nhanNutCloseSQLMenu(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("mysqld")) process.Kill();
                foreach (var process in Process.GetProcessesByName("httpd")) process.Kill();
                MessageBox.Show("Đã tắt apache và SQL!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.modelQLSV.TrangThaiSQL = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tắt apache và SQL: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Log.Information("USER - Tắt cơ sở dữ liệu");
        }

        private void tuongTacSQL(SinhVien sv)
        {
            if (this.modelQLSV.ChucNang == "Them")
            {
                sinhVienDao.getInstance().insert(sv);
                Log.Information("USER - Thêm sinh viên vào cơ sở dữ liệu");
            } 
            else if (this.modelQLSV.ChucNang == "ChinhSua")
            {
                sinhVienDao.getInstance().update(sv);
                Log.Information("USER - Chỉnh sửas sinh viên trong cơ sở dữ liệu");
            }
            else if (this.modelQLSV.ChucNang == "Xoa")
            {
                sinhVienDao.getInstance().delete(sv);
                Log.Information("USER - Xóa sinh viên khỏi cơ sở dữ liệu");
            }
        }
    }
}