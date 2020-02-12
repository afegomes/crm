using CRM.Cadastro.Aplicacao.Manutencao;
using CRM.Cadastro.Dominio;
using CRM.Cadastro.Dominio.Clientes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRM.Cadastro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteQuery _clienteQuery;
        private readonly InclusaoClienteCommandHandler _inclusaoClienteHandler;
        private readonly AtualizacaoClienteCommandHandler _atualizacaoClienteHandler;
        private readonly RemocaoClienteCommandHandler _remocaoClienteHandler;

        public ClienteController(IClienteQuery clienteQuery, InclusaoClienteCommandHandler inclusaoClienteHandler,
            AtualizacaoClienteCommandHandler atualizacaoClienteHandler, RemocaoClienteCommandHandler remocaoClienteHandler)
        {
            _clienteQuery = clienteQuery;
            _inclusaoClienteHandler = inclusaoClienteHandler;
            _atualizacaoClienteHandler = atualizacaoClienteHandler;
            _remocaoClienteHandler = remocaoClienteHandler;
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDto> Get(long id)
        {
            return Ok(_clienteQuery.FindById(id));
        }

        [HttpGet]
        public ActionResult<IList<ClienteDto>> Get()
        {
            return Ok(_clienteQuery.FindAll());
        }

        [HttpPost]
        public ActionResult<ClienteDto> Post(InclusaoClienteCommand command)
        {
            return Created(nameof(Get), _inclusaoClienteHandler.Handle(command));
        }

        [HttpPut]
        public ActionResult<string> Put(AtualizacaoClienteCommand command)
        {
            return Ok(_atualizacaoClienteHandler.Handle(command));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(long id)
        {
            return Ok(_remocaoClienteHandler.Handle(new IdentificationCommand { Id = id }));
        }
    }
}