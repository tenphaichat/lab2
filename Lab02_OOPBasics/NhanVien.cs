using System;

namespace Lab02_OOPBasics
{
    public class NhanVien
    {
        private string _maNV = "";
        private string _hoTen = "";
        private double _luongCoBan;
        private double _heSoLuong;
        private double _phuCap;

        public string MaNV
        {
            get => _maNV;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nhân viên không được rỗng.");
                _maNV = value.Trim().ToUpper();
            }
        }

        public string HoTen
        {
            get => _hoTen;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được rỗng.");
                _hoTen = value.Trim();
            }
        }

        public double LuongCoBan
        {
            get => _luongCoBan;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("LuongCoBan", "Lương cơ bản không được âm.");
                _luongCoBan = value;
            }
        }

        public double HeSoLuong
        {
            get => _heSoLuong;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("HeSoLuong", "Hệ số lương phải lớn hơn 0.");
                _heSoLuong = value;
            }
        }

        public double PhuCap
        {
            get => _phuCap;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("PhuCap", "Phụ cấp không được âm.");
                _phuCap = value;
            }
        }

        public NhanVien()
        {
            MaNV = "NV00";
            HoTen = "Chưa có";
            LuongCoBan = 1800000;
            HeSoLuong = 1.0;
            PhuCap = 0;
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan, double heSoLuong, double phuCap)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
            HeSoLuong = heSoLuong;
            PhuCap = phuCap;
        }

        public double TinhThucLinh()
        {
            return LuongCoBan * HeSoLuong + PhuCap;
        }

        public void InBangLuong()
        {
            Console.WriteLine("{0,-8} | {1,-18} | LCB: {2,10:N0} | Hệ số: {3,4:N2} | Phụ cấp: {4,9:N0} | Thực lĩnh: {5,12:N0} VNĐ",
                MaNV, HoTen, LuongCoBan, HeSoLuong, PhuCap, TinhThucLinh());
        }
    }
}
