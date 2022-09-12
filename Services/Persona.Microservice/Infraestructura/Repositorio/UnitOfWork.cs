using Dominio.Interfaces;
using Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ClienteDbContext _context;

        public UnitOfWork(ClienteDbContext dbContext)
        {
            _context = dbContext;
        }

        public int SaveChanges()
        {  
            return _context.SaveChanges();
            
        }
    }
}
