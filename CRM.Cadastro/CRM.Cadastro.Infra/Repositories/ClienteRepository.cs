using CRM.Cadastro.Dominio.Clientes;
using CRM.Cadastro.Infra.Persistence;

namespace CRM.Cadastro.Infra.Repositories
{
    internal class ClienteRepository : IClienteRepository
    {
        private readonly CadastroDbContext _db;

        public ClienteRepository(CadastroDbContext db)
        {
            _db = db;
        }

        public void Add(Cliente cliente)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
        }

        public Cliente FindById(long id)
        {
            return _db.Clientes.Find(id);
        }

        public void Remove(long id)
        {
            _db.Clientes.Remove(new Cliente { Id = id });
        }
    }
}