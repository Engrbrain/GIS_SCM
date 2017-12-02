using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIS_SCM.Models
{
    public enum MovementType
    {
        Supplier_To_Plant,
        Supplier_To_StorageLocation,
        Plant_To_DC,
        Plant_To_StorageLocation,
        StorageLocation_To_StorageLocation,
        Plant_To_Plant,
        DC_To_DC

    }

    public enum MovementStatus
    {
        Completed,
        Intransit,
        Awaiting_Loading

    }
    public class GoodsMovement
    {
        public int ID { get; set; }
        public MovementType? MovementType { get; set; }
        public string MaterialCode { get; set; }
        public string FromLatitude { get; set; }
        public string FromLongitude { get; set; }
        public string ToLatitude { get; set; }
        public string ToLongitude { get; set; }
        public int TransporterID { get; set; }

        public MovementStatus? MovementStatus { get; set; }
        
        public virtual Transporter Transporter { get; set; }

        public ICollection<GoodsInTransit> GoodsInTransit { get; set; }


    }
}