using Application.Coaches;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CoachController : BaseAPIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{skillName}")]
        public async Task<IActionResult> GetById(string skillName)
        {
            return HandleResult(await Mediator.Send(new Search.Query(skillName)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoach(CoachDTO coach)
        {
            return HandleResult(await Mediator.Send(new Update.Command(coach)));
        }

        [HttpPost]
        public async Task<IActionResult> PostCoach(CoachDTO coach)
        {
            return HandleResult(await Mediator.Send(new Create.Command(coach)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoach(string coach)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(coach)));
        }
    }
}
