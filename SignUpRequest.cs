namespace EcomwebProjNew.Models
{
    public class SignUpRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
