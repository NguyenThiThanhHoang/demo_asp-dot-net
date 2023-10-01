using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class ChiTietDonHang
    {
        public int DonHangId { get; set; }
        public int SanPhamId { get; set; }
        public int GiaTien { get; set; }
        public int SoLuong { get; set; }
        public int? GiamGia { get; set; }

        public virtual DonHang DonHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
