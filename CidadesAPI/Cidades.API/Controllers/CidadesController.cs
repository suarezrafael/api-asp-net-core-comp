using AutoMapper;
using Cidades.API.Models;
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
        //Consultar cidade pelo nome
        //Consultar cidade pelo estado

        [HttpGet("{cidadeId}")]
        public IActionResult GetCidade(Guid cidadeId)
        {
            var cidade = _apiRepository.GetCidade(cidadeId);

            if (cidade == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CidadeDto>(cidade));
        }

        [HttpGet("{nome}")]
        public IActionResult GetCidades(string nome)
        {
            var cidadesEntidade = _apiRepository.GetCidades(nome);

            return Ok(_mapper.Map<IEnumerable<CidadeDto>>(cidadesEntidade));
        }
    }
}
