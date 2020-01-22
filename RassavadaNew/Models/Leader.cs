using System;
using System.Collections.Generic;
using System.Text;

namespace RassavadaNew.Models
{
    public class Leader
    {
        public string Name { get; set; }
        public string Points { get; set; }
        public string ImageURL { get; set; }
        public string Rank { get; set; }

    }
    public class LeaderList
    {
        public List<Leader> Leaderboard { get; set; }
    }
}
