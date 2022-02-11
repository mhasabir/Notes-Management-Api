
using NotesManagement.Data;
using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly NotesManagementContext _context;

        public UserRepository(NotesManagementContext context)
        {
            this._context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return this._context.Users;
        }
        public User GetDataById(int userId)
        {
            return this._context.Users.FirstOrDefault(x => x.UserId == userId);
        }       
        public User GetDataByEmail(string email)
        {
            return this._context.Users.FirstOrDefault(x => x.Email == email);
        }
        public User Create(User user)
        {
            int count = this._context.Users.Select(x => x.UserId).DefaultIfEmpty(0).Max();
            user.UserId = count + 1;
            this._context.Users.Add(user);
            return user;
        }
        public User Delete(User user)
        {
            this._context.Users.Remove(user);
            return user;
        }
    }
}
