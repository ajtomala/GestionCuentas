using Microsoft.AspNetCore.Mvc;
using Aplicacion.Interfaces;
using Aplicacion.DTOs;

namespace Cliente.Microservice.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
       
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
            
        }
               

        [HttpPost]
        public IActionResult Crear(ClienteDTO cliente)
        {
            string mensaje = "NOK";
           var result =  _clienteService.CrearCliente(cliente);
            if (result >= 1) mensaje = "cliente creado";


            return Ok(new { mensaje = mensaje });
        }

        [HttpPatch("{identificacion}")]
        public IActionResult editar(string identificacion, ClienteEditarDTO model)
        {
            _clienteService.EditarCliente(identificacion, model);
            return Ok(new {
               
                mensaje =   "cliente editado" });
        }

        [HttpPut("{identificacion}")]
        public IActionResult actualizar(string identificacion, string cuenta, ClienteActualizarDTO model)
        {
            _clienteService.ActualizarCliente(identificacion, model);
            return Ok(new
            {
                
                mensaje = "cliente actualizado"
            });
        }

        [HttpDelete("{identificacion}")]
        public IActionResult Delete(string identificacion)
        {
            _clienteService.EliminarCliente(identificacion);
            return Ok(new { 
               
                mensaje = "cliente eliminado"
            });
        }
    }
}
