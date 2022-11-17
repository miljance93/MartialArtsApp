using Application.Core;
using Application.DTO;
using Application.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Martial_Arts
{
    public class Create
    {
        public record Command(MartialArtDTO MartialArt) : IRequest<Result<Unit>>;

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.MartialArt).SetValidator(new MartialArtValidator());
            }
        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMartialArtRepository _martialArtRepository;

            public Handler(IMartialArtRepository martialArtRepository)
            {
                _martialArtRepository = martialArtRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _martialArtRepository.Exists(request.MartialArt))
                {
                    return Result<Unit>.Failure($"{request.MartialArt.Name} is not created");
                }

                await _martialArtRepository.PostAsync(request.MartialArt);
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
