using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CreateUserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
