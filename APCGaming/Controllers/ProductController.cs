using APCGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCGaming.Controllers
{
    public class ProductController : Controller
    {
        private readonly APCGamingContext _context;
        public ProductController(APCGamingContext context)
        {
            _context = context;
        }
        [Route("shop", Name = ("ShopProduct"))]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var lsSanPhams = _context.SanPhams
                    .AsNoTracking()
                    .OrderBy(x => x.NgayTao);
                PagedList<SanPham> models = new PagedList<SanPham>(lsSanPhams, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [Route("danhmuc/{id}", Name = ("ListProduct"))]
        public IActionResult List(int id, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var danhMuc = _context.DanhMucs.AsNoTracking().SingleOrDefault(x => x.DanhMucId == id);

                var lsSanPhams = _context.SanPhams
                    .AsNoTracking()
                    .Where(x => x.DanhMucId == danhMuc.DanhMucId)
                    .OrderByDescending(x => x.NgayTao);
                PagedList<SanPham> models = new PagedList<SanPham>(lsSanPhams, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentDanhMuc = danhMuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("/san-pham/{id}", Name = ("ProductDetails"))]
        public IActionResult Details(int id)
        {
            try
            {
                var sanPham = _context.SanPhams.Include(x => x.DanhMuc).FirstOrDefault(x => x.SanPhamId == id);
                if (sanPham == null)
                {
                    return RedirectToAction("Index");
                }
                var lsSanPham = _context.SanPhams
                    .AsNoTracking()
                    .Where(x => x.DanhMucId == sanPham.DanhMucId && x.SanPhamId != id && x.TrangThai == true)
                    .Take(4)
                    .OrderByDescending(x => x.NgayTao)
                    .ToList();
                ViewBag.SanPham = lsSanPham;
                return View(sanPham);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}
