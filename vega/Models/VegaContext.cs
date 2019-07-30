using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelFeature>()
                .HasKey(t => new { t.ModelId, t.FeatureId });
        }
    }
}
