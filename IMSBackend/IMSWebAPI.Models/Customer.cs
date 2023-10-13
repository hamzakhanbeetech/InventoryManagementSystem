using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSWebAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactInfo { get; set; }

        // Navigation property to Sales
        public ICollection<Sale> Sales { get; set; }
    }

}
