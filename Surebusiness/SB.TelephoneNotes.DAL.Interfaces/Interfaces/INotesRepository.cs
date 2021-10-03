using SB.TelephoneNotes.DAL.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.TelephoneNotes.DAL.Interfaces
{
    public interface INotesRepository
    {
        Task<NoteEntity> Create(NoteEntity noteEntity);
        Task<NoteEntity> Get(int id);
        Task<List<NoteEntity>> GetAll();
        IQueryable<NoteEntity> GetIQueryable();
        Task<NoteEntity> Update(NoteEntity noteEntity);
    }
}