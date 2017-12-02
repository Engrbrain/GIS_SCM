using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class StorageLocation
    {
        public int ID { get; set; }
        public int PlantID { get; set; }
        public string StorageLocationNumber { get; set; }
        public string StorageLocationDesc { get; set; }
        public string StorageLocationAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Plant Plant { get; set; }

        public ICollection<InventoryByStorageLocation> InventoryByStorageLocation { get; set; }
    }
}