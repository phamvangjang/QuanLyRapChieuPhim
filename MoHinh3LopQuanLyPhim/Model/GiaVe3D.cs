using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoHinh3LopQuanLyPhim.Model
{
    class GiaVe3D : Phims
    {
        public double phuThuDacBiet {  get; set; }
        public double DinhDang3D()
        {
            return base.DinhDang3D()+phuThuDacBiet;
        }
    }
}
