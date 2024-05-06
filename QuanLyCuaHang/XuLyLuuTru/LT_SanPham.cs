using QuanLyCuaHang.Entities;
using QuanLyCuaHang.Pages;

namespace QuanLyCuaHang.XuLyLuuTru
{
    public class LT_SanPham
    {
        public static void LuuDanhSach(SanPham[] danhsach)
        {
            StreamWriter writer = new StreamWriter("H:\\teching\\CuaHangTVK1.txt");
            writer.WriteLine(danhsach.Length);
            for (int i = 0; i < danhsach.Length; i++)
            {
                writer.WriteLine($"{danhsach[i].MaSP},{danhsach[i].TenSP}," +
                    $"{danhsach[i].HanDung},{danhsach[i].CongTy_SX}," +
                    $"{danhsach[i].NgaySX},{danhsach[i].LoaiHang},{danhsach[i].Gia}");
            }
            writer.Close();
        }
        public static SanPham[] DocDanhSach()
        {
            SanPham[] danhsach;
            StreamReader reader = new StreamReader("H:\\teching\\CuaHangTVK1.txt");
            string s = reader.ReadLine();
            int n = int.Parse(s);
            danhsach = new SanPham[n];
            for (int i = 0; i < danhsach.Length; i++)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                danhsach[i] = new SanPham();
                danhsach[i].MaSP = m[0];
                danhsach[i].TenSP = m[1];
                danhsach[i].HanDung = m[2];
                danhsach[i].CongTy_SX = m[3];
                danhsach[i].NgaySX = m[4];
                danhsach[i].LoaiHang = m[5];
                danhsach[i].Gia = int.Parse(m[6]);
            }
            reader.Close();
            return danhsach;
        }
        public static void ThemSanPham(SanPham p)
        {
            SanPham[] danhsach = DocDanhSach();
            SanPham[] danhsachMoi = new SanPham[danhsach.Length + 1];
            for (int i = 0; i < danhsach.Length; i++)
            {
                danhsachMoi[i] = danhsach[i];
            }
            danhsachMoi[danhsachMoi.Length - 1] = p;
            LuuDanhSach(danhsachMoi);
        }
        public static SanPham? DocChiTietSanPham(string masp)
        {
            SanPham[] ds = DocDanhSach();
            foreach (SanPham s in ds)
            {
                if (s.MaSP == masp)
                {
                    return s;
                }
            }
            return null;
        }
        public static void SuaSanPham(SanPham p)
        {
            SanPham[] danhsach = DocDanhSach();
            for (int i = 0; i < danhsach.Length; i++)
            {
                if (danhsach[i].MaSP == p.MaSP)
                    danhsach[i] = p;
            }
            LuuDanhSach(danhsach);
        }
        public static void XoaSanPham(string masp)
        {
            SanPham[] danhsach = DocDanhSach();
            SanPham[] danhsachMoi = new SanPham[danhsach.Length - 1];
            int j = 0;
            for (int i = 0; i < danhsach.Length; i++)
            {
                if (danhsach[i].MaSP != masp)
                {
                    danhsachMoi[j++] = danhsach[i];
                }
            }
            LuuDanhSach(danhsachMoi);
        }
    }
}

