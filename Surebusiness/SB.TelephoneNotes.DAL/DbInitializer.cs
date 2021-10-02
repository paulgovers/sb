using SB.TelephoneNotes.DAL.Interfaces.Entities;
using System;
using System.Linq;

namespace SB.TelephoneNotes.DAL.EF
{
    public static class DbInitializer
    {
        public static void Initialize(PhoneNotesDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Notes.Any())
            {
                return;   // DB has been seeded
            }
            var Notes = new NoteEntity[]
            {
                new NoteEntity{ Name = "Paul", Notes= "Graag terug bellen", AssignedTo = "Willem", CreateDate = DateTime.Now, PhoneNumber = "123456789", Status = "nieuw" },
                new NoteEntity{ Name = "Paul", Notes= "Graag terug bellen", AssignedTo = "Willem", CreateDate = DateTime.Now, PhoneNumber = "123456789", Status = "nieuw" },
            };

            foreach (NoteEntity note in Notes)
            {
                context.Notes.Add(note);
            }
            context.SaveChanges();
        }
    }
}
