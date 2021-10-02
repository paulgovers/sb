using System;

namespace SB.TelephoneNotes.BLL.Interfaces.Models
{
    public class PhoneNote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
