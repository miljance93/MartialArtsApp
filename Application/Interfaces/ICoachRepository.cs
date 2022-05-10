using Application.DTO;
using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICoachRepository : IRepository<ApplicationUser>
    {
    }
}
