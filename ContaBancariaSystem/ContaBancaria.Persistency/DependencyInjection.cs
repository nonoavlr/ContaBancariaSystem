using ContaBancaria.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContaBancaria.Persistency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistency(this IServiceCollection services)
        {
            services.AddDbContext<ContaBancariaDbContext>(options =>
            {
                options.UseSqlite("Filename=../ContaBancaria.Persistency/ContaBancaria.db", opt =>
                {
                    opt.MigrationsAssembly(
                        typeof(ContaBancariaDbContext).Assembly.FullName
                    );
                });

                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IApplicationDbContext>(ctx =>
                ctx.GetRequiredService<ContaBancariaDbContext>());

            return services;
        }
    }
}
