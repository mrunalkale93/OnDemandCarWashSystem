using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarWashSystem.Data
{
    public class CarWashDbContext:DbContext
    {
        public CarWashDbContext(DbContextOptions dbcontextOptions) : base(dbcontextOptions) { }

        public DbSet<AddOn> AddOns { set; get; }
        public DbSet<Car> Cars { set; get; }
        public DbSet<OrderDetails> Orders { set; get; }
        public DbSet<Payment> Payments { set; get; }

        public DbSet<WashPackageDetails> WashPackages { set; get; }
        public DbSet<UserDetails> Users { set; get; }
    }
}
