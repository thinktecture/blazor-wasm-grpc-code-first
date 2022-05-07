using ConfTool.Shared.DTO;
using FluentValidation;

namespace ConfTool.Shared.Validation
{
    public class ConferenceDetailsValidator : AbstractValidator<ConferenceDetails>
    {
        public ConferenceDetailsValidator()
        {
            RuleFor(conference => conference.DateTo).GreaterThanOrEqualTo(conference => conference.DateFrom);
        }
    }
}
