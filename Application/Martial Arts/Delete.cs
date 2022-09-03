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
        public record Command(string Id) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IMartialArtRepository _martialArtRepository;

            public Handler(IMartialArtRepository martialArtRepository)
            {
                _martialArtRepository = martialArtRepository;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var getMartialArt = await _martialArtRepository.GetByIdAsync<MartialArtDTO>(x => x.Id.ToString() == request.Id);
                if (getMartialArt != null)
                {
                    var result = await _martialArtRepository.DeleteAsync(getMartialArt);
                    return new Result<bool> { IsSuccess = true, Value = result };
                }

                return new Result<bool> { IsSuccess = false, Error = "Martial art is not deleted!" };
            }
        }
    }
}
