using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infraestructura.Context
{
   public class ClienteDbContext : DbContext
    {

        public ClienteDbContext() : base() { }
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            builder.Entity<Persona>().ToTable("Persona");

            builder.Entity<Cliente>().ToTable("Cliente"); 
            builder.Entity<Cliente>().HasIndex(u => u.Personaid).IsUnique(true);
            builder.Entity<Cliente>().HasIndex(p => new { p.Personaid}).IsUnique(true).HasName("IX_clienteid");
           // builder.Entity<Cliente>().Property(u => u.ClienteId).ValueGeneratedOnUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);


            builder.Entity<Cuenta>().ToTable("Cuenta");
            builder.Entity<Cuenta>().HasIndex(u => u.numcuenta).IsUnique(true);

            
            builder.Entity<Movimiento>().ToTable("Movimiento").HasOne(c => c.cuenta).WithMany(x => x.movimientos);
            

        } 
    }
}
