using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLVB.Handler;
using QLVB.Models;
using QLVB.Models.DatabaseContext;
using QLVB.Models.DataModels;
using QLVB.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QLVB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdminDbContext _db;
        private readonly IAdminHandler _handler;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IAdminHandler handler, AdminDbContext db)
        {
            _db = db;
            _handler = handler;
            _logger = logger;
        }

        //[Authorize]
        public IActionResult Index()
        {
            List<VanBan> vanBans = _db.VanBans.ToList();
            return View(vanBans);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var vanban = _db.VanBans.Find(id);
            return View(vanban);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VanBan vanBan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.VanBans.Add(vanBan);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var vb = _db.VanBans.Find(id);
            if(vb != null)
            {
                return View(vb);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VanBan vanBan)
        {
            if (ModelState.IsValid)
            {
                _db.VanBans.Update(vanBan);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            var vb = _db.VanBans.Find(id);
            if(vb != null)
            {
                _db.VanBans.Remove(vb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Find(int id)
        {
            var vb = _db.VanBans.Find(id);
            if(vb != null) {
                return View(vb);
            }
            return NotFound();
        }

        public IActionResult Login()
        {
            if (HttpContext.User.Identity == null || !HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, String returnUrl = "/")
        {
            ViewData["returnUrl"] = returnUrl;

            var admins = await _handler.GetAllAsync();
            if (admins.Select(x => x.Email).Contains(model.Email))
            {
                var admin = admins.FirstOrDefault(x => x.Email == model.Email);
                if (admin.Password.Equals(model.Password))
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("MaNV", admin.MaNV.ToString()));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, admin.MaNV.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, "AuthCookie");
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity[] { claimsIdentity });

                    await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties
                    {
                        //IsPersistent = model.IsRememberMe,

                    });
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Pass", "Sai Pass");
                }
            }
            else
            {
                ModelState.AddModelError("Mail", "Sai Email");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
