using CRM.Cadastro.Aplicacao.Infra;
using CRM.Cadastro.Dominio.Clientes;

namespace CRM.Cadastro.Aplicacao.Manutencao
{
    public class AtualizacaoClienteCommandHandler : AbstractCommandHandler<AtualizacaoClienteCommand, string>
    {
        private readonly IClienteRepository _clienteRepository;

        public AtualizacaoClienteCommandHandler(IUnitOfWork unitOfWork, IClienteRepository clienteRepository) : base(unitOfWork)
        {
            _clienteRepository = clienteRepository;
        }

        protected override string ProcessCommand(AtualizacaoClienteCommand command)
        {
            var cliente = _clienteRepository.FindById(command.Id);
            cliente.Atualizar(command);

            return string.Empty;
        }
    }
}