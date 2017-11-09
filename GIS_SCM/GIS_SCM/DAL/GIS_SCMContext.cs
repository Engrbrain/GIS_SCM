using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GIS_SCM.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace GIS_SCM.DAL
{
    public class GIS_SCMContext : DbContext
    {
        public GIS_SCMContext() : base("GIS_SCMContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }
        public DbSet<DistributionCenter> DistributionCenters { get; set; }
 



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}