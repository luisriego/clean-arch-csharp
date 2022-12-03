using CleanArch.Application.Contracts.Persistence;
using CleanArch.Domain;
using CleanArch.Infrastructure.Persistence;

namespace CleanArch.Infrastructure.Repositories
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        public StreamerRepository(StreamerDbContext context) : base(context)
        { }
    }
}
