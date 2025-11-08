using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaVirtual.Domain.Ports.Output.Repository;
using PlataformaVirtual.Domain.Services.Implementations;
using PlataformaVirtual.Domain.Services.Interfaces;
using PlataformaVirtual.Infrastructure.Adapter.Output.Repository;
using PlataformaVirtual.Infrastructure.Configuration.Context;

namespace PlataformaVirtual.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TramiteDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbTramite"));
            });

            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPersonaService, PersonaService>();

            services.AddScoped<IOperadorRepository, OperadorRepository>();
            services.AddScoped<IOperadorService, OperadorService>();

            return services;
        }
    }
}
