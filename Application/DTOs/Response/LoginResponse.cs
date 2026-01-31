using Application.DTOs.Response;

namespace Application.DTOs.Response
{
    public class LoginResponse
    {
        public UserResponse User { get; set; }
        public string Token { get; set; }
    }
}
