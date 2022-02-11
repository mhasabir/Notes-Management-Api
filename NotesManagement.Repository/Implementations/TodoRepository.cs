
using NotesManagement.Data;
using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Repository.Implementations
{
    public class TodoRepository : ITodoRepository
    {
        private readonly NotesManagementContext _context;

        public TodoRepository(NotesManagementContext context)
        {
            this._context = context;
        }
        public IEnumerable<Todo> GetAll(int userId)
        {
            return this._context.Todos.Where(x => x.UserId == userId);
        }
        public Todo GetDataById(int userId, int id)
        {
            return this._context.Todos.FirstOrDefault(x => x.UserId == userId && x.TodoId == id);
        }
        public Todo Create(Todo todo)
        {
            int count = this._context.Todos.Select(x => x.TodoId).DefaultIfEmpty(0).Max();
            todo.TodoId = count + 1;
            this._context.Todos.Add(todo);
            return todo;
        }
        public Todo Delete(Todo todo)
        {
            this._context.Todos.Remove(todo);
            return todo;
        }
    }
}
