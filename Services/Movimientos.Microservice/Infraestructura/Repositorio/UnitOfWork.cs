using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Infraestructura.Context;
namespace Infraestructura.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly MovimientoContext _context;
        public UnitOfWork(MovimientoContext dbContext)
        {
            _context = dbContext;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();

        }

    }
}
