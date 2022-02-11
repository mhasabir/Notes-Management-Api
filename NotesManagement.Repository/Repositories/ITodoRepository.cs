using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace NotesManagement.Repository.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll(int userId);
        Todo GetDataById(int userId, int id);
        Todo Create(Todo todo);
        Todo Delete(Todo todo);
    }
}
