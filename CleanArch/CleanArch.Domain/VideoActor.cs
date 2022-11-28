using CleanArch.Domain.Common;

namespace CleanArch.Domain
{
    public class VideoActor: BaseDomainModel
    {
        public int VideoId { get; set; }

        public int ActorId { get; set; }
    }
}
