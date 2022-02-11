
using NotesManagement.Data;
using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Repository.Implementations
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly NotesManagementContext _context;

        public BookmarkRepository(NotesManagementContext context)
        {
            this._context = context;
        }
        public IEnumerable<Bookmark> GetAll(int userId)
        {
            return this._context.Bookmarks.Where(x => x.UserId == userId);
        }
        public Bookmark GetDataById(int userId, int id)
        {
            return this._context.Bookmarks.FirstOrDefault(x => x.UserId == userId && x.BookmarkId == id);
        }
        public Bookmark Create(Bookmark bookmark)
        {
            int count = this._context.Bookmarks.Select(x => x.BookmarkId).DefaultIfEmpty(0).Max();
            bookmark.BookmarkId = count + 1;
            this._context.Bookmarks.Add(bookmark);
            return bookmark;
        }
        public Bookmark Delete(Bookmark bookmark)
        {
            this._context.Bookmarks.Remove(bookmark);
            return bookmark;
        }
    }
}
