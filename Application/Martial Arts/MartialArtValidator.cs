using Application.DTO;
using FluentValidation;

namespace Application.Martial_Arts
{
    public class MartialArtValidator : AbstractValidator<MartialArtDTO>
    {
        public MartialArtValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.LongDescription).NotEmpty();
            RuleFor(x => x.ShortDescription).NotEmpty();
        }
    }
}
