using QuanLyCuaHang.Entities;
using QuanLyCuaHang.Pages;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyCuaHang.XuLyLuuTru
{
    public class LT_HoaDon
    {
        public static void LuuHoaDon_Ban(HoaDonBH[] HoaDon)
        {
            StreamWriter writer = new StreamWriter("H:\\teching\\HoaDonBH.txt");
            writer.WriteLine(HoaDon.Length);
            for (int i = 0; i < HoaDon.Length; i++)
            {
                writer.WriteLine($"{HoaDon[i].MaHD_BH},{HoaDon[i].NgayTaoHD_Ban}," +
                    $"{HoaDon[i].MatHang},{HoaDon[i].LoaiHang}," +
                    $"{HoaDon[i].SL},{HoaDon[i].Gia}");
            }
            writer.Close();
        }
        public static void LuuHoaDon_Nhap(HoaDonNH[] HoaDon)
        {
            StreamWriter writer = new StreamWriter("H:\\teching\\HoaDonNH.txt");
            writer.WriteLine(HoaDon.Length);
            for (int i = 0; i < HoaDon.Length; i++)
            {
                writer.WriteLine($"{HoaDon[i].MaHD_NH},{HoaDon[i].NgayTaoHD_Nhap}," +
                    $"{HoaDon[i].MatHang},{HoaDon[i].LoaiHang}," +
                    $"{HoaDon[i].SL},{HoaDon[i].Gia}");
            }
            writer.Close();
        }
        public static HoaDonBH[] DocHoaDon_BH()
        {
            HoaDonBH[] hoadonban;
            StreamReader reader = new StreamReader("H:\\teching\\HoaDonBH.txt");
            string s = reader.ReadLine();
            int n = int.Parse(s);
            hoadonban = new HoaDonBH[n];
            for (int i = 0; i < hoadonban.Length; i++)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                hoadonban[i] = new HoaDonBH();
                hoadonban[i].MaHD_BH = m[0];
                hoadonban[i].NgayTaoHD_Ban = m[1];
                hoadonban[i].MatHang = m[2];
                hoadonban[i].LoaiHang = m[3];
                hoadonban[i].SL = int.Parse(m[4]);
                hoadonban[i].Gia = int.Parse(m[5]);
            }
            reader.Close();
            return hoadonban;
        }
        public static HoaDonNH[] DocHoaDon_NH()
        {
            HoaDonNH[] hoadonnhap;
            StreamReader reader = new StreamReader("H:\\teching\\HoaDonNH.txt");
            string s = reader.ReadLine();
            int n = int.Parse(s);
            hoadonnhap = new HoaDonNH[n];
            for (int i = 0; i < hoadonnhap.Length; i++)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                hoadonnhap[i] = new HoaDonNH();
                hoadonnhap[i].MaHD_NH = m[0];
                hoadonnhap[i].NgayTaoHD_Nhap = m[1];
                hoadonnhap[i].MatHang = m[2];
                hoadonnhap[i].LoaiHang = m[3];
                hoadonnhap[i].SL = int.Parse(m[4]);
                hoadonnhap[i].Gia = int.Parse(m[5]);
            }
            reader.Close();
            return hoadonnhap;
        }
        public static void ThemHoaDon_Ban(HoaDonBH HD_Ban)
        {
            HoaDonBH[] hoadonban = DocHoaDon_BH();
            HoaDonBH[] hoadonbanmoi = new HoaDonBH[hoadonban.Length + 1];
            for (int i = 0; i < hoadonban.Length; i++)
            {
                hoadonbanmoi[i] = hoadonban[i];
            }
            hoadonbanmoi[hoadonbanmoi.Length - 1] = HD_Ban;
            LuuHoaDon_Ban(hoadonbanmoi);
        }
        public static void ThemHoaDon_Nhap(HoaDonNH HD_Nhap)
        {
            HoaDonNH[] hoadonnhap = DocHoaDon_NH();
            HoaDonNH[] hoadonnhapmoi = new HoaDonNH[hoadonnhap.Length + 1];
            for (int i = 0; i < hoadonnhap.Length; i++)
            {
                hoadonnhapmoi[i] = hoadonnhap[i];
            }
            hoadonnhapmoi[hoadonnhapmoi.Length - 1] = HD_Nhap;
            LuuHoaDon_Nhap(hoadonnhapmoi);
        }
        public static HoaDonBH? DocChiTiet_HDBan(string MaHD_BH)
        {
            HoaDonBH[] hd = DocHoaDon_BH();
            foreach (HoaDonBH h in hd)
            {
                if (h.MaHD_BH == MaHD_BH)
                {
                    return h;
                }
            }
            return null;
        }
        public static HoaDonNH? DocChiTiet_HDNhap(string MaHD_NH)
        {
            HoaDonNH[] hd = DocHoaDon_NH();
            foreach (HoaDonNH h in hd)
            {
                if (h.MaHD_NH == MaHD_NH)
                {
                    return h;
                }
            }
            return null;
        }
        public static void SuaHD_Ban(HoaDonBH b)
        {
            HoaDonBH[] hoadonban = DocHoaDon_BH();
            for (int i = 0; i < hoadonban.Length; i++)
            {
                if (hoadonban[i].MaHD_BH == b.MaHD_BH)
                    hoadonban[i] = b;
            }
            LuuHoaDon_Ban(hoadonban);
        }
        public static void SuaHD_Nhap(HoaDonNH n)
        {
            HoaDonNH[] hoadon = DocHoaDon_NH();
            for (int i = 0; i < hoadon.Length; i++)
            {
                if (hoadon[i].MaHD_NH == n.MaHD_NH)
                    hoadon[i] = n;
            }
            LuuHoaDon_Nhap(hoadon);
        }

        public static void XoaHD_Ban(string MaHD)
        {
            HoaDonBH[] hoadon = DocHoaDon_BH();
            HoaDonBH[] hoadonMoi = new HoaDonBH[hoadon.Length - 1];
            int j = 0;
            for (int i = 0; i < hoadon.Length; i++)
            {
                if (hoadon[i].MaHD_BH != MaHD)
                {
                    hoadonMoi[j++] = hoadon[i];
                }
            }
            LuuHoaDon_Ban(hoadonMoi);
        }
        public static void XoaHD_Nhap(string MaHD)
        {
            HoaDonNH[] hoadon = DocHoaDon_NH();
            HoaDonNH[] hoadonMoi = new HoaDonNH[hoadon.Length - 1];
            int j = 0;
            for (int i = 0; i < hoadon.Length; i++)
            {
                if (hoadon[i].MaHD_NH != MaHD)
                {
                    hoadonMoi[j++] = hoadon[i];
                }
            }
            LuuHoaDon_Nhap(hoadonMoi);
        }
        public static void TongHopHoaDon(HoaDonBH[] ban, HoaDonNH[] nhap)
        {

        }
    }
}
