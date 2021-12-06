using KuzeyCodeFirst.Models;
using KuzeyCodeFirst.Models.Abstracts;
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


            modelBuilder.Entity<SiparisDetay>()
                .HasKey(x => new { x.SiparisId, x.UrunId });

            modelBuilder.Entity<SiparisDetay>()
                .Property(x => x.Fiyat)
                .HasPrecision(10, 2);


            //modelBuilder.Entity<SiparisDetay>()
            //    .ToTable("SiparisDetaylari");

            //modelBuilder.Entity<SiparisDetay>()
            //    .HasKey(x => new { x.SiparisId, x.UrunId }); //composite key

            //modelBuilder.Entity<SiparisDetay>()
            //    .HasOne<Siparis>(sd => sd.Siparis)
            //    .WithMany(s => s.SiparisDetaylari)
            //    .HasForeignKey(sd => sd.SiparisId);

            //modelBuilder.Entity<SiparisDetay>()
            //    .HasOne<Urun>(sd => sd.Urun)
            //    .WithMany(u => u.SiparisDetaylari)
            //    .HasForeignKey(sd => sd.UrunId);

            //modelBuilder.Entity<SiparisDetay>()
            //    .Property(x => x.Fiyat)
            //    .HasPrecision(10, 2);

        }
        public override int SaveChanges()
        {
            var entiries = ChangeTracker.Entries()
                 .Where(x => x.Entity is BaseEntity && x.State == EntityState.Added);
            foreach (var item in entiries)
            {
                ((BaseEntity)item.Entity).CreatedDate = DateTime.Now;

            }

            entiries = ChangeTracker.Entries()
                 .Where(x => x.Entity is BaseEntity && x.State == EntityState.Modified);
            foreach (var item in entiries)
            {
                ((BaseEntity)item.Entity).UpdatedDate = DateTime.Now;
            }
            entiries = ChangeTracker.Entries()
                 .Where(x => x.Entity is BaseEntity && x.State == EntityState.Deleted);
            foreach (var item in entiries)
            {
                ((BaseEntity)item.Entity).DeletedDate = DateTime.Now;
                ((BaseEntity)item.Entity).IsDeleted =true;
                item.State = EntityState.Modified;
            }

            return base.SaveChanges();
        }
       
    }
}
