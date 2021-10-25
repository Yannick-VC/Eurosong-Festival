using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eurovision_Programming_Web.Models
{
    public class Vote
    {
        public int VoteID { get; private set; }
        public string IP { get; set; }
        public int SongID { get; set; }
        public int Points { get; set; }
    }
}
