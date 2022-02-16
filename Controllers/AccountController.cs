using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Security.Claims;
using _4Shapes.Models;
using _4Shapes.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace _4Shapes.Controllers
{
    public class AccountController : Controller
    {

        private readonly IDBService _dbSvc;
        private readonly IWebHostEnvironment _env;

        public AccountController(IDBService dbService, IWebHostEnvironment env)
        {
            _dbSvc = dbService;
            _env = env;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login( string StaffID, string Password, string ReturnUrl)
        {
            DataTable dt = _dbSvc.GetTable("SELECT * FROM Staff WHERE StaffId = '{0}' AND UserPw = HASHBYTES('SHA1', '{1}')", StaffID, Password);
            if (dt.Rows.Count == 1)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, StaffID)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Shapes/Index" : ReturnUrl);
            }
            else {
                ViewData["Message"] = "Incorrect User ID or Password";
                ViewData["MsgType"] = "warning";
                return View();
            }
                
        }
        public IActionResult Logoff(string returnUrl = null)
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Shapes");
        }
     

    }
}
