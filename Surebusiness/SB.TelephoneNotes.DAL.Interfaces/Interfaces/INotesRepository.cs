using SB.TelephoneNotes.DAL.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SB.TelephoneNotes.DAL.Interfaces
{
    public interface INotesRepository
    {
        Task<NoteEntity> Create(NoteEntity noteEntity);
        Task<NoteEntity> Get(int id);
        Task<List<NoteEntity>> GetAll();
        Task<NoteEntity> Update(NoteEntity noteEntity);
    }
}