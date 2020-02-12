using Microsoft.AspNetCore.Mvc;
using ViaCEP;

namespace CRM.ConsultaCEP.Proxy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly CepQueryService _cepQueryService;

        public CepController(CepQueryService cepQueryService)
        {
            _cepQueryService = cepQueryService;
        }

        [HttpGet("{numero}")]
        public ViaCEPResult Get(string numero)
        {
            return _cepQueryService.Find(numero);
        }
    }
}