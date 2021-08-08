using InsuranceClaimsApp.Exceptions;
using InsuranceClaimsApp.Interfaces.Services;
using InsuranceClaimsApp.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsuranceClaimsApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel loginInput)
        {
            if (loginInput == null || !ModelState.IsValid)
            {
                return View(loginInput);
            }
            try
            {
                var claimsPrincipal = await _accountService.AuthenticateUser(loginInput);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "LossTypes");
            }
            catch (FailedAuthenticationException failedAuthenticationException)
            {
                ModelState.AddModelError("other", failedAuthenticationException.Message);
                return View(loginInput);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}