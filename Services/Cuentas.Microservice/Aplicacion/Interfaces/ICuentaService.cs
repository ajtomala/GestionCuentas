
using Aplicacion.DTOs;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface ICuentaService
    {
        int CrearCuenta(CuentaDTO cuenta);
        void EditarCuenta(string identificacion, string NumCuenta, CuentaEditarDTO cuenta);
        void ActualizarCuenta(string identificacion,CuentaActualizarDTO cuenta);
        void EliminarCuenta(string identificacion, string cuenta);
    }
}
