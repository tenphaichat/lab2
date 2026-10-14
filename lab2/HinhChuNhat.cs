using System;

namespace Lab02_OOPBasics
{
    public class HinhChuNhat
    {
        private double _chieuDai;
        private double _chieuRong;

        public double ChieuDai
        {
            get => _chieuDai;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ChieuDai", "Chiều dài phải lớn hơn 0.");
                _chieuDai = value;
            }
        }

        public double ChieuRong
        {
            get => _chieuRong;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ChieuRong", "Chiều rộng phải lớn hơn 0.");
                _chieuRong = value;
            }
        }

        public HinhChuNhat()
        {
            _chieuDai = 1;
            _chieuRong = 1;
        }

        public HinhChuNhat(double chieuDai, double chieuRong)
        {
            ChieuDai = chieuDai;
            ChieuRong = chieuRong;
        }

        public double TinhChuVi()
        {
            return (ChieuDai + ChieuRong) * 2;
        }

        public double TinhDienTich()
        {
            return ChieuDai * ChieuRong;
        }

        public void HienThi()
        {
            Console.WriteLine("Dài: {0:N2} | Rộng: {1:N2} | Chu vi: {2:N2} | Diện tích: {3:N2}",
                ChieuDai, ChieuRong, TinhChuVi(), TinhDienTich());
        }
    }
}
