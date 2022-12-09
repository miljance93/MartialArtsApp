using Application.DTO;
using Domain;
using FluentValidation;

namespace Application.Martial_Arts
{
    public class MartialArtValidator : AbstractValidator<MartialArt>
    {
        public MartialArtValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.LongDescription).NotEmpty();
            RuleFor(x => x.ShortDescription).NotEmpty();
        }
    }
}
