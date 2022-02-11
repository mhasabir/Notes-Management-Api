using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesManagement.Service.Services
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAll(int userId);
        Todo GetDataById(int userId, int id);
        Todo Create(Todo todo);
        Todo Update(int userId, Todo todo);
        Todo Delete(int userId, int id);
    }
}
