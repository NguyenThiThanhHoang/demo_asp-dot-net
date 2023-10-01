using APCGaming.Extension;
using APCGaming.Helpper;
using APCGaming.Models;
using APCGaming.ModelViews;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APCGaming.Controllers
{
    [Authorize]
    public class khachHangsController : Controller
    {
        private readonly APCGamingContext _context;

        public INotyfService _notyfService { get; }
        public khachHangsController(APCGamingContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidatePhone(string Phone)
        {
            try
            {
                var khachHang = _context.KhachHangs.SingleOrDefault(x => x.Sđt == Int32.Parse(Phone));
                if (khachHang != null)
                    return Json(data: "Số điện thoại : " + Phone + "đã được sử dụng");

                return Json(data: true);

            }
            catch
            {
                return Json(data: true);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string Email)
        {
            try
            {
                var khachHang = _context.KhachHangs.SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
                if (khachHang != null)
                    return Json(data: "Email : " + Email + " đã được sử dụng");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }
        [Route("tai-khoan-cua-toi", Name = "Dashboard")]
        public IActionResult Dashboard()
        {
            var taiKhoanID = HttpContext.Session.GetString("KhachHangId");
            if (taiKhoanID != null)
            {
                var khachHang = _context.KhachHangs.SingleOrDefault(x => x.KhachHangId == Convert.ToInt32(taiKhoanID));
                if (khachHang != null)
                {
                    try
                    {
                        var lsDonHang = _context.DonHangs
                                       .Include(x => x.TrangThaiDonHang)
                                       .AsNoTracking()
                                       .Where(x => x.KhachHangId == khachHang.KhachHangId)
                                       .OrderByDescending(x => x.NgayTao)
                                       .ToList();
                        ViewBag.DonHang = lsDonHang;
                        return View(khachHang);
                    }
                    catch 
                    {
                        return View(khachHang);
                    }
                }

            }
            return RedirectToAction("Login");
        }
       

        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky", Name = "DangKy")]
        public IActionResult DangkyTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky", Name = "DangKy")]
        public async Task<IActionResult> DangkyTaiKhoan(RegisterViewModel taiKhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string chuoiMaHoa = Utilities.GetRandomKey();
                    KhachHang khachHang = new KhachHang
                    {
                        HoKh = taiKhoan.Ho.Trim(),
                        TenKh = taiKhoan.Ten.Trim(),
                        TenDangNhap = taiKhoan.TenĐN.Trim(),
                        Sđt = Int32.Parse(taiKhoan.Phone.Trim().ToLower()),
                        Email = taiKhoan.Email.Trim().ToLower(),
                        MatKhau = (taiKhoan.Password + chuoiMaHoa.Trim()).ToMD5(),
                        TrangThai = true,
                        ChuoiMaHoaMk = chuoiMaHoa
                    };
                    try
                    {
                        _context.Add(khachHang);
                        await _context.SaveChangesAsync();
                        //Lưu Session MaKh
                        HttpContext.Session.SetString("KhachHangId", khachHang.KhachHangId.ToString());
                        var taiKhoanID = HttpContext.Session.GetString("KhachHangId");

                        //Identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,khachHang.HoKh, khachHang.TenKh),
                            new Claim("KhachHangId", khachHang.KhachHangId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng ký thành công");
                        return RedirectToAction("Dashboard", "KhachHangs");
                    }
                    catch
                    {
                        return RedirectToAction("DangkyTaiKhoan", "KhachHangs");
                    }
                }
                else
                {
                    return View(taiKhoan);
                }
            }
            catch
            {
                return View(taiKhoan);
            }
        }
        [AllowAnonymous]
        [Route("dang-nhap", Name = "DangNhap")]
        public IActionResult Login(string returnUrl = null)
        {
            var taiKhoanID = HttpContext.Session.GetString("KhachHangId");
            if (taiKhoanID != null)
            {
                return RedirectToAction("Dashboard", "KhachHangs");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap", Name = "DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var khachhang = _context.KhachHangs.AsNoTracking().SingleOrDefault(x => x.TenDangNhap.Trim() == customer.UserName.Trim());
                    if (khachhang == null) return RedirectToAction("DangkyTaiKhoan");


                    string pass = (customer.Password + khachhang.ChuoiMaHoaMk.Trim()).ToMD5();
                    if (khachhang.MatKhau != pass)
                    {
                        _notyfService.Success("Thông tin đăng nhập chưa chính xác");
                        return View(customer);
                    }
                    //kiem tra xem account co bi disable hay khong

                    if (khachhang.TrangThai == false)
                    {
                        return RedirectToAction("ThongBao", "KhachHangs");
                    }

                    //Luu Session MaKh
                    HttpContext.Session.SetString("KhachHangId", khachhang.KhachHangId.ToString());
                    var taikhoanID = HttpContext.Session.GetString("KhachHangId");

                    //Identity
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,khachhang.HoKh, khachhang.TenKh),
                        new Claim("KhachHangId", khachhang.KhachHangId.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Success("Đăng nhập thành công");
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Dashboard", "KhachHangs");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
            }
            catch
            {
                return RedirectToAction("DangkyTaiKhoan", "KhachHangs");
            }
            return View(customer);
        }
        [HttpGet]
        [Route("dang-xuat", Name = "DangXuat")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("KhachHangId");
            _notyfService.Success("Đăng xuất thành công");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("KhachHangId");
                if (taikhoanID == null)
                {
                    return RedirectToAction("Login", "KhachHangs");
                }
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.KhachHangs.Find(Convert.ToInt32(taikhoanID));
                    if (taikhoan == null) return RedirectToAction("Login", "KhachHangs");
                    var pass = (model.PasswordNow.Trim() + taikhoan.ChuoiMaHoaMk.Trim()).ToMD5();
                    {
                        string passnew = (model.Password.Trim() + taikhoan.ChuoiMaHoaMk.Trim()).ToMD5();
                        taikhoan.MatKhau = passnew;
                        _context.Update(taikhoan);
                        _context.SaveChanges();
                        _notyfService.Success("Đổi mật khẩu thành công");
                        return RedirectToAction("Dashboard", "KhachHangs");
                    }
                }
            }
            catch
            {
                _notyfService.Success("Thay đổi mật khẩu không thành công");
                return RedirectToAction("Dashboard", "KhachHangs");
            }
            _notyfService.Success("Thay đổi mật khẩu không thành công");
            return RedirectToAction("Dashboard", "KhachHangs");
        }
    }
}
