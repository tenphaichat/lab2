using System;

namespace Lab02_OOPBasics
{
    public class SinhVien
    {
        private string _maSV = "";
        private string _hoTen = "";
        private DateTime _ngaySinh;
        private double _diemTB;

        public string MaSV
        {
            get { return _maSV; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã sinh viên không được để trống.");
                _maSV = value.Trim().ToUpper();
            }
        }

        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được rỗng.");
                _hoTen = value.Trim();
            }
        }

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }

        public double DiemTB
        {
            get { return _diemTB; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException("DiemTB", "Điểm TB phải thuộc khoảng [0, 10].");
                _diemTB = value;
            }
        }

        // Constructor mặc định (Bài 2)
        public SinhVien()
        {
            _maSV = "Chưa có";
            _hoTen = "Chưa có";
            _ngaySinh = DateTime.Today;
            _diemTB = 0;
        }

        // Constructor đầy đủ tham số (Bài 2, 3)
        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }

        // Phương thức tính tuổi chính xác (Bài 4)
        public int TinhTuoi()
        {
            int tuoi = DateTime.Today.Year - NgaySinh.Year;
            if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }

        // Phương thức xếp loại học lực (Bài 4)
        public string XepLoai()
        {
            if (DiemTB >= 9) return "Xuất sắc";
            if (DiemTB >= 8) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5) return "Trung bình";
            return "Yếu";
        }

        // Phương thức hiển thị (Bài 1, 5)
        public void HienThi()
        {
            Console.WriteLine("{0,-8} | {1,-20} | {2:dd/MM/yyyy} | Tuổi: {3,-2} | ĐTB: {4,4:N2} | Xếp loại: {5}",
                MaSV, HoTen, NgaySinh, TinhTuoi(), DiemTB, XepLoai());
        }
    }
}
