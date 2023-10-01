using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
            TinTucs = new HashSet<TinTuc>();
        }

        public int DanhMucId { get; set; }
        public string TenDanhMuc { get; set; }
        public bool TrangThai { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
        public virtual ICollection<TinTuc> TinTucs { get; set; }
    }
}
