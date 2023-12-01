using MoHinh3LopQuanLyPhim.Model;
using System;
using System.Windows.Forms;


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
            dtNgayCongchieu.Value = DateTime.Now;

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
            if (validate == true)
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
                    
                    // Thực hiện xóa từ cơ sở dữ liệu (thực hiện tương ứng với cơ sở dữ liệu của bạn)
                    Bussiness.Instance.XoaThongtinTheoMaDon(maDon);

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

                // Gọi phương thức trong Logic Layer để lấy thông tin chi tiết từ cơ sở dữ liệu
                Phims phim = Bussiness.Instance.LayThongTinPhimTheoMaDon(maDon);
                txtMaDon.Text = phim.MaDon.ToString();
                txtTenPhim.Text = phim.TenPhim.ToString();
                txtQuocGia.Text = phim.QuocGia.ToString();
                if (phim.TheLoai == "Tình cảm")
                {
                    rdbtnTinhCam.Checked = true;
                }
                else if (phim.TheLoai == "Hành động")
                {
                    rdbtnHanhDong.Checked = true;
                }
                dtNgayCongchieu.Text = phim.NgayCongChieu.Date.ToString();
                txtDoTuoi.Text = phim.DoTuoi.ToString();

                if (phim.phuthughedoi == 0)
                {
                    lblPhuThuGheDoi.Visible = false;
                    txtPhuthughedoi.Visible = false;
                    rdbtn3D.Checked = true;
                    lblPhuthudacbiet.Visible = true;
                    txtPhuthudacbiet.Visible = true;
                    txtPhuthudacbiet.Text = phim.phuthudacbiet.ToString();
                }
                else if (phim.phuthudacbiet == 0)
                {
                    lblPhuthudacbiet.Visible = false;
                    txtPhuthudacbiet.Visible = false;
                    rdbtn2d.Checked = true;
                    lblPhuThuGheDoi.Visible = true;
                    txtPhuthughedoi.Visible = true;
                    txtPhuthughedoi.Text = phim.phuthughedoi.ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Bussiness.Instance.Sua(lvDanhSachphim);
            Bussiness.Instance.Xem(lvDanhSachphim);
        }
    }
}
