using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDalogTask.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int TeamId { get; set; }

        public Team Team { get; set; }

        public ICollection<ProjectArea> ProjectAreas { get; set; }
    }
}
