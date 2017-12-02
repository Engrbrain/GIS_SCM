using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GIS_SCM.Models;

namespace GIS_SCM.DAL
{
    public class GIS_SCMInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GIS_SCMContext>
    {
        protected override void Seed(GIS_SCMContext context)
        {
            //Seed Customers Data
            var customer = new List<Customer>
            {
                new Customer{CustomerAddress="2 Owonikoko Street, Idimu",CustomerName="Uhunghama Harrison",CustomerNumber="1000123", CustomerState="Lagos", Latitude="NA", Longitude="NA", Nationality="NG"}
            };

            customer.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var plant = new List<Plant>
            {
                new Plant{ Latitude="NA", Longitude="NA", PlantAddress="Marina Lagos State, NG", PlantCode="1000", PlantName="Test Plant" }
            };

            plant.ForEach(p => context.Plants.Add(p));
            context.SaveChanges();
            //Seed Customers Data
           

            //Seed Material Data

            var Material = new List<Material>
            {
                new Material{ MaterialCode="TESTMAT100", MaterialDescription="Test Material", MaterialReorder="5000", MaterialType="TestMaterial" }
            };

            Material.ForEach(m => context.Materials.Add(m));
            context.SaveChanges();

            // Plant Seed Data

           

            // Storage Location Seed Data

          


            // Storage Location Seed Data

            var supplier = new List<Supplier>
            {
                new Supplier{ Latitude="NA", Longitude="NA", Nationality="NG", SupplierAddress="2, Kosoko street, Ojodu, lagos", SupplierName="Uhunghama Enterprises", SupplierNumber="TESTSUP0001", SupplierState="Lagos" }
            };

            supplier.ForEach(s => context.Suppliers.Add(s));
            context.SaveChanges();


        }
    }       
}