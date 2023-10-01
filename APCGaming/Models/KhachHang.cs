using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int KhachHangId { get; set; }
        public string TenKh { get; set; }
        public string HoKh { get; set; }
        public int? Sđt { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string Avatar { get; set; }
        public string TenDangNhap { get; set; }
        public string ChuoiMaHoaMk { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
