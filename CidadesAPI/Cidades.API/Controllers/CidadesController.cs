using AutoMapper;
using Cidades.API.Models;
using Cidades.API.ResourcesParameters;
using Cidades.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

        /// <summary>
        /// Cadastrar uma cidade que contêm Nome(string 100) e Estado(string 2)
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Consultar uma lista de cidades pelo nome ou pelo estado ou ambos
        /// </summary>
        /// <param name="cidadesResourceParameters"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Consultar uma cidade específica pelo ID
        /// </summary>
        /// <param name="cidadeId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobrescrevendo ValidationProblem para retornar mensagem de detalhe da validação e a url da instancia
        /// </summary>
        /// <param name="modelStateDictionary"></param>
        /// <returns></returns>
        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}
