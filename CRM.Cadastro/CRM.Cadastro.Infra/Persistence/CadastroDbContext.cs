using CRM.Cadastro.Dominio.Clientes;
using Microsoft.EntityFrameworkCore;

namespace CRM.Cadastro.Infra.Persistence
{
    public class CadastroDbContext : DbContext
    {
        public CadastroDbContext(DbContextOptions<CadastroDbContext> options) : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.MapCliente();
            builder.MapEndereco();
        }
    }
}