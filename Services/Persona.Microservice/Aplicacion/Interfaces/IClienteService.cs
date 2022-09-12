using Aplicacion.DTOs;

using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IClienteService
    {
        long CrearCliente(ClienteDTO clienteDTO);
        void EliminarCliente(string identificacion);
        void EditarCliente(string Identificacion, ClienteEditarDTO cliente);
        void ActualizarCliente(string Identificacion, ClienteActualizarDTO cliente);

    }
}
