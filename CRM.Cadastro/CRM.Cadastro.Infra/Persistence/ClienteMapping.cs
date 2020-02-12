using CRM.Cadastro.Dominio.Clientes;
using Microsoft.EntityFrameworkCore;

namespace CRM.Cadastro.Infra.Persistence
{
    internal static class ClienteMapping
    {
        public static void MapCliente(this ModelBuilder builder)
        {
            builder.Entity<Cliente>()
                .HasKey(x => x.Id);

            builder.Entity<Cliente>()
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Cliente>()
                .Property(x => x.Sexo)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength();

            builder.Entity<Cliente>()
                .Property(x => x.DataNascimento)
                .IsRequired();

            builder.Entity<Cliente>()
                .HasMany(x => x.Enderecos)
                .WithOne()
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}