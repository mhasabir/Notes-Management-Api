using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using NotesManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Service.Implementations
{
    public class BookmarkService: IBookmarkService
    {
        readonly IBookmarkRepository _bookmarkRepository;

        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            this._bookmarkRepository = bookmarkRepository;
        }
        public IEnumerable<Bookmark> GetAll(int userId)
        {
            return _bookmarkRepository.GetAll(userId);
        }
        public Bookmark GetDataById(int userId, int id)
        {
            return _bookmarkRepository.GetDataById(userId, id);
        }
        public Bookmark Create(Bookmark bookmark)
        {
            return _bookmarkRepository.Create(bookmark);
        }
        public Bookmark Update(int userId, Bookmark bookmark)
        {
            var response = _bookmarkRepository.GetDataById(userId, bookmark.BookmarkId);
            if (response != null)
            {
                response.WebURL = bookmark.WebURL;
            }
            return response;
        }
        public Bookmark Delete(int userId, int id)
        {
            var response = _bookmarkRepository.GetDataById(userId, id);
            if (response != null)
            {
                _bookmarkRepository.Delete(response);
                return response;
            }
            return response;
        }
    }
}
