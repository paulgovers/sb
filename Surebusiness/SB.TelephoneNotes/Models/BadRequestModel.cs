using FluentValidation.Results;
using System.Collections.Generic;

namespace SB.TelephoneNotes.Api.Models
{
    public class BadRequestModel
    {
        public string Description { get; set; }
        public BadRequestModel(ValidationResult validationResult)
        {
            ValidationMessages = new List<string>();
            foreach (ValidationFailure failure in validationResult.Errors)
            {
                ValidationMessages.Add(failure.ErrorMessage);
            }
        }
        public List<string> ValidationMessages { get; set; }
    }
}
