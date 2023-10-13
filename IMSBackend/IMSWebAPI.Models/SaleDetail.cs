using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSWebAPI.Models
{
    public class SaleDetail
    {
        [Key]
        public int SaleDetailID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int QuantitySold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation properties to Sale and Product
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }

}
