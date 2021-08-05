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
        public ActionResult<ClienteDto> CreateCliente(ClienteParaCriacaoDto cliente)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogCritical($"CreateCliente: Exceção ao cadastrar cliente com os seguintes parametros:  {cliente.ToString()}", ex);
                return StatusCode(500, "Ocorreu um problema ao lidar com sua solicitação.");
            }
        }

        //Consultar cliente pelo nome
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<ClienteDto>> GetClientes(
            [FromQuery] ClientesResourceParameters clientesResourceParameters)
        {
            try
            {
                var clientesEntidade = _apiRepository.GetClientes(clientesResourceParameters);
                return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientesEntidade));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"GetClientes: Exceção ao consultar cliente com os seguintes parametros:  {clientesResourceParameters.ToString()}", ex);
                return StatusCode(500, "Ocorreu um problema ao lidar com sua solicitação.");
            }
        }

        //Consultar cliente pelo Id
        [HttpGet("{clienteId}", Name = "GetCliente")]
        public IActionResult GetCliente(Guid clienteId)
        {
            try
            {
                //throw new Exception("Teste Exception 123.");
                var clienteEntidade = _apiRepository.GetCliente(clienteId);

                if (clienteEntidade == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ClienteDto>(clienteEntidade));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"GetCliente: Exceção ao consultar cliente com seguinte id:  {clienteId}", ex);
                return StatusCode(500, "Ocorreu um problema ao lidar com sua solicitação.");
            }
        }


        //Remover cliente
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogCritical($"DeleteCliente: Exceção ao excluir cliente com seguinte id:  {id}", ex);
                return StatusCode(500, "Ocorreu um problema ao lidar com sua solicitação.");
            }
        }


        //Alterar o nome do cliente
        [HttpPatch("{id}")]
        public IActionResult UpdateCliente(Guid id,
            [FromBody] JsonPatchDocument<ClienteParaAtualizacaoDto> patchDoc)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogCritical($"UpdateCliente: Exceção ao atualizar cliente com seguinte id:  {id}", ex);
                return StatusCode(500, "Ocorreu um problema ao lidar com sua solicitação.");
            }
        }

    }
}
