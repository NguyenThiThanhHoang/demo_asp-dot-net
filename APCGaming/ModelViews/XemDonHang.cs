using APCGaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCGaming.ModelViews
{
    public class XemDonHang
    {
        public DonHang DonHang { get; set; }
        public List<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
