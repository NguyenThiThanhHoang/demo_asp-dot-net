using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class BinhLuan
    {
        public int BinhLuanId { get; set; }
        public int SanPhamId { get; set; }
        public DateTime? NgayTao { get; set; }
        public string NoiDung { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
