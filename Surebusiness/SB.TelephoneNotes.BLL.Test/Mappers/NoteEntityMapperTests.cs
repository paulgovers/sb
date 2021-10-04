using SB.TelephoneNotes.BLL.Mappers;
using Xunit;
using FluentAssertions;
using SB.TelephoneNotes.DAL.Interfaces.Entities;
using SB.TelephoneNotes.BLL.Interfaces.Models;

namespace SB.TelephoneNotes.BLL.Test.Mappers
{
    public class NoteEntityMapperTests
    {
        [Fact]
        public void GivenNoteEntity_WhenMapToDomainModel_ThenEquivalentToNoteEntity()
        { 
            var noteEntity = new NoteEntity
            {
                Id = 1,
                AssignedTo = "Piet",
                Status = "nieuw",
                Name = "Jan",
                Notes ="Dit is een notitie",
                PhoneNumber = "123456"
            };
            var phoneNoteDomainModel = new PhoneNote
            {
                Id = 1,
                AssignedTo = "Piet",
                Status = "nieuw",
                Name = "Jan",
                Notes = "Dit is een notitie",
                PhoneNumber = "123456",
                CreateDate = noteEntity.CreateDate,
            };

            noteEntity.MapToDomainModel().Should().BeEquivalentTo(phoneNoteDomainModel);
        }
    }
}
