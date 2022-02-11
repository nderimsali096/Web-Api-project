using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDalogTask.Data.Models
{
    public class ProjectActivity
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public int ProjectAreaId { get; set; }
        public ProjectArea ProjectArea{ get; set; }
        public int TeamMembershipId { get; set; }

        public TeamMembership TeamMembership { get; set; }

    }
}
