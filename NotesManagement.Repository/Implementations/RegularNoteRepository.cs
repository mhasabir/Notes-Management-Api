
using NotesManagement.Data;
using NotesManagement.Entity.Models;
using NotesManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NotesManagement.Repository.Implementations
{
    public class RegularNoteRepository : IRegularNoteRepository
    {
        private readonly NotesManagementContext _context;

        public RegularNoteRepository(NotesManagementContext context)
        {
            this._context = context;
        }
        public IEnumerable<RegularNote> GetAll(int userId)
        {
            return this._context.RegularNotes.Where(x => x.UserId == userId);
        }
        public RegularNote GetDataById(int userId, int id)
        {
            return this._context.RegularNotes.FirstOrDefault(x => x.UserId == userId && x.RegularNoteId == id);
        }
        public RegularNote Create(RegularNote entity)
        {
            int count = this._context.RegularNotes.Select(x => x.RegularNoteId).DefaultIfEmpty(0).Max();
            entity.RegularNoteId = count + 1;
            this._context.RegularNotes.Add(entity);
            return entity;
        }
        public RegularNote Delete(RegularNote entity)
        {
            this._context.RegularNotes.Remove(entity);
            return entity;
        }
    }
}
