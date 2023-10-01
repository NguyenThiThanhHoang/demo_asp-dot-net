using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class NhanVien
    {
        public int TaiKhoanId { get; set; }
        public string TenNv { get; set; }
        public string HoNv { get; set; }
        public int? Sđt { get; set; }
        public string Email { get; set; }
        public string ChuoiMaHoaMk { get; set; }
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; }
        public int ChucVuId { get; set; }
        public DateTime? NgayVaoLam { get; set; }

        public virtual ChucVu ChucVu { get; set; }
    }
}
