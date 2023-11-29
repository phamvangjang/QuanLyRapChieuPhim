using MoHinh3LopQuanLyPhim.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MoHinh3LopQuanLyPhim.Bussiness;


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
            rdbtnTinhCam.Checked = true;
            rdbtn2d.Checked = true;
            dtNgayCongchieu.Value = DateTime.Now;
            Bussiness.Instance.Xem(lvDanhSachphim);
        }

        private void rdbtnTinhCam_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdbtn3D_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn3D.Checked)
            {
                txtPhuthughedoi.Visible = false;
                txtPhuthudacbiet.Visible = true;
                lblPhuthudacbiet.Visible = true;
                lblPhuThuGheDoi.Visible = false;
            }
        }

        private void rdbtn2d_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn2d.Checked)
            {
                txtPhuthughedoi.Visible = true;
                txtPhuthudacbiet.Visible = false;
                lblPhuThuGheDoi.Visible = true;
                lblPhuthudacbiet.Visible = false;
            }
        }

        public void Reset()
        {
            // Xóa dữ liệu trong các TextBox nhập liệu
            txtMaDon.Text = string.Empty;
            txtTenPhim.Text = string.Empty;
            txtQuocGia.Text = string.Empty;
            txtDoTuoi.Text = string.Empty;
            rdbtn2d.Checked = true;
            rdbtnTinhCam.Checked = true;
            txtPhuthudacbiet.Text = string.Empty;
            txtPhuthughedoi.Text = string.Empty;

            // Gán giá trị mặc định cho các TextBox nhập liệu
            txtMaDon.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public bool validate = false;
        private void btnLuu_Click(object sender, EventArgs e)
        {

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
            if (!DateTime.TryParse(dtNgayCongchieu.Text, out ngayCongChieu))
            {
                MessageBox.Show("Ngày công chiếu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDoTuoi.Text))
            {
                MessageBox.Show("Độ tuổi không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                validate = true;
            }
            if (validate==true)
            {
                Bussiness.Instance.Luu(lvDanhSachphim);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void lvDanhSachphim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachphim.SelectedItems.Count>0)
            {
                /*
                txtMaDon.Text = lvDanhSachphim.SelectedItems[0].Text;
                txtTenPhim.Text = lvDanhSachphim.SelectedItems[0].SubItems[1].Text;
                if (lvDanhSachphim.SelectedItems[0].SubItems[2].Text.Equals("Tình cảm"))
                {
                    rdbtnTinhCam.Checked = true;
                }else if (lvDanhSachphim.SelectedItems[0].SubItems[2].Text.Equals("Hành động"))
                {
                    rdbtnHanhDong.Checked = true;
                }
                */
                // Lấy giá trị của cột "Mã Đơn" từ dòng được chọn
                string maDon = lvDanhSachphim.SelectedItems[0].SubItems[0].Text;

                // Gọi phương thức trong Logic Layer để lấy thông tin chi tiết từ cơ sở dữ liệu
                Phims phim = QuanLyPhim.Bussiness.Instance.LayThongTinPhimTheoMaDon(maDon);

                // Hiển thị thông tin lên bảng điều khiển
                HienThiThongTinLenBangDieuKhien(phim);
            }
        }
    }
}
