using MoHinh3LopQuanLyPhim.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                item.SubItems.Add(row["PhuThuGheDoi"].ToString());
                item.SubItems.Add(row["PhuThuSuatChieuDacBiet"].ToString());
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
                    }else if (form1.rdbtnHanhDong.Checked)
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
                    giaVe2D.PhuThuGheDoi = double.Parse(form1.txtPhuthughedoi.Text);

                    DAO.Instance.LuuPhim2D(giaVe2D);
                }else if (form1.rdbtn3D.Checked)
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
                    giaVe3D.phuThuDacBiet = double.Parse(form1.txtPhuthudacbiet.Text);

                    DAO.Instance.LuuPhim3D(giaVe3D);
                }
            }
        }

        public Phims LayThongTinPhimTheoMaDon(string maDon)
        {
            Phims phims = new Phims();
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
            }
            return phims;
        }

        public bool XoaThongtinTheoMaDon(string maDon)
        {
            return DAO.Instance.XoaThongtinTheoMaDon(maDon);
        }
    }
}
