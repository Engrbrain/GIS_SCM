using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class DistributionCenter
    {
        public int ID { get; set; }
        public string ServicingPlantCode { get; set; }
        public string DCNumber { get; set; }
        public string DCDesc { get; set; }
        public string DCAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}