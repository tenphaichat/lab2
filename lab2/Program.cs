using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab02_OOPBasics
{
    class Program
    {
        // Danh sách sinh viên dùng chung cho các bài tập
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
                Console.WriteLine("1. Khai báo lớp SinhVien và in thông tin");
                Console.WriteLine("2. Constructor và nạp chồng constructor");
                Console.WriteLine("3. Đóng gói và kiểm tra tính hợp lệ dữ liệu");
                Console.WriteLine("4. Phương thức tính tuổi và xếp loại học tập");
                Console.WriteLine("5. Quản lý danh sách List<SinhVien> và tìm kiếm");
                Console.WriteLine("6. Lớp SanPham (Mã, tên, giá, số lượng, thành tiền)");
                Console.WriteLine("7. Lớp TaiKhoanNganHang (Nạp, rút, chuyển tiền)");
                Console.WriteLine("8. Lớp NhanVien (Tính thực lĩnh và in bảng lương)");
                Console.WriteLine("9. Lớp HinhChuNhat (Tính chu vi và diện tích)");
                Console.WriteLine("10. Ứng dụng quản lý sinh viên Console hoàn chỉnh");
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

        // Bài 1: Khai báo lớp SinhVien
        static void Bai1()
        {
            Console.WriteLine("Bài 1: Khai báo lớp SinhVien và in thông tin");
            SinhVien sv = new SinhVien();
            sv.MaSV = "SV01";
            sv.HoTen = "Phan Văn Thắng";
            sv.NgaySinh = new DateTime(2006, 3, 26);
            sv.DiemTB = 8.5;

            Console.WriteLine("Thông tin sinh viên vừa khởi tạo:");
            sv.HienThi();
        }

        // Bài 2: Constructor và nạp chồng
        static void Bai2()
        {
            Console.WriteLine("Bài 2: Constructor và nạp chồng constructor");
            SinhVien sv1 = new SinhVien();
            Console.WriteLine("1. Đối tượng khởi tạo bằng constructor mặc định:");
            sv1.HienThi();

            SinhVien sv2 = new SinhVien("SV02", "Trần Thị Bình", new DateTime(2004, 9, 3), 7.5);
            Console.WriteLine("2. Đối tượng khởi tạo bằng constructor có tham số:");
            sv2.HienThi();
        }

        // Bài 3: Đóng gói và kiểm tra tính hợp lệ dữ liệu
        static void Bai3()
        {
            Console.WriteLine("Bài 3: Đóng gói và kiểm tra dữ liệu");
            SinhVien sv = new SinhVien();
            
            Console.WriteLine("Thử nghiệm 1: Gán Họ tên hợp lệ và Điểm TB = 8.8:");
            sv.HoTen = "Lê Hoàng Cường";
            sv.DiemTB = 8.8;
            Console.WriteLine("Gán thành công -> Họ tên: {0}, Điểm: {1}", sv.HoTen, sv.DiemTB);

            Console.WriteLine("\nThử nghiệm 2: Gán Điểm TB không hợp lệ (12.5):");
            try
            {
                sv.DiemTB = 12.5;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Bắt ngoại lệ thành công: " + ex.Message);
            }

            Console.WriteLine("\nThử nghiệm 3: Gán Họ tên để trống (chuỗi rỗng):");
            try
            {
                sv.HoTen = "   ";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Bắt ngoại lệ thành công: " + ex.Message);
            }
        }

        // Bài 4: Phương thức nghiệp vụ tính tuổi và xếp loại
        static void Bai4()
        {
            Console.WriteLine("Bài 4: Phương thức tính tuổi và xếp loại học tập");
            SinhVien sv1 = new SinhVien("SV03", "Lê Hoàng Cường", new DateTime(2005, 1, 20), 9.2);
            SinhVien sv2 = new SinhVien("SV04", "Phạm Minh Đức", new DateTime(2003, 11, 15), 4.8);

            Console.WriteLine("Sinh viên 1: {0} | Tuổi: {1} | Xếp loại: {2}", sv1.HoTen, sv1.TinhTuoi(), sv1.XepLoai());
            Console.WriteLine("Sinh viên 2: {0} | Tuổi: {1} | Xếp loại: {2}", sv2.HoTen, sv2.TinhTuoi(), sv2.XepLoai());
        }

        // Bài 5: Quản lý danh sách List<SinhVien> và tìm kiếm
        static void Bai5()
        {
            Console.WriteLine("Bài 5: Quản lý danh sách List<SinhVien> và tìm kiếm");
            Console.WriteLine("Danh sách sinh viên mẫu:");
            foreach (var sv in danhSachSV)
            {
                sv.HienThi();
            }

            Console.Write("\nNhập mã sinh viên cần tìm (ví dụ SV01): ");
            string? ma = Console.ReadLine();
            SinhVien? ketQua = danhSachSV.Find(x => x.MaSV.Equals(ma?.Trim(), StringComparison.OrdinalIgnoreCase));

            if (ketQua != null)
            {
                Console.WriteLine("Tìm thấy thông tin sinh viên:");
                ketQua.HienThi();
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã: " + ma);
            }
        }

        // Bài 6: Lớp SanPham
        static void Bai6()
        {
            Console.WriteLine("Bài 6: Quản lý đối tượng SanPham");
            SanPham sp1 = new SanPham("SP01", "Laptop Dell", 15500000, 3);
            SanPham sp2 = new SanPham("SP02", "Chuột Logitech", 350000, 10);
            
            Console.WriteLine("Thông tin sản phẩm và tính thành tiền:");
            sp1.HienThi();
            sp2.HienThi();

            Console.WriteLine("\nKiểm tra ràng buộc đơn giá âm (-50000):");
            try
            {
                SanPham spLoi = new SanPham("SP03", "Bàn phím", -50000, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bắt lỗi thành công: " + ex.Message);
            }
        }

        // Bài 7: Lớp TaiKhoanNganHang
        static void Bai7()
        {
            Console.WriteLine("Bài 7: Nghiệp vụ tài khoản ngân hàng");
            TaiKhoanNganHang tk1 = new TaiKhoanNganHang("1022334455", "Phan Văn Thắng", 5000000);
            TaiKhoanNganHang tk2 = new TaiKhoanNganHang("9876543210", "Trần Thị Bình", 1000000);

            Console.WriteLine("Trạng thái ban đầu:");
            tk1.HienThi();
            tk2.HienThi();

            Console.WriteLine("\n1. Thực hiện nạp thêm 2,000,000 VNĐ vào TK 1:");
            tk1.NapTien(2000000);

            Console.WriteLine("\n2. Thực hiện rút 1,500,000 VNĐ từ TK 1:");
            tk1.RutTien(1500000);

            Console.WriteLine("\n3. Chuyển 3,000,000 VNĐ từ TK 1 sang TK 2:");
            tk1.ChuyenTien(tk2, 3000000);

            Console.WriteLine("\nTrạng thái sau giao dịch:");
            tk1.HienThi();
            tk2.HienThi();
        }

        // Bài 8: Lớp NhanVien
        static void Bai8()
        {
            Console.WriteLine("Bài 8: Quản lý nhân viên và tính lương");
            List<NhanVien> dsNV = new List<NhanVien>()
            {
                new NhanVien("NV01", "Hoàng Văn Tuấn", 5000000, 2.34, 1500000),
                new NhanVien("NV02", "Lê Thanh Hương", 5000000, 3.00, 2000000),
                new NhanVien("NV03", "Đỗ Hải Nam", 4500000, 1.80, 800000)
            };

            Console.WriteLine("Bảng lương nhân viên:");
            foreach (var nv in dsNV)
            {
                nv.InBangLuong();
            }
        }

        // Bài 9: Lớp HinhChuNhat
        static void Bai9()
        {
            Console.WriteLine("Bài 9: Tính chu vi và diện tích hình chữ nhật");
            HinhChuNhat hcn1 = new HinhChuNhat(12.5, 6.0);
            Console.WriteLine("Hình chữ nhật 1 (Dài 12.5, Rộng 6.0):");
            hcn1.HienThi();

            Console.WriteLine("\nKiểm tra gán chiều rộng không hợp lệ (-3):");
            try
            {
                hcn1.ChieuRong = -3;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bắt lỗi thành công: " + ex.Message);
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
