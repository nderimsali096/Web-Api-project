using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDalogTask.Data.Models;

namespace WebApiDalogTask.Data
{
    public class DalogDbContext : DbContext
    {
        public DalogDbContext() { }
        public DalogDbContext(DbContextOptions<DalogDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectActivity> ProjectActivities { get; set; }
        public DbSet<ProjectArea> ProjectAreas { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMembership> TeamMemberships { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

    }
}
