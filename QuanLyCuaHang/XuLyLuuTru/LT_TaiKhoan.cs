using QuanLyCuaHang.Entities;
using QuanLyCuaHang.Pages;

namespace QuanLyCuaHang.XuLyLuuTru
{
    public class LT_TaiKhoan
    {
        public static void LuuDanhSach(User[] danhsach)
        {
            StreamWriter writer = new StreamWriter("H:\\teching\\User1.txt");
            writer.WriteLine(danhsach.Length);
            for (int i = 0; i < danhsach.Length; i++)
            {
                writer.WriteLine($"{danhsach[i].Fullname},{danhsach[i].Email},{danhsach[i].Password}");
            }
            writer.Close();
        }
        public static User[] DocDanhSach()
        {
            User[] danhsach;
            StreamReader reader = new StreamReader("H:\\teching\\User1.txt");
            string s = reader.ReadLine();
            int n = int.Parse(s);
            danhsach = new User[n];
            for (int i = 0; i < danhsach.Length; i++)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                danhsach[i] = new User();
                danhsach[i].Fullname = m[0];
                danhsach[i].Email = m[1];
                danhsach[i].Password = m[2];
            }
            reader.Close();
            return danhsach;
        }
        public static void ThemNguoiDung(User p)
        {
            User[] danhsach = DocDanhSach();
            User[] danhsachMoi = new User[danhsach.Length + 1];
            for (int i = 0; i < danhsach.Length; i++)
            {
                danhsachMoi[i] = danhsach[i];
            }
            danhsachMoi[danhsachMoi.Length - 1] = p;
            LuuDanhSach(danhsachMoi);
        }
    }
}
