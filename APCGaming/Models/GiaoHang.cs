using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class GiaoHang
    {
        public int DonHangId { get; set; }
        public int NguoiGiaoHangId { get; set; }
        public DateTime? NgayGh { get; set; }

        public virtual DonHang DonHang { get; set; }
        public virtual NguoiGiaoHang NguoiGiaoHang { get; set; }
    }
}
