using FinalProject.Areas.Admin.Models;
using FinalProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers.Account
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginVM model)
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            if (!ModelState.IsValid) return View(model);

            var existingUser = await _userManager.FindByNameAsync(model.Email);

            if (existingUser is null)
            {
                model.ErrorMessage = "Username or password is incorrect!";
                return View(model);
            }

            var result = await _signInManager
                .PasswordSignInAsync(existingUser, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                model.ErrorMessage = "Username or password is incorrect!";
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
