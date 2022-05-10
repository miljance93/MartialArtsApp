using Application.Classes;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ClassController : BaseAPIController
    {
        [HttpPost]
        public async Task<IActionResult> Create(ClassDTO classDTO)
        {
            return HandleResult(await Mediator.Send(new Create.Command(classDTO)));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(id)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClassDTO classDTO)
        {
            return HandleResult(await Mediator.Send(new Update.Command(classDTO)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
    }
}
