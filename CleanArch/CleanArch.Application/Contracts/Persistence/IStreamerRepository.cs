using CleanArch.Domain;

namespace CleanArch.Application.Contracts.Persistence
{
    public interface IStreamerRepository : IAsyncRepository<Streamer>
    {
        //task<streamer> getstreamerbyname(string streamername); // solo a modo de ejemplo para ver como se implementa

        //task<ienumerable<streamer>> getstreamersbyusername(string username);
    }
}
