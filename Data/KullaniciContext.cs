using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class KullaniciContext : DbContext
    {
        public KullaniciContext (DbContextOptions<KullaniciContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication3.Models.Urun> Urun { get; set; }
        public DbSet<WebApplication3.Models.Ulke> Ulke { get; set; }
        public DbSet<WebApplication3.Models.Kullanici> Kullanici { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>().ToTable("Urun");
            modelBuilder.Entity<Ulke>().ToTable("Ulke");
            modelBuilder.Entity<Kullanici>().ToTable("Kullanici");
        }
    }
}
