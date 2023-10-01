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
    public class BlogController : Controller
    {
        private readonly APCGamingContext _context;
        public BlogController(APCGamingContext context)
        {
            _context = context;
        }
        [Route("blogs", Name =("Blogs"))]
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTinTuc = _context.TinTucs.AsNoTracking().OrderByDescending(x => x.TinTucId);
            PagedList<TinTuc> models = new PagedList<TinTuc>(lsTinTuc, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);
        }
        [Route("/tin-tuc/{id}", Name = "TinChiTiet")]
        public IActionResult Details(int id)
        {
            var tinTuc = _context.TinTucs.AsNoTracking().SingleOrDefault(x => x.TinTucId == id);
            if (tinTuc == null)
            {
                return RedirectToAction("Index");
            }
            var lsBaiVietLienQuan = _context.TinTucs
                .AsNoTracking().Where(x => x.TrangThai == true && x.TinTucId != id)
                .Take(3)
                .OrderByDescending(x => x.NgayTao).ToList();
            ViewBag.BaiVietLienQuan = lsBaiVietLienQuan;
            return View(tinTuc);
        }
    }
}
