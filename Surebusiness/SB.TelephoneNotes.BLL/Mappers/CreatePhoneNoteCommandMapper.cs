using SB.TelephoneNotes.BLL.Interfaces.Commands;
using SB.TelephoneNotes.DAL.Interfaces.Entities;

namespace SB.TelephoneNotes.BLL.Mappers
{
    public static class CreatePhoneNoteCommandMapper
    {
        public static NoteEntity MapToNoteEntity(this CreatePhoneNote createPhoneNoteCommand)
        {
            if (createPhoneNoteCommand == null)
                return null;

            return new NoteEntity()
            {
                Name = createPhoneNoteCommand.Name,
                Notes = createPhoneNoteCommand.Notes,
                PhoneNumber = createPhoneNoteCommand.PhoneNumber,
                Status = createPhoneNoteCommand.Status,
                AssignedTo = createPhoneNoteCommand.AssignedTo
            };
        }
    }
}
