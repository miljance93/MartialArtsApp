using Application.Interfaces;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UserFollowingRepository : Repository<UserFollowing>, IUserFollowingRepository
    {
        public UserFollowingRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
