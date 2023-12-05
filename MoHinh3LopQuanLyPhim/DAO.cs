﻿using MoHinh3LopQuanLyPhim.Model;
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
        public bool LuuPhim2D(GiaVe2D ph)
        {
            string sql = "INSERT INTO Phim(MaDon, TenPhim, QuocGia, TheLoai, NgayCongChieu, DoTuoiQuyDinh, PhuThuGheDoi, DinhDang)" + "VALUES ( @MaDon, @TenPhim, @QuocGia, @TheLoai, @NgayCongChieu, @DoTuoiQuyDinh, @PhuThuGheDoi, @DinhDang )";
            Object[] prms = new object[] { ph.MaDon, ph.TenPhim, ph.QuocGia, ph.TheLoai, ph.NgayCongChieu, ph.DoTuoi, ph.PhuThuGheDoi, ph.DinhDang };
            return DataProvider.Instance.execNonSql(sql, prms) > 0;
        }
        public bool LuuPhim3D(GiaVe3D ph)
        {
            string sql = "INSERT INTO Phim(MaDon, TenPhim, QuocGia, TheLoai, NgayCongChieu, DoTuoiQuyDinh, PhuThuSuatChieuDacBiet, DinhDang)" + "VALUES ( @MaDon, @TenPhim, @QuocGia, @TheLoai, @NgayCongChieu, @DoTuoiQuyDinh, @PhuThuSuatChieuDacBiet, @DinhDang )";
            Object[] prms = new object[] { ph.MaDon, ph.TenPhim, ph.QuocGia, ph.TheLoai, ph.NgayCongChieu, ph.DoTuoi, ph.phuThuDacBiet, ph.DinhDang};
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
        public bool SuaPhim2D(GiaVe2D giaVe2D, string madon)
        {
            string query = "UPDATE Phim SET TenPhim = @TenPhim, QuocGia = @QuocGia, TheLoai = @TheLoai, NgayCongChieu = @NgayCongChieu, DoTuoiQuyDinh = @DoTuoiQuyDinh, PhuThuGheDoi = @PhuThuGheDoi, DinhDang = @DinhDang" +
                " WHERE MaDon = @MaDon";
            object[] prms = new object[] { giaVe2D.TenPhim, giaVe2D.QuocGia, giaVe2D.TheLoai, giaVe2D.NgayCongChieu, giaVe2D.DoTuoi, giaVe2D.PhuThuGheDoi, giaVe2D.DinhDang, madon };
            return DataProvider.Instance.execNonSql(query, prms)>0;
        }

        public bool SuaPhim3D(GiaVe3D giaVe3D, string madon)
        {
            string query = "UPDATE Phim SET TenPhim = @TenPhim, QuocGia = @QuocGia, TheLoai = @TheLoai, NgayCongChieu = @NgayCongChieu, DoTuoiQuyDinh = @DoTuoiQuyDinh, PhuThuSuatChieuDacBiet = @PhuThuSuatChieuDacBiet, DinhDang = @DinhDang" +
                " WHERE MaDon = @MaDon";
            object[] prms = new object[] { giaVe3D.TenPhim, giaVe3D.QuocGia, giaVe3D.TheLoai, giaVe3D.NgayCongChieu, giaVe3D.DoTuoi, giaVe3D.phuThuDacBiet, giaVe3D.DinhDang, madon };
            return DataProvider.Instance.execNonSql(query, prms) > 0;
        }
        public DataTable SapXepPhims()
        {
            string query = $"SELECT * FROM Phim ORDER BY NgayCongChieu ASC, DoTuoiQuyDinh DESC";
            return DataProvider.Instance.execSql(query);
        }
        public DataTable ThongKe()
        {
            string query = $"SELECT DinhDang, " +
                $"COUNT(*) AS TongSoLuong, " +
                $"SUM(CASE WHEN DinhDang = '2D' THEN PhuThuGheDoi ELSE 0 END) AS TongDoanhThu2D,    " +
                $"SUM(CASE WHEN DinhDang = '3D' THEN PhuThuSuatChieuDacBiet ELSE 0 END) AS TongDoanhThu3D " +
                $"FROM Phim " +
                $"GROUP BY DinhDang;";
            return DataProvider.Instance.execSql(query);
        }
    }
}
