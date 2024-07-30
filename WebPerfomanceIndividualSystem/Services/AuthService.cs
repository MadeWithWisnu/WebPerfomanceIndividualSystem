using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerformanceIndividualBusiness.Interfaces;
using System.Security.Claims;
using System.Security.Principal;
using WebPerfomanceIndividualSystem.ViewModels;
using PerformanceIndividualDataAccess.Models;
using PerformanceIndividualBusiness.Exceptions;

namespace WebPerfomanceIndividualSystem.Services
{
    public class AuthService
    {
        private readonly IAccountRepository _accountRepository;
        public AuthService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        private ClaimsPrincipal GetPrincipal(AuthLoginVM model)
        {
            List<Claim> claims = new List<Claim>{
            new Claim(ClaimTypes.Name, model.Username),
            new Claim(ClaimTypes.Role, model.Role),
        };
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(identity);
        }

        private AuthenticationTicket GetAuthenticationTicket(ClaimsPrincipal principal)
        {
            AuthenticationProperties authenticationProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.Now,
                ExpiresUtc = DateTime.Now.AddMinutes(30),
                AllowRefresh = false
            };
            return new AuthenticationTicket(principal, authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public AuthenticationTicket GetTicket(AuthLoginVM model)
        {
            User user = _accountRepository.Get(model.Username);
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) throw new UsernamePasswordException("Password tidak terdaftar");
            if (user.Username != model.Role) throw new Exception("Role tidak sesuai");

            ClaimsPrincipal principal = GetPrincipal(model);
            return GetAuthenticationTicket(principal);
        }

        private List<SelectListItem> GetRoles()
        {
            return new List<SelectListItem>{
            new SelectListItem{
                Text = "Admin",
                Value = "admin"
            },
            new SelectListItem{
                Text = "Employee",
                Value = "employee"
            },
            new SelectListItem{
                Text = "Superior",
                Value = "superior"
            },
        };

        }
    }
}
