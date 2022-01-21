using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
    public class ProductRecallDbContext:DbContext
    {
        public ProductRecallDbContext(DbContextOptions<ProductRecallDbContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Manufactureres> Manufactureres { get; set; }
        public DbSet<Recalls> Recalls { get; set; }
        public DbSet<Announcements> Announcements { get; set; }

    }
}
