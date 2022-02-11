
using NotesManagement.Data;
using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Repository.Implementations
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly NotesManagementContext _context;

        public ReminderRepository(NotesManagementContext context)
        {
            this._context = context;
        }
        public IEnumerable<Reminder> GetAll(int userId)
        {
            return this._context.Reminders.Where(x => x.UserId == userId);
        }
        public Reminder GetDataById(int userId, int id)
        {
            return this._context.Reminders.FirstOrDefault(x => x.UserId == userId && x.ReminderId == id);
        }
        public Reminder Create(Reminder reminder)
        {
            int count = this._context.Reminders.Select(x => x.ReminderId).DefaultIfEmpty(0).Max();
            reminder.ReminderId = count + 1;
            this._context.Reminders.Add(reminder);
            return reminder;
        }
        public Reminder Delete(Reminder reminder)
        {
            this._context.Reminders.Remove(reminder);
            return reminder;
        }
    }
}
