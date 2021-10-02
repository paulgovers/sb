using SB.TelephoneNotes.BLL.Interfaces.Models;
using SB.TelephoneNotes.DAL.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SB.TelephoneNotes.BLL.Mappers
{
    public static class NoteEntityMapper
    {
        public static List<PhoneNote> MapToDomainModel(this List<NoteEntity> noteEntityList)
        {
            return (from x in noteEntityList select x.MapToDomainModel()).ToList();
        }
        public static PhoneNote MapToDomainModel(this NoteEntity noteEntity)
        {
            if (noteEntity == null)
                return null;

            return new PhoneNote
            {
                Id = noteEntity.Id,
                AssignedTo = noteEntity.AssignedTo,
                Status = noteEntity.Status,
                PhoneNumber = noteEntity.PhoneNumber,
                CreateDate = noteEntity.CreateDate,
                Name = noteEntity.Name,
                Notes = noteEntity.Notes
            };
        }
    }
}
