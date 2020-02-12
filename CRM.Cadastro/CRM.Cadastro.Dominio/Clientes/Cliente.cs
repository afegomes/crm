using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Cadastro.Dominio.Clientes
{
    public class Cliente : AbstractEntity
    {
        public string Nome { get; set; }

        public char Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public Endereco GetEnderecoResidencial()
        {
            return Enderecos.SingleOrDefault(x => x.Tipo == TipoEndereco.RESIDENCIAL);
        }

        public Endereco GetEnderecoComercial()
        {
            return Enderecos.SingleOrDefault(x => x.Tipo == TipoEndereco.COMERCIAL);
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            if (Enderecos == null)
            {
                Enderecos = new List<Endereco>();
            }

            if (Enderecos.Any(x => x.Tipo == endereco.Tipo))
            {
                throw new TipoEnderecoExistenteException();
            }

            Enderecos.Add(endereco);
        }

        public void RemoverEndereco(Endereco endereco)
        {
            if (Enderecos == null)
            {
                return;
            }

            Enderecos.Remove(endereco);
        }

        public void Atualizar(AtualizacaoClienteCommand command)
        {
            Nome = command.Nome;
            Sexo = command.Sexo.First();
            DataNascimento = command.DataNascimento;

            var endereco = GetEnderecoResidencial();
            endereco.Logradouro = command.Logradouro;
            endereco.Numero = int.Parse(command.Numero);
            endereco.Complemento = command.Complemento;
            endereco.Cep = command.Cep;
            endereco.Bairro = command.Bairro;
            endereco.Cidade = command.Cidade;
            endereco.Estado = command.Estado;
        }

        public static Cliente Novo(InclusaoClienteCommand command)
        {
            var cliente = new Cliente
            {
                Nome = command.Nome,
                DataNascimento = command.DataNascimento,
                Sexo = command.Sexo.First()
            };

            var endereco = new Endereco
            {
                Logradouro = command.Logradouro,
                Numero = int.Parse(command.Numero),
                Complemento = command.Complemento,
                Cep = command.Cep,
                Bairro = command.Bairro,
                Cidade = command.Cidade,
                Estado = command.Estado,
                Tipo = TipoEndereco.RESIDENCIAL
            };

            cliente.AdicionarEndereco(endereco);

            return cliente;
        }
    }
}