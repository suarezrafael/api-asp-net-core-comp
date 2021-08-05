using AutoMapper;
using Cidades.API.Models;
using Cidades.API.ResourcesParameters;
using Cidades.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Cidades.API.Controllers
{

    // Revisar com analista se para acessar clientes deve passar por cidades
    //[Route("api/cidades/{cidadeId}/clientes")]

    [ApiController]
    [Route("api/clientes")]
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
        [HttpPost]
        public ActionResult<ClienteDto> Createcliente(ClienteParaCriacaoDto cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteEntidade = _mapper.Map<Entities.Cliente>(cliente);
            _apiRepository.AddCliente(clienteEntidade);
            _apiRepository.Save();

            var clienteParaRetorno = _mapper.Map<ClienteDto>(clienteEntidade);
            return CreatedAtRoute("GetCliente",
                new { clienteId = clienteParaRetorno.Id },
                clienteParaRetorno);
        }

        //Consultar cliente pelo nome
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<ClienteDto>> GetClientes(
            [FromQuery] ClientesResourceParameters clientesResourceParameters)
        {
            var clientesEntidade = _apiRepository.GetClientes(clientesResourceParameters);
            return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientesEntidade));
        }


        //Consultar cliente pelo Id
        [HttpGet("{clienteId}", Name = "GetCliente")]
        public IActionResult GetCliente(Guid clienteId)
        {
            var clienteEntidade = _apiRepository.GetCliente(clienteId);

            if (clienteEntidade == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClienteDto>(clienteEntidade));
        }


        //Remover cliente
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(Guid id)
        {

            var clienteEntidade = _apiRepository
                .GetCliente(id);

            if (clienteEntidade == null)
            {
                return NotFound();
            }

            _apiRepository.DeleteCliente(clienteEntidade);

            _apiRepository.Save();

            return NoContent();
        }


        //Alterar o nome do cliente
        [HttpPatch("{id}")]
        public IActionResult UpdateCliente(Guid id, 
            [FromBody]JsonPatchDocument<ClienteParaAtualizacaoDto> patchDoc)
        {
            var clienteEntidade = _apiRepository
                .GetCliente(id);

            if (clienteEntidade == null)
            {
                return NotFound();
            }

            var clientePatch = _mapper.Map<ClienteParaAtualizacaoDto>(clienteEntidade);

            patchDoc.ApplyTo(clientePatch);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(clientePatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(clientePatch, clienteEntidade);

            _apiRepository.UpdateCliente(clienteEntidade);

            _apiRepository.Save();

            return NoContent();
        }

    }
}
