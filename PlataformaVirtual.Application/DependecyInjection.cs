using Microsoft.Extensions.DependencyInjection;
using PlataformaVirtual.Application.Ports.Implementations;
using PlataformaVirtual.Application.Ports.Input.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreatePersonaUseCase, CreatePersonaUseCase>();
            return services;
        }
    }
}
