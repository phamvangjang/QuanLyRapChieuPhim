using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyRapChieuPhim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        QuanLyDoanhThuPhimEntities1 _db = new QuanLyDoanhThuPhimEntities1();
        //dong chuong trinh
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn chặn việc đóng ứng dụng nếu người dùng không đồng ý.
            }
        }
        //chay chuong trinh
        private void Form1_Load(object sender, System.EventArgs e)
        {
            Reset();
            ResetListView(_db.Phims.ToList());
        }

        private void rdoTinhCam_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void rdo2D_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdo2D.Checked)
            {
                txtGhedoi.Visible = true;
                txtDacbiet.Visible = false;
                lblGhedoi.Visible = true;
                lblDacbiet.Visible = false;
            }
        }

        private void rdo3D_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdo3D.Checked)
            {
                txtGhedoi.Visible = false;
                txtDacbiet.Visible = true;
                lblDacbiet.Visible = true;
                lblGhedoi.Visible = false;
            }
        }
        
        private void ResetListView(IEnumerable<Phim> phims)
        {
            lvDSP.Items.Clear();
            foreach (var a in phims)
            {
                ListViewItem listViewItem = new ListViewItem(a.MaDon);
                listViewItem.SubItems.Add(a.TenPhim.ToString());
                listViewItem.SubItems.Add(a.TheLoai.ToString());
                listViewItem.SubItems.Add(a.NgayCC.Value.ToString("dd/MM/yyyy"));
                DateTime ngayht = DateTime.Now;
                TimeSpan timeDifference = DateTime.Parse(a.NgayCC.ToString()) - ngayht;
                if (timeDifference.TotalDays <= 7 && timeDifference.TotalDays >= 0) // Nếu phim công chiếu trong vòng 7 ngày
                {
                    listViewItem.BackColor = Color.LightGoldenrodYellow; // Tô nền vàng cho dòng dữ liệu
                }

                lvDSP.Items.Add(listViewItem);
            }
        }
        
        public void Reset()
        {
            foreach (ListViewItem listViewItem in lvDSP.Items)
            {
                listViewItem.Selected = false;   
            }
            // Xóa dữ liệu trong các TextBox nhập liệu
            txtMaDon.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtQG.Text = string.Empty;
            rdoTinhCam.Checked = true;
            dtNgayCC.Value=DateTime.Now;
            txtDT.Text = string.Empty;
            rdo2D.Checked = true;
            txtDacbiet.Text = string.Empty;
            txtGhedoi.Text = string.Empty;

            // Gán giá trị mặc định cho các TextBox nhập liệu
            txtMaDon.Focus();
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Reset();
            txtMaDon.Enabled = true;
            txtMaDon.Focus();
        }

        private new bool Validate()
        {
            if (string.IsNullOrEmpty(txtMaDon.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtQG.Text) || string.IsNullOrEmpty(txtDT.Text) || (string.IsNullOrEmpty(txtGhedoi.Text) && rdo2D.Checked) || (string.IsNullOrEmpty(txtDacbiet.Text) && rdo3D.Checked))
            {
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtNgayCC.Value < DateTime.Now)
            {
                MessageBox.Show("Ngày công chiếu không được nhỏ hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDT.Text.Any(n => !char.IsDigit(n)))
            {
                MessageBox.Show("Độ tuối phải là số dương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtGhedoi.Text.Any(n => !char.IsDigit(n)) && rdo2D.Checked)
            {
                MessageBox.Show("Phụphim phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDacbiet.Text.Any(n => !char.IsDigit(n)) && rdo3D.Checked)
            {
                MessageBox.Show("Phụphim phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            // validate
            if (Validate())
            {
                bool validate = _db.Phims.Any(a => a.MaDon == txtMaDon.Text);
                if (validate)
                {
                    MessageBox.Show("Mã đơn đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    float ptghedoi = 0;
                    float ptdacbiet = 0;
                    float dt = 0;
                    if (rdo2D.Checked)
                    {
                        ptghedoi+=(float.Parse(txtGhedoi.Text));
                        dt += (110000 + ptghedoi);
                    }
                    else
                    {
                        ptdacbiet=float.Parse(txtDacbiet.Text);
                        dt += (210000 + ptdacbiet);
                    }
                    //save to db
                    _db.Phims.Add(new Phim() { MaDon = txtMaDon.Text, TenPhim = txtTen.Text, QuocGia = txtQG.Text, TheLoai = rdoTinhCam.Checked ? "Tình cám" : "Hành động", NgayCC = dtNgayCC.Value, DoTuoi = int.Parse(txtDT.Text), GheDoi = ptghedoi, DacBiet = ptdacbiet, DinhDang = rdo2D.Checked ? "2D" : "3D", Doanhthu = dt });
                    _db.SaveChanges();

                    //show to listview
                    ListViewItem listViewItem = new ListViewItem(txtMaDon.Text);
                    listViewItem.SubItems.Add(txtTen.Text);
                    listViewItem.SubItems.Add(rdoTinhCam.Checked ? "Tình cám" : "Hành động");
                    listViewItem.SubItems.Add(dtNgayCC.Value.ToString("dd/MM/yyyy"));

                    //hight light to listview
                    /*
                    DateTime ngayht = DateTime.Now;
                    TimeSpan timeDifference = DateTime.Parse(dtNgayCC.ToString()) - ngayht;
                    if (timeDifference.TotalDays <= 7 && timeDifference.TotalDays >= 0) // Nếu phim công chiếu trong vòng 7 ngày
                    {
                        listViewItem.BackColor = Color.LightGoldenrodYellow; // Tô nền vàng cho dòng dữ liệu
                    }
                    */
                    lvDSP.Items.Add(listViewItem);
                    MessageBox.Show("Đã thêm thú cưng thành công!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    Reset();
                }
            }
        }
        
        private void lvDSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDSP.SelectedItems.Count > 0)
            {
                //get id in listview
                string madon = lvDSP.SelectedItems[0].SubItems[0].Text;
                txtMaDon.Enabled = false;
                //find in _db if exists ?
                var phim = _db.Phims.SingleOrDefault(z => z.MaDon == madon);
                if (phim!=null)
                {
                    txtMaDon.Text = phim.MaDon.Trim();
                    txtTen.Text = phim.TenPhim.Trim();
                    txtQG.Text = phim.QuocGia.Trim();
                    if(phim.TheLoai== "Tình cám")
                    {
                        rdoTinhCam.Checked = true;
                    }
                    else
                    {
                        rdoHanhDong.Checked = true;
                    }
                    dtNgayCC.Value=phim.NgayCC.Value;
                    txtDT.Text = (phim.DoTuoi.ToString());
                    if (phim.DinhDang == "2D")
                    {
                        rdo2D.Checked = true;
                        txtGhedoi.Text=phim.GheDoi.ToString();
                        txtDacbiet.Clear();
                    }
                    else
                    {
                        rdo3D.Checked = true;
                        txtDacbiet.Text=phim.DacBiet.ToString();
                        txtGhedoi.Clear ();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phim!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDSP.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa phim này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int index = lvDSP.Items.IndexOf(lvDSP.SelectedItems[0]);
                    string mathu = lvDSP.SelectedItems[0].SubItems[0].Text.Trim();

                    Phim ph = _db.Phims.Where(p => p.MaDon.Trim() == mathu).SingleOrDefault();
                    _db.Phims.Remove(ph);
                    _db.SaveChanges();

                    lvDSP.Items.Remove(lvDSP.SelectedItems[0]);

                    if (lvDSP.Items.Count > 0)
                    {
                        if (index < lvDSP.Items.Count)
                        {
                            lvDSP.Items[index].Selected = true;
                        }
                        else
                        {
                            Reset();
                        }
                    }
                    else if (lvDSP.Items.Count == 0)
                    {
                        Reset();
                    }
                }
                MessageBox.Show("Đã xóa phim thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phim nào để xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvDSP.SelectedItems.Count > 0)
            {
                int index = lvDSP.Items.IndexOf(lvDSP.SelectedItems[0]);
                string maphim = lvDSP.SelectedItems[0].SubItems[0].Text.Trim();

                Phim phim = _db.Phims.Where(p => p.MaDon.Trim() == maphim).SingleOrDefault();
                float ptghedoi = 0;
                float ptdacbiet = 0;
                float dt = 0;
                if (rdo2D.Checked)
                {
                    ptghedoi = float.Parse(txtGhedoi.Text);
                    dt += (110000 + ptghedoi);
                }
                else
                {
                    ptdacbiet = float.Parse(txtDacbiet.Text);
                    dt += (210000 + ptdacbiet);
                }

                if (Validate())
                {
                   phim.TenPhim = txtTen.Text;
                   phim.QuocGia = txtQG.Text;
                   phim.TheLoai = rdoTinhCam.Checked ? "Tình cám" : "Hành động";
                   phim.NgayCC = dtNgayCC.Value;
                   phim.DoTuoi = int.Parse(txtDT.Text);
                   phim.GheDoi = ptghedoi;
                   phim.DacBiet=ptdacbiet;
                   phim.DinhDang = rdo2D.Checked ? "2D" : "3D";
                   phim.Doanhthu = dt;
                    _db.SaveChanges();
                    txtMaDon.Enabled = true;
                    ResetListView(_db.Phims.ToList());
                    Reset();
                    MessageBox.Show("Đã sửa phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phim nào để sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            try
            {
                var sort = _db.Phims.OrderBy(p => p.NgayCC).OrderByDescending(p => p.DoTuoi).ToList();
                ResetListView(sort);
                MessageBox.Show("Đã sắp xếp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                var s = from ph in _db.Phims
                        group ph by ph.DinhDang into g
                        select new
                        {
                            dinhdang = g.Key,
                            Sophim = g.Count(),
                            dthu = g.Sum(p => p.Doanhthu)
                        };

                string message = "Thống kê theo loại phim\n\n";

                foreach (var t in s)
                {
                    if (t.dinhdang == "2D")
                        message += $"Phim 2D:\n";
                    else
                        message += $"Phim 3D:\n";
                    message += $"Số lượng: {t.Sophim}\n";
                    message += $"Tổng doanh thu: {t.dthu:#,#}\n\n";
                }

                MessageBox.Show(message, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatBC_Click(object sender, EventArgs e)
        {
            //Chuẩn bị nguồn dữ liệu
            var data = _db.Phims.Select(p => new { maDon = p.MaDon, QuocGia = p.QuocGia, TenPhim = p.TenPhim, TheLoai = p.TheLoai }).ToList();
            //Gán nguồn dữ liệu cho CrystalReport
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(data);
            //Hiển thị báo cáo 
            Form2 fRpt = new Form2();
            fRpt.crystalReportViewer1.ReportSource = rpt;
            fRpt.ShowDialog();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWB = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet excelWS = excelApp.Worksheets[1];

            Excel.Range excelRange = excelWS.Cells[1, 1];
            excelRange.Font.Size = 16;
            excelRange.Font.Bold = true;
            excelRange.Font.Color = Color.Blue;
            excelRange.Value = "DANH MỤC SẢN PHẨM";

            //LẤY SP THEO DANH MỤC
            var catalogs = _db.Phims.Select(c => new { MaDon = c.MaDon, TenPhim = c.TenPhim }).ToList();
            int row = 2;
            foreach (var c in catalogs)
            {
                excelWS.Range["A" + row].Font.Bold = true;
                excelWS.Range["A" + row].Value = c.TenPhim;
                row++;
                //Lấy sản phẩm theo danh mục 
                var products = from p in _db.Phims where p.MaDon == c.MaDon select p;
                foreach (var p in products)
                {
                    excelWS.Range["A" + row].Value = p.MaDon;
                    excelWS.Range["B" + row].ColumnWidth = 50;
                    excelWS.Range["B" + row].Value = p.TenPhim;
                    excelWS.Range["C" + row].Value = p.QuocGia;
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
        }
    }
}
