using System;
using System.ComponentModel.DataAnnotations;

namespace SB.TelephoneNotes.DAL.Interfaces.Entities
{
    public class NoteEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
