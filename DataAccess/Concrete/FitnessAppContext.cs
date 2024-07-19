using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class FitnessAppContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2N1ABAB\SQLEXPRESS03;Initial Catalog=FitnessAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<PersonelGirisi> PersonelGirisi { get; set; }
        public DbSet<YoneticiGirisi> YoneticiGirisi { get; set; }
        public DbSet<OzelDers> OzelDers { get; set; }
        public DbSet<Maas> Maas { get; set; }
        public DbSet<Egitmen> Egitmen { get; set; }
        public DbSet<Odeme> Odeme { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Paket> Paketler { get; set; }
        public DbSet<Gider> Gider { get; set; }







    }
}
