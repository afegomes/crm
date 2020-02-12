using CRM.Cadastro.Dominio.Clientes;
using Xunit;

namespace CRM.Cadastro.UnitTests.Dominio
{
    public class ClienteTest
    {
        private readonly Cliente _cliente;

        public ClienteTest()
        {
            _cliente = new Cliente();
        }

        [Fact]
        public void DadoUmNovoClienteQuandoIncluirUmEnderecoEntaoDeveraSerIncluidoComSucesso()
        {
            _cliente.AdicionarEndereco(CriarEndereco(TipoEndereco.COMERCIAL));
        }

        [Fact]
        public void DadoUmClienteComUmEnderecoQuandoIncluirUmEnderecoDeOutroTipoEntaoDeveraSerIncluidoComSucesso()
        {
            _cliente.AdicionarEndereco(CriarEndereco(TipoEndereco.COMERCIAL));
            _cliente.AdicionarEndereco(CriarEndereco(TipoEndereco.RESIDENCIAL));
        }

        [Fact]
        public void DadoUmClienteComUmEnderecoQuandoIncluirUmEnderecoDoMesmoTipoEntaoDeveraLancarUmaExcecao()
        {
            _cliente.AdicionarEndereco(CriarEndereco(TipoEndereco.COMERCIAL));

            Assert.Throws<TipoEnderecoExistenteException>(() => _cliente.AdicionarEndereco(CriarEndereco(TipoEndereco.COMERCIAL)));
        }

        [Fact]
        public void DadoUmClienteComUmEnderecoResidencialQuandoSolicitarUmEnderecoResidencialEntaoDevereiObterOMesmo()
        {
            var endereco = CriarEndereco(TipoEndereco.RESIDENCIAL);

            _cliente.AdicionarEndereco(endereco);

            Assert.Equal(endereco, _cliente.GetEnderecoResidencial());
        }

        [Fact]
        public void DadoUmClienteComUmEnderecoResidencialQuandoSolicitarUmEnderecoDeOutroTipoEntaoNaoDevereiObterNada()
        {
            _cliente.AdicionarEndereco(CriarEndereco(TipoEndereco.RESIDENCIAL));

            Assert.Null(_cliente.GetEnderecoComercial());
        }

        [Fact]
        public void DadoUmClienteComUmEnderecoComercialQuandoSolicitarUmEnderecoComercialEntaoDevereiObterOMesmo()
        {
            var endereco = CriarEndereco(TipoEndereco.COMERCIAL);

            _cliente.AdicionarEndereco(endereco);

            Assert.Equal(endereco, _cliente.GetEnderecoComercial());
        }

        [Fact]
        public void DadoUmClienteComUmEnderecoComercialQuandoSolicitarUmEnderecoDeOutroTipoEntaoNaoDevereiObterNada()
        {
            _cliente.AdicionarEndereco(CriarEndereco(TipoEndereco.COMERCIAL));

            Assert.Null(_cliente.GetEnderecoResidencial());
        }

        [Fact]
        public void DadoUmClienteComUmEnderecoQuandoRemoverEsseEnderecoEntaoOMesmoNaoDeveraConstarMais()
        {
            var endereco = CriarEndereco(TipoEndereco.RESIDENCIAL);

            _cliente.AdicionarEndereco(endereco);
            _cliente.RemoverEndereco(endereco);

            Assert.Null(_cliente.GetEnderecoResidencial());
        }

        private Endereco CriarEndereco(TipoEndereco tipo)
        {
            return new Endereco
            {
                Tipo = tipo
            };
        }
    }
}