using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APCGaming.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using APCGaming.ModelViews;

namespace APCGaming.Controllers
{
    public class DonHangsController : Controller
    {
        private readonly APCGamingContext _context;
        public INotyfService _notyfService { get; }

        public DonHangsController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }


        // GET: DonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var taiKhoanID = HttpContext.Session.GetString("KhachHangId");
                if (string.IsNullOrEmpty(taiKhoanID)) return RedirectToAction("Login", "KhachHangs");
                var khachhang = _context.KhachHangs.AsNoTracking().SingleOrDefault(x => x.KhachHangId == Convert.ToInt32(taiKhoanID));
                if (khachhang == null) return NotFound();
                var donHang = await _context.DonHangs
                       .Include(d => d.KhachHang)
                       .Include(d => d.TrangThaiDonHang)
                       .FirstOrDefaultAsync(m => m.DonHangId == id && Convert.ToInt32(taiKhoanID) == m.KhachHangId);
                if (donHang == null)
                {
                    return NotFound();
                }

                var chitietdonhang = _context.ChiTietDonHangs
                     .Include(x => x.SanPham)
                     .AsNoTracking()
                     .Where(x => x.SanPhamId == id)
                     .OrderBy(x => x.DonHangId)
                     .ToList();
                XemDonHang donhang = new XemDonHang();
                donhang.DonHang = donHang;
                donhang.ChiTietDonHang = chitietdonhang;
                return PartialView("Details", donhang);
            }
            catch (Exception)
            {

                throw;
            }
        }
      
    }
}
