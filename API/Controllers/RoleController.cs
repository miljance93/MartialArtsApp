using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Roles;
using Domain;

namespace API.Controllers
{
    public class RoleController : BaseAPIController
    {
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDTO role)
        {
            return HandleResult(await Mediator.Send(new Create.Command(role)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDTO role)
        {
            return HandleResult(await Mediator.Send(new Update.Command(role)));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            return HandleResult(await Mediator.Send(new Search.Query(id)));
        }
    }
}
