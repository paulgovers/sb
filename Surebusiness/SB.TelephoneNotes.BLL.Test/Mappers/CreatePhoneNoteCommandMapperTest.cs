using SB.TelephoneNotes.BLL.Interfaces.Commands;
using SB.TelephoneNotes.BLL.Mappers;
using Xunit;
using SB.TelephoneNotes.DAL.Interfaces.Entities;
using FluentAssertions;

namespace SB.TelephoneNotes.BLL.Test.Mappers
{
    public class CreatePhoneNoteCommandMapperTest
    {
        [Fact]
        public void GivenCreatePhoneNoteModel_WhenMapToNoteEntity_ThenEquivalentToNoteEntity()
        {
            var noteEntity = new NoteEntity
            {
                AssignedTo = "Piet",
                Status = "nieuw",
                Name = "Jan",
                Notes ="Dit is een notitie",
                PhoneNumber = "123456"
            };

            var createPhoneNote = new CreatePhoneNote
            {
                AssignedTo = "Piet",
                Status = "nieuw",
                Name = "Jan",
                Notes = "Dit is een notitie",
                PhoneNumber = "123456"
            };

            createPhoneNote.MapToNoteEntity().Should().BeEquivalentTo(noteEntity);
        }
    }
}
