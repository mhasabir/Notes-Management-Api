using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using NotesManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Service.Implementations
{
    public class RegularNoteService : IRegularNoteService
    {
        readonly IRegularNoteRepository _regularNoteRepository;

        public RegularNoteService(IRegularNoteRepository regularNoteRepository)
        {
            this._regularNoteRepository = regularNoteRepository;
        }
        public IEnumerable<RegularNote> GetAll(int userId)
        {
            return _regularNoteRepository.GetAll(userId);
        }
        public RegularNote GetDataById(int userId, int id)
        {
            return _regularNoteRepository.GetDataById(userId, id);
        }
        public RegularNote Create(RegularNote entity)
        {
            return _regularNoteRepository.Create(entity);
        }
        public RegularNote Update(int userId, RegularNote entity)
        {
            var response = _regularNoteRepository.GetDataById(userId, entity.RegularNoteId);
            if (response != null)
            {
                response.Note = entity.Note;
            }
            return response;
        }
        public RegularNote Delete(int userId, int id)
        {
            var response = _regularNoteRepository.GetDataById(userId, id);
            if (response != null)
            {
                _regularNoteRepository.Delete(response);
                return response;
            }
            return response;
        }
    }
}
