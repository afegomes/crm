using CRM.Cadastro.Aplicacao.Infra;
using CRM.Cadastro.Dominio.Clientes;

namespace CRM.Cadastro.Aplicacao.Manutencao
{
    public class InclusaoClienteCommandHandler : AbstractCommandHandler<InclusaoClienteCommand, ClienteDto>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ElegibilidadeService _elegibilidadeService;

        public InclusaoClienteCommandHandler(IUnitOfWork unitOfWork, IClienteRepository clienteRepository, IDateTimeProvider dateTimeProvider,
            ElegibilidadeService elegibilidadeService) : base(unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _dateTimeProvider = dateTimeProvider;
            _elegibilidadeService = elegibilidadeService;
        }

        protected override ClienteDto ProcessCommand(InclusaoClienteCommand command)
        {
            _elegibilidadeService.ValidarMaioridade(command.DataNascimento, _dateTimeProvider.Current());

            var cliente = Cliente.Novo(command);
            _clienteRepository.Add(cliente);

            return new ClienteDto
            {
                Id = cliente.Id.Value
            };
        }
    }
}