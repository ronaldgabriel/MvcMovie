using System.ComponentModel.DataAnnotations;

namespace MinimalApiSample.Models
{
    public class FireBaseModel
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
        public string TokenFire { get; set; }
    }
}
