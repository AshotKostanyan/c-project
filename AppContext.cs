using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SignIn
{
    public class AppContext : DbContext
    {
        public AppContext() : base("DbConnectionString") { }
        public DbSet<Users> Users { get; set; }
    }
}
