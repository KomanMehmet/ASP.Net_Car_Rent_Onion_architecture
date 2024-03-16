using MediatR;

namespace CarRent.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand : IRequest
    {
        public int BlogID { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Content { get; set; }

        public string Email { get; set; }
    }
}
