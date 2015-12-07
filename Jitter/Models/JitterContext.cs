using System;
using System.Web;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace Jitter.Models
{
    public class JitterContext : ApplicationDbContext
    {
        public virtual DbSet<JitterUser> JitterUsers { get; set; }
        public virtual DbSet<Jot> Jots { get; set; }
    }
}