using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FakeStore.Models
{
    class SqliteDBContext : DbContext
    {
        //public DbSet<Product> Products { get; set; }
        
      //  public DbSet<> Cart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=db.sqlite");
            base.OnConfiguring(options);
        }

    }
}
