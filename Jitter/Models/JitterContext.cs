using System;
using System.Web;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace Jitter.Models
{
    public class JitterContext : DbContext
    {
        public virtual DbSet<JitterUser> JitterUsers { get; set; }
        public DbSet<Jot> Jots { get; set; }
    }
}