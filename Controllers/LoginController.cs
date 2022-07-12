using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RingCentralReport.Models;
namespace RingCentralReport.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly RignCentral_ReportingContext _context;
        private readonly SecurityProvider _securityProvider;
        private readonly IsecurityProvider _provider;
        public LoginController(RignCentral_ReportingContext context
            ,IsecurityProvider isecurityProvider)
        {
            _context = context;
            _provider = isecurityProvider;
        }

        // GET: Login
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserInfos.ToListAsync());
        }

        [Authorize]
        // GET: Login/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfos
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // GET: Login/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,DisplayName,UserName,Email,Password")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                //userInfo.Password = _provider.Encrypt(userInfo.Password);
                userInfo.CreatedDate = DateTime.Now;
                _context.Add(userInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
               // userInfo.Password = _securityProvider.Decrypt(userInfo.Password);
            var result =  await _context.UserInfos.FirstOrDefaultAsync(X => X.Email == userInfo.Email && X.Password == userInfo.Password);
                if(result == null)
                {
                    ViewBag.ErrorMessage = "Email or Password is incorrect";
                    return View("Login");
                }
                else
                {
                    ViewBag.ErrorMessage = "Email or Password is correct";

                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userInfo.Email)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                }
                return RedirectToAction("Index","Report");
            }
            return View(userInfo);
        }

        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return View(userInfo);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,DisplayName,UserName,Email,Password")] UserInfo userInfo)
        {
            if (id != userInfo.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userInfo.CreatedDate = DateTime.Now;
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInfoExists(userInfo.UserId))
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
            return View(userInfo);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfos
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInfo = await _context.UserInfos.FindAsync(id);
            _context.UserInfos.Remove(userInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInfos.Any(e => e.UserId == id);
        }
    }
}
