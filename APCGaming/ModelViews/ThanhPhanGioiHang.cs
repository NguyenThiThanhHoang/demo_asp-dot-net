using APCGaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCGaming.ModelViews
{
    public class ThanhPhanGioiHang
    {
        public SanPham sanPham { get; set; }
        public int SoLuong { get; set; }
        
        public double TongTien => SoLuong * sanPham.GiaTien;
    }
}
