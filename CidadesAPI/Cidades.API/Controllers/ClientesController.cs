using AutoMapper;
using Cidades.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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

        //Consultar cliente pelo nome
        //Consultar cliente pelo Id
        //Remover cliente

        //Alterar o nome do cliente
    }
}
