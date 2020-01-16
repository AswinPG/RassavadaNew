using System;
using System.Collections.Generic;
using System.Text;

namespace RassavadaNew.Models
{
    public enum ExpType
    {
        Food,
        TouristPlace,
        Cultural,
        Historic
    }
    public class Experience
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string AvgTime { get; set; }
        public string MajCentre { get; set; }
        public string DistMajCentre { get; set; }
        public bool Seasonal { get; set; }
        public List<string> Seasons { get; set; }
        public List<string> Images { get; set; }
        public ExpType expType { get; set; }
        public string docId { get; set; }

    }
}


