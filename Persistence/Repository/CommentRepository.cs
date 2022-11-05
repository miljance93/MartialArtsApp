using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Persistence.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
