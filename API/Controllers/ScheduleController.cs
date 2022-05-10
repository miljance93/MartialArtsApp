using Application.DTO;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Schedules;

namespace API.Controllers
{
    public class ScheduleController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return HandleResult(await Mediator.Send(new Search.Query(id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostSchedule(ScheduleDTO schedule)
        {
            return HandleResult(await Mediator.Send(new Create.Command(schedule)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchedule(ScheduleDTO schedule)
        {
            return HandleResult(await Mediator.Send(new Update.Command(schedule)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchedule(ScheduleDTO schedule)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(schedule)));
        }
    }
}
