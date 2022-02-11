using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesManagement.Data
{
    public class NotesManagementContext
    {
        public List<User> Users;
        public List<Bookmark> Bookmarks;
        public List<RegularNote> RegularNotes;
        public List<Reminder> Reminders;
        public List<Todo> Todos;

        public NotesManagementContext()
        {
            Users = new List<User>();
            Bookmarks = new List<Bookmark>();
            RegularNotes = new List<RegularNote>();
            Reminders = new List<Reminder>();
            Todos = new List<Todo>();
        }
    }
}
