using ContaBancaria.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ClientHandler>(
                serviceProvider => new ClientHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                    )
            );

            services.AddScoped<IEntityCrudHandler<Agencia>>(
                serviceProvider => new AgenciaHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                    )
            );

            services.AddScoped<IEntityCrudHandler<Conta>>(
                serviceProvider => new ContaHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                    )
            );

            services.AddScoped<IEntityCrudHandler<Endereco>>(
                serviceProvider => new EnderecoHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                    )
            );

            services.AddScoped<IEntityCrudHandler<Banco>>(
                serviceProvider => new BancoHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                    )
            );

            return services;
        }
    }
}
