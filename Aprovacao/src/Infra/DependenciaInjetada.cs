using Aplicacao.Interfaces;
using Infra.Interfaces.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependenciaInjetada
    {
        public static IServiceCollection AdicionarInfra(this IServiceCollection services)
        {
           services.AddDbContext<AplicacaoDbContext>(options =>
                    options.UseInMemoryDatabase("AprovacaoDb"));
            
            services.AddScoped<IAplicacaoDbContext>(provider => provider.GetService<AplicacaoDbContext>());

            return services;
        }
    }
}
