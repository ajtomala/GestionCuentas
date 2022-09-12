using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ICuentaRepositorio
    {
        void CrearCuenta(Cuentum cuenta);
        void EditarCuenta(Cuentum cuenta);
        void EliminarCuenta(Cuentum cuenta);

        void ActualizarCuenta(Cuentum cuenta);


        long ObtenerIdCliente(string identificacion);
        Cuentum ObtenerCuentaCliente(string identificacion, string cuenta);
        
    }
}
