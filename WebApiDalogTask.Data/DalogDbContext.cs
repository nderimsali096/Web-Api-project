using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDalogTask.Data.Models;

namespace WebApiDalogTask.Data
{
    public class DalogDbContext : IdentityDbContext
    {
        public DalogDbContext() { }
        public DalogDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

    }
}
