using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.DTOs;
using Aplicacion.Interfaces;

namespace Movimientos.Microservice.Controllers
{
    [ApiController]
    [Route("api/movimientos")]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;

        public MovimientosController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpPost]
        public IActionResult Crear(string NumeroCuenta, MovimientoDTO  movimiento)
        {
            string mensaje = "Transaccion realizada correctamente";
             
            long response =_movimientoService.CrearMovimiento(NumeroCuenta,movimiento);
           
            if (response == -1)
                 mensaje = "Saldo no disponible";
                           
            return Ok(new { codmensaje = response, mensaje = mensaje });
        }

        [HttpDelete("{CodigoMovimiento}")]
        public IActionResult Delete(long CodigoMovimiento)
        {
            _movimientoService.EliminarMovimiento(CodigoMovimiento);
            return Ok(new
            {
                codmensaje = "0000",
                mensaje = "movimiento eliminada"
            });
        }

        [HttpPut("{CodigoMovimiento}")]
        public IActionResult actualizar(long CodigoMovimiento, ActualizarMovimientoDTO model)
        {
            _movimientoService.ActualizarMovimiento(CodigoMovimiento, model);
            return Ok(new
            {
                codmensaje = "0000",
                mensaje = "movimiento actualizado"
            });
        }

        [HttpPatch("{CodigoMovimiento}")]
        public IActionResult editar(long codigoMovimeinto, EditarMovimientoDTO model)
        {
            _movimientoService.EditarMovimiento(codigoMovimeinto, model);
            return Ok(new
            {
                codmensaje = "0000",
                mensaje = "movimiento editado"
            });
        }

        [HttpGet("reportes")]
        public IActionResult MovimientosUsuarioPorFecha(string identificacion,DateTime fechaInicio, DateTime fechaFinal)
        {
           var movimientos = _movimientoService.MovimientosFechasUsuario(identificacion, fechaInicio, fechaFinal);
            return Ok(new
            {
                movimientos,
                codmensaje = "0000",
                mensaje = "Exito"
            });
        }
    }
}
