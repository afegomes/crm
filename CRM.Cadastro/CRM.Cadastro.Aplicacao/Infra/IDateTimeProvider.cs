using System;

namespace CRM.Cadastro.Aplicacao.Infra
{
    public interface IDateTimeProvider
    {
        DateTime Current();
    }
}