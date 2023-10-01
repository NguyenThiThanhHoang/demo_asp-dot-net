using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APCGaming.Models;
using PagedList.Core;
using APCGaming.Helpper;
using System.IO;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace APCGaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSanPhamsController : Controller
    {
        private readonly APCGamingContext _context;
        public INotyfService _notyfService { get; }

        public AdminSanPhamsController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminSanPhams
        public IActionResult Index(int page = 1, int DanhMucID = 0)
        {
            List<SelectListItem> lsTrangThai = new List<SelectListItem>();
            lsTrangThai.Add(new SelectListItem() { Text = "Active", Value = "1" });
            lsTrangThai.Add(new SelectListItem() { Text = "Block", Value = "0" });
            ViewData["lsTrangThai"] = lsTrangThai;

            var pageNumber = page;
            var pageSize = 10;

            List<SanPham> lsSanPham = new List<SanPham>();

            if (DanhMucID != 0)
            {
                lsSanPham = _context.SanPhams
                    .AsNoTracking()
                    .Where(x => x.DanhMucId == DanhMucID)
                    .Include(x => x.DanhMuc)
                    .OrderByDescending(x => x.SanPhamId).ToList();

            }
            else
            {
                lsSanPham = _context.SanPhams
                    .AsNoTracking()
                    .Include(x => x.DanhMuc)
                    .OrderByDescending(x => x.SanPhamId).ToList();
            }

            PagedList<SanPham> models = new PagedList<SanPham>(lsSanPham.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentDanhMucID = DanhMucID;
            ViewBag.CurrentPage = pageNumber;
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc", DanhMucID);

            return View(models);
        }

        public IActionResult Filtter ( int DanhMucID, int Active = 0)
        {
            var url = $"/Admin/AdminSanPhams?DanhMucID={DanhMucID}";
            if (DanhMucID == 0 )
            {
                url = $"/Admin/AdminSanPhams";
            }
           
            return Json(new { status = "success", redirectUrl = url });
        }

        // GET: Admin/AdminSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.DanhMuc)
                .FirstOrDefaultAsync(m => m.SanPhamId == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/AdminSanPhams/Create
        public IActionResult Create()
        {
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc");
            return View();
        }

        // POST: Admin/AdminSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SanPhamId,TenSp,Avatar,MoTa,The,DanhMucId,GiaTien,GiamGia,TrangThai,NgayTao,NgayCapNhat")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.TenSp = Utilities.ToTitleCase(sanPham.TenSp);
               

                sanPham.NgayCapNhat = DateTime.Now;
                sanPham.NgayTao = DateTime.Now;
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc", sanPham.DanhMucId);
            return View(sanPham);
        }

        // GET: Admin/AdminSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc", sanPham.DanhMucId);
            return View(sanPham);
        }

        // POST: Admin/AdminSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SanPhamId,TenSp,Avatar,MoTa,The,DanhMucId,GiaTien,GiamGia,TrangThai,NgayTao,NgayCapNhat")] SanPham sanPham)
        {
            if (id != sanPham.SanPhamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sanPham.TenSp = Utilities.ToTitleCase(sanPham.TenSp);
                   

                    sanPham.NgayCapNhat = DateTime.Now.Date;
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.SanPhamId))
                    {
                        _notyfService.Success("Cập nhật thất bại");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc", sanPham.DanhMucId);
            return View(sanPham);
        }

        // GET: Admin/AdminSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.DanhMuc)
                .FirstOrDefaultAsync(m => m.SanPhamId == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/AdminSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.SanPhamId == id);
        }
    }
}
