using Aplicacion.Interfaces;
using Dominio.Interfaces;
using System;
using Aplicacion.DTOs;
using Dominio.Entidades;
using System.Collections.Generic;
using Dominio.Reportes;

namespace Aplicacion.Servicios
{

    public class MovimientoService : IMovimientoService
    {
        readonly IMovimientoRespositorio _movimientoRepository;
        readonly IUnitOfWork _unitOfWork;
        public MovimientoService(IMovimientoRespositorio MovimientoRespositorio, IUnitOfWork unitOfWork)
        {
            _movimientoRepository = MovimientoRespositorio;
            _unitOfWork = unitOfWork;
        }
        public long CrearMovimiento(string cuenta, MovimientoDTO movimientoDto)
        {
            Cuentum ItemCuenta = _movimientoRepository.ObtenerCuentaCliente(cuenta);
            Movimiento mov = _movimientoRepository.ObtenerUltimoMovimiento(ItemCuenta.Cuentaid);

            decimal saldoInicial = (mov == null) ? ItemCuenta.Saldoinicial : mov.Saldo;


            string tipoMovimiento = TipoMovimiento(movimientoDto.Valor);
            Decimal valorMovimiento = Math.Abs(movimientoDto.Valor);

            if (tipoMovimiento.Equals("Debito")
                && !FondosDisponible(ItemCuenta.Saldoinicial, valorMovimiento))

                return -1;//Saldo no disponible.


            Decimal saldo = NuevoSaldo(tipoMovimiento, saldoInicial, valorMovimiento);

            Movimiento movimiento = new Movimiento
            {
                Cuentaid = ItemCuenta.Cuentaid,

                Descripcion = movimientoDto.Descripcion,
                Tipomovimiento = tipoMovimiento,
                Fecha = movimientoDto.Fecha,
                Saldo = saldo,
                Valor = valorMovimiento

            };
            ItemCuenta.Saldoinicial = saldoInicial;

            _movimientoRepository.CrearMovimiento(movimiento);
            _unitOfWork.SaveChanges();
            return movimiento.Movimientoid;
        }
        public void ActualizarMovimiento(long codMovimiento, ActualizarMovimientoDTO actualizarMovimiento)
        {
            if (!_movimientoRepository.ExistMovimiento(codMovimiento)) return;

            Movimiento movimiento = new Movimiento() {
                Movimientoid = codMovimiento,
                Descripcion = actualizarMovimiento.Descripcion,
                Fecha = actualizarMovimiento.Fecha,
                Saldo = actualizarMovimiento.Saldo,
                Tipomovimiento = actualizarMovimiento.TipoMovimiento,
                Valor = actualizarMovimiento.Valor
            };

            _movimientoRepository.ActualizarMovimiento(movimiento);
            _unitOfWork.SaveChanges();
        }

        public void EditarMovimiento(long codMovimiento, EditarMovimientoDTO editarMovimiento)
        {
            if (!_movimientoRepository.ExistMovimiento(codMovimiento)) return;

            Movimiento movimiento = new Movimiento()
            {
                Movimientoid = codMovimiento,
                Descripcion = editarMovimiento.Descripcion,
                Fecha = editarMovimiento.Fecha,
                
            };
            _movimientoRepository.EditarMovimiento(movimiento);
            _unitOfWork.SaveChanges();
        }

        public void EliminarMovimiento(long codMovimiento)
        {
            if (!_movimientoRepository.ExistMovimiento(codMovimiento)) return;

            _movimientoRepository.EliminarMovimiento(codMovimiento);
            _unitOfWork.SaveChanges();
        }
                
        public List<ReporteMovimientoDTO> MovimientosFechasUsuario(string identificacion, DateTime fechasInicio, DateTime fechaFin)
        {
            var movimientos = _movimientoRepository.MovimientosFechasUsuario(identificacion, fechasInicio, fechaFin);

            List<ReporteMovimientoDTO> movimientoDTOs = new List<ReporteMovimientoDTO>();

            foreach (ReporteUsuarioFecha item in movimientos)
            {
                ReporteMovimientoDTO itemMovimiento = new ReporteMovimientoDTO()
                {
                    Cliente = item.Cliente,
                    Estado = item.Estado,
                    Fecha = item.Fecha.Date,
                    NumeroCuenta = item.NumeroCuenta,
                    Movimiento = item.Movimiento,
                    SaldoDisponible = item.SaldoDisponible,
                    SaldoInicial = item.SaldoInicial,
                    Tipo = item.Tipo

                };
                movimientoDTOs.Add(itemMovimiento);
            }

            return movimientoDTOs;
        }

        string TipoMovimiento(decimal valorMovimiento) {

            return valorMovimiento > 0 ? "Credito" : "Debito";
        }

        bool FondosDisponible(decimal saldoInicial, decimal valorMovimiento)
        {
            return 
             (saldoInicial == 0
                       //50             49
                || (saldoInicial > valorMovimiento));
       }

        decimal NuevoSaldo(string tipo, decimal saldo, decimal valorMovimiento) {

            return (tipo.Equals("Debito") ? (saldo - valorMovimiento) : (saldo + valorMovimiento));
        
        }

        
    }
}
