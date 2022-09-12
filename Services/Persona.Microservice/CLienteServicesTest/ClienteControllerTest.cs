using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace CLienteServicesTest
{
    public class ClienteControllerTest
    {

        private readonly IClienteService _clienteService;

        public ClienteControllerTest(IClienteService clienteService)
        {
            _clienteService = clienteService;

        }

        [Fact]
        public void Crear()
        {
           
            var cliente = new ClienteDTO()
            {
                Edad =10,
                contrasenia = "12333",
                Direccion = "villa",
                Genero ="Masculino",
                Identificacion = "0923101711",
                Nombre="Alexi",
                Telefono = "0986257345"
            };

           
            
            long resul = _clienteService.CrearCliente(cliente);
          

            Assert.IsType<long>(resul);

            Assert.Equal(1,resul);

            
            var clienteIncompleto = new ClienteDTO()
            {
                Genero = "Masculino",
                Identificacion = "0923101711",
                Nombre = "Alexi",
                Telefono = "0986257345"
            };


           
            long resulIncom = _clienteService.CrearCliente(clienteIncompleto);

            
            Assert.IsType<OkObjectResult>(resulIncom);

           

        }
    }
}
