﻿using Application.Martial_Arts;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class MartialArtController : BaseAPIController 
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMartialArts([FromQuery] MartialArtParams @params)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = @params}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMartialArt(string id)
        {
            return HandleResult(await Mediator.Send(new Search.Query(id)));
        }

        [Authorize(Policy = "IsMartialArtHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditMartialArt(string id, MartialArt martialArt)
        {
            martialArt.Id = id;
            return HandleResult(await Mediator.Send(new Update.Command(martialArt)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMartialArt(MartialArt martialArt)
        {
            return HandleResult(await Mediator.Send(new Create.Command { MartialArt = martialArt}));
        }


        [Authorize(Policy = "IsMartialArtHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMartialArt(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(id)));
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(string id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id= id }));
        }
    }
}
