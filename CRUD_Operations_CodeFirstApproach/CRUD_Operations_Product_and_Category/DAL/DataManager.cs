using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_Operations_Product_and_Category.DAL
{
    public class DataManager :DbContext
    {
        public DataManager():base("WebAppCon")
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}