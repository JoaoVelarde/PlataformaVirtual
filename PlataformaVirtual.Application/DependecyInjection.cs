using Microsoft.Extensions.DependencyInjection;
using PlataformaVirtual.Application.Ports.Implementations;
using PlataformaVirtual.Application.Ports.Input.Personas;

namespace PlataformaVirtual.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreatePersonaUseCase, CreatePersonaUseCase>();
            services.AddScoped<IGetPersonaUseCase, GetPersonaUseCase>();
            return services;
        }
    }
}
