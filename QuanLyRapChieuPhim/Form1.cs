using System;
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
        QuanLyDoanhThuPhimEntities db;
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
            rdoTinhCam.Checked = true;
            rdo2D.Checked = true;
            db = new QuanLyDoanhThuPhimEntities();
            //load list view
            db.Phims.ToList().ForEach(p =>
            {
                ListViewItem listViewItem = new ListViewItem(p.MaDon);
                listViewItem.SubItems.Add(p.TenPhim);
                listViewItem.SubItems.Add(p.QuocGia);
                listViewItem.SubItems.Add(p.TheLoai);
                //listViewItem.SubItems.Add(p.NgayCongChieu?.ToString("dd/MM/yyyy"));
                listViewItem.SubItems.Add(p.NgayCongChieu?.ToString("MM/dd/yyyy"));
                listViewItem.SubItems.Add(p.DoTuoiQuyDinh.ToString());
                listViewItem.SubItems.Add(p.PhuThuGheDoi.ToString());
                listViewItem.SubItems.Add(p.PhuThuSuatChieuDacBiet.ToString());

                lvDSP.Items.Add(listViewItem);
            });
            HighlightRecentMovies();
        }

        private void rdoTinhCam_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void rdo2D_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdo2D.Checked)
            {
                txtPhuthughedoi.Visible = true;
                txtPhuThudacbiet.Visible = false;
                lblPhuthughedoi.Visible = true;
                lblPhuthudacbiet.Visible = false;
            }
        }

        private void rdo3D_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdo3D.Checked)
            {
                txtPhuthughedoi.Visible = false;
                txtPhuThudacbiet.Visible = true;
                lblPhuthudacbiet.Visible = true;
                lblPhuthughedoi.Visible = false;
            }
        }
        //Nut them
        public void Reset()
        {
            // Xóa dữ liệu trong các TextBox nhập liệu
            txtMaDon.Text = string.Empty;
            txtTenPhim.Text = string.Empty;
            txtQuocGia.Text = string.Empty;
            txtDotuoi.Text = string.Empty;
            rdo2D.Checked = true;
            rdoTinhCam.Checked = true;
            txtPhuThudacbiet.Text = string.Empty;
            txtPhuthughedoi.Text = string.Empty;

            // Gán giá trị mặc định cho các TextBox nhập liệu
            txtMaDon.Focus();
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Reset();
            SetEditMode();
        }

        //nut luu
        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            // validate
            // Kiểm tra thông tin có hợp lệ
            if (string.IsNullOrEmpty(txtMaDon.Text))
            {
                MessageBox.Show("Mã phim không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTenPhim.Text))
            {
                MessageBox.Show("Tên phim không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtQuocGia.Text))
            {
                MessageBox.Show("Quốc gia không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime ngayCongChieu;
            if (!DateTime.TryParse(dtNgayCongChieu.Text, out ngayCongChieu))
            {
                MessageBox.Show("Ngày công chiếu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*
            if (ngayCongChieu > DateTime.Now)
            {
                MessageBox.Show("Ngày công chiếu không được lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */
            if (string.IsNullOrEmpty(txtDotuoi.Text))
            {
                MessageBox.Show("Độ tuổi không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //luu vao db
            var p = new Phim
            {
                MaDon = txtMaDon.Text,
                TenPhim = txtTen.Text,
                QuocGia = txtQuocGia.Text,
                TheLoai = rdoTinhCam.Checked ? "Tình cảm" : "Hành động",
                NgayCongChieu = dtNgayCongChieu.Value
            };

            // Kiểm tra và chuyển đổi DoTuoiQuyDinh thành kiểu int
            if (int.TryParse(txtDotuoi.Text, out int doTuoi))
            {
                p.DoTuoiQuyDinh = doTuoi;
            }
            /*
            else
            {
                // Xử lý lỗi chuyển đổi dữ liệu cho DoTuoiQuyDinh
                MessageBox.Show("Lỗi chuyển đổi dữ liệu từ TextBox sang int (DoTuoiQuyDinh).!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            // Kiểm tra và chuyển đổi PhuThuGheDoi thành kiểu float
            if (float.TryParse(txtPhuthughedoi.Text, out float phuThuGheDoi))
            {
                p.PhuThuGheDoi = phuThuGheDoi;
            }
            /*
            else
            {
                // Xử lý lỗi chuyển đổi dữ liệu cho PhuThuGheDoi
                MessageBox.Show("Lỗi chuyển đổi dữ liệu từ TextBox sang float (PhuThuGheDoi)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            // Kiểm tra và chuyển đổi PhuThuSuatChieuDacBiet thành kiểu float
            if (float.TryParse(txtPhuThudacbiet.Text, out float phuThuSuatChieuDacBiet))
            {
                p.PhuThuSuatChieuDacBiet = phuThuSuatChieuDacBiet;
            }
            /*
            else
            {
                // Xử lý lỗi chuyển đổi dữ liệu cho PhuThuSuatChieuDacBiet
                MessageBox.Show("Lỗi chuyển đổi dữ liệu từ TextBox sang float (PhuThuSuatChieuDacBiet)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            // Thêm đối tượng vào DbContext và lưu thay đổi
            MessageBox.Show("Dữ liệu đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reset();
            db.Phims.Add(p);
            db.SaveChanges();


            //show infomation in listview
            db = new QuanLyDoanhThuPhimEntities();
            //load list view again
            lvDSP.Items.Clear();
            db.Phims.ToList().ForEach(ph =>
            {
                ListViewItem listViewItem = new ListViewItem(ph.MaDon);
                listViewItem.SubItems.Add(ph.TenPhim);
                listViewItem.SubItems.Add(ph.QuocGia);
                listViewItem.SubItems.Add(ph.TheLoai);
                listViewItem.SubItems.Add(ph.NgayCongChieu?.ToString("MM/dd/yyyy"));
                listViewItem.SubItems.Add(ph.DoTuoiQuyDinh.ToString());
                listViewItem.SubItems.Add(ph.PhuThuGheDoi.ToString());
                listViewItem.SubItems.Add(ph.PhuThuSuatChieuDacBiet.ToString());

                lvDSP.Items.Add(listViewItem);
            });
            // Chọn dòng dữ liệu mới được thêm vào
            int index = lvDSP.Items.Count - 1; // Index của dòng cuối cùng (dòng mới nhất)
            if (index >= 0)
            {
                lvDSP.Items[index].Selected = true;
                lvDSP.Select(); // Đảm bảo rằng ListView đang được chọn
            }
            HighlightRecentMovies();
        }
        //to nen vang phim duoc chieu trong tuan gan nhat
        private void HighlightRecentMovies()
        {
            DateTime currentDate = DateTime.Now;

            foreach (ListViewItem item in lvDSP.Items)
            {
                /*
                DateTime ngayCongChieu = DateTime.Parse(item.SubItems[4].Text); // Giả sử ngày công chiếu là cột thứ 5 trong ListView
                TimeSpan timeDifference = currentDate - ngayCongChieu;

                if (timeDifference.TotalDays <= 7) // Nếu phim công chiếu trong vòng 7 ngày
                {
                    item.BackColor = Color.Yellow; // Tô nền vàng cho dòng dữ liệu
                }
                else
                {
                    item.BackColor = Color.White; // Đặt lại nền mặc định nếu không phải phim công chiếu trong vòng 7 ngày
                }
                */
                string ngayCongChieuString = item.SubItems[4].Text; // Giả sử ngày công chiếu là cột thứ 5 trong ListView

                // Kiểm tra định dạng của chuỗi ngày công chiếu
                if (DateTime.TryParse(ngayCongChieuString, out DateTime ngayCongChieu))
                {
                    TimeSpan timeDifference = currentDate - ngayCongChieu;

                    if (timeDifference.TotalDays <= 7) // Nếu phim công chiếu trong vòng 7 ngày
                    {
                        item.BackColor = Color.Yellow; // Tô nền vàng cho dòng dữ liệu
                    }
                    else
                    {
                        item.BackColor = Color.White; // Đặt lại nền mặc định nếu không phải phim công chiếu trong vòng 7 ngày
                    }
                }
                else
                {
                    // Xử lý lỗi định dạng ngày không hợp lệ
                    MessageBox.Show($"Lỗi định dạng ngày không hợp lệ: {ngayCongChieuString}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void SetReadOnlyMode()
        {
            txtMaDon.ReadOnly = true;
            txtTenPhim.ReadOnly = true;
            txtQuocGia.ReadOnly = true;
            rdoTinhCam.Enabled = false;
            rdoHanhDong.Enabled = false;
            dtNgayCongChieu.Enabled = false;
            txtDotuoi.ReadOnly = true;
            rdo2D.Enabled = false;
            rdo3D.Enabled = false;
            txtPhuthughedoi.ReadOnly = true;
            txtPhuThudacbiet.ReadOnly = true;
        }
        private void SetEditMode()
        {
            txtMaDon.ReadOnly = false;
            txtTen.ReadOnly = false;
            txtQuocGia.ReadOnly = false;
            rdoTinhCam.Enabled = true;
            rdoHanhDong.Enabled = true;
            dtNgayCongChieu.Enabled = true;
            txtDotuoi.ReadOnly = false;
            rdo2D.Enabled = true;
            rdo3D.Enabled = true;
            txtPhuthughedoi.ReadOnly = false;
            txtPhuThudacbiet.ReadOnly = false;
            txtMaDon.Focus();
        }
        //6. listview danh sach phim
        private void lvDSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDSP.SelectedItems.Count > 0)
            {
                // Lấy dòng được chọn
                ListViewItem selectedRow = lvDSP.SelectedItems[0];

                // Hiển thị dữ liệu từ dòng được chọn vào các điều khiển
                txtMaDon.Text = selectedRow.SubItems[0].Text;
                txtTen.Text = selectedRow.SubItems[1].Text;
                txtQuocGia.Text = selectedRow.SubItems[2].Text;

                // Cột thứ 3 là thể loại (sử dụng RadioButton)
                /*
                rdoTinhCam.Checked = selectedRow.SubItems[3].Text.Equals("Tình cảm", StringComparison.OrdinalIgnoreCase);
                rdoHanhDong.Checked = selectedRow.SubItems[3].Text.Equals("Hành động", StringComparison.OrdinalIgnoreCase);
                */
                // Cột thứ 3 là thể loại (sử dụng RadioButton)
                string theLoai = selectedRow.SubItems[3].Text;
                if (theLoai.Equals("Tình cảm", StringComparison.OrdinalIgnoreCase))
                {
                    rdoTinhCam.Checked = true;
                    rdoHanhDong.Checked = false;
                }
                else if (theLoai.Equals("Hành động", StringComparison.OrdinalIgnoreCase))
                {
                    rdoTinhCam.Checked = false;
                    rdoHanhDong.Checked = true;
                }

                // Cột thứ 4 là ngày công chiếu (kiểu DateTime)
                string ngayCongChieuString = selectedRow.SubItems[4].Text;
                if (DateTime.TryParse(ngayCongChieuString, out DateTime ngayCongChieu))
                {
                    dtNgayCongChieu.Value = ngayCongChieu;
                }
                else
                {
                    MessageBox.Show($"Lỗi định dạng ngày không hợp lệ: {ngayCongChieuString}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cột thứ 5 là độ tuổi (kiểu số nguyên)
                txtDotuoi.Text = selectedRow.SubItems[5].Text;


                /*
                // Cột thứ 6 là phụ thu ghế đôi (RadioButton 2D)
                rdo2D.Checked = selectedRow.SubItems[6].Text.Equals("1", StringComparison.OrdinalIgnoreCase);

                // Cột thứ 7 là phụ thu suất chiếu đặc biệt (RadioButton 3D)
                rdo3D.Checked = selectedRow.SubItems[7].Text.Equals("1", StringComparison.OrdinalIgnoreCase);
                */
                // Cột thứ 6 là phụ thu ghế đôi
                bool hasPhuThuGheDoi = !string.IsNullOrEmpty(selectedRow.SubItems[6].Text);

                // Cột thứ 7 là phụ thu suất chiếu đặc biệt
                bool hasPhuThuChieuDacBiet = !string.IsNullOrEmpty(selectedRow.SubItems[7].Text);

                // Thiết lập giá trị cho RadioButton và hiển thị/ẩn TextBox tương ứng
                if (hasPhuThuGheDoi)
                {
                    rdo2D.Checked = true;
                    rdo3D.Checked = false;

                    txtPhuthughedoi.Visible = true;
                    txtPhuThudacbiet.Visible = false;

                    // Hiển thị giá trị từ cột thứ 6 trong TextBox
                    txtPhuthughedoi.Text = selectedRow.SubItems[6].Text;
                }
                else if (hasPhuThuChieuDacBiet)
                {
                    rdo2D.Checked = false;
                    rdo3D.Checked = true;

                    txtPhuthughedoi.Visible = false;
                    txtPhuThudacbiet.Visible = true;

                    // Hiển thị giá trị từ cột thứ 7 trong TextBox
                    txtPhuThudacbiet.Text = selectedRow.SubItems[7].Text;
                }
                //SetReadOnlyMode();
                txtMaDon.ReadOnly = true;
            }

        }
        //7. nut xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDSP.SelectedItems.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phim này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Lấy dòng được chọn
                    ListViewItem selectedRow = lvDSP.SelectedItems[0];

                    // Lấy index của dòng để xóa
                    int indexToRemove = selectedRow.Index;

                    // Xóa dòng khỏi ListView
                    lvDSP.Items.Remove(selectedRow);


                    // Chọn dòng liền kề sau nếu có
                    if (indexToRemove < lvDSP.Items.Count)
                    {
                        lvDSP.Items[indexToRemove].Selected = true;
                        lvDSP.Select();
                    }
                    else if (indexToRemove > 0)
                    {
                        // Nếu không có dòng liền kề sau, chọn dòng liền kề trước
                        lvDSP.Items[indexToRemove - 1].Selected = true;
                        lvDSP.Select();
                    }
                    else
                    {
                        // Nếu không còn dòng nào trong ListView, xóa thông tin ở bảng điều khiển và đưa trỏ chuột lên txtMaDon
                        Reset();
                        txtMaDon.Focus();
                    }
                    // Lấy thông tin của phim từ dòng được chọn
                    string maDon = lvDSP.SelectedItems[0].SubItems[0].Text;

                    // Thực hiện xóa từ cơ sở dữ liệu (thực hiện tương ứng với cơ sở dữ liệu của bạn)
                    var phimToRemove = db.Phims.FirstOrDefault(p => p.MaDon == maDon);
                    if (phimToRemove != null) { db.Phims.Remove(phimToRemove); db.SaveChanges(); }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phim nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //8. nut sua x
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvDSP.SelectedItems.Count > 0)
            {
                txtMaDon.ReadOnly = true;
                txtTen.Focus();

                // Lấy dòng được chọn
                ListViewItem selectedRow = lvDSP.SelectedItems[0];

                // Lấy thông tin mới từ các trình điều khiển nhập liệu
                selectedRow.SubItems[0].Text = txtMaDon.Text;
                selectedRow.SubItems[1].Text = txtTen.Text;
                selectedRow.SubItems[2].Text = txtQuocGia.Text;

                // Lấy thể loại mới và cập nhật RadioButton tương ứng
                string theLoai = rdoTinhCam.Checked ? "Tình cảm" : "Hành động";
                selectedRow.SubItems[3].Text = theLoai;

                // Lấy ngày công chiếu mới
                selectedRow.SubItems[4].Text = dtNgayCongChieu.Value.ToString("dd/MM/yyyy");

                // Lấy độ tuổi quy định mới
                selectedRow.SubItems[5].Text = txtDotuoi.Text;

                // Lấy loại phim mới và cập nhật RadioButton tương ứng
                string loaiPhim = rdo2D.Checked ? "2D" : "3D";
                //selectedRow.SubItems[8].Text = loaiPhim;

                // Lấy phụ thu ghế đôi mới
                selectedRow.SubItems[6].Text = txtPhuthughedoi.Text;

                // Lấy phụ thu suất chiếu đặc biệt mới
                selectedRow.SubItems[7].Text = txtPhuThudacbiet.Text;

                // Cập nhật dữ liệu trong cơ sở dữ liệu (thực hiện tương ứng với cơ sở dữ liệu của bạn)
                try
                {
                    // Ví dụ:
                    var phimToUpdate = db.Phims.FirstOrDefault(p => p.MaDon == txtMaDon.Text);
                    if (phimToUpdate != null)
                    {
                        phimToUpdate.TenPhim = txtTen.Text;
                        phimToUpdate.QuocGia = txtTen.Text;
                        phimToUpdate.TheLoai = rdoTinhCam.Checked ? "Tình cảm" : "Hành động";
                        phimToUpdate.NgayCongChieu = dtNgayCongChieu.Value;
                        if (int.TryParse(txtDotuoi.Text, out int doTuoi))
                        {
                            phimToUpdate.DoTuoiQuyDinh = doTuoi;
                        }
                        // Kiểm tra và chuyển đổi PhuThuGheDoi thành kiểu float
                        if (float.TryParse(txtPhuthughedoi.Text, out float phuThuGheDoi))
                        {
                            phimToUpdate.PhuThuGheDoi = phuThuGheDoi;
                        }
                        // Kiểm tra và chuyển đổi PhuThuSuatChieuDacBiet thành kiểu float
                        if (float.TryParse(txtPhuThudacbiet.Text, out float phuThuSuatChieuDacBiet))
                        {
                            phimToUpdate.PhuThuSuatChieuDacBiet = phuThuSuatChieuDacBiet;
                        }
                        // Thêm đối tượng vào DbContext và lưu thay đổi
                        MessageBox.Show("Dữ liệu đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.SaveChanges();
                    }
                }
                catch (DbUpdateException ex)
                {
                    // Xử lý exception nếu có lỗi khi cập nhật cơ sở dữ liệu
                    MessageBox.Show("Lỗi khi cập nhật cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Chọn lại dòng đang chọn trong ListView
                selectedRow.Selected = true;
                lvDSP.Select();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phim nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HighlightRecentMovies();
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            // Sắp xếp danh sách phim theo ngày công chiếu tăng dần, nếu cùng ngày thì sắp xếp giảm dần theo độ tuổi quy định
            var danhSachDaSapXep = lvDSP.Items.Cast<ListViewItem>()
                .OrderBy(item => DateTime.Parse(item.SubItems[4].Text))
                .ThenByDescending(item => int.Parse(item.SubItems[5].Text));

            // Xóa tất cả các mục trong ListView
            lvDSP.Items.Clear();

            // Thêm lại các mục đã sắp xếp
            lvDSP.Items.AddRange(danhSachDaSapXep.ToArray());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int tongSoLuong2D = 0;
            int tongSoLuong3D = 0;
            double tongDoanhThu2D = 0;
            double tongDoanhThu3D = 0;

            foreach (ListViewItem item in lvDSP.Items)
            {
                int soLuong = 1; // Giả sử mỗi dòng đại diện cho một suất chiếu
                double phuThuGheDoi = 0;
                double phuThuSuatChieuDacBiet = 0;

                if (double.TryParse(item.SubItems[6].Text, out phuThuGheDoi) && double.TryParse(item.SubItems[7].Text, out phuThuSuatChieuDacBiet))
                {
                    tongSoLuong2D += soLuong;
                    tongDoanhThu2D += phuThuGheDoi;

                    tongSoLuong3D += soLuong;
                    tongDoanhThu3D += phuThuSuatChieuDacBiet;
                }
            }

            // Hiển thị thông báo
            string thongBao = $"Thống kê:\n\nTổng số lượng phim 2D: {tongSoLuong2D}\nTổng doanh thu 2D: {tongDoanhThu2D:C}\n\nTổng số lượng phim 3D: {tongSoLuong3D}\nTổng doanh thu 3D: {tongDoanhThu3D:C}";

            MessageBox.Show(thongBao, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXuatBC_Click(object sender, EventArgs e)
        {
            //Chuẩn bị nguồn dữ liệu
            var data = db.Phims.Select(p => new { maDon = p.MaDon, QuocGia = p.QuocGia, TenPhim = p.TenPhim, TheLoai = p.TheLoai }).ToList();
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
            var catalogs = db.Phims.Select(c => new { MaDon = c.MaDon, TenPhim = c.TenPhim }).ToList();
            int row = 2;
            foreach (var c in catalogs)
            {
                excelWS.Range["A" + row].Font.Bold = true;
                excelWS.Range["A" + row].Value = c.TenPhim;
                row++;
                //Lấy sản phẩm theo danh mục 
                var products = from p in db.Phims where p.MaDon == c.MaDon select p;
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
