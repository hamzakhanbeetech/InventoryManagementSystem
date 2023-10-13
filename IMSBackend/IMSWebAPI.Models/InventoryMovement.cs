using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSWebAPI.Models
{
    public class InventoryMovement
    {
        [Key]
        public int MovementID { get; set; }
        public int ProductID { get; set; }
        public string MovementType { get; set; } // 'Purchase' or 'Sale'
        public DateTime MovementDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation property to Product
        public Product Product { get; set; }
    }

}
