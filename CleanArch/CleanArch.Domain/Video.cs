﻿using CleanArch.Domain.Common;

namespace CleanArch.Domain
{
    public class Video : BaseDomainModel
    {
        public Video()
        {
            Actors = new HashSet<Actor>();
        }
    
    public int StreamerId { get; set; }

        public virtual Streamer? Streamer { get; set; }

        public virtual ICollection<Actor>? Actors { get; set; }

        public virtual Director Director { get; set; }
    }
}
