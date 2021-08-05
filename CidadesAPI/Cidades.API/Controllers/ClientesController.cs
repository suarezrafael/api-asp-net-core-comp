using AutoMapper;
using Cidades.API.Models;
using Cidades.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Cidades.API.Controllers
{
    [ApiController]
    [Route("api/cidades/{cidadeId}/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IApiRepository _apiRepository;
        private readonly IMapper _mapper;

        public ClientesController(ILogger<ClientesController> logger, IApiRepository apiRepository,
            IMapper mapper)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _apiRepository = apiRepository ??
                throw new ArgumentNullException(nameof(apiRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //Cadastrar cliente
        // TODO

        //Consultar cliente pelo nome
        [HttpGet]
        public ActionResult<IEnumerable<ClienteDto>> GetClientePorNome(Guid cidadeId, string nome)
        {
            if (!_apiRepository.CidadeExists(cidadeId))
            {
                return NotFound();
            }

            var clientes = _apiRepository.GetClientes(cidadeId, nome);

            return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientes));
        }

        //Consultar cliente pelo Id
        [HttpGet("{clienteId}")]
        public ActionResult<ClienteDto> GetCourseForAuthor(Guid cidadeId, Guid clienteId)
        {
            if (!_apiRepository.CidadeExists(cidadeId))
            {
                return NotFound();
            }

            var cliente = _apiRepository.GetCliente(cidadeId, clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Models.ClienteDto>(cliente));
        }

        //Remover cliente
        // TODO

        //Alterar o nome do cliente
        // TODO
    }
}
