using Application.Core;
using Application.DTO;
using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reviews
{
    public class List
    {
        public class Query : IRequest<Result<List<ReviewDTO>>>
        {
            public ReviewDTO Review { get; set; }
        }

        public class GetAllReviewsHandler : IRequestHandler<Query, Result<List<ReviewDTO>>>
        {
            private readonly IReviewRepository repository;

            public GetAllReviewsHandler(IReviewRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<List<ReviewDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var reviews = await repository.GetAllAsync<ReviewDTO>();
                if (reviews != null)
                {
                    return new Result<List<ReviewDTO>> { IsSuccess = true, Value = reviews.ToList() };
                }

                return new Result<List<ReviewDTO>> { IsSuccess = false, Error = "List of reviews not found!" };
            }
        }
    }
}
