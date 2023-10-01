using System;
using System.Collections.Generic;

#nullable disable

namespace APCGaming.Models
{
    public partial class NguoiGiaoHang
    {
        public NguoiGiaoHang()
        {
            GiaoHangs = new HashSet<GiaoHang>();
        }

        public int NguoiGiaoHangId { get; set; }
        public string TenGh { get; set; }
        public string HoGh { get; set; }
        public int? Sđt { get; set; }
        public string CongTy { get; set; }

        public virtual ICollection<GiaoHang> GiaoHangs { get; set; }
    }
}
