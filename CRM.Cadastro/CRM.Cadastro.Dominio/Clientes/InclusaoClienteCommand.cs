using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Cadastro.Dominio.Clientes
{
    public class InclusaoClienteCommand : ICommand
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }
}