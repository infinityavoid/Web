using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace automastAPI.Models
{
    public class DataDbContext : DbContext
    {
        public DataDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
