using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class Truck
    {
        public int ID { get; set; }
        public string TruckNumber { get; set; }
        public string TruckModel { get; set; }
        public string TruckColor { get; set; }
        public string LastParkedLongitude { get; set; }
        public string LastParkedLatitude { get; set; }

        public ICollection<Transporter> Transporter { get; set; }
    }
}