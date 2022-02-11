using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace NotesManagement.Repository.Repositories
{
    public interface IBookmarkRepository
    {
        IEnumerable<Bookmark> GetAll(int userId);
        Bookmark GetDataById(int userId, int id);
        Bookmark Create(Bookmark bookmark);
        Bookmark Delete(Bookmark bookmark);
    }
}
