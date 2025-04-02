namespace AlrightAPI.Models.Dto
{
    public class LoginDto
    {
        public required string NationalIDNumber { get; set; }
        public required string Password { get; set; }
    }
}
