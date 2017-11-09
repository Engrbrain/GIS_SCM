using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class Plant
    {
        public int ID { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string PlantAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}