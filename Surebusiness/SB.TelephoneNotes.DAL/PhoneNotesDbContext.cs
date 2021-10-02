using Microsoft.EntityFrameworkCore;
using SB.TelephoneNotes.DAL.Interfaces.Entities;

namespace SB.TelephoneNotes.DAL.EF
{
    public class PhoneNotesDbContext : DbContext
    {
        public PhoneNotesDbContext(DbContextOptions<PhoneNotesDbContext> options): base(options)
        {
           
        }
        public DbSet<NoteEntity> Notes { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteEntity>().ToTable("Notes");
        }
    }
}
