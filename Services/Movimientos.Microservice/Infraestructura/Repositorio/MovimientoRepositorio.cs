using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Context;
namespace Infraestructura.Repositorio
{
    public class MovimientoRepositorio : IMovimientoRespositorio
    {
        readonly MovimientoContext _context;
        public MovimientoRepositorio(MovimientoContext context)
        {
            _context = context;
        }
        public void CrearMovimiento(Movimiento movimiento)
        {
            Movimiento _cuenta = new Movimiento()
            {
                Saldo = movimiento.Saldo,
                Cuentaid = movimiento.Cuentaid,
                Descripcion =  movimiento.Descripcion,
                Fecha =  movimiento.Fecha,
                Tipomovimiento = movimiento.Tipomovimiento,
                Valor =  movimiento.Valor              

            };
            _context.Movimientos.Add(_cuenta);
        }
        public void ActualizarMovimiento(Movimiento movimiento)
        {
            _context.Movimientos.Update(movimiento);
            
        }

        public void EditarMovimiento(Movimiento movimiento)
        {
            _context.Movimientos.Update(movimiento);
        }

        public void EliminarMovimiento(long CodMovimiento)
        {            
           _context.Movimientos.Remove(new Movimiento() { Movimientoid = CodMovimiento });
                         
        }
        public Cuentum ObtenerCuentaCliente(string cuenta)
        {
            var CuentaCliente =
                  _context
                  .Cuenta
                  .FirstOrDefault
                  (x => x.Numcuenta == cuenta);

            return CuentaCliente;
        }

        public Movimiento ObtenerUltimoMovimiento(long CodCuenta)
        {
            var movimiento = _context
                .Movimientos.Where(x=>x.Cuentaid == CodCuenta)
                .OrderByDescending(m => m.Fecha).FirstOrDefault();
            return movimiento;

        }


        public List<ReporteUsuarioFecha> MovimientosFechasUsuario(string identificacion, DateTime fechasInicio,DateTime fechaFin)
        {
            var reporte = (from m in _context.Movimientos
                        join c in _context.Cuenta on m.Cuentaid equals c.Cuentaid
                        join p in _context.Clientes on c.Clienteid equals p.Personaid
                        where m.Fecha.Date >= fechasInicio.Date 
                           && m.Fecha.Date <= fechaFin.Date
                           && p.Persona.Identificacion == identificacion

                          select new ReporteUsuarioFecha
                          {
                              Fecha = m.Fecha.Date,
                              Cliente = p.Persona.Nombre,
                              Estado = c.Estado,
                              NumeroCuenta= c.Numcuenta,
                              Tipo = c.Tipocuenta,
                              SaldoInicial = c.Saldoinicial,
                              SaldoDisponible = m.Saldo,
                              Movimiento = m.Valor

                          }).ToList();


            return reporte;


        }

        public bool ExistMovimiento(long codMovimiento) {

            return _context.Movimientos.Any(i => i.Movimientoid == codMovimiento);

        }
         
    }
}
