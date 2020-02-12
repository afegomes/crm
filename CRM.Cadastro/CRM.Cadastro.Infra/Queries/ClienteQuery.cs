using CRM.Cadastro.Aplicacao.Manutencao;
using CRM.Cadastro.Dominio.Clientes;
using CRM.Cadastro.Infra.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Cadastro.Infra.Queries
{
    internal class ClienteQuery : IClienteQuery
    {
        private readonly CadastroDbContext _db;

        public ClienteQuery(CadastroDbContext db)
        {
            _db = db;
        }

        public ClienteDto FindById(long id)
        {
            var result = from cliente in _db.Clientes.Where(x => x.Id == id)
                         let endereco = cliente.Enderecos.Where(x => x.Tipo == TipoEndereco.RESIDENCIAL).SingleOrDefault()
                         select new ClienteDto
                         {
                             Id = cliente.Id.Value,
                             Nome = cliente.Nome,
                             Sexo = cliente.Sexo.ToString(),
                             DataNascimento = cliente.DataNascimento.ToString("dd/MM/yyyy"),
                             Logradouro = endereco.Logradouro,
                             Numero = endereco.Numero,
                             Complemento = endereco.Complemento,
                             Cep = endereco.Cep,
                             Bairro = endereco.Bairro,
                             Cidade = endereco.Cidade,
                             Estado = endereco.Estado
                         };

            return result.SingleOrDefault();
        }

        public IList<ClienteDto> FindAll()
        {
            var result = from cliente in _db.Clientes
                         select new ClienteDto
                         {
                             Id = cliente.Id.Value,
                             Nome = cliente.Nome
                         };

            return result.ToList();
        }
    }
}