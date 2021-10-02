using FluentValidation;
using SB.TelephoneNotes.BLL.Interfaces.Commands;

namespace SB.TelephoneNotes.BLL.Validators
{
		public class CreatePhoneNoteValidator : AbstractValidator<CreatePhoneNote>
		{
			public CreatePhoneNoteValidator()
			{
				RuleFor(x => x.Name).Length(0, 100);
				RuleFor(x => x.Status).Must(status => status == "nieuw" || status == "inbehandeling" || status == "afgehandeld").WithMessage("Status mogelijke waarden: nieuw | inbehandeling | afgehandeld");
				RuleFor(x => x.Notes).NotEmpty().WithMessage("Notitie kan niet leeg zijn");
			}
		}
	
}
