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
    public class TrangController : Controller
    {
        private readonly APCGamingContext _context;
        public TrangController(APCGamingContext context)
        {
            _context = context;
        }
        [Route("trang", Name = ("trangs"))]
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTrang = _context.Trangs.AsNoTracking().OrderByDescending(x => x.TrangId);
            PagedList<Trang> models = new PagedList<Trang>(lsTrang, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);
        }
        [Route("/trang/{id}", Name = "NoiDungChiTiet")]
        public IActionResult Details(int id)
        {
            var trang = _context.Trangs.AsNoTracking().SingleOrDefault(x => x.TrangId == id);
            if (trang == null)
            {
                return RedirectToAction("Index");
            }
            var lsBaiVietLienQuan = _context.Trangs
                .AsNoTracking().Where(x => x.TrangThai == true && x.TrangId != id)
                .Take(3)
                .OrderByDescending(x => x.NgayTao).ToList();
            ViewBag.BaiVietLienQuan = lsBaiVietLienQuan;
            return View(trang);
        }
    }
}
