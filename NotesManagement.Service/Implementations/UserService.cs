using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using NotesManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace NotesManagement.Service.Implementations
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User GetDataById(int userId)
        {
            return _userRepository.GetDataById(userId);
        }       
        public User GetDataByEmail(string email)
        {
            return _userRepository.GetDataByEmail(email);
        }
        public User Create(UserRegistration userRegistration)
        {
            var user = new User();
            (user.Salt, user.PasswordHash) = HashPassword(userRegistration.Password);
            user.Name = userRegistration.Name;
            user.Email = userRegistration.Email;
            user.DateOfBirth = userRegistration.DateOfBirth;
            return _userRepository.Create(user);
        }
        public User Update(int userId, User user)
        {
            var response = _userRepository.GetDataById(userId);
            if (response != null)
            {
                response.Email = user.Email;
            }
            return response;
        }
        private (string Salt, string Hashed) HashPassword(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            byte[] hashed = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return (Convert.ToBase64String(salt), Convert.ToBase64String(hashed));
        }
    }
}
