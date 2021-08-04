﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cidades.API
{
    [ApiController]
    [Route("api/cidades")]
    public class CidadesController : ControllerBase
    {
        private readonly ILogger<CidadesController> _logger;

        public CidadesController(ILogger<CidadesController> logger)
        {
            _logger = logger;
        }

        //Cadastrar cidade
        //Consultar cidade pelo nome
        //Consultar cidade pelo estado

    }
}