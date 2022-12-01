using AutoMapper;
using CleanArch.Application.Contracts.Persistence;
using MediatR;

namespace CleanArch.Application.Features.Videos.Queries.GetVideosList
{
    internal class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository=videoRepository;
            _mapper=mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videoRepository.GetVideosByUsername(request._Username);
            
            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
