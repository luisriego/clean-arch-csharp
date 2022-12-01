using MediatR;

namespace CleanArch.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreaemerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
