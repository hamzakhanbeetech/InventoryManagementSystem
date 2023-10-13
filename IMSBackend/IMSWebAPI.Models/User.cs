using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSWebAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }


        // Navigation property to Role
        public ICollection<Role> Role { get; set; }
    }

}
