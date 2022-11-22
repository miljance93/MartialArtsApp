using Application.DTO;
using Application.Martial_Arts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class MartialArtController : BaseAPIController 
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMartialArts()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMartialArt(int id)
        {
            return HandleResult(await Mediator.Send(new Search.Query(id)));
        }

        [HttpPut]
        public async Task<IActionResult> EditMartialArt(MartialArtDTO martialArt)
        {
            return HandleResult(await Mediator.Send(new Update.Command(martialArt)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMartialArt(MartialArtDTO martialArt)
        {
            return HandleResult(await Mediator.Send(new Create.Command(martialArt)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMartialArt(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(id)));
        }
    }
}
