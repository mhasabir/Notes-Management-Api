using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using NotesManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesManagement.Service.Implementations
{
    public class TodoService : ITodoService
    {
        readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            this._todoRepository = todoRepository;
        }
        public IEnumerable<Todo> GetAll(int userId)
        {
            return _todoRepository.GetAll(userId);
        }
        public Todo GetDataById(int userId, int id)
        {
            return _todoRepository.GetDataById(userId, id);
        }
        public Todo Create(Todo todo)
        {
            return _todoRepository.Create(todo);
        }
        public Todo Update(int userId, Todo todo)
        {
            var response = _todoRepository.GetDataById(userId, todo.TodoId);
            if (response != null)
            {
                response.Note = todo.Note;
            }
            return response;
        }
        public Todo Delete(int userId, int id)
        {
            var response = _todoRepository.GetDataById(userId, id);
            if (response != null)
            {
                _todoRepository.Delete(response);
                return response;
            }
            return response;
        }
    }
}
