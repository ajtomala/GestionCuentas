using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IClienteRepositorio
    {
       
        void CrearCliente(Cliente cliente);
        void EditarCliente(Cliente cliente);
        void EliminarCliente(Cliente cliente);

        void ActualizarCliente(Cliente cliente);
        
        Cliente obtenerCliente(string identificacion);
    }
}
