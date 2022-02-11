using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using NotesManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Service.Implementations
{
    public class ReminderService : IReminderService
    {
        readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            this._reminderRepository = reminderRepository;
        }
        public IEnumerable<Reminder> GetAll(int userId)
        {
            return _reminderRepository.GetAll(userId);
        }
        public Reminder GetDataById(int userId, int id)
        {
            return _reminderRepository.GetDataById(userId, id);
        }
        public Reminder Create(Reminder reminder)
        {
            return _reminderRepository.Create(reminder);
        }
        public Reminder Update(int userId, Reminder reminder)
        {
            var response = _reminderRepository.GetDataById(userId, reminder.ReminderId);
            if (response != null)
            {
                response.Note = reminder.Note;
                response.ReminderDateTime = reminder.ReminderDateTime;
            }
            return response;
        }
        public Reminder Delete(int userId, int id)
        {
            var response = _reminderRepository.GetDataById(userId, id);
            if (response != null)
            {
                _reminderRepository.Delete(response);
                return response;
            }
            return response;
        }
    }
}

