using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APCGaming.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using APCGaming.Helpper;
using APCGaming.Extension;
using Microsoft.AspNetCore.Http;

namespace APCGaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNhanViensController : Controller
    {
        private readonly APCGamingContext _context;
        public INotyfService _notyfService { get; }
        public AdminNhanViensController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminNhanViens
        public async Task<IActionResult> Index()
        {

            ViewData["ChucVuNhanVien"] = new SelectList(_context.ChucVus, "ChucVuId", "TenChucVu");

            List<SelectListItem> lsTrangThai = new List<SelectListItem>();
            lsTrangThai.Add(new SelectListItem() { Text = "Active", Value = "1" });
            lsTrangThai.Add(new SelectListItem() { Text = "Block", Value = "0" });
            ViewData["lsTrangThai"] = lsTrangThai;

            var aPCGamingContext = _context.NhanViens.Include(n => n.ChucVu);
            return View(await aPCGamingContext.ToListAsync());
        }

        // GET: Admin/AdminNhanViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.ChucVu)
                .FirstOrDefaultAsync(m => m.TaiKhoanId == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: Admin/AdminNhanViens/Create
        public IActionResult Create()
        {
            ViewData["ChucVuNhanVien"] = new SelectList(_context.ChucVus, "ChucVuId", "TenChucVu");
            return View();
        }

        // POST: Admin/AdminNhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaiKhoanId,TenNv,HoNv,Sđt,Email,ChuoiMaHoaMk,MatKhau,TrangThai,ChucVuId,NgayVaoLam,LanCuoiDn")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                string chuoiMaHoaMK = Utilities.GetRandomKey();
                nhanVien.ChuoiMaHoaMk = chuoiMaHoaMK;

                nhanVien.MatKhau = (nhanVien.Sđt + chuoiMaHoaMK.Trim()).ToMD5();
                

                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới tài khoản thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChucVuNhanVien"] = new SelectList(_context.ChucVus, "ChucVuId", "TenChucVu", nhanVien.ChucVuId);
            return View(nhanVien);
        }
        

        // GET: Admin/AdminNhanViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["ChucVuNhanVien"] = new SelectList(_context.ChucVus, "ChucVuId", "TenChucVu", nhanVien.ChucVuId);
            return View(nhanVien);
        }

        // POST: Admin/AdminNhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaiKhoanId,TenNv,HoNv,Sđt,Email,ChuoiMaHoaMk,MatKhau,TrangThai,ChucVuId,NgayVaoLam,LanCuoiDn")] NhanVien nhanVien)
        {
            if (id != nhanVien.TaiKhoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.TaiKhoanId))
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
            ViewData["ChucVuNhanVien"] = new SelectList(_context.ChucVus, "ChucVuId", "TenChucVu", nhanVien.ChucVuId);
            return View(nhanVien);
        }

        // GET: Admin/AdminNhanViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.ChucVu)
                .FirstOrDefaultAsync(m => m.TaiKhoanId == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: Admin/AdminNhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanViens.Any(e => e.TaiKhoanId == id);
        }
    }
}
