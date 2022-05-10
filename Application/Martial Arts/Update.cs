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
    public class Update
    {
        public record Command(MartialArtDTO MartialArt) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IMartialArtRepository _martialArtRepository;

            public Handler(IMartialArtRepository martialArtRepository)
            {
                _martialArtRepository = martialArtRepository;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _martialArtRepository.Exists(request.MartialArt))
                {
                    var result = await _martialArtRepository.UpdateAsync(request.MartialArt);
                    return new Result<bool> { IsSuccess = true, Value = result };
                }

                return new Result<bool> { IsSuccess = false, Error = "Martial art is not updated!" };
            }
        }
    }
}
