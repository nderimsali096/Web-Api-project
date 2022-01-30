using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiDalogTask.Data.Models
{
    public class TeamMembership
    {
        public int Id { get; set; }
        public int TeamId { get; set; }

        [Required]
        public Team Team { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<ProjectActivity> ProjectActivities { get; set; }
        
    }
}
