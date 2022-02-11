using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesManagement.Service.Services
{
    public interface IRegularNoteService
    {
        IEnumerable<RegularNote> GetAll(int userId);
        RegularNote GetDataById(int userId, int id);
        RegularNote Create(RegularNote entity);
        RegularNote Update(int userId, RegularNote entity);
        RegularNote Delete(int userId, int id);
    }
}
