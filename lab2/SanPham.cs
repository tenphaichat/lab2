using System;

namespace Lab02_OOPBasics
{
    public class SanPham
    {
        private string _maSP = "";
        private string _tenSP = "";
        private double _donGia;
        private int _soLuong;

        public string MaSP
        {
            get => _maSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã sản phẩm không được để trống.");
                _maSP = value.Trim().ToUpper();
            }
        }

        public string TenSP
        {
            get => _tenSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sản phẩm không được để trống.");
                _tenSP = value.Trim();
            }
        }

        public double DonGia
        {
            get => _donGia;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("DonGia", "Đơn giá không được âm.");
                _donGia = value;
            }
        }

        public int SoLuong
        {
            get => _soLuong;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("SoLuong", "Số lượng không được âm.");
                _soLuong = value;
            }
        }

        public SanPham()
        {
            MaSP = "SP00";
            TenSP = "Mặc định";
            DonGia = 0;
            SoLuong = 0;
        }

        public SanPham(string maSP, string tenSP, double donGia, int soLuong)
        {
            MaSP = maSP;
            TenSP = tenSP;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public double TinhThanhTien()
        {
            return DonGia * SoLuong;
        }

        public void HienThi()
        {
            Console.WriteLine("{0,-8} | {1,-20} | Đơn giá: {2,10:N0} VNĐ | SL: {3,3} | Thành tiền: {4,12:N0} VNĐ",
                MaSP, TenSP, DonGia, SoLuong, TinhThanhTien());
        }
    }
}
