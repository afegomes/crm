using CRM.Cadastro.Dominio.Clientes;
using Microsoft.EntityFrameworkCore;

namespace CRM.Cadastro.Infra.Persistence
{
    internal static class EnderecoMapping
    {
        public static void MapEndereco(this ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasKey(x => x.Id);

            builder.Entity<Endereco>()
                .Property(x => x.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            builder.Entity<Endereco>()
                .Property(x => x.Numero)
                .IsRequired();

            builder.Entity<Endereco>()
                .Property(x => x.Complemento)
                .HasMaxLength(20);

            builder.Entity<Endereco>()
                .Property(x => x.Cep)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Entity<Endereco>()
                .Property(x => x.Bairro)
                .IsRequired()
                .HasMaxLength(30);

            builder.Entity<Endereco>()
                .Property(x => x.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<Endereco>()
                .Property(x => x.Estado)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength();

            builder.Entity<Endereco>()
                .Property(x => x.Tipo)
                .IsRequired();
        }
    }
}