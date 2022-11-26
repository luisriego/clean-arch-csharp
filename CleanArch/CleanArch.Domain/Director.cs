using CleanArch.Domain.Common;

namespace CleanArch.Domain
{
    public class Director : BaseDomainModel
    {   
        public string? Surname { get; set; }

        public int VideoId { get; set; }

        public virtual Video? Video { get; set; }
    }
}
