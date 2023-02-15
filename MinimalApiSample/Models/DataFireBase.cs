using System.ComponentModel.DataAnnotations;

namespace MinimalApiSample.Models
{
    public class DataFireBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
