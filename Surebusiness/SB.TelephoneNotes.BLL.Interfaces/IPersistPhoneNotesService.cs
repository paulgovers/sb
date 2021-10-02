using SB.TelephoneNotes.BLL.Interfaces.Commands;
using SB.TelephoneNotes.BLL.Interfaces.Models;
using System.Threading.Tasks;

namespace SB.TelephoneNotes.BLL.Interfaces
{
    public interface IPersistPhoneNotesService
    {
        Task<PhoneNote> Save(CreatePhoneNoteCommand createPhoneNoteCommand);
        Task<PhoneNote> UpdateAssignedTo(int id, string assignedTo);
        Task<PhoneNote> UpdateStatus(int id, string status);
    }
}