using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoHinh3LopQuanLyPhim.Model
{
    class GiaVe2D : Phims
    {
        public double PhuThuGheDoi {  get; set; }
        public double DinhDang2D()
        {
            return base.DinhDang2D() + PhuThuGheDoi;
        }
    }
}
