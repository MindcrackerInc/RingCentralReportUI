using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RingCentralReport.Models;


namespace RingCentralReport.Controllers
{
    public class AccountController : Controller
    {
        private readonly RignCentral_ReportingContext _context;
        private readonly IsecurityProvider _securityProvider;
        public AccountController(RignCentral_ReportingContext context
            , IsecurityProvider isecurityProvider)
        {
            _context = context;
            _securityProvider = isecurityProvider;
        }
        public IActionResult Login()
        {
             var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                 //userInfo.Password = _securityProvider.Decrypt(userInfo.Password);
                var result = await _context.UserInfos.FirstOrDefaultAsync(X => X.Email == userInfo.Email && X.Password == userInfo.Password);
                if (result == null)
                {
                    ViewBag.ErrorMessage = "Email or Password is incorrect";
                    return View("../Login/Login");
                }
                else
                {
                    ViewBag.ErrorMessage = "Email or Password is correct";

                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, result.DisplayName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                }
                return RedirectToAction("Index", "Report");
            }
            return View(userInfo);
        }
        
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

    }
}
