using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Service.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetDataById(int userId);
        User GetDataByEmail(string email);
        User Create(UserRegistration userRegistration);
        User Update(int userId, User user);
    }
}
