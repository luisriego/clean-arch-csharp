using AutoMapper;
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Application.Exceptions;
using CleanArch.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreaemerCommandHandler : IRequestHandler<DeleteStreaemerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStreaemerCommandHandler> _logger;

        public DeleteStreaemerCommandHandler(
            IStreamerRepository streamerRepository, 
            IMapper mapper, 
            ILogger<DeleteStreaemerCommandHandler> logger)
        {
            _streamerRepository=streamerRepository;
            _mapper=mapper;
            _logger=logger;
        }

        public async Task<Unit> Handle(DeleteStreaemerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete == null)
            {
                _logger.LogError($"Streamer {request.Id} not found.");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _streamerRepository.DeleteAsync(streamerToDelete);

            _logger.LogInformation($"The Streamer {streamerToDelete.Name} was deleted!");

            return Unit.Value;
        }
    }
}
