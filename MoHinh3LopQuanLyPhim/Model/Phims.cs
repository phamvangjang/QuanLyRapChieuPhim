using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoHinh3LopQuanLyPhim.Model
{
    class Phims
    {
        public string MaDon {  get; set; }
        public string TenPhim { get; set;}
        public string QuocGia { get; set;}
        public string TheLoai { get;set; }
        public DateTime NgayCongChieu { get; set; }
        public int DoTuoi {  get; set; }
        public float phuthughedoi {  get; set; }
        public float phuthudacbiet {  get; set; }
        public string DinhDang {  get; set; }
        public double DinhDang2D()
        {
            return 110000;
        }
        public double DinhDang3D()
        {
            return 210000;
        }
    }
}
