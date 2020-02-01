using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class Inventories
    {
        [Key]
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal ItemQuantity { get; set; }

        
        

    }

    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public string CustomerEmail { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }
        public int ItemId { get; internal set; }
    }

    public class OrderDetails
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        [ForeignKey("Inventories")]
        public int ItemId { get; set; }

        public decimal ItemQuantity { get; set; }

    }
}
