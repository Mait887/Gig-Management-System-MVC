using System;
using System.Collections.Generic;

#nullable disable

namespace GigManagement.GigManagement.Model
{
    public partial class Following
    {
        public string Username { get; set; }
        public string ArtistUsername { get; set; }

        public virtual ArtistDetail ArtistUsernameNavigation { get; set; }
        public virtual UserDetail UsernameNavigation { get; set; }
    }
}
