using Aplicacion.Interfaces;
using Dominio.Interfaces;
using System;
using Aplicacion.DTOs;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Aplicacion.Servicios
{
    public class CuentaService : ICuentaService
    {

          readonly ICuentaRepositorio _cuentaRepository;        
        readonly IUnitOfWork _unitOfWork;
        public CuentaService(ICuentaRepositorio cuentaRespositorio, IUnitOfWork unitOfWork)
        {
            _cuentaRepository = cuentaRespositorio;
            _unitOfWork = unitOfWork;
        }

        public int CrearCuenta(CuentaDTO cuentaDto)
        {
           long clienteid =  _cuentaRepository.ObtenerIdCliente(cuentaDto.identificacion);
            
            if (clienteid == 0) return -1; //no existe cliente con esa identificación

            var item = _cuentaRepository.ObtenerCuentaCliente(cuentaDto.identificacion, cuentaDto.identificacion);

            if (item != null) return -2;//cuenta se enceuntra registrada

            Cuentum cuenta = new Cuentum
            {
                Clienteid = clienteid,
                Estado = true,
                Saldoinicial = cuentaDto.saldoinicial,
                Numcuenta = cuentaDto.numcuenta,
                Tipocuenta = cuentaDto.tipocuenta

            };

            _cuentaRepository.CrearCuenta(cuenta);
            return _unitOfWork.SaveChanges();
        }

        public void ActualizarCuenta(string identificacion, CuentaActualizarDTO cuenta)
        {
            var item = _cuentaRepository.ObtenerCuentaCliente(identificacion, cuenta.Numcuenta);

            item.Numcuenta = cuenta.Numcuenta;
            item.Saldoinicial = cuenta.Saldoinicial;
            item.Tipocuenta = cuenta.Tipocuenta;
            item.Estado = cuenta.Estado;            

            _cuentaRepository.ActualizarCuenta(item);
            _unitOfWork.SaveChanges();
        
        }

        public void EditarCuenta(string identificacion,string NumCuenta,CuentaEditarDTO cuenta)
        {
            var item = _cuentaRepository.ObtenerCuentaCliente(identificacion, NumCuenta);
                        
            item.Saldoinicial = cuenta.SaldoInicial;
            item.Tipocuenta = cuenta.Tipocuenta;
            item.Estado = cuenta.Estado;

            _cuentaRepository.ActualizarCuenta(item);
            _unitOfWork.SaveChanges();
        }

        public void EliminarCuenta(string identificacion,string cuenta)
        {
            var cliente = _cuentaRepository.ObtenerCuentaCliente(identificacion,cuenta);
            if (cliente == null) throw new KeyNotFoundException("Cliente no existe");

            _cuentaRepository.EliminarCuenta(cliente);
            _unitOfWork.SaveChanges();
        }
    }
}
