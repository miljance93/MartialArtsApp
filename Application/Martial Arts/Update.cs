﻿using Application.Core;
using Application.DTO;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Martial_Arts
{
    public class Update
    {
        public record Command(MartialArt MartialArt) : IRequest<Result<Unit>>;

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
                    await _martialArtRepository.UpdateAsync(request.MartialArt);
                    return Result<Unit>.Success(Unit.Value);
                }

                return  Result<Unit>.Failure("Failed to update martial art");
            }
        }
    }
}
