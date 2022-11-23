using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab11_efcore_crud.Models;

namespace lab11_efcore_crud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<lab11_efcore_crud.Models.Student> Student { get; set; } = default!;
    }
}
