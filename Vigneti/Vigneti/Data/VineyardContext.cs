using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigneti.Models;

namespace Vigneti.Data
{
    public class VineyardContext : DbContext
    {
        public VineyardContext(DbContextOptions<VineyardContext> options) : base(options) { }


        // Creazione delle tabelle

        public DbSet<VineGrower> VineGrowers { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Vineyard> Vineyards { get; set; }


        // Metodo utile per cambiare i nomi delle tabelle
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VineGrower>().ToTable("VineGrower");
            modelBuilder.Entity<Wine>().ToTable("Wine");
            modelBuilder.Entity<Vineyard>().ToTable("Vineyard");
        }
    }
}
