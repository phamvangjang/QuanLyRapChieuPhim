using MoHinh3LopQuanLyPhim.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MoHinh3LopQuanLyPhim
{
    class Bussiness
    {

        private static Bussiness instance;
        internal static Bussiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bussiness();
                }
                return instance;
            }
        }

        public Bussiness() { }
        Phims phim = new Phims();
        public void Xem(ListView lv)
        {
            foreach (DataRow row in DAO.Instance.Xem().Rows)
            {
                ListViewItem item = new ListViewItem(row["MaDon"].ToString());
                item.SubItems.Add(row["TenPhim"].ToString());
                item.SubItems.Add(row["TheLoai"].ToString());
                item.SubItems.Add(row["NgayCongChieu"].ToString());
                lv.Items.Add(item);
            }
        }
        public void Luu(ListView lv)
        {
            GiaVe2D giaVe2D = new GiaVe2D();
            GiaVe3D giaVe3D = new GiaVe3D();
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1 != null)
            {
                if (form1.rdbtn2d.Checked)
                {
                    string theLoai = "";
                    if (form1.rdbtnTinhCam.Checked)
                    {
                        theLoai = "Tình cảm";
                    }
                    else if (form1.rdbtnHanhDong.Checked)
                    {
                        theLoai = "Hành động";
                    }
                    string ngaycc = form1.dtNgayCongchieu.Value.ToShortDateString();
                    ListViewItem listViewItem = new ListViewItem(form1.txtMaDon.Text);
                    listViewItem.SubItems.Add(form1.txtTenPhim.Text);
                    listViewItem.SubItems.Add(theLoai);
                    listViewItem.SubItems.Add(ngaycc);

                    form1.lvDanhSachphim.Items.Add(listViewItem);

                    giaVe2D.MaDon = form1.txtMaDon.Text;
                    giaVe2D.TenPhim = form1.txtTenPhim.Text;
                    giaVe2D.QuocGia = form1.txtQuocGia.Text;
                    giaVe2D.TheLoai = theLoai;
                    giaVe2D.NgayCongChieu = DateTime.Parse(ngaycc);
                    giaVe2D.DoTuoi = Convert.ToInt32(form1.txtDoTuoi.Text);
                    string dinhdangphim = "2D";
                    giaVe2D.DinhDang = dinhdangphim;
                    giaVe2D.PhuThuGheDoi = double.Parse(form1.txtPhuthughedoi.Text);

                    DAO.Instance.LuuPhim2D(giaVe2D);
                    MessageBox.Show("Đã thêm phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (form1.rdbtn3D.Checked)
                {
                    string theLoai = "";
                    if (form1.rdbtnTinhCam.Checked)
                    {
                        theLoai = "Tình cảm";
                    }
                    else if (form1.rdbtnHanhDong.Checked)
                    {
                        theLoai = "Hành động";
                    }
                    string ngaycc = form1.dtNgayCongchieu.Value.ToShortDateString();
                    ListViewItem listViewItem = new ListViewItem(form1.txtMaDon.Text);
                    listViewItem.SubItems.Add(form1.txtTenPhim.Text);
                    listViewItem.SubItems.Add(theLoai);
                    listViewItem.SubItems.Add(ngaycc);

                    form1.lvDanhSachphim.Items.Add(listViewItem);

                    giaVe3D.MaDon = form1.txtMaDon.Text;
                    giaVe3D.TenPhim = form1.txtTenPhim.Text;
                    giaVe3D.QuocGia = form1.txtQuocGia.Text;
                    giaVe3D.TheLoai = theLoai;
                    giaVe3D.NgayCongChieu = DateTime.Parse(ngaycc);
                    giaVe3D.DoTuoi = Convert.ToInt32(form1.txtDoTuoi.Text);
                    string dinhdangphim = "3D";
                    giaVe3D.DinhDang = dinhdangphim;
                    giaVe3D.phuThuDacBiet = double.Parse(form1.txtPhuthudacbiet.Text);

                    DAO.Instance.LuuPhim3D(giaVe3D);
                    MessageBox.Show("Đã thêm phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public Phims LayThongTinPhimTheoMaDon(string maDon)
        {
            Phims phims = new Phims();
            GiaVe2D giaVe2D = new GiaVe2D();
            GiaVe3D giaVe3D = new GiaVe3D();
            DataTable dataTable = DAO.Instance.LayThongTinPhimTheoMaDon(maDon);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                phims.MaDon = dataRow[0].ToString();
                phims.TenPhim = dataRow[1].ToString();
                phims.QuocGia = dataRow[2].ToString();
                phims.TheLoai = dataRow[3].ToString();
                phims.NgayCongChieu = DateTime.Parse(dataRow[4].ToString());
                phims.DoTuoi = int.Parse(dataRow[5].ToString());
                if (dataRow[6].ToString() != "")
                {
                    phims.phuthughedoi = float.Parse(dataRow[6].ToString());
                    phims.phuthudacbiet = 0;
                }
                else
                {
                    phims.phuthudacbiet = float.Parse(dataRow[7].ToString());
                    phims.phuthughedoi = 0;
                }
                phims.DinhDang = dataRow[8].ToString();
            }
            return phims;
        }

        public bool XoaThongtinTheoMaDon(string maDon)
        {
            return DAO.Instance.XoaThongtinTheoMaDon(maDon);
        }
        public void Sua(ListView listView)
        {
            GiaVe2D giaVe2D = new GiaVe2D();
            GiaVe3D giaVe3D = new GiaVe3D();
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1.lvDanhSachphim.SelectedItems.Count > 0)
            {
                string madon = form1.lvDanhSachphim.SelectedItems[0].Text;
                if (!string.IsNullOrEmpty(madon))
                {
                    string theloai = "";
                    if (form1.rdbtnTinhCam.Checked)
                    {
                        theloai = "Tình cảm";
                    }
                    else if (form1.rdbtnHanhDong.Checked)
                    {
                        theloai = "Hành động";
                    }
                    string ngaycongchieu = form1.dtNgayCongchieu.Value.ToShortDateString();
                    if (form1.rdbtn2d.Checked)
                    {
                        giaVe2D.TenPhim = form1.txtTenPhim.Text;
                        giaVe2D.QuocGia = form1.txtQuocGia.Text;
                        giaVe2D.TheLoai = theloai;
                        giaVe2D.NgayCongChieu = DateTime.Parse(ngaycongchieu);
                        giaVe2D.DoTuoi = Int32.Parse(form1.txtDoTuoi.Text);
                        giaVe2D.PhuThuGheDoi = double.Parse(form1.txtPhuthughedoi.Text);
                        giaVe2D.DinhDang = "2D";
                        DAO.Instance.SuaPhim2D(giaVe2D, madon);
                        MessageBox.Show("Dữ liệu đã được sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (form1.rdbtn3D.Checked)
                    {
                        giaVe3D.TenPhim = form1.txtTenPhim.Text;
                        giaVe3D.QuocGia = form1.txtQuocGia.Text;
                        giaVe3D.TheLoai = theloai;
                        giaVe3D.NgayCongChieu = DateTime.Parse(ngaycongchieu);
                        giaVe2D.DoTuoi = Int32.Parse(form1.txtDoTuoi.Text);
                        giaVe3D.phuThuDacBiet = double.Parse(form1.txtPhuthudacbiet.Text);
                        giaVe3D.DinhDang = "3D";
                        DAO.Instance.SuaPhim3D(giaVe3D, madon);
                        MessageBox.Show("Dữ liệu đã được sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phim nào để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void SapXepPhims(ListView listView)
        {
            foreach (DataRow rows in DAO.Instance.SapXepPhims().Rows)
            {
                ListViewItem item = new ListViewItem(rows["MaDon"].ToString());
                item.SubItems.Add(rows["TenPhim"].ToString());
                item.SubItems.Add(rows["TheLoai"].ToString());
                item.SubItems.Add(rows["NgayCongChieu"].ToString());
                listView.Items.Add(item);
            }
            MessageBox.Show("Đã sắp xếp phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ThongKe()
        {
            DataTable dataTable = DAO.Instance.ThongKe();
            DataRow dataRow1 = dataTable.Rows[0];
            int sl2d = dataRow1.Field<int>("TongSoLuong");
            double dt2d = dataRow1.Field<double>("TongDoanhThu2D");

            DataRow dataRow2 = dataTable.Rows[1];
            int sl3d = dataRow2.Field<int>("TongSoLuong");
            double dt3d = dataRow2.Field<double>("TongDoanhThu3D");
            MessageBox.Show("Số lượng phim 2D: " + sl2d + "\n" +
                            "Doanh thu phim 2D: " + (dt2d + sl2d * 110000) + "\n" +
                            "Số lượng phim 3D: " + sl3d + "\n" +
                            "Doanh thu phim 3D: " + (dt3d + sl3d * 210000),
                            "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
