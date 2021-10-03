namespace SB.TelephoneNotes.BLL.Interfaces.Models
{
    public class NotesFilter
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;

        public string Status { get; set; }
        public string AssignedTo { get; set; }
        
        public int PageNumber { get; set; } = 1;
        
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
