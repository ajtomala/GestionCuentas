using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entidades;
using Infraestructura.Context;

namespace Infraestructura.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        readonly ClienteDbContext _context;
        public ClienteRepositorio(ClienteDbContext context)
        {
            _context = context;
        }
         
        public void CrearCliente(Cliente cliente) {

          Cliente _cliente = new Cliente() {
             Personaid = cliente.Personaid,
             contrasenia = cliente.contrasenia,
             estado = true,
              Direccion = cliente.Direccion,
              Edad = cliente.Edad,
              Genero = cliente.Genero,
              Identificacion = cliente.Identificacion,
              Nombre = cliente.Nombre,
              Telefono = cliente.Telefono,

          };
           _context.Cliente.Add(_cliente);
            
           
        }
        public void EditarCliente(Cliente cliente) {

            _context.Cliente.Update(cliente);
           

        }

        public void ActualizarCliente(Cliente cliente)
        {

            _context.Cliente.Update(cliente);
           
        }
        public void EliminarCliente(Cliente cliente) {

            _context.Cliente.Remove(cliente);

        }
        public Cliente obtenerCliente(string identificacion) {

           var persona =  _context.Persona.FirstOrDefault(x => x.Identificacion == identificacion);
            if (persona == null) return null;
            return _context.Cliente.FirstOrDefault(x => x.Personaid == persona.Personaid);


        }
    }
}
