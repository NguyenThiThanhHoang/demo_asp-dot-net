using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APCGaming.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using PagedList.Core;
using Microsoft.AspNetCore.Authorization;

namespace APCGaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangsController : Controller
    {
        private readonly APCGamingContext _context;
        public INotyfService _notyfService { get; }

        public DonHangsController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/DonHangs
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var donHang = _context.DonHangs.Include(o => o.KhachHang).Include(o => o.TrangThaiDonHang)
                .AsNoTracking()
                .OrderBy(x => x.NgayTao);
            PagedList<DonHang> models = new PagedList<DonHang>(donHang, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;



            return View(models);
        }

        // GET: Admin/DonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.KhachHang)
                .Include(d => d.TrangThaiDonHang)
                .FirstOrDefaultAsync(m => m.DonHangId == id);
            if (donHang == null)
            {
                return NotFound();
            }

            var chitietdonhang = _context.ChiTietDonHangs
               .Include(x => x.SanPham)
               .AsNoTracking()
               .Where(x => x.DonHangId == donHang.DonHangId)
               .OrderBy(x => x.DonHangId)
               .ToList();
            ViewBag.ChiTiet = chitietdonhang;

            return View(donHang);
        }


        // GET: Admin/DonHangs/Create
        public IActionResult Create()
        {
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "HoKh");
            ViewData["TrangThaiDonHangId"] = new SelectList(_context.TrangThaiDonHangs, "TrangThaiDonHangId", "TrangThaiDonHangId");
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonHangId,KhachHangId,NgayTao,TrangThaiDonHangId,TrangThaiThanhToan,NgayThanhToan,GhiChu,TongTien")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "KhachHangId", "HoKh", donHang.KhachHangId);
            ViewData["TrangThaiDonHangId"] = new SelectList(_context.TrangThaiDonHangs, "TrangThaiDonHangId", "TrangThaiDonHangId", donHang.TrangThaiDonHangId);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["KhachHang"] = new SelectList(_context.KhachHangs, "KhachHangId", "TenKH", donHang.KhachHangId);
            ViewData["TrangThaiDonHang"] = new SelectList(_context.TrangThaiDonHangs, "TrangThaiDonHangId", "Ten", donHang.TrangThaiDonHangId);
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonHangId,KhachHangId,NgayTao,TrangThaiDonHangId,TrangThaiThanhToan,NgayThanhToan,GhiChu,TongTien")] DonHang donHang)
        {
            if (id != donHang.DonHangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.DonHangId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachHang"] = new SelectList(_context.KhachHangs, "KhachHangId", "TenKh", donHang.KhachHangId);
            ViewData["TrangThaiDonHang"] = new SelectList(_context.TrangThaiDonHangs, "TrangThaiDonHangId", "Ten", donHang.TrangThaiDonHangId);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.KhachHang)
                .Include(d => d.TrangThaiDonHang)
                .FirstOrDefaultAsync(m => m.DonHangId == id);
            if (donHang == null)
            {
                return NotFound();
            }

            var chitietdonhang = _context.ChiTietDonHangs
                .Include(x => x.SanPham)
                .AsNoTracking()
                .Where(x => x.DonHangId == donHang.DonHangId)
                .OrderBy(x => x.DonHangId)
                .ToList();
            ViewBag.ChiTiet = chitietdonhang;

            return View(donHang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            _context.DonHangs.Remove(donHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(int id)
        {
            return _context.DonHangs.Any(e => e.DonHangId == id);
        }
    }
}
