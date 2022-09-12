using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Dominio.Interfaces;
using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using Infraestructura.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infraestructura.IoC
{
    public class IoC
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuracion)
        {

            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<ICuentaRepositorio, CuentaRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<CuentaContext>(options =>
            options.UseSqlServer(configuracion.GetConnectionString("DefaultConnection")));
        }

    }
}
