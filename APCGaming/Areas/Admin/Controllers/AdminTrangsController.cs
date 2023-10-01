using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APCGaming.Models;
using PagedList.Core;
using System.IO;
using APCGaming.Helpper;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace APCGaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTrangsController : Controller
    {
        private readonly APCGamingContext _context;
        public INotyfService _notyfService { get; }
        public AdminTrangsController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminTrangs
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTrang = _context.Trangs.AsNoTracking().OrderByDescending(x => x.TrangId);
            PagedList<Trang> models = new PagedList<Trang>(lsTrang, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;


            return View(models);
        }


        // GET: Admin/AdminTrangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trang = await _context.Trangs
                .FirstOrDefaultAsync(m => m.TrangId == id);
            if (trang == null)
            {
                return NotFound();
            }

            return View(trang);
        }

        // GET: Admin/AdminTrangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminTrangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrangId,TenTrang,NoiDung,HinhAnh,TrangThai,TieuDe,NgayTao")] Trang trang)
        {
            if (ModelState.IsValid)
            {
                trang.NgayTao = DateTime.Now;
                _context.Add(trang);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(trang);
        }

        // GET: Admin/AdminTrangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trang = await _context.Trangs.FindAsync(id);
            if (trang == null)
            {
                return NotFound();
            }
            return View(trang);
        }

        // POST: Admin/AdminTrangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrangId,TenTrang,NoiDung,HinhAnh,TrangThai,TieuDe,NgayTao")] Trang trang)
        {
            if (id != trang.TrangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   

                    _context.Update(trang);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrangExists(trang.TrangId))
                    {
                        _notyfService.Success("Có lỗi xảy ra");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trang);
        }

        // GET: Admin/AdminTrangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trang = await _context.Trangs
                .FirstOrDefaultAsync(m => m.TrangId == id);
            if (trang == null)
            {
                return NotFound();
            }

            return View(trang);
        }

        // POST: Admin/AdminTrangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trang = await _context.Trangs.FindAsync(id);
            _context.Trangs.Remove(trang);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool TrangExists(int id)
        {
            return _context.Trangs.Any(e => e.TrangId == id);
        }
    }
}
