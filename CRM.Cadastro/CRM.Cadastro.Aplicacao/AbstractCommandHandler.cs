using CRM.Cadastro.Aplicacao.Infra;
using CRM.Cadastro.Dominio;

namespace CRM.Cadastro.Aplicacao
{
    public abstract class AbstractCommandHandler<T, U>
        where T : ICommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public AbstractCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public U Handle(T command)
        {
            _unitOfWork.Begin();

            var result = ProcessCommand(command);

            _unitOfWork.SaveChanges();
            _unitOfWork.Commit();

            return result;
        }

        protected abstract U ProcessCommand(T command);
    }
}