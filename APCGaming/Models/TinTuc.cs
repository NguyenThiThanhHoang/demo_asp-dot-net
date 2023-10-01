using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class TinTuc
    {
        public int TinTucId { get; set; }
        public string TieuDe { get; set; }
        public string MoTaNgan { get; set; }
        public string MoTaDai { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public string TacGia { get; set; }
        public bool IsHot { get; set; }
        public bool IsNewfeed { get; set; }
        public int? Views { get; set; }
        public int? DanhMucId { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
