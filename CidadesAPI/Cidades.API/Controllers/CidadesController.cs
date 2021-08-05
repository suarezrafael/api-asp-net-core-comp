using AutoMapper;
using Cidades.API.Models;
using Cidades.API.ResourcesParameters;
using Cidades.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Cidades.API
{
    [ApiController]
    [Route("api/cidades")]
    public class CidadesController : ControllerBase
    {
        private readonly ILogger<CidadesController> _logger;
        private readonly IApiRepository _apiRepository;
        private readonly IMapper _mapper;

        public CidadesController(ILogger<CidadesController> logger, IApiRepository apiRepository,
            IMapper mapper)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _apiRepository = apiRepository ??
                throw new ArgumentNullException(nameof(apiRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //Cadastrar cidade
        [HttpPost]
        public ActionResult<CidadeDto> CreateCidade(CidadeParaCriacaoDto cidade)
        {
            try
            {
                var cidadeEntidade = _mapper.Map<Entities.Cidade>(cidade);

                _apiRepository.AddCidade(cidadeEntidade);

                _apiRepository.Save();

                var cidadeParaRetorno = _mapper.Map<CidadeDto>(cidadeEntidade);

                return CreatedAtRoute("GetCidade",
                    new { cidadeId = cidadeParaRetorno.Id },
                    cidadeParaRetorno);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exceção ao cadastrar cidade com nome {cidade.Nome}", ex);
                return StatusCode(500, "Ocorreu um problema ao lidar com sua solicitação.");
            }
        }

        //Consultar cidade pelo nome
        //Consultar cidade pelo estado

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<CidadeDto>> GetCidades(
            [FromQuery] CidadesResourceParameters cidadesResourceParameters)
        {
            try
            {
                var cidadeEntidade = _apiRepository.GetCidades(cidadesResourceParameters);
                return Ok(_mapper.Map<IEnumerable<CidadeDto>>(cidadeEntidade));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exceção ao consultar cidade com os parametros: {cidadesResourceParameters.ToString()}", ex);
                return StatusCode(500, "Ocorreu um problema ao lidar com sua solicitação.");
            }
        }

        // Usado para retorno de CreatedAtRoute em CreateCidade
        [HttpGet("{cidadeId}", Name = "GetCidade")]
        public IActionResult GetCidade(Guid cidadeId)
        {
            try
            {
                var cidadeEntidade = _apiRepository.GetCidade(cidadeId);

                if (cidadeEntidade == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<CidadeDto>(cidadeEntidade));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exceção ao consultar cidade com o id: {cidadeId}", ex);
                return StatusCode(500, "Ocorreu um problema ao lidar com sua solicitação.");
            }
        }

    }
}
