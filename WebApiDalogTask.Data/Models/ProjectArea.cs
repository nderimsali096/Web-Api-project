using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDalogTask.Data.Models
{
    public class ProjectArea
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<ProjectActivity> ProjectActivities { get; set; }
    }
}
