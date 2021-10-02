using System.Collections.Generic;

namespace SB.TelephoneNotes.Api.Models
{
    public class Error
    {
        public string PropertyName { get; set; }
        public IList<string> Messages { get; set; }
    }
}
