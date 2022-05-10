using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Posts;

namespace API.Controllers
{
    public class PostController : BaseAPIController 
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

        [HttpPut]
        public async Task<IActionResult> UpdatePost(PostDTO post)
        {
            return HandleResult(await Mediator.Send(new Update.Command(post)));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostDTO postDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command(postDto)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(PostDTO post)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(post)));
        }


    }
}
