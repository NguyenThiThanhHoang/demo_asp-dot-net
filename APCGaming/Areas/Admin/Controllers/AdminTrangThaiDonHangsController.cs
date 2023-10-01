using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APCGaming.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace APCGaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTrangThaiDonHangsController : Controller
    {
        private readonly APCGamingContext _context;
        public INotyfService _notyfService { get; }
        public AdminTrangThaiDonHangsController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminTrangThaiDonHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrangThaiDonHangs.ToListAsync());
        }

        // GET: Admin/AdminTrangThaiDonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangThaiDonHang = await _context.TrangThaiDonHangs
                .FirstOrDefaultAsync(m => m.TrangThaiDonHangId == id);
            if (trangThaiDonHang == null)
            {
                return NotFound();
            }

            return View(trangThaiDonHang);
        }

        // GET: Admin/AdminTrangThaiDonHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminTrangThaiDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrangThaiDonHangId,Ten,MoTa")] TrangThaiDonHang trangThaiDonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trangThaiDonHang);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(trangThaiDonHang);
        }

        // GET: Admin/AdminTrangThaiDonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangThaiDonHang = await _context.TrangThaiDonHangs.FindAsync(id);
            if (trangThaiDonHang == null)
            {
                return NotFound();
            }
            return View(trangThaiDonHang);
        }

        // POST: Admin/AdminTrangThaiDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrangThaiDonHangId,Ten,MoTa")] TrangThaiDonHang trangThaiDonHang)
        {
            if (id != trangThaiDonHang.TrangThaiDonHangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trangThaiDonHang);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrangThaiDonHangExists(trangThaiDonHang.TrangThaiDonHangId))
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
            return View(trangThaiDonHang);
        }

        // GET: Admin/AdminTrangThaiDonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangThaiDonHang = await _context.TrangThaiDonHangs
                .FirstOrDefaultAsync(m => m.TrangThaiDonHangId == id);
            if (trangThaiDonHang == null)
            {
                return NotFound();
            }

            return View(trangThaiDonHang);
        }

        // POST: Admin/AdminTrangThaiDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trangThaiDonHang = await _context.TrangThaiDonHangs.FindAsync(id);
            _context.TrangThaiDonHangs.Remove(trangThaiDonHang);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa quyền truy cập thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool TrangThaiDonHangExists(int id)
        {
            return _context.TrangThaiDonHangs.Any(e => e.TrangThaiDonHangId == id);
        }
    }
}
