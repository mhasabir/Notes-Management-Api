using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace NotesManagement.Repository.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetDataById(int userId);
        User GetDataByEmail(string email);
        User Create(User user);
        User Delete(User user);
    }
}
