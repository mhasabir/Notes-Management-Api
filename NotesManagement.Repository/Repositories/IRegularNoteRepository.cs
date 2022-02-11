using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace NotesManagement.Repository.Repositories
{
    public interface IRegularNoteRepository
    {
        IEnumerable<RegularNote> GetAll(int userId);
        RegularNote GetDataById(int userId, int id);
        RegularNote Create(RegularNote entity);
        RegularNote Delete(RegularNote entity);
    }
}
