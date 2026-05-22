using Cliniq.DAL.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cliniq.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // =====================================
        // Register
        // =====================================

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(
            string fullName,
            string email,
            string password)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
     string.IsNullOrWhiteSpace(email) ||
     string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "All fields are required.");
                return View();
            }
            var user = new AppUser
            {
                UserName = email,   // Identity يعتمد على UserName
                Email = email,
                FullName = fullName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // تسجيل دخول تلقائي بعد إنشاء الحساب
                await _signInManager.SignInAsync(user, isPersistent: false);

                // تحويل إلى صفحة الـ Dashboard
                return RedirectToAction("Index", "Dashboard");
            }

            // عرض أخطاء الإنشاء
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        // =====================================
        // Login
        // =====================================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(
            string email,
            string password)
        {
            if (!ModelState.IsValid)
                return View();

            // لأننا خزّنا UserName = Email
            var result = await _signInManager.PasswordSignInAsync(
                email,
                password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View();
        }

        // =====================================
        // Logout
        // =====================================

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}