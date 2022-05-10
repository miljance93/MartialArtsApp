using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<bool> Exists(PostDTO post)
        {
            if (await context.Posts.ContainsAsync(mapper.Map<Post>(post)))
            {
                return true;
            }
            return false;
        }
    }
}
