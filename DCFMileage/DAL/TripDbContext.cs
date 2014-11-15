using DCFMileage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DCFMileage.DAL
{
    public class TripDbContext : DbContext
    {
        public TripDbContext() : base("name=TripDb")
        {
            Database.SetInitializer<TripDbContext>(new TripDbInitializer());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Make table names singular instead of plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}