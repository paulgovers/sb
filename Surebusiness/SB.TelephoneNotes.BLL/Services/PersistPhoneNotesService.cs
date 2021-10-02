using SB.TelephoneNotes.BLL.Interfaces.Commands;
using SB.TelephoneNotes.BLL.Interfaces.Models;
using SB.TelephoneNotes.DAL.Interfaces;
using SB.TelephoneNotes.BLL.Mappers;
using System.Threading.Tasks;
using SB.TelephoneNotes.BLL.Interfaces;

namespace SB.TelephoneNotes.BLL.Services
{
    public class PersistPhoneNotesService : IPersistPhoneNotesService
    {
        INotesRepository _notesRepository;
        public PersistPhoneNotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        public async Task<PhoneNote> Save(CreatePhoneNoteCommand createPhoneNoteCommand)
        {
            var noteEntity = createPhoneNoteCommand.MapToNoteEntity();
            noteEntity.CreateDate = System.DateTime.Now;
            await _notesRepository.Create(noteEntity);
            return noteEntity.MapToDomainModel();
        }
        public async Task<PhoneNote> UpdateStatus(int id, string status)
        {
            var noteEntity = await _notesRepository.Get(id);
            noteEntity.Status = status;
            await _notesRepository.Update(noteEntity);
            return noteEntity.MapToDomainModel(); ;
        }

        public async Task<PhoneNote> UpdateAssignedTo(int id, string assignedTo)
        {
            var noteEntity = await _notesRepository.Get(id);
            noteEntity.AssignedTo = assignedTo;
            await _notesRepository.Update(noteEntity);
            return noteEntity.MapToDomainModel(); ;
        }
    }
}
