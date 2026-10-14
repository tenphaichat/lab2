========================================================================
TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á (EAUT)
KHOA CÔNG NGHỆ THÔNG TIN - BỘ MÔN CÔNG NGHỆ PHẦN MỀM
HỌC PHẦN: LẬP TRÌNH .NET
LAB 2: LỚP, ĐỐI TƯỢNG, CONSTRUCTOR VÀ ĐÓNG GÓI
========================================================================

1. HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY
------------------------------------------------------------------------
- Yêu cầu môi trường: Visual Studio 2022 hoặc .NET SDK (>= .NET 8 / .NET 9).
- Mở bằng Visual Studio:
  + Mở file solution: IT3212_Labs.sln
  + Nhấn F5 hoặc Ctrl+F5 để build và chạy ứng dụng Console.
- Chạy bằng dòng lệnh (CLI):
  + Di chuyển vào thư mục lab2:
      cd lab2
  + Chạy lệnh:
      dotnet run --project Lab02_OOPBasics/Lab02_OOPBasics.csproj

2. DANH SÁCH BÀI TẬP ĐÃ HOÀN THÀNH
------------------------------------------------------------------------
Tổ chức mã nguồn OOP chuẩn tách biệt các lớp vào từng file .cs riêng biệt:

* PHẦN 1: BÀI TẬP CÓ HƯỚNG DẪN (1 - 5)
  [x] Bài 1: Khai báo lớp SinhVien (MaSV, HoTen, NgaySinh, DiemTB) và in thông tin qua phương thức HienThi().
  [x] Bài 2: Constructor mặc định và nạp chồng constructor đầy đủ tham số để bảo đảm trạng thái đối tượng hợp lệ.
  [x] Bài 3: Đóng gói (Encapsulation) với backing field private _hoTen, _diemTB; kiểm tra không cho rỗng và điểm ngoài [0, 10].
  [x] Bài 4: Cài đặt phương thức nghiệp vụ TinhTuoi() chính xác theo ngày tháng năm sinh và XepLoai() học lực.
  [x] Bài 5: Quản lý danh sách List<SinhVien>, hiển thị danh sách và tìm kiếm sinh viên theo mã bằng List.Find().

* PHẦN 2: BÀI TẬP TỰ THỰC HIỆN (6 - 10)
  [x] Bài 6: Lớp SanPham (MaSP, TenSP, DonGia, SoLuong) với ràng buộc không âm và tính thành tiền (DonGia * SoLuong).
  [x] Bài 7: Lớp TaiKhoanNganHang (SoTaiKhoan, ChuTaiKhoan, SoDu) hỗ trợ nghiệp vụ nạp tiền, rút tiền, chuyển tiền và không cho số dư âm.
  [x] Bài 8: Lớp NhanVien (MaNV, HoTen, LuongCoBan, HeSoLuong, PhuCap) tính thực lĩnh và in bảng lương.
  [x] Bài 9: Lớp HinhChuNhat (ChieuDai, ChieuRong) kiểm tra cạnh dương, tính chu vi và diện tích.
  [x] Bài 10: Ứng dụng Console quản lý sinh viên hoàn chỉnh với menu thêm, sửa, xóa, tìm kiếm, sắp xếp giảm dần theo điểm và thống kê xếp loại.

3. DỮ LIỆU KIỂM THỬ MẪU (TEST CASES)
------------------------------------------------------------------------
- Bài 1: Sinh viên SV01 - Phan Văn Thắng - 26/03/2006 - Điểm: 8.50.
- Bài 2: Constructor mặc định ("Chưa có", điểm 0) và Constructor có tham số.
- Bài 3: Kiểm thử gán DiemTB = 12.5 -> Bắt ngoại lệ ArgumentOutOfRangeException; gán HoTen = "" -> Bắt ArgumentException.
- Bài 4: SinhVien sinh ngày 20/01/2005 (tuổi 21) xếp loại Xuất sắc; 15/11/2003 xếp loại Yếu.
- Bài 5: Tìm kiếm mã "SV01" -> Trả về thông tin sinh viên Phan Văn Thắng.
- Bài 6: SP01 Laptop Dell (Đơn giá: 15,500,000, SL: 3) -> Thành tiền: 46,500,000 VNĐ.
- Bài 7: TK1 có 5,000,000; nạp 2,000,000 -> 7,000,000; rút 1,500,000 -> 5,500,000; chuyển 3,000,000 sang TK2 -> TK1 còn 2,500,000; TK2 nhận thành 4,000,000.
- Bài 8: NV01 (LCB 5,000,000, Hệ số 2.34, Phụ cấp 1,500,000) -> Thực lĩnh: 13,200,000 VNĐ.
- Bài 9: Hình chữ nhật Dài 12.5, Rộng 6.0 -> Chu vi: 37.00, Diện tích: 75.00.
- Bài 10: Menu quản lý đầy đủ 7 chức năng thêm, sửa, xóa, sắp xếp và thống kê chính xác.
