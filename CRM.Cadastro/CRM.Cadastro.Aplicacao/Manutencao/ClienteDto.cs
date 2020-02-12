namespace CRM.Cadastro.Aplicacao.Manutencao
{
    public class ClienteDto
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }

        public string DataNascimento { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public int? Numero { get; set; }
    }
}