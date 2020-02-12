using CRM.Cadastro.Aplicacao.Infra;
using CRM.Cadastro.Aplicacao.Manutencao;
using CRM.Cadastro.Dominio.Clientes;
using CRM.Cadastro.Infra.Persistence;
using CRM.Cadastro.Infra.Queries;
using CRM.Cadastro.Infra.Repositories;
using CRM.Cadastro.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CRM.Cadastro.Infra
{
    public static class IServiceCollectionExtensions
    {
        public static ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurePersistence(configuration);
            services.RegisterDomainServices();
            services.RegisterRepositories();
            services.RegisterApplicationServices();
            services.RegisterQueries();
            services.RegisterInfraServices();
        }

        private static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CadastroDbContext>(options =>
                options
                    .UseLoggerFactory(ConsoleLoggerFactory)
                    .UseMySql(configuration.GetConnectionString("DefaultConnection"))
                );
        }

        private static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<ElegibilidadeService>();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }

        private static void RegisterQueries(this IServiceCollection services)
        {
            services.AddScoped<IClienteQuery, ClienteQuery>();
        }

        private static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<InclusaoClienteCommandHandler>();
            services.AddScoped<AtualizacaoClienteCommandHandler>();
            services.AddScoped<RemocaoClienteCommandHandler>();
        }

        private static void RegisterInfraServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }
    }
}