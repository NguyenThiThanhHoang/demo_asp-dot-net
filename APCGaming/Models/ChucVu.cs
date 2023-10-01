using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int ChucVuId { get; set; }
        public string TenChucVu { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
