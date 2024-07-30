using System.ComponentModel.DataAnnotations;

namespace WebPerfomanceIndividualSystem.ViewModels
{
    public class AuthLoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
