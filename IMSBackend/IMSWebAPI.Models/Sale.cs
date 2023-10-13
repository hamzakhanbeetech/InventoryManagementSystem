using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSWebAPI.Models
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal TotalRevenue { get; set; }

        // Navigation property to Customer
        public Customer Customer { get; set; }

        // Navigation property to SaleDetails
        public ICollection<SaleDetail> SaleDetails { get; set; }
    }

}
