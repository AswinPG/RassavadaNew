using System;
using System.Collections.Generic;
using System.Text;

namespace RassavadaNew.Models
{

    public enum VehicleType
    {
        TwoWheeler,
        ThreeWheeler,
        FourWheeler
    }
    public class Guide
    {
        public string UserName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string CurrentLoc { get; set; }
        public string Hometown { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public bool HasVehicle { get; set; }
        public VehicleType VehicleType { get; set; }
        public string ImgUrl { get; set; }
        public string IdProofUrl { get; set; }

    }
}
