using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using System;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
