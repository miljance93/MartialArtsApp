using Application.Profiles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProfilesController : BaseAPIController
    {

        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            return HandleResult(await Mediator.Send(new Details.Query(username)));
        }

        [HttpGet("{username}/martialarts")]
        public async Task<IActionResult> GetUserEvents(string username, string predicate)
        {
            return HandleResult(await Mediator.Send(new ListMartialArts.Query { Username = username, Predicate = predicate }));
        }
    }
}
