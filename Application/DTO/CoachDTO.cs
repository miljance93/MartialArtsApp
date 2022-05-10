using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CoachDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleDTO Role { get; set; }
    }
}
