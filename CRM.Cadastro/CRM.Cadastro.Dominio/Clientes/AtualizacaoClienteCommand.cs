using System.ComponentModel.DataAnnotations;

namespace CRM.Cadastro.Dominio.Clientes
{
    public class AtualizacaoClienteCommand : InclusaoClienteCommand
    {
        [Required]
        public long Id { get; set; }
    }
}