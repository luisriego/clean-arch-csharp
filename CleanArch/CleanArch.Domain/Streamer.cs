using CleanArch.Domain.Common;

namespace CleanArch.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string? Url { get; set; }

        public ICollection<Video>? Videos { get; set; }
    }
}
