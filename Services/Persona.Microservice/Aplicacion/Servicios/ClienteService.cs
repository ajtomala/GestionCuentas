using Aplicacion.DTOs;
using Aplicacion.Interfaces;

using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Aplicacion.Helpers;

namespace Aplicacion.Servicios
{
    public class ClienteService : IClienteService
    {

         readonly IClienteRepositorio _clienteRepositorio;
         readonly IUnitOfWork  _unitOfWork;
        
        public ClienteService(IClienteRepositorio clienteRespositorio, IUnitOfWork unitOfWork )
        {
            _clienteRepositorio = clienteRespositorio;
            _unitOfWork = unitOfWork;
        }

        public  long CrearCliente(ClienteDTO  clienteDTO)
        {
           
            var esCliente = _clienteRepositorio.obtenerCliente(clienteDTO.Identificacion);

            if(esCliente != null) throw new AppException("Cliente ya existe");


            Cliente cliente = new Cliente
            {
                Nombre = clienteDTO.Nombre,
                Direccion = clienteDTO.Direccion,
                Edad = clienteDTO.Edad,
                Genero = clienteDTO.Genero,
                Identificacion = clienteDTO.Identificacion,
                Telefono = clienteDTO.Telefono,                
                estado = true,
                contrasenia = ComputeSha256Hash(clienteDTO.contrasenia)
            };

            _clienteRepositorio.CrearCliente(cliente);
            return _unitOfWork.SaveChanges();
                        
        }

        public void EditarCliente(string identificacion, ClienteEditarDTO cliente)
        {
            var item = _clienteRepositorio.obtenerCliente(identificacion);
            
            if(item ==null) throw new AppException("Cliente no existe");

            item.Genero = cliente.Genero;
            item.Edad = cliente.Edad;
            item.Direccion = cliente.Direccion;
            item.contrasenia = ComputeSha256Hash(cliente.contrasenia);
            item.Telefono = cliente.Telefono;
            item.Nombre = cliente.Nombre;
            item.Identificacion = identificacion;
            item.estado = cliente.estado;

            _clienteRepositorio.EditarCliente(item);
            _unitOfWork.SaveChanges();
        }

        public void ActualizarCliente(string identificacion, ClienteActualizarDTO cliente)
        {
            var item = _clienteRepositorio.obtenerCliente(identificacion);

            if (item == null) throw new AppException("Cliente no existe"); ;

            item.Genero = cliente.Genero;
            item.Edad = cliente.Edad;
            item.Direccion = cliente.Direccion;
            item.contrasenia = ComputeSha256Hash(cliente.contrasenia);
            item.Telefono = cliente.Telefono;
            item.Nombre = cliente.Nombre;
            item.Identificacion = cliente.identificacion;
            item.estado = cliente.estado;

            _clienteRepositorio.ActualizarCliente(item);
            _unitOfWork.SaveChanges();
        }

        public void EliminarCliente(string identificacion)
        {
            var cliente = _clienteRepositorio.obtenerCliente(identificacion);
            if (cliente == null) throw new AppException("Cliente no existe");

            _clienteRepositorio.EliminarCliente(cliente);
            _unitOfWork.SaveChanges();
        }

         
        static byte[] ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                //StringBuilder builder = new StringBuilder();
                //for (int i = 0; i < bytes.Length; i++)
                //{
                //    builder.Append(bytes[i].ToString("x2"));
                //}
                return bytes; //builder.ToString();
            }
        }
       
    }
}
