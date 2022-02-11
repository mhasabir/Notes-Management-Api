using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace NotesManagement.Repository.Repositories
{
    public interface IReminderRepository
    {
        IEnumerable<Reminder> GetAll(int userId);
        Reminder GetDataById(int userId, int id);
        Reminder Create(Reminder reminder);
        Reminder Delete(Reminder reminder);
    }
}
