using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Reportes;

namespace Dominio.Interfaces
{
   public interface IMovimientoRespositorio
    {
        void CrearMovimiento(Movimiento movimiento);
        void EditarMovimiento(Movimiento movimiento);
        void EliminarMovimiento(long CodMovimiento);

        void ActualizarMovimiento(Movimiento movimiento);

        Cuentum ObtenerCuentaCliente(string cuenta);

        Movimiento ObtenerUltimoMovimiento(long CodCuenta);

        bool ExistMovimiento(long codMovimiento);

        List<ReporteUsuarioFecha> MovimientosFechasUsuario(string identificacion, DateTime fechasInicio, DateTime fechaFin);
    }
}
