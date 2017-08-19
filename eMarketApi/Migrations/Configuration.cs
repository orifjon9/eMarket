namespace eMarketApi.Migrations
{
    using eMarketApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eMarketDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eMarketDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Categories.AddOrUpdate(c => c.Id,
                new Category() { Id = 1, Name = "Food" },
                new Category() { Id = 2, Name = "Electronics" },

                new Category() { Id = 3, Name = "Fruits", ParentId = 1 },
                new Category() { Id = 4, Name = "Vegetable", ParentId = 1 },


                new Category() { Id = 5, Name = "Laptop", ParentId = 2 },
                new Category() { Id = 6, Name = "Phone", ParentId = 2 }
                );


            context.Products.AddOrUpdate(p => p.Id, 
                new Product() { Id = 1, Name = "Apple", Description = "Red Apple", CategoryId = 3, Price = 2.5M, Weight = 0.5M  },
                new Product() { Id = 2, Name = "Banana", Description = "Yellow Apple", CategoryId = 3, Price = 1.5M, Weight = 0.7M  },
                new Product() { Id = 3, Name = "Tomato", Description = "Red Tomato", CategoryId = 4, Price = 3.5M, Weight = 1M },
                new Product() { Id = 4, Name = "Carrot", Description = "Orange Carrot", CategoryId = 4, Price = 2.5M, Weight = 0.9M },

                new Product() { Id = 5, Name = "iPhone 6", Description = "Gold iPhone 6", CategoryId = 6, Price = 7.99M, Weight = 0.2M },
                new Product() { Id = 6, Name = "MSI", Description = "GP62 6QF", CategoryId = 5, Price = 1000.99M, Weight = 2.7M }

                );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
