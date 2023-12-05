using Booky.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.DAL.Data
{
    public class BookyDbContext:DbContext
    {//Empty ParamterLess Constructor:base
        public BookyDbContext(DbContextOptions<BookyDbContext> options ):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="Action",DisplayOrder=1},
                new Category { Id =2, Name = "SciFic", DisplayOrder =2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
