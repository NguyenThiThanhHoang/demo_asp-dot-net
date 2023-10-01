using APCGaming.Extension;
using APCGaming.Models;
using APCGaming.ModelViews;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCGaming.Controllers
{
    public class GioHangController : Controller
    {
        private readonly APCGamingContext _context;
        private readonly INotyfService _notyfService;

        public GioHangController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<ThanhPhanGioiHang> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<ThanhPhanGioiHang>>("GioHang");
                if (gh == default(List<ThanhPhanGioiHang>))
                {
                    gh = new List<ThanhPhanGioiHang>();
                }
                return gh;
            }
        }
        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult ThemVaoGio(int sanPhamID, int? soLuong)
        {
            List<ThanhPhanGioiHang> cart = GioHang;

            try
            {
                
                ThanhPhanGioiHang item = GioHang.SingleOrDefault(p => p.sanPham.SanPhamId == sanPhamID);
                if (item != null) 
                {
                    if (soLuong.HasValue)
                    {
                        item.SoLuong = soLuong.Value;
                    }
                    else
                    {
                        item.SoLuong++;
                    }
                }
                else
                {
                    SanPham sp = _context.SanPhams.SingleOrDefault(p => p.SanPhamId == sanPhamID);
                    item = new ThanhPhanGioiHang
                    {
                        SoLuong = soLuong.HasValue ? soLuong.Value : 1,
                        sanPham = sp
                    };
                    cart.Add(item);
                }

                //Luu lai Session
                HttpContext.Session.Set<List<ThanhPhanGioiHang>>("GioHang", cart);
                _notyfService.Success("Đã thêm sản phẩm thành công!");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int sanPhamId, int? soLuong)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<ThanhPhanGioiHang>>("GioHang");
            try
            {
                if (cart != null)
                {
                    ThanhPhanGioiHang item = cart.SingleOrDefault(p => p.sanPham.SanPhamId == sanPhamId);
                    if (item != null && soLuong.HasValue) // da co -> cap nhat so luong
                    {
                        item.SoLuong = soLuong.Value;
                    }
                    //Luu lai session
                    HttpContext.Session.Set<List<ThanhPhanGioiHang>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/cart/remove")]
        public ActionResult XoaKhoiGio(int sanPhamId)
        {

            try
            {
                List<ThanhPhanGioiHang> gioHang = GioHang;
                ThanhPhanGioiHang item = gioHang.SingleOrDefault(p => p.sanPham.SanPhamId == sanPhamId);
                if (item != null)
                {
                    gioHang.Remove(item);
                }
                //luu lai session
                HttpContext.Session.Set<List<ThanhPhanGioiHang>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [Route("cart", Name = "Cart")]
        public IActionResult Index()
        {
            return View(GioHang);
        }
    }
}
