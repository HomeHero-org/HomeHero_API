﻿using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace HomeHero_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteUser(string email)
        {
            _context.User.Remove(_context.User.FirstOrDefault(u => u.Email == email));
            return _context.SaveChanges() >= 0 ? true : false;

        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }
        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUsers()
        {
            return _context.User.Include(u => u.LocationResidence).Include(u => u.Role_User).ToList();
        }

        public bool existUser(string email)
        {
            var user = _context.User.FirstOrDefault(x => x.Email.Equals(email.Trim()));
            if (user == null) return false;
            return true;
        }

        public Task<UserLoginResponseDto> Login(UserLoginDto userloginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(UserRegisterDto userRegisterDto)
        {
            string hashedPassword = HashPassword(userRegisterDto.Password);
            var newUser = new User()
            {
                RoleID_User = userRegisterDto.RoleID_User,
                Email = userRegisterDto.Email,
                NamesUser = userRegisterDto.NamesUser,
                SurnamesUser = userRegisterDto.SurnamesUser,
                Password = hashedPassword,
                LocationResidenceID = userRegisterDto.LocationResidenceID
            };
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
            return _context.User
                .Include(u => u.LocationResidence)
                .Include(u => u.Role_User)
                .FirstOrDefault(u => u.Email.Equals(userRegisterDto.Email));
        }

        public async Task<User> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = _context.User
                .Include(u => u.LocationResidence)
                .Include(u => u.Role_User)
                .FirstOrDefault(u => u.Email == userUpdateDto.email);
            if(user == null) {
                return null;
            }
            if (!userUpdateDto.RealUserID.Trim().IsNullOrEmpty())
            {
                user.RealUserID = userUpdateDto.RealUserID.Trim();
            }
            if (!userUpdateDto.NamesUser.Trim().IsNullOrEmpty())
            {
                user.NamesUser = userUpdateDto.NamesUser.Trim();
            }
            if (!userUpdateDto.SurnamesUser.Trim().IsNullOrEmpty())
            {
                user.SurnamesUser = userUpdateDto.SurnamesUser.Trim();
            }
            if (userUpdateDto.SexUser != null)
            {
                user.SexUser = userUpdateDto.SexUser;
            }
            if (userUpdateDto.ProfilePicture != null && userUpdateDto.ProfilePicture.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    userUpdateDto.ProfilePicture.CopyTo(stream);
                    byte[] bytesImagen = stream.ToArray();
                    user.ProfilePicture = bytesImagen;
                }
            }
            if (userUpdateDto.Curriculum != null && userUpdateDto.Curriculum.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    userUpdateDto.Curriculum.CopyTo(stream);
                    byte[] bytesImagen = stream.ToArray();
                    user.Curriculum = bytesImagen;
                }
            }
            if( userUpdateDto.RoleID_User != user.RoleID_User)
            {
                user.RoleID_User = userUpdateDto.RoleID_User;
            }
            if (userUpdateDto.LocationResidenceID != user.LocationResidenceID)
            {
                user.LocationResidenceID = userUpdateDto.LocationResidenceID;
            }
            _context.SaveChanges();
            return user;

        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}