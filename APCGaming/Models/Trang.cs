using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class Trang
    {
        public int TrangId { get; set; }
        public string TenTrang { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }
        public string TieuDe { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
