using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebPerfomanceIndividualSystem.Services;

namespace WebPerfomanceIndividualSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _service;

        public AccountController(AuthService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Auth");
        }
    }
}
