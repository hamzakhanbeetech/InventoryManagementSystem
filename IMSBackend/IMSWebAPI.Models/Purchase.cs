using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSWebAPI.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalCost { get; set; }

        // Navigation property to Supplier
        public Supplier Supplier { get; set; }

        // Navigation property to PurchaseDetails
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }

}
