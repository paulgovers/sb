using SB.TelephoneNotes.BLL.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SB.TelephoneNotes.BLL.Interfaces
{
    public interface IQueryPhoneNotesService
    {
        Task<List<PhoneNote>> GetAll();
        Task<PhoneNote> GetById(int id);
        PagedList<PhoneNote> GetNotes(NotesFilter notesFilter);

    }
}