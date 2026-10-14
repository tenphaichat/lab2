using System;

namespace Lab02_OOPBasics
{
    public class TaiKhoanNganHang
    {
        private string _soTaiKhoan = "";
        private string _chuTaiKhoan = "";
        private double _soDu;

        public string SoTaiKhoan
        {
            get => _soTaiKhoan;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Số tài khoản không được để trống.");
                _soTaiKhoan = value.Trim();
            }
        }

        public string ChuTaiKhoan
        {
            get => _chuTaiKhoan;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Chủ tài khoản không được để trống.");
                _chuTaiKhoan = value.Trim();
            }
        }

        public double SoDu
        {
            get => _soDu;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("SoDu", "Số dư không được nhỏ hơn 0.");
                _soDu = value;
            }
        }

        public TaiKhoanNganHang(string soTaiKhoan, string chuTaiKhoan, double soDuBanDau = 0)
        {
            SoTaiKhoan = soTaiKhoan;
            ChuTaiKhoan = chuTaiKhoan;
            if (soDuBanDau < 0)
                throw new ArgumentException("Số dư khởi tạo không được âm.");
            _soDu = soDuBanDau;
        }

        // Nạp tiền
        public bool NapTien(double soTien)
        {
            if (soTien <= 0)
            {
                Console.WriteLine("Số tiền nạp phải lớn hơn 0.");
                return false;
            }
            _soDu += soTien;
            Console.WriteLine("Nạp thành công {0:N0} VNĐ vào TK {1}. Số dư hiện tại: {2:N0} VNĐ", soTien, SoTaiKhoan, _soDu);
            return true;
        }

        // Rút tiền
        public bool RutTien(double soTien)
        {
            if (soTien <= 0)
            {
                Console.WriteLine("Số tiền rút phải lớn hơn 0.");
                return false;
            }
            if (soTien > _soDu)
            {
                Console.WriteLine("Rút tiền thất bại! Số dư không đủ (Hiện có: {0:N0} VNĐ).", _soDu);
                return false;
            }
            _soDu -= soTien;
            Console.WriteLine("Rút thành công {0:N0} VNĐ từ TK {1}. Số dư còn lại: {2:N0} VNĐ", soTien, SoTaiKhoan, _soDu);
            return true;
        }

        // Chuyển tiền
        public bool ChuyenTien(TaiKhoanNganHang taiKhoanNhan, double soTien)
        {
            if (taiKhoanNhan == null)
            {
                Console.WriteLine("Tài khoản thụ hưởng không tồn tại.");
                return false;
            }
            if (soTien <= 0)
            {
                Console.WriteLine("Số tiền chuyển phải lớn hơn 0.");
                return false;
            }
            if (soTien > _soDu)
            {
                Console.WriteLine("Chuyển tiền thất bại! Số dư không đủ.");
                return false;
            }

            _soDu -= soTien;
            taiKhoanNhan._soDu += soTien;
            Console.WriteLine("Chuyển {0:N0} VNĐ từ {1} tới {2} ({3}) thành công!",
                soTien, ChuTaiKhoan, taiKhoanNhan.ChuTaiKhoan, taiKhoanNhan.SoTaiKhoan);
            return true;
        }

        public void HienThi()
        {
            Console.WriteLine("TK: {0,-12} | Chủ TK: {1,-20} | Số dư: {2,12:N0} VNĐ", SoTaiKhoan, ChuTaiKhoan, SoDu);
        }
    }
}
