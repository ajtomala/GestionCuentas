using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infraestructura.Context 
{
    public class CuentaContextFactory : IDesignTimeDbContextFactory<CuentaContext>
    {
        public CuentaContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<CuentaContext>();
            OptionsBuilder.UseSqlServer("DefaultConnection");
            return new CuentaContext(OptionsBuilder.Options);
        }
    }
}
