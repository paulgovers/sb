using Microsoft.EntityFrameworkCore;
using SB.TelephoneNotes.DAL.Interfaces;
using SB.TelephoneNotes.DAL.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SB.TelephoneNotes.DAL.EF.Repositories
{
    public class NotesRepository : INotesRepository
    {
        PhoneNotesDbContext _phoneNotesDbContext;
        public NotesRepository(PhoneNotesDbContext phoneNotesDbContext)
        {
            _phoneNotesDbContext = phoneNotesDbContext;
        }
        public async Task<List<NoteEntity>> GetAll()
        {
            return await _phoneNotesDbContext.Notes.OrderByDescending(x=>x.Id).ToListAsync();
        }

        /* public IQueryable<NoteEntity> GetWhere(Expression<Func<NoteEntity, bool>> predicate)
         {
             return _phoneNotesDbContext.Set<NoteEntity>().Where(predicate).AsNoTracking();
         }*/

        public async Task<NoteEntity> Get(int id)
        {
            return await _phoneNotesDbContext.Notes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<NoteEntity> Create(NoteEntity noteEntity)
        {
            await _phoneNotesDbContext.AddAsync(noteEntity);
            await _phoneNotesDbContext.SaveChangesAsync();
            return noteEntity;
        }

        public async Task<NoteEntity> Update(NoteEntity noteEntity)
        {
            _phoneNotesDbContext.Update(noteEntity);
            await _phoneNotesDbContext.SaveChangesAsync();
            return noteEntity;
        }
    }
}
