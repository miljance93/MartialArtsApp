using Application.Clients;
using Application.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class ClientController : BaseAPIController
    {
        [AllowAnonymous]
        [HttpGet("paging")]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClientsPaginated([FromQuery] PagingParameterModel pagingParameterModel)
        {
            return HandlePagedResult(await Mediator.Send(new PaginatedList.Query(pagingParameterModel)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new List.Query())); 
        }

        [AllowAnonymous]
        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            return HandleResult(await Mediator.Send(new Search.Query(username)));
        }

        [HttpPost]
        public async Task<IActionResult> PostClient(ClientDTO client)
        {
            return HandleResult(await Mediator.Send(new Create.Command(client)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(ClientDTO client)
        {
            return HandleResult(await Mediator.Send(new Update.Command(client)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(ClientDTO client)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(client)));
        }
    }
}
