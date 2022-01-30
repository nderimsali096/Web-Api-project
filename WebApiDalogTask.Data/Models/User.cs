using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiDalogTask.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public int CompanyId { get; set; }

        [Required]
        public Company Company { get; set; }

        public Team Team { get; set; }
        public int TeamId { get; set; }

        public ICollection<TeamMembership> TeamMemberships { get; set; }

    }
}
