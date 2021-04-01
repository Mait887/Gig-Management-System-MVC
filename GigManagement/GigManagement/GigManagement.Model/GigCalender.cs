using System;
using System.Collections.Generic;

#nullable disable

namespace GigManagement.GigManagement.Model
{
    public partial class GigCalender
    {
        public string Username { get; set; }
        public int? GigId { get; set; }

        public virtual Gig Gig { get; set; }
        public virtual UserDetail UsernameNavigation { get; set; }
    }
}
