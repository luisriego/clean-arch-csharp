using CleanArch.Domain.Common;

namespace CleanArch.Domain
{
    public class Actor : BaseDomainModel
    {
        public Actor()
        {
            Videos = new HashSet<Video>();
        }
        
        public string? Surname { get; set; }

        public virtual ICollection<Video>? Videos { get; set; }
    }
}
