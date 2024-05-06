using QuanLyCuaHang.Entities;
using QuanLyCuaHang.XuLyLuuTru;

namespace QuanLyCuaHang.XuLyNghiepVu
{
    public class XL_SanPham
    {
        public static SanPham[] DocDanhSach(string TuKhoa = "")
        {
            SanPham[] danhsach;
            danhsach = LT_SanPham.DocDanhSach();
            //Dem so luong phan tu thoa dieu kien
            int n = 0;
            for (int i = 0; i < danhsach.Length; i++)
            {
                if (danhsach[i].LoaiHang.Contains(TuKhoa) ||
                    danhsach[i].TenSP.Contains(TuKhoa))
                {
                    n++;
                }
            }
            SanPham[] ketqua;
            ketqua = new SanPham[n];
            int j = 0;
            for (int i = 0; i < danhsach.Length; i++)
            {
                if (danhsach[i].LoaiHang.Contains(TuKhoa) ||
                    danhsach[i].TenSP.Contains(TuKhoa))
                {
                    ketqua[j] = danhsach[i];
                    j++;
                }
            }
            return ketqua;
        }
        public static string KiemTraTinhHopLe(SanPham p)
        {
            string chuoi = string.Empty;
            if (p.Gia < 0)
            {
                chuoi = "Gia san pham khong hop le";
            }
            return chuoi;
        }
        public static string ThemSanPham(SanPham p)
        {
            string chuoi = KiemTraTinhHopLe(p);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_SanPham.ThemSanPham(p);
            }
            return chuoi;
        }
        public static SanPham? DocChiTietSanPham(string masp)
        {
            SanPham? kq;
            kq = LT_SanPham.DocChiTietSanPham(masp);
            return kq;
        }
        public static string SuaSanPham(SanPham p)
        {
            string chuoi = KiemTraTinhHopLe(p);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_SanPham.SuaSanPham(p);
            }
            return chuoi;
        }
        public static string XoaSanPham(string masp)
        {
            string chuoi = string.Empty;
            LT_SanPham.XoaSanPham(masp);
            return chuoi;
        }
    }
}
