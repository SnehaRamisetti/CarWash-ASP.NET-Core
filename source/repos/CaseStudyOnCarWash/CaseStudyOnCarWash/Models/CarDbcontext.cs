using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Models
{
    public class CarDbcontext : DbContext
    {
        public CarDbcontext(DbContextOptions<CarDbcontext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<PackageDetails> PackageDetails{ get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(p => new { p.Email, p.Password })
                .IsUnique();
            builder.Entity<Admin>()
               .HasIndex(a => new { a.Email, a.Password })
               .IsUnique();
        }
    }
}
