using Application.DTO;
using Application.Mentorships;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class MentorshipController : BaseAPIController
    {
        [HttpGet("{id}/dashboard")]
        public async Task<IActionResult> GetAll(string coachId)
        {
            return HandleResult(await Mediator.Send(new List.Query(coachId)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return HandleResult(await Mediator.Send(new Search.Query(id)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMentor(MentorshipDTO mentorship)
        {
            return HandleResult(await Mediator.Send(new Update.Command(mentorship)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMentor(MentorshipDTO mentorship)
        {
            return HandleResult(await Mediator.Send(new Create.Command(mentorship)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMentor(MentorshipDTO mentorship)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(mentorship)));
        }
    }
}
