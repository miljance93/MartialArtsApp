using Application.DTO;
using Application.Martial_Arts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class MartialArtController : BaseAPIController 
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await Mediator.Send(new Search.Query(id)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMartialArt(MartialArtDTO martialArt)
        {
            return HandleResult(await Mediator.Send(new Update.Command(martialArt)));
        }

        [HttpPost]
        public async Task<IActionResult> PostMartialArt(MartialArtDTO martialArt)
        {
            return HandleResult(await Mediator.Send(new Create.Command(martialArt)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMartialArt(MartialArtDTO martialArt)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(martialArt)));
        }
    }
}
