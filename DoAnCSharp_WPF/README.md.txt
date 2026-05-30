Phần mềm quản lý sinh viên


I.Mô tả dự án
Ứng dụng được xây dựng giúp người dùng quản lý sinh viên một cách tốt hơn.
Giải quyết bài toán liên quan đến nhập liệu, kết nối với một cơ sở dữ liệu để lưu trữ dữ liệu.
Phần mềm được viết bằng C# kết nối với cơ sở dữ liệu thông qua XAMPP.


II.ác tính năng
Xem, thêm, sửa, xóa thông tin sinh viên.
Quản lý trạng thái kích hoạt tự động của cơ sở dữ liệu SQL.
Ghi và đọc danh sách sinh viên từ cơ sở dữ liệu
Ghi và đọc danh sách sinh viên từ file
Ghi log tự động xoay vòng bằng Serilog.


III. Hướng dẫn cài đặt & Khởi chạy (Installation & Setup)
Yêu cầu hệ thống: 
Cần cài phần mềm: 
.NET SDK 8.0 +
XAMPP v3.3 + (Có thể cài thêm HeidiSQL để tương tác với cơ sở dữ liệu bằng giao diện)
Tạo cơ sở dữ liệu trên xampp với các thông số như sau:
"Server=localhost;Port=3306;Database=quanlysinhvien;User ID = root;Password = ;"
Visual studio Comunity latest version.

Các bước cài đặt: 
1. Clone code về máy (git clone ...)
2. Mở file .slnx bằng Visual Studio
3. Nhấn F5 hoặc nút Start để chạy phần mềm


IV. Hướng dẫn sử dụng
A. Tương tác với đối tượng sinh viên:
1. Thêm sinh viên - Nhấn nút thêm - lúc này chương trinh sẽ xóa sạch thông tin trên ô nhập liệu - Nhập liệu - Nhấn nút lưu - Giữ nguyên chức năng lưu.
2. Chỉnh sửa sinh viên - Nhấn vào nút chỉnh sửa - Nhấn vào sinh viên cần sửa chửa thông tin lên bảng - Sửa thông tin sinh viên - Nhấn nút lưu - Giứ nguyên chức năng chỉnh sửa.
3. Xóa sinh viên - Nhấn nút xóa - Nhấn vào sinh viên cần xóa ở bảng - Nhấn nút lưu - Giữ nguyên chức năng xóa.

B. Tương tác với BD.
Trên thanh menubar - Nhấn vào SQL - Nhấn vào Open SQL để kết nối với cơ sở dữ liệu
Trên thanh menubar - Nhấn vào SQL - Nhấn vào Load SQL để lấy dữ liệu từ cơ sở dữ liệu load lên phần mềm.
Trên thanh menubar - Nhấn vào SQL - Nhấn vào Close SQL để tắt liên kết với cơ sở dữ liệu hoặc sẽ tự tắt khi người dùng đang bật khi close phần mềm.

C. Tương tác với File
Trên thanh menubar - Nhấn vào File - Nhấn vào Open để load dữ liệu từ file lên chương trình.
Trên thanh menubar - Nhấn vào File - Nhấn vào Save để load dữ liệu object xuống file.
Trên thanh menubar - Nhấn vào File - Nhấn vào Close để thoát file đang edit và tạo một file mới.


V.Hướng phát triển thêm dự tính.


