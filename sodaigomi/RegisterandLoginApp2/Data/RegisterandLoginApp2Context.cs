#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegisterandLoginApp2.Models;

namespace RegisterandLoginApp2.Data
{
    public class RegisterandLoginApp2Context : DbContext
    {
        public RegisterandLoginApp2Context (DbContextOptions<RegisterandLoginApp2Context> options)
            : base(options)
        {
        }

        public DbSet<RegisterandLoginApp2.Models.Movie> Movie { get; set; }

        public DbSet<RegisterandLoginApp2.Models.ItemStock> ItemStock { get; set; }

        public DbSet<RegisterandLoginApp2.Models.ac> ac { get; set; }

        public DbSet<RegisterandLoginApp2.Models.mirror> mirror { get; set; }

        public DbSet<RegisterandLoginApp2.Models.refrigerator> refrigerator { get; set; }
    }
}
