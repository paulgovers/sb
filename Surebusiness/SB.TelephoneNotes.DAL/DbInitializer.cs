using SB.TelephoneNotes.DAL.Interfaces.Entities;
using System;
using System.Linq;
using Tynamix.ObjectFiller;

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
            Filler<NoteEntity> pFiller = new Filler<NoteEntity>();
            pFiller.Setup(true)
              .OnProperty(x => x.Name).Use<RealNames>()
              .OnProperty(x => x.AssignedTo).Use(new RandomListItem<string>("Kees", "Jan", "Willem", "Piet"))
              .OnProperty(x => x.Status).Use(new RandomListItem<string>("inbehandeling", "nieuw", "afgehandeld"))
              .OnProperty(x => x.PhoneNumber).Use("06-123456789")
              .OnProperty(x => x.CreateDate).Use(DateTime.Now)
              .OnProperty(x => x.Notes).Use(new Lipsum(LipsumFlavor.LoremIpsum,20, 30, 2));


            var Notes = pFiller.Create(100);

            foreach (NoteEntity note in Notes)
            {
                context.Notes.Add(note);
            }
            context.SaveChanges();
        }
    }
}
