using Application.Interfaces;
using AutoMapper;
using Domain;
using Repository;

namespace RepositoryLayer
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
