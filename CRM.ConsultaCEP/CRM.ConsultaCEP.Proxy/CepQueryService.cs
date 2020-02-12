using Polly;
using ViaCEP;

namespace CRM.ConsultaCEP.Proxy
{
    public class CepQueryService
    {
        private readonly ISyncPolicy _cachePolicy;

        public CepQueryService(ISyncPolicy cachePolicy)
        {
            _cachePolicy = cachePolicy;
        }

        public ViaCEPResult Find(string cep)
        {
            var result = _cachePolicy.ExecuteAndCapture(x => ViaCEPClient.Search(cep), new Context(cep));

            return result.Result;
        }
    }
}