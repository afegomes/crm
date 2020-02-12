using System.Collections.Generic;

namespace CRM.Cadastro.Aplicacao.Manutencao
{
    public interface IClienteQuery
    {
        ClienteDto FindById(long id);

        IList<ClienteDto> FindAll();
    }
}