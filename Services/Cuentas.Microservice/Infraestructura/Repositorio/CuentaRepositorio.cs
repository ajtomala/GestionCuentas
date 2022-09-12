using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Context;

namespace Infraestructura.Repositorio
{
    public class CuentaRepositorio : ICuentaRepositorio
    {
        readonly CuentaContext _context;
        public CuentaRepositorio(CuentaContext context)
        {
            _context = context;
        }
       
        public void CrearCuenta(Cuentum cuenta)
        {

            Cuentum _cuenta = new Cuentum()
            {
                Clienteid = cuenta.Clienteid,
                Estado = cuenta.Estado,
                Saldoinicial = cuenta.Saldoinicial,
                Numcuenta = cuenta.Numcuenta,
                Tipocuenta = cuenta.Tipocuenta              

            };
            _context.Cuenta.Add(_cuenta);
        }

        public void EditarCuenta(Cuentum cuenta)
        {
            _context.Cuenta.Update(cuenta);
        }

        public void EliminarCuenta(Cuentum cuenta)
        {
            _context.Cuenta.Remove(cuenta);
        }
        public void ActualizarCuenta(Cuentum cuenta)
        {
            _context.Cuenta.Update(cuenta);
        }

        public long ObtenerIdCliente(string identificacion)
        {

            var persona = _context.Personas.FirstOrDefault(x => x.Identificacion == identificacion);
            if (persona == null) return 0;

            return _context.Clientes.FirstOrDefault(x => x.Personaid == persona.Personaid)?.Personaid ??0;

        }
         
        public Cuentum ObtenerCuentaCliente(string identificacion, string cuenta)
        {
            var CuentaCliente =
                 _context
                 .Cuenta
                 .FirstOrDefault
                 (x => x.Cliente.Persona.Identificacion == identificacion && x.Numcuenta == cuenta);

            return CuentaCliente;
        }

        
    }

}
