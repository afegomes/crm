using CRM.Cadastro.Aplicacao.Infra;
using CRM.Cadastro.Dominio;
using CRM.Cadastro.Dominio.Clientes;

namespace CRM.Cadastro.Aplicacao.Manutencao
{
    public class RemocaoClienteCommandHandler : AbstractCommandHandler<IdentificationCommand, string>
    {
        private readonly IClienteRepository _clienteRepository;

        public RemocaoClienteCommandHandler(IUnitOfWork unitOfWork, IClienteRepository clienteRepository) : base(unitOfWork)
        {
            _clienteRepository = clienteRepository;
        }

        protected override string ProcessCommand(IdentificationCommand command)
        {
            _clienteRepository.Remove(command.Id);

            return string.Empty;
        }
    }
}