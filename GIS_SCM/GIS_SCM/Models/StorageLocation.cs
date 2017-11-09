using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class StorageLocation
    {
        public int ID { get; set; }
        public string ServicingPlantCode { get; set; }
        public string StorageLocationNumber { get; set; }
        public string StorageLocationDesc { get; set; }
        public string StorageLocationAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}