using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Context
{
    public class ClienteContextFactory : IDesignTimeDbContextFactory<ClienteDbContext>
    {
        public ClienteDbContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<ClienteDbContext>();
            OptionsBuilder.UseSqlServer("DefaultConnection");
            return new ClienteDbContext(OptionsBuilder.Options);
        }
    }
}
