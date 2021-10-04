using SB.TelephoneNotes.BLL.Services;
using System;
using Microsoft.AspNetCore.JsonPatch;
using Xunit;
using Moq;
using SB.TelephoneNotes.DAL.Interfaces;
using SB.TelephoneNotes.BLL.Interfaces.Commands;
using System.Threading.Tasks;
using SB.TelephoneNotes.DAL.Interfaces.Entities;
using SB.TelephoneNotes.BLL.Interfaces.Models;
using FluentAssertions;

namespace SB.TelephoneNotes.BLL.Test.Services
{
    public class PersistPhoneNotesServiceTests
    {
        [Fact]
        public async Task GivenPhoneNoteJsonPatchDocument_WhenPatched_ThenPatchSuccessfull()
        {
            var id = 1;
            var noteEntity = new NoteEntity
            {
                Id = id,
                AssignedTo = "Piet",
                Status = "nieuw",
                Name = "Jan",
                Notes = "Dit is een notitie",
                PhoneNumber = "123456",
                CreateDate = DateTime.Now
            };

            var patchedPhoneNoteDomainModel = new PhoneNote
            {
                Id = id,
                AssignedTo = "Jan",
                Status = "afgehandeld",
                Name = "Jan",
                Notes = "Dit is een notitie",
                PhoneNumber = "123456",
                CreateDate = noteEntity.CreateDate,
            };

            var notesRepositoryMock = new Mock<INotesRepository>();
            notesRepositoryMock.Setup(x => x.Get(id)).ReturnsAsync(noteEntity);
            var persistPhoneNotesService = new PersistPhoneNotesService(notesRepositoryMock.Object);
            var jsonPatchDocument = new JsonPatchDocument<PatchPhoneNote>();
            jsonPatchDocument.Replace(d => d.AssignedTo, "Jan");
            jsonPatchDocument.Replace(d => d.Status, "afgehandeld");

            var patchedNote = await persistPhoneNotesService.Patch(id, jsonPatchDocument);
            patchedNote.Should().BeEquivalentTo(patchedPhoneNoteDomainModel);
        }
    }
}
