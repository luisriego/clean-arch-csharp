using CleanArch.Domain;

namespace CleanArch.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideoByName(string videoName); // solo a modo de ejemplo para ver como se implementa

        Task<IEnumerable<Video>> GetVideosByUsername(string username);
    }
}
