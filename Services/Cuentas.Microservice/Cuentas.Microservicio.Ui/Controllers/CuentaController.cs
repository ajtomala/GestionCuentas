using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.DTOs;
using Aplicacion.Interfaces;

namespace Cuentas.Microservicio.Ui.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        private string mensaje = "OK";
        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;

        }


        [HttpPost]
        public IActionResult Crear(CuentaDTO cliente)
        {

            var result =  _cuentaService.CrearCuenta(cliente);

            if (result == -1) mensaje = "No existe cliente con la identificación ingresada";

            if (result == -2) mensaje = "La cuenta ingresada  fue previamente registrada";

            return Ok(new {mensaje = mensaje });
        }

        [HttpPatch("{identificacion}")]
        public IActionResult editar(string identificacion,string cuenta, CuentaEditarDTO model)
        {
            _cuentaService.EditarCuenta(identificacion,cuenta,model);
            return Ok(new
            {
                mensaje = "cliente editado"
            });
        }

        [HttpPut("{identificacion}")]
        public IActionResult actualizar(string identificacion, CuentaActualizarDTO model)
        {
            _cuentaService.ActualizarCuenta(identificacion,model);
            return Ok(new
            {
               
                mensaje = "cliente actualizado"
            });
        }

        [HttpDelete("{identificacion}")]
        public IActionResult Delete(string identificacion,string cuenta)
        {
            _cuentaService.EliminarCuenta(identificacion, cuenta);
            return Ok(new
            {
              
                mensaje = "Cuenta eliminada"
            });
        }
    }
}
