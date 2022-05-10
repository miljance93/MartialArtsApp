using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> PackageLimitExceeded(string trainerId)
        {
            return await context.Packages.CountAsync(x => x.TrainerId == trainerId) == 3;
        }
    }
}
