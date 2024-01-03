using MoHinh3LopQuanLyPhim.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MoHinh3LopQuanLyPhim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn chặn việc đóng ứng dụng nếu người dùng không đồng ý.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            Bussiness.Instance.Xem(lvDanhSachphim);
        }

        private void rdbtnTinhCam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbtn3D_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn3D.Checked)
            {
                txtGhedoi.Visible = false;
                txtDacbiet.Visible = true;
                txtGhedoi.Clear();
                lblDacbiet.Visible = true;
                lblGheDoi.Visible = false;
            }
        }

        private void rdbtn2d_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn2d.Checked)
            {
                txtGhedoi.Visible = true;
                txtDacbiet.Visible = false;
                txtGhedoi.Clear();
                lblGheDoi.Visible = true;
                lblDacbiet.Visible = false;
            }
        }

        public void Reset()
        {
            // Xóa dữ liệu trong các TextBox nhập liệu
            txtMaDon.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtQG.Text = string.Empty;
            rdbtnTCam.Checked = true;
            dtNCC.Value = DateTime.Now;
            txtDT.Text = string.Empty;
            rdbtn2d.Checked = true;
            txtDacbiet.Text = string.Empty;
            txtGhedoi.Text = string.Empty;

            // Gán giá trị mặc định cho các TextBox nhập liệu
            txtMaDon.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            txtMaDon.Enabled = true;
        }
        public new bool Validate
        {
            get
            {
                // Kiểm tra thông tin có hợp lệ
                if (string.IsNullOrEmpty(txtMaDon.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtQG.Text) || string.IsNullOrEmpty(txtDT.Text) || string.IsNullOrEmpty(txtGhedoi.Text) || string.IsNullOrEmpty(txtDacbiet.Text))
                {
                    MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (dtNCC.Value < DateTime.Now)
                {
                    MessageBox.Show("Ngày công chiếu không được lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtDT.Text.Any(n => !char.IsDigit(n)))
                {
                    MessageBox.Show("Độ tuổi phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtGhedoi.Text.Any(n => !char.IsDigit(n)) && rdbtn2d.Checked)
                {
                    MessageBox.Show("Phụ thu phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtDacbiet.Text.Any(n => !char.IsDigit(n)) && rdbtn3D.Checked)
                {
                    MessageBox.Show("Phụ thu phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin có hợp lệ
            if (Validate)
            {
                Bussiness.Instance.Luu(lvDanhSachphim);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhSachphim.SelectedItems.Count > 0)
            {
                //hien thi hop thoai xac nhan
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa phim này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //lay dong duoc chon
                    ListViewItem selectedRow = lvDanhSachphim.SelectedItems[0];
                    // Lấy thông tin của phim từ dòng được chọn
                    string maDon = lvDanhSachphim.SelectedItems[0].SubItems[0].Text;
                    // Lấy index của dòng để xóa
                    int indexToRemove = selectedRow.Index;

                    // Xóa dòng khỏi ListView
                    lvDanhSachphim.Items.Remove(selectedRow);

                    // Chọn dòng liền kề sau nếu có
                    if (indexToRemove < lvDanhSachphim.Items.Count)
                    {
                        lvDanhSachphim.Items[indexToRemove].Selected = true;
                        lvDanhSachphim.Select();
                    }
                    else if (indexToRemove > 0)
                    {
                        // Nếu không có dòng liền kề sau, chọn dòng liền kề trước
                        lvDanhSachphim.Items[indexToRemove - 1].Selected = true;
                        lvDanhSachphim.Select();
                    }
                    else
                    {
                        // Nếu không còn dòng nào trong ListView, xóa thông tin ở bảng điều khiển và đưa trỏ chuột lên txtMaDon
                        Reset();
                    }
                    
                    // Thực hiện xóa từ cơ sở dữ liệu
                    Bussiness.Instance.XoaThongtinTheoMaDon(maDon);
                    MessageBox.Show("Đã xóa phim thành công!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phim nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void lvDanhSachphim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachphim.SelectedItems.Count > 0)
            {
                // Lấy giá trị của cột "Mã Đơn" từ dòng được chọn
                string maDon = lvDanhSachphim.SelectedItems[0].SubItems[0].Text;
                txtMaDon.Enabled = false;

                // Gọi phương thức trong Bussiness để lấy thông tin chi tiết từ cơ sở dữ liệu
                Phims phim = Bussiness.Instance.LayThongTinPhimTheoMaDon(maDon);
                txtMaDon.Text = phim.MaDon.ToString();
                txtTen.Text = phim.TenPhim.ToString();
                txtQG.Text = phim.QuocGia.ToString();
                if (phim.TheLoai == "Tình cảm")
                {
                    rdbtnTCam.Checked = true;
                }
                else if (phim.TheLoai == "Hành động")
                {
                    rdbtnHDong.Checked = true;
                }
                dtNCC.Text = phim.NgayCC.Date.ToString();
                txtDT.Text = phim.DoTuoi.ToString();
                if (phim.DinhDang=="3D")
                {
                    rdbtn3D.Checked = true;
                    txtDacbiet.Text = phim.DacBiet.ToString();
                    txtGhedoi.Clear();
                }
                else if (phim.DinhDang == "2D")
                {
                    rdbtn2d.Checked = true;
                    txtGhedoi.Text = phim.GheDoi.ToString();
                    txtDacbiet.Clear();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Validate)
            {
                Bussiness.Instance.Sua(lvDanhSachphim);
                lvDanhSachphim.Items.Clear();
                Bussiness.Instance.Xem(lvDanhSachphim);
            }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            lvDanhSachphim.Items.Clear();
            Bussiness.Instance.SapXepPhims(lvDanhSachphim);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Bussiness.Instance.ThongKe();
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            
        }

        private void grbDSP_Enter(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Bussiness.Instance.XuatExcel();
        }
    }
}
