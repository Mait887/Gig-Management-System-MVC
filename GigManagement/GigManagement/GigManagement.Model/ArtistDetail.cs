using System;
using System.Collections.Generic;

#nullable disable

namespace GigManagement.GigManagement.Model
{
    public partial class ArtistDetail
    {
        public ArtistDetail()
        {
            Followings = new HashSet<Following>();
        }

        public string ArtistUsername { get; set; }
        public string Names { get; set; }
        public string Passwords { get; set; }

        public virtual ICollection<Following> Followings { get; set; }
    }
}
