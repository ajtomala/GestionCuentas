using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Infraestructura.Context
{
   public class MovimientoContextFactory : IDesignTimeDbContextFactory<MovimientoContext>
    {
        public MovimientoContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<MovimientoContext>();
            OptionsBuilder.UseSqlServer("DefaultConnection");
            return new MovimientoContext(OptionsBuilder.Options);
        }
    }
}
