using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request
{
    public class LoginRequest
    {
        [Required]
        public string username { get; set; }
        
        [Required]
        public string password { get; set; }
    }
}
