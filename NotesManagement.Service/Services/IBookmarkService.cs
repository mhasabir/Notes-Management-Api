using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Service.Services
{
    public interface IBookmarkService
    {
        IEnumerable<Bookmark> GetAll(int userId);
        Bookmark GetDataById(int userId, int id);
        Bookmark Create(Bookmark bookmark);
        Bookmark Update(int userId, Bookmark bookmark);
        Bookmark Delete(int userId, int id);
    }
}
