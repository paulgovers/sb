namespace SB.TelephoneNotes.BLL.Interfaces.Commands
{
    public class CreatePhoneNoteCommand
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
    }
}
