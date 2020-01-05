using System;
using System.Collections.Generic;
using System.Text;

namespace RassavadaNew.Models
{
    public class GoogleUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }
        public string token { get; set; }
    }
}
