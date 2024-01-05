namespace QuanLyRapChieuPhim
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_QL = new System.Windows.Forms.Label();
            this.grb_TTP = new System.Windows.Forms.GroupBox();
            this.txtGhedoi = new System.Windows.Forms.TextBox();
            this.lblGhedoi = new System.Windows.Forms.Label();
            this.txtDacbiet = new System.Windows.Forms.TextBox();
            this.lblDacbiet = new System.Windows.Forms.Label();
            this.lblĐindang = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtn3D = new System.Windows.Forms.RadioButton();
            this.rdbtn2D = new System.Windows.Forms.RadioButton();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.lblDotuoi = new System.Windows.Forms.Label();
            this.dtNgayCC = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.grbTheLoai = new System.Windows.Forms.GroupBox();
            this.rdoHanhDong = new System.Windows.Forms.RadioButton();
            this.rdoTinhCam = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvDSP = new System.Windows.Forms.ListView();
            this.colMaDon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenPhim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTheLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbTacVu = new System.Windows.Forms.GroupBox();
            this.btnXuatBC = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnSapXep = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grb_TTP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbTheLoai.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbTacVu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_QL
            // 
            this.lbl_QL.AutoSize = true;
            this.lbl_QL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QL.Location = new System.Drawing.Point(128, 9);
            this.lbl_QL.Name = "lbl_QL";
            this.lbl_QL.Size = new System.Drawing.Size(810, 32);
            this.lbl_QL.TabIndex = 0;
            this.lbl_QL.Text = "CHƯƠNG TRÌNH QUẢN LÝ DOANH THU PHIM CHIẾU RẠP";
            // 
            // grb_TTP
            // 
            this.grb_TTP.Controls.Add(this.txtGhedoi);
            this.grb_TTP.Controls.Add(this.lblGhedoi);
            this.grb_TTP.Controls.Add(this.txtDacbiet);
            this.grb_TTP.Controls.Add(this.lblDacbiet);
            this.grb_TTP.Controls.Add(this.lblĐindang);
            this.grb_TTP.Controls.Add(this.groupBox1);
            this.grb_TTP.Controls.Add(this.txtDT);
            this.grb_TTP.Controls.Add(this.lblDotuoi);
            this.grb_TTP.Controls.Add(this.dtNgayCC);
            this.grb_TTP.Controls.Add(this.label4);
            this.grb_TTP.Controls.Add(this.grbTheLoai);
            this.grb_TTP.Controls.Add(this.label3);
            this.grb_TTP.Controls.Add(this.txtQG);
            this.grb_TTP.Controls.Add(this.label2);
            this.grb_TTP.Controls.Add(this.txtTen);
            this.grb_TTP.Controls.Add(this.label1);
            this.grb_TTP.Controls.Add(this.txtMaDon);
            this.grb_TTP.Controls.Add(this.lblMaDon);
            this.grb_TTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_TTP.ForeColor = System.Drawing.Color.Black;
            this.grb_TTP.Location = new System.Drawing.Point(2, 39);
            this.grb_TTP.Name = "grb_TTP";
            this.grb_TTP.Size = new System.Drawing.Size(368, 417);
            this.grb_TTP.TabIndex = 1;
            this.grb_TTP.TabStop = false;
            this.grb_TTP.Text = "Thông tin phim";
            // 
            // txtGhedoi
            // 
            this.txtGhedoi.Location = new System.Drawing.Point(180, 326);
            this.txtGhedoi.Name = "txtGhedoi";
            this.txtGhedoi.Size = new System.Drawing.Size(179, 30);
            this.txtGhedoi.TabIndex = 17;
            // 
            // lblGhedoi
            // 
            this.lblGhedoi.AutoSize = true;
            this.lblGhedoi.Location = new System.Drawing.Point(9, 330);
            this.lblGhedoi.Name = "lblGhedoi";
            this.lblGhedoi.Size = new System.Drawing.Size(154, 25);
            this.lblGhedoi.TabIndex = 16;
            this.lblGhedoi.Text = "Phụ thu ghế đôi:";
            // 
            // txtDacbiet
            // 
            this.txtDacbiet.Location = new System.Drawing.Point(180, 371);
            this.txtDacbiet.Name = "txtDacbiet";
            this.txtDacbiet.Size = new System.Drawing.Size(180, 30);
            this.txtDacbiet.TabIndex = 15;
            // 
            // lblDacbiet
            // 
            this.lblDacbiet.AutoSize = true;
            this.lblDacbiet.Location = new System.Drawing.Point(10, 375);
            this.lblDacbiet.Name = "lblDacbiet";
            this.lblDacbiet.Size = new System.Drawing.Size(164, 25);
            this.lblDacbiet.TabIndex = 14;
            this.lblDacbiet.Text = "PT suất chiếu DB";
            // 
            // lblĐindang
            // 
            this.lblĐindang.AutoSize = true;
            this.lblĐindang.Location = new System.Drawing.Point(10, 273);
            this.lblĐindang.Name = "lblĐindang";
            this.lblĐindang.Size = new System.Drawing.Size(101, 25);
            this.lblĐindang.TabIndex = 12;
            this.lblĐindang.Text = "Định dạng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbtn3D);
            this.groupBox1.Controls.Add(this.rdbtn2D);
            this.groupBox1.Location = new System.Drawing.Point(180, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 47);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // rdbtn3D
            // 
            this.rdbtn3D.AutoSize = true;
            this.rdbtn3D.Location = new System.Drawing.Point(95, 14);
            this.rdbtn3D.Name = "rdbtn3D";
            this.rdbtn3D.Size = new System.Drawing.Size(58, 29);
            this.rdbtn3D.TabIndex = 1;
            this.rdbtn3D.TabStop = true;
            this.rdbtn3D.Text = "3D";
            this.rdbtn3D.UseVisualStyleBackColor = true;
            this.rdbtn3D.CheckedChanged += new System.EventHandler(this.rdo3D_CheckedChanged);
            // 
            // rdbtn2D
            // 
            this.rdbtn2D.AutoSize = true;
            this.rdbtn2D.Location = new System.Drawing.Point(15, 14);
            this.rdbtn2D.Name = "rdbtn2D";
            this.rdbtn2D.Size = new System.Drawing.Size(58, 29);
            this.rdbtn2D.TabIndex = 0;
            this.rdbtn2D.TabStop = true;
            this.rdbtn2D.Text = "2D";
            this.rdbtn2D.UseVisualStyleBackColor = true;
            this.rdbtn2D.CheckedChanged += new System.EventHandler(this.rdo2D_CheckedChanged);
            // 
            // txtDT
            // 
            this.txtDT.Location = new System.Drawing.Point(180, 228);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(180, 30);
            this.txtDT.TabIndex = 11;
            // 
            // lblDotuoi
            // 
            this.lblDotuoi.AutoSize = true;
            this.lblDotuoi.Location = new System.Drawing.Point(5, 233);
            this.lblDotuoi.Name = "lblDotuoi";
            this.lblDotuoi.Size = new System.Drawing.Size(158, 25);
            this.lblDotuoi.TabIndex = 10;
            this.lblDotuoi.Text = "Độ tuổi quy định:";
            // 
            // dtNgayCC
            // 
            this.dtNgayCC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayCC.Location = new System.Drawing.Point(180, 184);
            this.dtNgayCC.Name = "dtNgayCC";
            this.dtNgayCC.Size = new System.Drawing.Size(179, 30);
            this.dtNgayCC.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ngày công chiếu:";
            // 
            // grbTheLoai
            // 
            this.grbTheLoai.Controls.Add(this.rdoHanhDong);
            this.grbTheLoai.Controls.Add(this.rdoTinhCam);
            this.grbTheLoai.Location = new System.Drawing.Point(104, 133);
            this.grbTheLoai.Name = "grbTheLoai";
            this.grbTheLoai.Size = new System.Drawing.Size(256, 45);
            this.grbTheLoai.TabIndex = 7;
            this.grbTheLoai.TabStop = false;
            // 
            // rdoHanhDong
            // 
            this.rdoHanhDong.AutoSize = true;
            this.rdoHanhDong.Location = new System.Drawing.Point(120, 14);
            this.rdoHanhDong.Name = "rdoHanhDong";
            this.rdoHanhDong.Size = new System.Drawing.Size(132, 29);
            this.rdoHanhDong.TabIndex = 1;
            this.rdoHanhDong.TabStop = true;
            this.rdoHanhDong.Text = "Hành Động";
            this.rdoHanhDong.UseVisualStyleBackColor = true;
            // 
            // rdoTinhCam
            // 
            this.rdoTinhCam.AutoSize = true;
            this.rdoTinhCam.Location = new System.Drawing.Point(6, 13);
            this.rdoTinhCam.Name = "rdoTinhCam";
            this.rdoTinhCam.Size = new System.Drawing.Size(114, 29);
            this.rdoTinhCam.TabIndex = 0;
            this.rdoTinhCam.TabStop = true;
            this.rdoTinhCam.Text = "Tình cảm";
            this.rdoTinhCam.UseVisualStyleBackColor = true;
            this.rdoTinhCam.CheckedChanged += new System.EventHandler(this.rdoTinhCam_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Thể loại:";
            // 
            // txtQG
            // 
            this.txtQG.Location = new System.Drawing.Point(111, 100);
            this.txtQG.Name = "txtQG";
            this.txtQG.Size = new System.Drawing.Size(249, 30);
            this.txtQG.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quốc gia:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(111, 64);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(249, 30);
            this.txtTen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên phim:";
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(111, 26);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(249, 30);
            this.txtMaDon.TabIndex = 1;
            // 
            // lblMaDon
            // 
            this.lblMaDon.AutoSize = true;
            this.lblMaDon.Location = new System.Drawing.Point(10, 30);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(92, 25);
            this.lblMaDon.TabIndex = 0;
            this.lblMaDon.Text = "Mã Đơn: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvDSP);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(381, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 417);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phim";
            // 
            // lvDSP
            // 
            this.lvDSP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaDon,
            this.colTenPhim,
            this.colTheLoai,
            this.colNCC});
            this.lvDSP.FullRowSelect = true;
            this.lvDSP.GridLines = true;
            this.lvDSP.HideSelection = false;
            this.lvDSP.Location = new System.Drawing.Point(11, 29);
            this.lvDSP.Name = "lvDSP";
            this.lvDSP.Size = new System.Drawing.Size(605, 388);
            this.lvDSP.TabIndex = 0;
            this.lvDSP.UseCompatibleStateImageBehavior = false;
            this.lvDSP.View = System.Windows.Forms.View.Details;
            this.lvDSP.SelectedIndexChanged += new System.EventHandler(this.lvDSP_SelectedIndexChanged);
            // 
            // colMaDon
            // 
            this.colMaDon.Text = "Mã đơn";
            this.colMaDon.Width = 100;
            // 
            // colTenPhim
            // 
            this.colTenPhim.Text = "Tên phim";
            this.colTenPhim.Width = 120;
            // 
            // colTheLoai
            // 
            this.colTheLoai.Text = "Thể loại";
            this.colTheLoai.Width = 120;
            // 
            // colNCC
            // 
            this.colNCC.Text = "Ngày công chiếu";
            this.colNCC.Width = 200;
            // 
            // grbTacVu
            // 
            this.grbTacVu.Controls.Add(this.btnXuatBC);
            this.grbTacVu.Controls.Add(this.btnXuatExcel);
            this.grbTacVu.Controls.Add(this.btnThongKe);
            this.grbTacVu.Controls.Add(this.btnSapXep);
            this.grbTacVu.Controls.Add(this.btnSua);
            this.grbTacVu.Controls.Add(this.btnXoa);
            this.grbTacVu.Controls.Add(this.btnLuu);
            this.grbTacVu.Controls.Add(this.btnThem);
            this.grbTacVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTacVu.Location = new System.Drawing.Point(2, 462);
            this.grbTacVu.Name = "grbTacVu";
            this.grbTacVu.Size = new System.Drawing.Size(995, 88);
            this.grbTacVu.TabIndex = 3;
            this.grbTacVu.TabStop = false;
            this.grbTacVu.Text = "Tác vụ";
            // 
            // btnXuatBC
            // 
            this.btnXuatBC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXuatBC.Location = new System.Drawing.Point(851, 29);
            this.btnXuatBC.Name = "btnXuatBC";
            this.btnXuatBC.Size = new System.Drawing.Size(114, 42);
            this.btnXuatBC.TabIndex = 7;
            this.btnXuatBC.Text = "Report";
            this.btnXuatBC.UseVisualStyleBackColor = false;
            this.btnXuatBC.Click += new System.EventHandler(this.btnXuatBC_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXuatExcel.Location = new System.Drawing.Point(731, 29);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(114, 42);
            this.btnXuatExcel.TabIndex = 6;
            this.btnXuatExcel.Text = "Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThongKe.Location = new System.Drawing.Point(611, 29);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(114, 42);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnSapXep
            // 
            this.btnSapXep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSapXep.Location = new System.Drawing.Point(491, 29);
            this.btnSapXep.Name = "btnSapXep";
            this.btnSapXep.Size = new System.Drawing.Size(114, 42);
            this.btnSapXep.TabIndex = 4;
            this.btnSapXep.Text = "Sắp xếp";
            this.btnSapXep.UseVisualStyleBackColor = false;
            this.btnSapXep.Click += new System.EventHandler(this.btnSapXep_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSua.Location = new System.Drawing.Point(371, 29);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(114, 42);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXoa.Location = new System.Drawing.Point(251, 29);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(114, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLuu.Location = new System.Drawing.Point(131, 29);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(114, 42);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThem.Location = new System.Drawing.Point(11, 29);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(114, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1032, 566);
            this.Controls.Add(this.grbTacVu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grb_TTP);
            this.Controls.Add(this.lbl_QL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grb_TTP.ResumeLayout(false);
            this.grb_TTP.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbTheLoai.ResumeLayout(false);
            this.grbTheLoai.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grbTacVu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_QL;
        private System.Windows.Forms.GroupBox grb_TTP;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label lblMaDon;
        private System.Windows.Forms.DateTimePicker dtNgayCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbTheLoai;
        private System.Windows.Forms.RadioButton rdoHanhDong;
        private System.Windows.Forms.RadioButton rdoTinhCam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGhedoi;
        private System.Windows.Forms.Label lblGhedoi;
        private System.Windows.Forms.TextBox txtDacbiet;
        private System.Windows.Forms.Label lblDacbiet;
        private System.Windows.Forms.Label lblĐindang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtn3D;
        private System.Windows.Forms.RadioButton rdbtn2D;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.Label lblDotuoi;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvDSP;
        private System.Windows.Forms.ColumnHeader colMaDon;
        private System.Windows.Forms.ColumnHeader colTenPhim;
        private System.Windows.Forms.ColumnHeader colTheLoai;
        private System.Windows.Forms.ColumnHeader colNCC;
        private System.Windows.Forms.GroupBox grbTacVu;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnSapXep;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXuatBC;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}

