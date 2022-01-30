using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDalogTask.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int TeamLeaderUserId { get; set; }
        public  ICollection<TeamMembership> TeamMemberships { get; set; }

        public ICollection<Project> projects { get; set; }

        public User User { get; set; }
    }
}
