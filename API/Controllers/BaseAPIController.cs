using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Application.Core;
using Domain.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseAPIController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result != null && result.IsSuccess == true)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }

        protected ActionResult HandlePagedResult<T>(PagedList<T> result)
        {
            if (result != null && result.Count != 0)
            {
                return Ok(result);
            }
            return BadRequest("No results found");
        }
    }
}
