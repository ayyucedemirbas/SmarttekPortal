using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;

namespace DataAcces.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Temaslar> Temaslar { get; set; }
        //public DbSet<Firmalar> Firmalar { get; set; }
        public DbSet<Temaslar> Temaslar { get; set; }
        public DbSet<Gorevler> Gorevler { get; set; }
        public DbSet<Personeller> Personel { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<FirmaAciklama> FirmaAciklama { get; set; }
        public DbSet<FirmaYetkili> FirmaYetkili { get; set; }
    }
}
