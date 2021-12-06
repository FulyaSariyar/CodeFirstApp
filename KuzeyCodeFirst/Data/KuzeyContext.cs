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
        public DbSet<Kategori> Kategoriler {get; set;}
        public DbSet<Urun>Urunler { get; set; }
    }
}
