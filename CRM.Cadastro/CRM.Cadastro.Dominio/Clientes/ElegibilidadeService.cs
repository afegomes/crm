using System;

namespace CRM.Cadastro.Dominio.Clientes
{
    public class ElegibilidadeService
    {
        public void ValidarMaioridade(DateTime dataNascimento, DateTime dataAtual)
        {
            var maioridade = dataNascimento.Date.AddYears(18);

            if (dataAtual.Date.CompareTo(maioridade) < 0)
            {
                // TODO: Lançar uma exceção e criar um tratamento na API
            }
        }
    }
}