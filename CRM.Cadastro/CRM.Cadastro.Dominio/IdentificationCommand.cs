using System.ComponentModel.DataAnnotations;

namespace CRM.Cadastro.Dominio
{
    public class IdentificationCommand : ICommand
    {
        [Required]
        public long Id { get; set; }
    }
}