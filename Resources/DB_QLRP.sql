CREATE DATABASE QuanLyDoanhThuPhim;

USE QuanLyDoanhThuPhim;

CREATE TABLE Phim (
    MaDon NVARCHAR(50) PRIMARY KEY,
    TenPhim NVARCHAR(100),
    QuocGia NVARCHAR(50),
    TheLoai NVARCHAR(50),
    NgayCongChieu DATETIME,
    DoTuoiQuyDinh INT,
    PhuThuGheDoi float,
    PhuThuSuatChieuDacBiet float
);
