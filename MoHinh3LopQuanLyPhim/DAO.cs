﻿using MoHinh3LopQuanLyPhim.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoHinh3LopQuanLyPhim
{
    class DAO
    {
        private static DAO instance;
        private object command;
        internal static DAO Instance
        {
            get { 
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
            string sql = "INSERT INTO Phim(MaDon, TenPhim, QuocGia, TheLoai, NgayCongChieu, DoTuoiQuyDinh, PhuThuGheDoi)" + "VALUES ( @MaDon, @TenPhim, @QuocGia, @TheLoai, @NgayCongChieu, @DoTuoiQuyDinh, @PhuThuGheDoi )";
            Object[] prms = new object[] {ph.MaDon, ph.TenPhim, ph.QuocGia, ph.TheLoai, ph.NgayCongChieu, ph.DoTuoi, ph.PhuThuGheDoi};
            return DataProvider.Instance.execNonSql(sql, prms)>0;
        }
        public bool LuuPhim3D(GiaVe3D ph)
        {
            string sql = "INSERT INTO Phim(MaDon, TenPhim, QuocGia, TheLoai, NgayCongChieu, DoTuoiQuyDinh, PhuThuSuatChieuDacBiet)" + "VALUES ( @MaDon, @TenPhim, @QuocGia, @TheLoai, @NgayCongChieu, @DoTuoiQuyDinh, @PhuThuSuatChieuDacBiet )";
            Object[] prms = new object[] { ph.MaDon, ph.TenPhim, ph.QuocGia, ph.TheLoai, ph.NgayCongChieu, ph.DoTuoi, ph.phuThuDacBiet };
            return DataProvider.Instance.execNonSql(sql, prms) > 0;
        }

        public class PhimDataAccess
        {
            private readonly DatabaseConnection databaseConnection;

            public PhimDataAccess(string connectionString)
            {
                databaseConnection = new DatabaseConnection(connectionString);
            }

            public Phims LayThongTinPhimTheoMaDon(string maDon)
            {
                // Viết câu truy vấn SQL để lấy thông tin chi tiết của phim từ cơ sở dữ liệu
                string query = $"SELECT * FROM Phim WHERE MaDon = '{maDon}'";

                // Thực hiện truy vấn và trả về đối tượng Phim
                // Lưu ý: Cần kiểm tra và xử lý kết quả truy vấn, xử lý exception, ...
                return databaseConnection.ExecuteQuery<Phims>(query);
            }
        }

    }
}
