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

namespace Application.Reviews
{
    public class Update
    {
        public record Command(ReviewDTO Review) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IReviewRepository _reviewRepository;

            public Handler(IReviewRepository reviewRepository)
            {
                _reviewRepository = reviewRepository;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _reviewRepository.Exists(request.Review))
                {
                    var result = await _reviewRepository.UpdateAsync(request.Review);
                    return new Result<bool> { IsSuccess = true, Value = result };
                }

                return new Result<bool> { IsSuccess = false, Error = "Review is not updated!" };
            }
        }
    }
}
