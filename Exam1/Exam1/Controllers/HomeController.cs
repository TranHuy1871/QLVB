using Exam1.Handler;
using Exam1.Hubs;
using Exam1.Models;
using Exam1.Models.DatabaseContext;
using Exam1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Exam1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<WebHub> _hubContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserHandler _handler;

        public HomeController(ILogger<HomeController> logger, IUserHandler handler, IHubContext<WebHub> hubContext)
        {
            _hubContext = hubContext;
            _logger = logger;
            _handler = handler;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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

            var users = await _handler.GetAllAsync();
            if (users.Select(x => x.Email).Contains(model.Email))
            {
                var user = users.FirstOrDefault(x => x.Email.Equals(model.Email));

                if (user.Password.Equals(model.Password))
                {
                    List<Claim> claims = new List<Claim>();

                    claims.Add(new Claim("userId", user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, "AuthCookie");
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity[] { claimsIdentity });
                    await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties
                    {
                        IsPersistent = model.IsRememberMe,

                    });
                    await _hubContext.Clients.All.SendAsync("LoginAlert", user.Name + " - " + user.Email + " has loged in");

                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Password", "Pass sai");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Email sai");
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
