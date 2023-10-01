using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class TrangThaiDonHang
    {
        public TrangThaiDonHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int TrangThaiDonHangId { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
