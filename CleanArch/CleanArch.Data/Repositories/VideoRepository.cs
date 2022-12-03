using CleanArch.Application.Contracts.Persistence;
using CleanArch.Domain;
using CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        { }

        public async Task<Video> GetVideoByName(string videoName)
        {
            return await _context.Videos!.Where(v => v.Name == videoName).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideosByUsername(string username)
        {
            return await _context.Videos!.Where(v => v.CreatedBy == username).ToListAsync();
        }
    }
}
