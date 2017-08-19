using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eMarketApi.Models
{
    public class eMarketDbContext : DbContext
    {
        public eMarketDbContext() : base("name=eMarketDbContext")
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}