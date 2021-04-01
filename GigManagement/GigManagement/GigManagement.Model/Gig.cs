using System;
using System.Collections.Generic;

#nullable disable

namespace GigManagement.GigManagement.Model
{
    public partial class Gig
    {
        public int GigId { get; set; }
        public string GigName { get; set; }
        public string ArtistName { get; set; }
        public string Venue { get; set; }
        public DateTime? GigDate { get; set; }
        public string Genre { get; set; }
        public string IsCancelled { get; set; }
    }
}
