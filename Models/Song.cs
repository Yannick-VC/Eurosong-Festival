using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eurovision_Programming_Web.Models
{
    public class Song
    {
        public int ID { get; private set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public string Spotify { get; set; }
    }
}
