using System.ComponentModel.DataAnnotations;

namespace MinimalApiSample.Models
{
    public class UserLoginAuth
    {

        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
