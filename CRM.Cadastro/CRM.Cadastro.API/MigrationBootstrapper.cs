using CRM.Cadastro.Infra.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Cadastro.API
{
    /// <summary>
    /// Amarra a atualização da base ao deploy da aplicação para efeitos de demonstração.
    /// Num cenário real, a atualização da base seria executada dentro de um pipeline antes do deploy.
    /// </summary>
    internal static class MigrationBootstrapper
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var ctx = scope.ServiceProvider.GetService<CadastroDbContext>();

            ctx.Database.Migrate();
        }
    }
}