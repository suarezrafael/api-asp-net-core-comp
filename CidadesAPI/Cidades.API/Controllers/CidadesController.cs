using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        //Cadastrar cliente
        //Consultar cidade pelo nome
        //Consultar cidade pelo estado
        //Consultar cliente pelo nome
        //Consultar cliente pelo Id
        //Remover cliente
        //Alterar o nome do cliente
        //Considere o cadastro com dados básicos:
        //Cidades: nome e estado
        //Cliente: nome completo, sexo, data de nascimento, idade e cidade onde mora.exemplos


    }
}
