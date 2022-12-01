using AutoMapper;
using CleanArch.Application.Contracts.Inftrastructure;
using CleanArch.Application.Contracts.Persistence;
using CleanArch.Application.Models;
using CleanArch.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.Application.Features.Streamers.Commands.CreateStreamer
{
    internal class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository,
                                      IMapper mapper,
                                      IEmailService emailService,
                                      ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);

            var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

            _logger.LogInformation($"Streamer {newStreamer.Id} was created.");

            await SendEmail(newStreamer);

            return newStreamer.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email()
            {
                To = "riegomontero@gmail.com",
                Body = $"Streamer {streamer.Name} was created.",
                Subject = "A new streamer was created."
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Email could not be sent to {email.To}. Exception message: {ex.Message}");
            }
        }
    }
}