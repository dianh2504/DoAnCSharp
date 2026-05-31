using System;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace DoAnCSharp_WPF
{
    public partial class AboutUsWindow : Window
    {
        public AboutUsWindow()
        {
            InitializeComponent();
            DocFileHuongDan();
        }

        private void DocFileHuongDan()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "intructionDocument/HuongDanSuDung.txt");

                if (File.Exists(filePath))
                {
                    textBoxHuongDan.Text = File.ReadAllText(filePath);
                }
                else
                {
                    textBoxHuongDan.Text = "HƯỚNG DẪN CHẠY ỨNG DỤNG:\n\n" +
                                           "Lưu ý: Hệ thống hiện không tìm thấy tệp tin 'HuongDanSuDung.txt'.\n" +
                                           "Vui lòng bổ sung tệp tin này vào thư mục gốc để hiển thị nội dung.";
                }
            }
            catch (Exception ex)
            {
                textBoxHuongDan.Text = "Đã xảy ra lỗi trong quá trình đọc tài liệu: " + ex.Message;
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi chạy đường liên kết: " + ex.Message, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}