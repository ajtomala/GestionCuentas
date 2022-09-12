
using Aplicacion.DTOs;
using Dominio.Entidades;
using Dominio.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IMovimientoService
    {
        long CrearMovimiento(string NumeroCuenta, MovimientoDTO movimiento);
        void EditarMovimiento(long CodMovimiento,EditarMovimientoDTO editarMovimiento);
        void ActualizarMovimiento(long CodMovimiento, ActualizarMovimientoDTO actualizarMovimiento);
        void EliminarMovimiento(long CodMovimiento);

        List<ReporteMovimientoDTO> MovimientosFechasUsuario(string identificacion, DateTime fechasInicio, DateTime fechaFin);


    }
}
