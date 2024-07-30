using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebPerfomanceIndividualSystem.Services;
using WebPerfomanceIndividualSystem.ViewModels;

namespace WebPerfomanceIndividualSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _service;

        public AuthController(AuthService service) { _service = service; }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthLoginVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AuthenticationTicket ticket = _service.GetTicket(model);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ticket.Principal,
                        ticket.Properties
                    );
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception exception)
                {
                    ViewBag.Message = exception.Message;
                    return View();
                }
            }
            return View();
        }

        [HttpGet("access-denied")]
        public IActionResult Denied()
        {
            return View();
        }
    }
}
