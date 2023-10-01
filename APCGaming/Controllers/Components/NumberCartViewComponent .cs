using APCGaming.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APCGaming.Extension;

namespace APCGaming.Controllers.Components
{
    public class NumberCartViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<ThanhPhanGioiHang>>("GioHang");
            return View(cart);
        }
    }
}
