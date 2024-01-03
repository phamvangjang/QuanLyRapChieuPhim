using MoHinh3LopQuanLyPhim.Model;
using System;
using System.Data;

namespace MoHinh3LopQuanLyPhim
{
    class DAO
    {
        private static DAO instance;
        private object command;
        internal static DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO();
                return instance;
            }
        }
        private DAO() { }
        public DataTable Xem()
        {
            string sql = "SELECT * FROM Phim";
            return DataProvider.Instance.execSql(sql);
        }
        public bool LuuPhim(Phims ph)
        {
            string sql = "INSERT INTO Phim(MaDon, TenPhim, QuocGia, TheLoai, NgayCC, DoTuoi, GheDoi, DacBiet, DinhDang, Doanhthu)" + "VALUES ( @MaDon, @TenPhim, @QuocGia, @TheLoai, @NgayCC, @DoTuoi, @GheDoi, @DacBiet, @DinhDang, @Doanhthu )";
            Object[] prms = new object[] { ph.MaDon, ph.TenPhim, ph.QuocGia, ph.TheLoai, ph.NgayCC, ph.DoTuoi, ph.GheDoi, ph.DacBiet, ph.DinhDang, ph.Doanhthu };
            return DataProvider.Instance.execNonSql(sql, prms) > 0;
        }

        public DataTable LayThongTinPhimTheoMaDon(string maDon)
        {
            // Viết câu truy vấn SQL để lấy thông tin chi tiết của phim từ cơ sở dữ liệu
            string query = $"SELECT * FROM Phim WHERE MaDon = '{maDon}'";

            // Thực hiện truy vấn và trả về đối tượng Phim
            return DataProvider.Instance.execSql(query);
        }

        public bool XoaThongtinTheoMaDon(string maDon)
        {
            try
            {
                string query = $"DELETE FROM Phim WHERE MaDon = '{maDon}'";
                int affectedRows = DataProvider.Instance.execNonSql(query);

                // Kiểm tra số dòng bị ảnh hưởng, nếu lớn hơn 0, xóa thành công
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SuaPhim(Phims phims, string madon)
        {
            string query = "UPDATE Phim SET TenPhim = @TenPhim, QuocGia = @QuocGia, TheLoai = @TheLoai, NgayCC = @NgayCC, DoTuoi = @DoTuoi, GheDoi = @GheDoi, DacBiet = @DacBiet, DinhDang = @DinhDang, Doanhthu = @Doanhthu" +
                " WHERE MaDon = @MaDon";
            object[] prms = new object[] { phims.TenPhim, phims.QuocGia, phims.TheLoai, phims.NgayCC, phims.DoTuoi, phims.GheDoi, phims.DacBiet, phims.DinhDang, phims.Doanhthu, madon };
            return DataProvider.Instance.execNonSql(query, prms)>0;
        }

        public DataTable SapXepPhims()
        {
            string query = $"SELECT * FROM Phim ORDER BY NgayCC ASC, DoTuoi DESC";
            return DataProvider.Instance.execSql(query);
        }
        public DataTable ThongKe()
        {
            string query = $"SELECT DinhDang, " +
                $"COUNT(*) AS TongSoLuong, " +
                $"SUM(CASE WHEN DinhDang = '2D' THEN GheDoi ELSE 0 END) AS TongDoanhThu2D,    " +
                $"SUM(CASE WHEN DinhDang = '3D' THEN DacBiet ELSE 0 END) AS TongDoanhThu3D " +
                $"FROM Phim " +
                $"GROUP BY DinhDang;";
            return DataProvider.Instance.execSql(query);
        }
    }
}
