using APCGaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCGaming.ModelViews
{
    public class HomeVM
    {
        public List<TinTuc> TinTucs { get; set; }
        public List<SanPham> SanPhams { get; set; }
        //public QuangCao quangcao { get; set; }
    }
}
