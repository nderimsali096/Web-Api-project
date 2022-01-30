using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDalogTask.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public ICollection<User> Users {get; set;}
    }
}
