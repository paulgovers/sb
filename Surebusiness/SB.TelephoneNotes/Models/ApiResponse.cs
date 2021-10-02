using System.Collections.Generic;

namespace SB.TelephoneNotes.Api.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public IList<Error> Errors { get; set; }

        public bool HasErrors => Errors != null && Errors.Count > 0;

        public ApiResponse<T> WithError(string error)
        {
            Errors = new List<Error> {
                new Error
                {
                    Messages=new List<string>{error}
                }
            };
            return this;
        }

        public ApiResponse<T> WithErrors(List<Error> errors)
        {
            Errors = errors;
            return this;
        }
    }

}
