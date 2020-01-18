using System;
using System.Collections.Generic;
using System.Text;

namespace RassavadaNew.Models
{
    public class Package
    {
        public List<Experience> Experiences { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public float Cost { get; set; }
        public string Detail { get; set; }
        public string docId { get; set; }
        
    }
}
