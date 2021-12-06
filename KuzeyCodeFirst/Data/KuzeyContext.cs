using KuzeyCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyCodeFirst.Data
{
    public class KuzeyContext : DbContext
    {
        public KuzeyContext()
            : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBulder)
        {
            if (!optionsBulder.IsConfigured)
            {
                optionsBulder.UseSqlServer(
                    connectionString: @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Kuzey4Db; Integrated Security = True;"
                    );
            }
        }
        public DbSet<Kategori> Kategoriler {get; set;}
        public DbSet<Urun>Urunler { get; set; }
        protected  override void OnModelCreating(ModelBuilder modelBuilder) //fluent apı.
        {
            modelBuilder.Entity<Urun>()
                 .Property(x => x.Fiyat)
                 .HasPrecision(10, 2);
                
        }
    }
}
