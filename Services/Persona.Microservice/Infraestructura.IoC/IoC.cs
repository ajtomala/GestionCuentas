using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Dominio.Interfaces;
using Infraestructura.Context;
using Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infraestructura.IoC
{
    public class IoC
    {
        public static void RegisterServices(IServiceCollection services,
            IConfiguration configuracion)
        {

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ClienteDbContext>(options =>
            options.UseSqlServer(configuracion.GetConnectionString("DefaultConnection")));// @"Server = sds0100db20; Database = BaseDatos; User Id = sa; Password = Pruebasa1"));//configuration.GetConnectionString("cliente")));
        }

    }
}
