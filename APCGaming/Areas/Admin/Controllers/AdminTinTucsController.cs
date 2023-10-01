using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APCGaming.Models;
using PagedList.Core;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.IO;
using APCGaming.Helpper;

namespace APCGaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTinTucsController : Controller
    {
        private readonly APCGamingContext _context;
        public INotyfService _notyfService { get; }

        public AdminTinTucsController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminTinTucs
        public IActionResult Index(int? page)
        {
            var ls = _context.TinTucs.AsNoTracking().ToList();
            foreach (var item in ls)
            {
                if (item.NgayTao == null)
                {
                    item.NgayTao = DateTime.Now;
                    _context.Update(item);
                    _context.SaveChanges();
                }
            }

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTinTuc = _context.TinTucs.AsNoTracking().OrderByDescending(x => x.TinTucId);
            PagedList<TinTuc> models = new PagedList<TinTuc>(lsTinTuc, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);
        }

        // GET: Admin/AdminTinTucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs
                .Include(t => t.DanhMuc)
                .FirstOrDefaultAsync(m => m.TinTucId == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // GET: Admin/AdminTinTucs/Create
        public IActionResult Create()
        {
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc");
            ViewData["NhanVien"] = new SelectList(_context.NhanViens, "TaiKhoanId", "HoNv");
            return View();
        }

        // POST: Admin/AdminTinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TinTucId,TieuDe,MoTaNgan,MoTaDai,HinhAnh,TrangThai,NgayTao,TacGia,IsHot,IsNewfeed,Views,DanhMucId")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                tinTuc.NgayTao = DateTime.Now;
                _context.Add(tinTuc);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc", tinTuc.DanhMucId);
            return View(tinTuc);
        }

        // GET: Admin/AdminTinTucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs.FindAsync(id);
            if (tinTuc == null)
            {
                return NotFound();
            }
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc", tinTuc.DanhMucId);
            return View(tinTuc);
        }

        // POST: Admin/AdminTinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TinTucId,TieuDe,MoTaNgan,MoTaDai,HinhAnh,TrangThai,NgayTao,TacGia,IsHot,IsNewfeed,Views,DanhMucId")] TinTuc tinTuc)
        {
            if (id != tinTuc.TinTucId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(tinTuc);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinTucExists(tinTuc.TinTucId))
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
            ViewData["DanhMuc"] = new SelectList(_context.DanhMucs, "DanhMucId", "TenDanhMuc", tinTuc.DanhMucId);
            return View(tinTuc);
        }

        // GET: Admin/AdminTinTucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs
                .Include(t => t.DanhMuc)
                .FirstOrDefaultAsync(m => m.TinTucId == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // POST: Admin/AdminTinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinTuc = await _context.TinTucs.FindAsync(id);
            _context.TinTucs.Remove(tinTuc);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool TinTucExists(int id)
        {
            return _context.TinTucs.Any(e => e.TinTucId == id);
        }
    }
}
