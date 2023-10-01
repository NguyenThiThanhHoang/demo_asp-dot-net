using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        public int SanPhamId { get; set; }
        public string TenSp { get; set; }
        public string Avatar { get; set; }
        public string MoTa { get; set; }
        public string The { get; set; }
        public int? SoLuong { get; set; }
        public int DanhMucId { get; set; }
        public int GiaTien { get; set; }
        public int? GiamGia { get; set; }
        public bool TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
