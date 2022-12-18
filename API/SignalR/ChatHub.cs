using Application.Comments;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace API.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendComment(Create.Command command)
        {
            var comment = await _mediator.Send(command);

            await Clients.Group(command.MartialArtId)
                .SendAsync("ReceiveComment", comment.Value);
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var martialArtId = httpContext.Request.Query["martialArtId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, martialArtId);
            var result = await _mediator.Send(new List.Query { MartialArtId = martialArtId });
            await Clients.Caller.SendAsync("LoadComments", result.Value);
        }
    }
}
