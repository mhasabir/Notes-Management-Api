using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Service.Services
{
    public interface IReminderService
    {
        IEnumerable<Reminder> GetAll(int userId);
        Reminder GetDataById(int userId, int id);
        Reminder Create(Reminder reminder);
        Reminder Update(int userId, Reminder reminder);
        Reminder Delete(int userId, int id);
    }
}