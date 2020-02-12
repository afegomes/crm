namespace CRM.Cadastro.Aplicacao.Infra
{
    public interface IUnitOfWork
    {
        void Begin();

        void Commit();

        void Rollback();

        void SaveChanges();
    }
}