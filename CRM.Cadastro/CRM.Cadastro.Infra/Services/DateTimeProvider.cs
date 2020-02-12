using CRM.Cadastro.Aplicacao.Infra;
using System;

namespace CRM.Cadastro.Infra.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Current()
        {
            return DateTime.Now;
        }
    }
}