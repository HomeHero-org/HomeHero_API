﻿namespace HomeHero_API.Models.Dto.UserDto
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
    }
}
