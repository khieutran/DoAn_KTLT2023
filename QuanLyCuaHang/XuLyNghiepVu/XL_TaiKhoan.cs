using QuanLyCuaHang.XuLyLuuTru;
using QuanLyCuaHang.Entities;

namespace QuanLyCuaHang.XuLyNghiepVu
{
    public class XL_TaiKhoan
    {
        public static string KiemTraTinhHopLe(User p)
        {
            string chuoi = string.Empty;
            if (string.IsNullOrEmpty(p.Email))
            {
                chuoi = "Email khong hop le";
            }
            else if (string.IsNullOrEmpty(p.Password) ||
               (p.Password.Length < 6))
            {
                chuoi = "Mat khau khong hop le";
            }
            else
            {
                chuoi = "Dang ki thanh cong! " +
                    "Vui long dang nhap de su dung dich vu";
            }
            return chuoi;
        }
        public static string Register(User p)
        {
            string chuoi = KiemTraTinhHopLe(p);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_TaiKhoan.ThemNguoiDung(p);
            }
            return chuoi;
        }
        public static User? Login(string email, string password)
        {
            User[] danhsach = LT_TaiKhoan.DocDanhSach();
            for (int i = 0; i < danhsach.Length; i++)
            {
                if (danhsach[i].Email == email &&
                    danhsach[i].Password == password)
                {
                    return danhsach[i];
                }
            }
            return null;
        }
    }
}
