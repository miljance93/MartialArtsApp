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
    public class Search
    {
        public record Query(int StarRating) : IRequest<Result<ReviewDTO>>;

        public class Handler : IRequestHandler<Query, Result<ReviewDTO>>
        {
            private readonly IReviewRepository _reviewRepository;

            public Handler(IReviewRepository reviewRepository)
            {
                _reviewRepository = reviewRepository;
            }

            public async Task<Result<ReviewDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _reviewRepository.FindAsync<ReviewDTO>(x => x.StarRating == request.StarRating);
                if (result != null)
                {
                    return new Result<ReviewDTO> { IsSuccess = true, Value = result };
                }

                return new Result<ReviewDTO> { IsSuccess = false, Error = "No star rating!" };
            }
        }
    }
}
