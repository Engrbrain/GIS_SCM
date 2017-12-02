using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIS_SCM.Models
{
    public class InventoryByStorageLocation
    {
        public int ID { get; set; }
        public int MaterialID { get; set; }
        public int StorageLocationID { get; set; }
        public string StockLevel { get; set; }

        public virtual Material Material { get; set; }
        public virtual StorageLocation StorageLocation { get; set; }
    }
}