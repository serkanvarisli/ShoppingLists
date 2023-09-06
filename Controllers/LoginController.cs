using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.ViewModel;
using Microsoft.AspNetCore.Authorization;
using ShoppingList.Models;
using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Controllers
{
    [Authorize]

    public class LoginController : Controller
    {
        MyDbContext _context;
        public object PageUtility { get; private set; }

        public LoginController(MyDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "UserAuthentication")]

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User model)
        {
            var user = _context.Users.FirstOrDefault(c => c.UserEmail == model.UserEmail && c.Password == model.Password);
            if (user != null)
            {
                await HttpContext.SignOutAsync("UserAuthentication");

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.UserEmail));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("UserAuthentication", principal, new AuthenticationProperties() { IsPersistent = false });
                Response.Cookies.Append("UserEmail", model.UserEmail);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı";

            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (_context.Users.Any(c => c.UserEmail == user.UserEmail))
                {
                    TempData["Hata"] = "Kullanıcı zaten kayıtlı";
                    return RedirectToAction("Register", "Login");
                }
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["Kayıt"] = "Kayıt başarılı giriş yapınız";
                return RedirectToAction("Register", "Login");

            }
        }
        [AllowAnonymous]
        public IActionResult Logout()
        {
            // Oturumu sonlandırma işlemleri
            HttpContext.SignOutAsync("UserAuthentication"); // Oturumu sonlandır
            return RedirectToAction("Index", "Home"); // Anasayfaya yönlendir
        }

        [Authorize(AuthenticationSchemes = "AdminAuthentication")]
        [AllowAnonymous]

        public IActionResult Admin()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [AllowAnonymous]

        [HttpPost]
        public async Task<IActionResult> Admin(AdminLoginViewModel model)
        {
            if (model.adminemail == "admin@gmail.com" && model.adminpassword == "123")
            {
                await HttpContext.SignOutAsync("AdminAuthentication");

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, model.adminemail));


                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("AdminAuthentication", principal, new AuthenticationProperties() { IsPersistent = false });

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı";

            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult AdminLogout()
        {
            // Oturumu sonlandırma işlemleri
            HttpContext.SignOutAsync("AdminAuthentication"); // Oturumu sonlandır
            return RedirectToAction("Index", "Admin"); // Anasayfaya yönlendir
        }
    }
}
