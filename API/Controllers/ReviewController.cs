using Application.DTO;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Reviews;

namespace API.Controllers
{
    public class ReviewController : BaseAPIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{starRating}")]
        public async Task<IActionResult> Get(int starRating)
        {
            return HandleResult(await Mediator.Send(new Search.Query(starRating)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(ReviewDTO review)
        {
            return HandleResult(await Mediator.Send(new Update.Command(review)));
        }

        [HttpPost]
        public async Task<IActionResult> PostReview(ReviewDTO reviewDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command(reviewDto)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReview(ReviewDTO review)
        {
            return HandleResult(await Mediator.Send(new Delete.Command(review)));
        }


    }
}
