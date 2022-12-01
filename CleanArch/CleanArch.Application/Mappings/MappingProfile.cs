using AutoMapper;
using CleanArch.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArch.Application.Features.Videos.Queries.GetVideosList;
using CleanArch.Domain;

namespace CleanArch.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>(); // quizas deberia ser StreamerVm o StreamerCommmandVm
        }
    }
}
