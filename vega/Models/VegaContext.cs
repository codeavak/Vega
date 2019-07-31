using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega.Models;

namespace vega.Models
{
    public class VegaContext: DbContext
    {
        public VegaContext(DbContextOptions<VegaContext> options) : base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(t => new { t.VehicleId, t.FeatureId });
        }

        public DbSet<vega.Models.Vehicle> Vehicle { get; set; }
    }
}
