namespace HomeHero_API.Models.Dto.UserDto
{
    public class UserLoginResponseDto
    {
        public Object User { get; set; }
        public string Token { get; set; }

        public string? RefresherToken {  get; set; }
    }
}
