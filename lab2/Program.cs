using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab02_OOPBasics
{
    class Program
    {
        // Danh sách sinh viên dùng chung
        static List<SinhVien> danhSachSV = new List<SinhVien>()
        {
            new SinhVien("SV01", "Phan Văn Thắng", new DateTime(2006, 3, 26), 8.5),
            new SinhVien("SV02", "Trần Thị Bình", new DateTime(2004, 9, 3), 6.8),
            new SinhVien("SV03", "Lê Hoàng Cường", new DateTime(2005, 1, 20), 9.2),
            new SinhVien("SV04", "Phạm Minh Đức", new DateTime(2003, 11, 15), 4.5),
            new SinhVien("SV05", "Hoàng Ngọc Ánh", new DateTime(2005, 7, 8), 7.4)
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int chon = -1;
            while (chon != 0)
            {
                Console.WriteLine("\nCHƯƠNG TRÌNH THỰC HÀNH LAB 2");
                Console.WriteLine("1. Nhập thông tin sinh viên và in thông tin (Lớp SinhVien)");
                Console.WriteLine("2. Constructor và nạp chồng constructor");
                Console.WriteLine("3. Đóng gói và kiểm tra tính hợp lệ dữ liệu (Properties)");
                Console.WriteLine("4. Phương thức tính tuổi và xếp loại học tập");
                Console.WriteLine("5. Quản lý danh sách List<SinhVien> và tìm kiếm");
                Console.WriteLine("6. Lớp SanPham (Nhập sản phẩm và tính thành tiền)");
                Console.WriteLine("7. Lớp TaiKhoanNganHang (Nạp, rút, chuyển tiền)");
                Console.WriteLine("8. Lớp NhanVien (Nhập nhân viên và tính lương)");
                Console.WriteLine("9. Lớp HinhChuNhat (Nhập kích thước, tính chu vi và diện tích)");
                Console.WriteLine("10. Ứng dụng quản lý sinh viên Console hoàn chỉnh (CRUD)");
                Console.WriteLine("0. Thoát");
                Console.Write("Mời bạn chọn bài (0-10): ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Vui lòng nhập số từ 0 đến 10!");
                    continue;
                }

                Console.WriteLine();
                switch (chon)
                {
                    case 1:
                        Bai1();
                        break;
                    case 2:
                        Bai2();
                        break;
                    case 3:
                        Bai3();
                        break;
                    case 4:
                        Bai4();
                        break;
                    case 5:
                        Bai5();
                        break;
                    case 6:
                        Bai6();
                        break;
                    case 7:
                        Bai7();
                        break;
                    case 8:
                        Bai8();
                        break;
                    case 9:
                        Bai9();
                        break;
                    case 10:
                        Bai10();
                        break;
                    case 0:
                        Console.WriteLine("Đã thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }

                if (chon != 0)
                {
                    Console.WriteLine("\nẤn Enter để tiếp tục...");
                    Console.ReadLine();
                }
            }
        }

        // Bài 1: Cho người dùng nhập thông tin sinh viên từ bàn phím
        static void Bai1()
        {
            Console.WriteLine("Bài 1: Khai báo lớp SinhVien và in thông tin");
            try
            {
                SinhVien sv = new SinhVien();
                Console.Write("Nhập mã sinh viên (mặc định: SV01): ");
                string? ma = Console.ReadLine();
                sv.MaSV = string.IsNullOrWhiteSpace(ma) ? "SV01" : ma;

                Console.Write("Nhập họ và tên (mặc định: Phan Văn Thắng): ");
                string? ten = Console.ReadLine();
                sv.HoTen = string.IsNullOrWhiteSpace(ten) ? "Phan Văn Thắng" : ten;

                Console.Write("Nhập ngày sinh (dd/MM/yyyy, mặc định: 26/03/2006): ");
                string? nsInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nsInput))
                {
                    sv.NgaySinh = new DateTime(2006, 3, 26);
                }
                else
                {
                    sv.NgaySinh = DateTime.ParseExact(nsInput.Trim(), "dd/MM/yyyy", null);
                }

                Console.Write("Nhập điểm trung bình (0 - 10, mặc định: 8.5): ");
                string? dtbInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(dtbInput))
                {
                    sv.DiemTB = 8.5;
                }
                else
                {
                    sv.DiemTB = double.Parse(dtbInput);
                }

                Console.WriteLine("\nThông tin sinh viên vừa nhập:");
                sv.HienThi();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nhập dữ liệu: " + ex.Message);
            }
        }

        // Bài 2: Constructor và nạp chồng constructor
        static void Bai2()
        {
            Console.WriteLine("Bài 2: Constructor và nạp chồng constructor");
            Console.WriteLine("1. Khởi tạo đối tượng bằng constructor mặc định (không tham số):");
            SinhVien sv1 = new SinhVien();
            sv1.HienThi();

            Console.WriteLine("\n2. Khởi tạo đối tượng bằng constructor có tham số:");
            Console.Write("Nhập mã SV: ");
            string ma = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(ma)) ma = "SV02";

            Console.Write("Nhập họ tên: ");
            string ten = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(ten)) ten = "Trần Thị Bình";

            Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
            string? nsStr = Console.ReadLine();
            DateTime ns = string.IsNullOrWhiteSpace(nsStr) ? new DateTime(2004, 9, 3) : DateTime.ParseExact(nsStr, "dd/MM/yyyy", null);

            Console.Write("Nhập điểm TB: ");
            string? diemStr = Console.ReadLine();
            double diem = string.IsNullOrWhiteSpace(diemStr) ? 7.5 : double.Parse(diemStr);

            SinhVien sv2 = new SinhVien(ma, ten, ns, diem);
            Console.WriteLine("\nKết quả tạo đối tượng với constructor có tham số:");
            sv2.HienThi();
        }

        // Bài 3: Đóng gói và kiểm tra tính hợp lệ dữ liệu
        static void Bai3()
        {
            Console.WriteLine("Bài 3: Đóng gói và kiểm tra dữ liệu");
            SinhVien sv = new SinhVien();

            Console.WriteLine("--- Nhập thử dữ liệu để kiểm tra tính năng đóng gói ---");
            Console.Write("Nhập họ tên (thử để trống hoặc nhập chuỗi rỗng): ");
            string? ten = Console.ReadLine();
            try
            {
                sv.HoTen = ten!;
                Console.WriteLine("Họ tên hợp lệ: " + sv.HoTen);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("-> Bắt ngoại lệ họ tên: " + ex.Message);
            }

            Console.Write("\nNhập Điểm TB (thử nhập số < 0 hoặc > 10, ví dụ: 12.5): ");
            string? diemStr = Console.ReadLine();
            try
            {
                if (double.TryParse(diemStr, out double d))
                {
                    sv.DiemTB = d;
                    Console.WriteLine("Điểm TB hợp lệ: " + sv.DiemTB);
                }
                else
                {
                    Console.WriteLine("Không phải định dạng số thực.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("-> Bắt ngoại lệ điểm: " + ex.Message);
            }
        }

        // Bài 4: Phương thức nghiệp vụ tính tuổi và xếp loại
        static void Bai4()
        {
            Console.WriteLine("Bài 4: Phương thức tính tuổi và xếp loại học tập");
            try
            {
                Console.Write("Nhập họ tên sinh viên: ");
                string ten = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(ten)) ten = "Phan Văn Thắng";

                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                string? nsStr = Console.ReadLine();
                DateTime ns = string.IsNullOrWhiteSpace(nsStr) ? new DateTime(2006, 3, 26) : DateTime.ParseExact(nsStr, "dd/MM/yyyy", null);

                Console.Write("Nhập điểm trung bình (0 - 10): ");
                string? dStr = Console.ReadLine();
                double diem = string.IsNullOrWhiteSpace(dStr) ? 8.5 : double.Parse(dStr);

                SinhVien sv = new SinhVien("SV_TEST", ten, ns, diem);
                Console.WriteLine("\nKết quả xử lý nghiệp vụ:");
                Console.WriteLine("Sinh viên: {0}", sv.HoTen);
                Console.WriteLine("Ngày sinh: {0:dd/MM/yyyy}", sv.NgaySinh);
                Console.WriteLine("Tuổi tính được: {0} tuổi", sv.TinhTuoi());
                Console.WriteLine("Điểm trung bình: {0:N2}", sv.DiemTB);
                Console.WriteLine("Xếp loại học lực: {0}", sv.XepLoai());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        // Bài 5: Quản lý danh sách List<SinhVien> và tìm kiếm
        static void Bai5()
        {
            Console.WriteLine("Bài 5: Quản lý danh sách List<SinhVien> và tìm kiếm");
            Console.WriteLine("Danh sách sinh viên hiện có:");
            foreach (var sv in danhSachSV)
            {
                sv.HienThi();
            }

            Console.Write("\nNhập mã sinh viên bạn muốn tìm (ví dụ: SV01): ");
            string? ma = Console.ReadLine();
            SinhVien? ketQua = danhSachSV.Find(x => x.MaSV.Equals(ma?.Trim(), StringComparison.OrdinalIgnoreCase));

            if (ketQua != null)
            {
                Console.WriteLine("ĐÃ TÌM THẤY:");
                ketQua.HienThi();
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã: " + ma);
            }
        }

        // Bài 6: Lớp SanPham cho phép người dùng tự nhập
        static void Bai6()
        {
            Console.WriteLine("Bài 6: Quản lý đối tượng SanPham");
            try
            {
                SanPham sp = new SanPham();
                Console.Write("Nhập mã sản phẩm: ");
                string? ma = Console.ReadLine();
                sp.MaSP = string.IsNullOrWhiteSpace(ma) ? "SP01" : ma;

                Console.Write("Nhập tên sản phẩm: ");
                string? ten = Console.ReadLine();
                sp.TenSP = string.IsNullOrWhiteSpace(ten) ? "Laptop Asus" : ten;

                Console.Write("Nhập đơn giá (VNĐ): ");
                string? giaStr = Console.ReadLine();
                sp.DonGia = string.IsNullOrWhiteSpace(giaStr) ? 15000000 : double.Parse(giaStr);

                Console.Write("Nhập số lượng: ");
                string? slStr = Console.ReadLine();
                sp.SoLuong = string.IsNullOrWhiteSpace(slStr) ? 2 : int.Parse(slStr);

                Console.WriteLine("\nThông tin sản phẩm và thành tiền:");
                sp.HienThi();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nhập sản phẩm: " + ex.Message);
            }
        }

        // Bài 7: Lớp TaiKhoanNganHang có tương tác nạp, rút, chuyển
        static void Bai7()
        {
            Console.WriteLine("Bài 7: Nghiệp vụ tài khoản ngân hàng");
            TaiKhoanNganHang tk1 = new TaiKhoanNganHang("1022334455", "Phan Văn Thắng", 5000000);
            TaiKhoanNganHang tk2 = new TaiKhoanNganHang("9876543210", "Trần Thị Bình", 1000000);

            Console.WriteLine("Tài khoản của bạn:");
            tk1.HienThi();

            Console.WriteLine("\n--- MENU GIAO DỊCH TÀI KHOẢN ---");
            Console.WriteLine("1. Nạp tiền vào tài khoản");
            Console.WriteLine("2. Rút tiền từ tài khoản");
            Console.WriteLine("3. Chuyển tiền tới tài khoản Trần Thị Bình (9876543210)");
            Console.Write("Chọn giao dịch (1-3, hoặc phím khác để bỏ qua): ");
            string? gd = Console.ReadLine();

            switch (gd)
            {
                case "1":
                    Console.Write("Nhập số tiền muốn nạp: ");
                    if (double.TryParse(Console.ReadLine(), out double tienNap))
                        tk1.NapTien(tienNap);
                    break;
                case "2":
                    Console.Write("Nhập số tiền muốn rút: ");
                    if (double.TryParse(Console.ReadLine(), out double tienRut))
                        tk1.RutTien(tienRut);
                    break;
                case "3":
                    Console.Write("Nhập số tiền muốn chuyển: ");
                    if (double.TryParse(Console.ReadLine(), out double tienChuyen))
                        tk1.ChuyenTien(tk2, tienChuyen);
                    break;
            }

            Console.WriteLine("\nSố dư tài khoản sau thao tác:");
            tk1.HienThi();
        }

        // Bài 8: Lớp NhanVien cho phép tự nhập thông tin
        static void Bai8()
        {
            Console.WriteLine("Bài 8: Quản lý nhân viên và tính lương");
            try
            {
                NhanVien nv = new NhanVien();
                Console.Write("Nhập mã nhân viên: ");
                string? ma = Console.ReadLine();
                nv.MaNV = string.IsNullOrWhiteSpace(ma) ? "NV01" : ma;

                Console.Write("Nhập họ tên nhân viên: ");
                string? ten = Console.ReadLine();
                nv.HoTen = string.IsNullOrWhiteSpace(ten) ? "Hoàng Văn Tuấn" : ten;

                Console.Write("Nhập lương cơ bản (VNĐ): ");
                string? lcbStr = Console.ReadLine();
                nv.LuongCoBan = string.IsNullOrWhiteSpace(lcbStr) ? 5000000 : double.Parse(lcbStr);

                Console.Write("Nhập hệ số lương: ");
                string? hsStr = Console.ReadLine();
                nv.HeSoLuong = string.IsNullOrWhiteSpace(hsStr) ? 2.34 : double.Parse(hsStr);

                Console.Write("Nhập phụ cấp (VNĐ): ");
                string? pcStr = Console.ReadLine();
                nv.PhuCap = string.IsNullOrWhiteSpace(pcStr) ? 1000000 : double.Parse(pcStr);

                Console.WriteLine("\nBảng lương chi tiết:");
                nv.InBangLuong();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nhập nhân viên: " + ex.Message);
            }
        }

        // Bài 9: Lớp HinhChuNhat cho phép người dùng tự nhập chiều dài và chiều rộng
        static void Bai9()
        {
            Console.WriteLine("Bài 9: Tính chu vi và diện tích hình chữ nhật");
            try
            {
                Console.Write("Nhập chiều dài: ");
                double dai = double.Parse(Console.ReadLine()!);

                Console.Write("Nhập chiều rộng: ");
                double rong = double.Parse(Console.ReadLine()!);

                HinhChuNhat hcn = new HinhChuNhat(dai, rong);
                Console.WriteLine("\nKết quả tính toán:");
                hcn.HienThi();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kích thước hình chữ nhật: " + ex.Message);
            }
        }

        // Bài 10: Ứng dụng quản lý sinh viên Console hoàn chỉnh
        static void Bai10()
        {
            int subChon = -1;
            do
            {
                Console.WriteLine("\n--- MENU QUẢN LÝ SINH VIÊN (BÀI 10) ---");
                Console.WriteLine("1. Xem danh sách sinh viên");
                Console.WriteLine("2. Thêm mới sinh viên");
                Console.WriteLine("3. Sửa sinh viên theo mã");
                Console.WriteLine("4. Xóa sinh viên theo mã");
                Console.WriteLine("5. Tìm kiếm sinh viên theo tên hoặc mã");
                Console.WriteLine("6. Sắp xếp sinh viên giảm dần theo Điểm TB");
                Console.WriteLine("7. Thống kê theo xếp loại học lực");
                Console.WriteLine("0. Quay về menu chính");
                Console.Write("Mời bạn chọn chức năng (0-7): ");

                if (!int.TryParse(Console.ReadLine(), out subChon))
                {
                    Console.WriteLine("Vui lòng nhập số từ 0 đến 7.");
                    continue;
                }

                Console.WriteLine();
                switch (subChon)
                {
                    case 1:
                        Console.WriteLine("DANH SÁCH SINH VIÊN HIỆN CÓ ({0} sinh viên):", danhSachSV.Count);
                        foreach (var sv in danhSachSV) sv.HienThi();
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("NHẬP THÔNG TIN SINH VIÊN MỚI:");
                            Console.Write("Mã SV: ");
                            string ma = Console.ReadLine()!;
                            if (danhSachSV.Any(x => x.MaSV.Equals(ma.Trim(), StringComparison.OrdinalIgnoreCase)))
                            {
                                Console.WriteLine("Mã sinh viên đã tồn tại!");
                                break;
                            }
                            Console.Write("Họ và tên: ");
                            string ten = Console.ReadLine()!;
                            Console.Write("Ngày sinh (dd/MM/yyyy): ");
                            DateTime ns = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);
                            Console.Write("Điểm trung bình (0-10): ");
                            double dtb = double.Parse(Console.ReadLine()!);

                            SinhVien svMoi = new SinhVien(ma, ten, ns, dtb);
                            danhSachSV.Add(svMoi);
                            Console.WriteLine("Thêm sinh viên thành công!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Thêm thất bại! Lỗi: " + ex.Message);
                        }
                        break;

                    case 3:
                        Console.Write("Nhập mã sinh viên cần sửa: ");
                        string maSua = Console.ReadLine()!;
                        SinhVien? svSua = danhSachSV.Find(x => x.MaSV.Equals(maSua.Trim(), StringComparison.OrdinalIgnoreCase));
                        if (svSua == null)
                        {
                            Console.WriteLine("Không tìm thấy sinh viên có mã: " + maSua);
                        }
                        else
                        {
                            try
                            {
                                Console.Write("Họ tên mới: ");
                                svSua.HoTen = Console.ReadLine()!;
                                Console.Write("Điểm TB mới: ");
                                svSua.DiemTB = double.Parse(Console.ReadLine()!);
                                Console.WriteLine("Cập nhật thông tin thành công!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Cập nhật lỗi: " + ex.Message);
                            }
                        }
                        break;

                    case 4:
                        Console.Write("Nhập mã sinh viên cần xóa: ");
                        string maXoa = Console.ReadLine()!;
                        SinhVien? svXoa = danhSachSV.Find(x => x.MaSV.Equals(maXoa.Trim(), StringComparison.OrdinalIgnoreCase));
                        if (svXoa != null)
                        {
                            danhSachSV.Remove(svXoa);
                            Console.WriteLine("Đã xóa sinh viên mã " + maXoa);
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy mã sinh viên cần xóa.");
                        }
                        break;

                    case 5:
                        Console.Write("Nhập từ khóa tìm kiếm (Mã hoặc Họ tên): ");
                        string tuKhoa = Console.ReadLine()?.Trim().ToLower() ?? "";
                        var ketQuaTim = danhSachSV.Where(x => x.MaSV.ToLower().Contains(tuKhoa) || x.HoTen.ToLower().Contains(tuKhoa)).ToList();
                        if (ketQuaTim.Count > 0)
                        {
                            Console.WriteLine("Tìm thấy {0} kết quả:", ketQuaTim.Count);
                            foreach (var sv in ketQuaTim) sv.HienThi();
                        }
                        else
                        {
                            Console.WriteLine("Không có kết quả nào phù hợp.");
                        }
                        break;

                    case 6:
                        danhSachSV.Sort((a, b) => b.DiemTB.CompareTo(a.DiemTB));
                        Console.WriteLine("Đã sắp xếp danh sách sinh viên giảm dần theo Điểm TB:");
                        foreach (var sv in danhSachSV) sv.HienThi();
                        break;

                    case 7:
                        Console.WriteLine("THỐNG KÊ THEO XẾP LOẠI HỌC LỰC:");
                        var nhom = danhSachSV.GroupBy(x => x.XepLoai());
                        foreach (var g in nhom)
                        {
                            Console.WriteLine("- Loại {0,-10}: {1} sinh viên", g.Key, g.Count());
                        }
                        break;

                    case 0:
                        Console.WriteLine("Quay về menu chính.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }

            } while (subChon != 0);
        }
    }
}
