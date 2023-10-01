using APCGaming.Extension;
using APCGaming.Helpper;
using APCGaming.Models;
using APCGaming.ModelViews;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCGaming.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly APCGamingContext _context;
        public INotyfService _notyfService { get; }
        public ThanhToanController(APCGamingContext context, INotyfService notyfService)
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
        [Route("thanh-toan", Name = "ThanhToan")]
        public IActionResult Index(string returnUrl = null)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<ThanhPhanGioiHang>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachHang = _context.KhachHangs.AsNoTracking().SingleOrDefault(x => x.KhachHangId == Convert.ToInt32(taikhoanID));
                model.KhachHangId = khachHang.KhachHangId;
                model.Ten = khachHang.TenKh;
                model.Ho = khachHang.HoKh;
                model.Email = khachHang.Email;
                model.Phone = khachHang.Sđt.ToString();
            }
            ViewBag.GioHang = cart;
            return View(model);
        }

        [HttpPost]
        [Route("/thanh-toan", Name = "ThanhToan")]
        public IActionResult Index(MuaHangVM muaHang)
        {
            //Lay ra gio hang de xu ly
            var cart = HttpContext.Session.Get<List<ThanhPhanGioiHang>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("KhachHangId");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachHang = _context.KhachHangs.AsNoTracking().SingleOrDefault(x => x.KhachHangId == Convert.ToInt32(taikhoanID));
                model.KhachHangId = khachHang.KhachHangId;
                model.Ten = khachHang.TenKh;
                model.Ho = khachHang.HoKh;
                model.Email = khachHang.Email;
                model.Phone = khachHang.Sđt.ToString();

                _context.Update(khachHang);
                _context.SaveChanges();
            }
            try
            {
                //Khoi tao don hang
                DonHang donhang = new DonHang();
                donhang.KhachHangId = model.KhachHangId;
                donhang.NgayTao = donhang.NgayThanhToan = DateTime.Now;
                donhang.TrangThaiDonHangId = 1;//Don hang moi
                donhang.TrangThaiThanhToan = true;
                //donhang.GhiChu = Utilities.StripHTML(model.Note);
                donhang.TongTien = Convert.ToInt32(cart.Sum(x => x.TongTien));
                //donhang.DiaChi = model.Address;
                _context.Add(donhang);
                _context.SaveChanges();
                //tao danh sach don hang

                foreach (var item in cart)
                {
                    ChiTietDonHang orderDetail = new ChiTietDonHang();
                    orderDetail.DonHangId = donhang.DonHangId;
                    orderDetail.SanPhamId = item.sanPham.SanPhamId;
                    orderDetail.SoLuong = item.SoLuong;
                    orderDetail.GiaTien = item.sanPham.GiaTien;
                    _context.Add(orderDetail);
                }
                _context.SaveChanges();
                //clear gio hang
                HttpContext.Session.Remove("GioHang");
                //Xuat thong bao
                _notyfService.Success("Đơn hàng đặt thành công");
                //cap nhat thong tin khach hang
                return RedirectToAction("Dashboard", "KhachHangs");

            }
            catch
            {
                ViewBag.GioHang = cart;
                return View(model);
            }

            ViewBag.GioHang = cart;
            return View(model);
        }
    }   
}
