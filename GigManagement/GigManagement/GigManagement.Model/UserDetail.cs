using System;
using System.Collections.Generic;

#nullable disable

namespace GigManagement.GigManagement.Model
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Followings = new HashSet<Following>();
        }

        public string Username { get; set; }
        public string Names { get; set; }
        public string Passwords { get; set; }

        public virtual ICollection<Following> Followings { get; set; }
    }
}
