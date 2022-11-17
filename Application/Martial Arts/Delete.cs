using Application.Core;
using Application.DTO;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Martial_Arts
{
    public class Delete
    {
        public record Command(string Id) : IRequest<Result<Unit>>;

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMartialArtRepository _martialArtRepository;

            public Handler(IMartialArtRepository martialArtRepository)
            {
                _martialArtRepository = martialArtRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var getMartialArt = await _martialArtRepository.GetByIdAsync<MartialArtDTO>(x => x.Id.ToString() == request.Id);
                if (getMartialArt != null)
                {
                    await _martialArtRepository.DeleteAsync(getMartialArt);
                    return Result<Unit>.Success(Unit.Value);
                }

                return new Result<Unit> { IsSuccess = false, Error = "Martial art is not deleted!" };
            }
        }
    }
}
