using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDalogTask.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public int CompanyId { get; set; }

    }
}
