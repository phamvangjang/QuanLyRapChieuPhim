using MoHinh3LopQuanLyPhim.Model;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
                item.SubItems.Add(row["NgayCC"].ToString());
                DateTime ngayht = DateTime.Now;
                TimeSpan timeDifference = DateTime.Parse(row["NgayCC"].ToString())-ngayht;
                if (timeDifference.TotalDays <= 7 && timeDifference.TotalDays >=0) // Nếu phim công chiếu trong vòng 7 ngày
                {
                    item.BackColor = Color.LightGoldenrodYellow; // Tô nền vàng cho dòng dữ liệu
                }
                lv.Items.Add(item);

            }
        }
        public void Luu(ListView lv)
        {
            Phims phims = new Phims();
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1 != null)
            {
                //save to listview
                string theLoai = "";
                if (form1.rdbtnTCam.Checked)
                {
                    theLoai = "Tình cảm";
                }
                else if (form1.rdbtnHDong.Checked)
                {
                    theLoai = "Hành động";
                }
                string ngaycc = form1.dtNCC.Value.ToShortDateString();
                ListViewItem listViewItem = new ListViewItem(form1.txtMaDon.Text);
                listViewItem.SubItems.Add(form1.txtTen.Text);
                listViewItem.SubItems.Add(theLoai);
                listViewItem.SubItems.Add(ngaycc);

                //hight light to listview
                DateTime ngayht = DateTime.Now;
                TimeSpan timeDifference = DateTime.Parse(ngaycc) - ngayht;
                if (timeDifference.TotalDays <= 7 && timeDifference.TotalDays >= 0) // Nếu phim công chiếu trong vòng 7 ngày
                {
                    listViewItem.BackColor = Color.LightGoldenrodYellow; // Tô nền vàng cho dòng dữ liệu
                }
                form1.lvDanhSachphim.Items.Add(listViewItem);

                //save info form object
                float dt = 0;
                float ptghedoi = 0;
                float ptdacbiet = 0;
                phims.MaDon = form1.txtMaDon.Text;
                phims.TenPhim = form1.txtTen.Text;
                phims.QuocGia = form1.txtQG.Text;
                phims.TheLoai = theLoai;
                phims.NgayCC = DateTime.Parse(ngaycc);
                phims.DoTuoi = Convert.ToInt32(form1.txtDT.Text);
                if (form1.rdbtn2d.Checked)
                {
                    phims.DinhDang = "2D";
                    ptghedoi = float.Parse(form1.txtGhedoi.Text);
                    dt += (110000 + ptghedoi);
                }
                else if(form1.rdbtn3D.Checked)
                {
                    phims.DinhDang = "3D";
                    ptdacbiet = float.Parse(form1.txtDacbiet.Text);
                    dt += (210000 + ptdacbiet);
                }
                phims.GheDoi = ptghedoi;
                phims.DacBiet = ptdacbiet;
                phims.Doanhthu = dt;
                DAO.Instance.LuuPhim(phims);
                MessageBox.Show("Đã thêm phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                phims.NgayCC = DateTime.Parse(dataRow[4].ToString());
                phims.DoTuoi = int.Parse(dataRow[5].ToString());
                if (dataRow[8].ToString() == "2D")
                {
                    phims.GheDoi = float.Parse(dataRow[6].ToString());
                    phims.DacBiet = 0;
                }
                else
                {
                    phims.DacBiet = float.Parse(dataRow[7].ToString());
                    phims.GheDoi = 0;
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
            Phims phims = new Phims();
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1.lvDanhSachphim.SelectedItems.Count > 0)
            {
                string madon = form1.lvDanhSachphim.SelectedItems[0].Text;
                if (!string.IsNullOrEmpty(madon))
                {
                    string theloai = "";
                    if (form1.rdbtnTCam.Checked)
                    {
                        theloai = "Tình cảm";
                    }
                    else if (form1.rdbtnHDong.Checked)
                    {
                        theloai = "Hành động";
                    }
                    float dt = 0;
                    float ptghedoi = 0;
                    float ptdacbiet = 0;
                    string NgayCC = form1.dtNCC.Value.ToShortDateString();
                    phims.TenPhim = form1.txtTen.Text;
                    phims.QuocGia = form1.txtQG.Text;
                    phims.TheLoai = theloai;
                    phims.NgayCC = DateTime.Parse(NgayCC);
                    phims.DoTuoi = int.Parse(form1.txtDT.Text);
                    if (form1.rdbtn2d.Checked)
                    {                        
                        phims.DinhDang = "2D";
                        ptghedoi = float.Parse(form1.txtGhedoi.Text);
                        dt += (110000 + ptghedoi);
                    }
                    else if (form1.rdbtn3D.Checked)
                    {
                        ptdacbiet = float.Parse(form1.txtDacbiet.Text);
                        phims.DinhDang = "3D";
                        dt += (210000 + ptdacbiet);
                    }
                    phims.GheDoi = ptghedoi;
                    phims.DacBiet=ptdacbiet;
                    phims.Doanhthu = dt;
                    DAO.Instance.SuaPhim(phims, madon);
                    MessageBox.Show("Dữ liệu đã được sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                item.SubItems.Add(rows["NgayCC"].ToString());

                DateTime ngayht = DateTime.Now;
                TimeSpan timeDifference = DateTime.Parse(rows["NgayCC"].ToString()) - ngayht;
                if (timeDifference.TotalDays <= 7 && timeDifference.TotalDays >= 0) // Nếu phim công chiếu trong vòng 7 ngày
                {
                    item.BackColor = Color.LightGoldenrodYellow; // Tô nền vàng cho dòng dữ liệu
                }
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
            MessageBox.Show("Số lượng phim 2D: " + sl2d + "(Phim)\n" +
                            "Doanh thu phim 2D: " + dt2d + "(vnd)\n\n" +
                            "Số lượng phim 3D: " + sl3d + "(phim)\n" +
                            "Doanh thu phim 3D: " + dt3d,
                            "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void XuatExcel()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWB = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet excelWS = excelApp.Worksheets[1];

            Excel.Range excelRange = excelWS.Cells[1, 1];
            excelRange.Font.Size = 16;
            excelRange.Font.Bold = true;
            excelRange.Font.Color = Color.Blue;
            excelRange.Value = "DANH MỤC PHIMS";
            int row = 2;
            foreach (DataRow dataRow in DAO.Instance.Xem().Rows)
            {
                excelWS.Range["A" + row].Font.Bold = true;
                excelWS.Range["A" + row].Value = dataRow["TenPhim"].ToString();
                row++;
                foreach (DataRow ph in DAO.Instance.Xem().Rows)
                {
                    excelWS.Range["A" + row].Value = ph["MaDon"].ToString();
                    excelWS.Range["B" + row].ColumnWidth = 100;
                    excelWS.Range["B" + row].Value = ph["TenPhim"].ToString();
                    excelWS.Range["C" + row].ColumnWidth = 100;
                    excelWS.Range["C" + row].Value = ph["QuocGia"].ToString();
                    excelWS.Range["D" + row].ColumnWidth = 100;
                    excelWS.Range["D" + row].Value = ph["TheLoai"].ToString();
                    excelWS.Range["E" + row].ColumnWidth = 100;
                    excelWS.Range["E" + row].Value = ph["NgayCC"].ToString();
                    excelWS.Range["F" + row].ColumnWidth = 100;
                    excelWS.Range["F" + row].Value = ph["DoTuoiQuyDinh"].ToString();
                    excelWS.Range["G" + row].ColumnWidth = 100;
                    excelWS.Range["G" + row].Value = ph["GheDoi"].ToString();
                    excelWS.Range["H" + row].ColumnWidth = 100;
                    excelWS.Range["H" + row].Value = ph["PhuThuSuatChieuDacBiet"].ToString();
                    excelWS.Range["K" + row].ColumnWidth = 100;
                    excelWS.Range["K" + row].Value = ph["DinhDang"].ToString();
                    row++;
                }
            }
            excelWS.Name = "DanhMucSanPham";
            excelWB.Activate();
            //Lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                excelWB.SaveAs(saveFileDialog.FileName);
            excelApp.Quit();
            MessageBox.Show("Đã xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
