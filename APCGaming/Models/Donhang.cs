using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        public int DonHangId { get; set; }
        public int KhachHangId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? TrangThaiDonHangId { get; set; }
        public bool? TrangThaiThanhToan { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string GhiChu { get; set; }
        public int? TongTien { get; set; }
        public string DiaChi { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual TrangThaiDonHang TrangThaiDonHang { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
