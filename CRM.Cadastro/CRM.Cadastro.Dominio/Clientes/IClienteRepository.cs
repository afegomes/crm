namespace CRM.Cadastro.Dominio.Clientes
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);

        Cliente FindById(long id);

        void Remove(long id);
    }
}