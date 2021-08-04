using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cidades.API.Controllers
{
    [ApiController]
    [Route("api/cidades")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        //Cadastrar cliente

        //Consultar cliente pelo nome
        //Consultar cliente pelo Id
        //Remover cliente

        //Alterar o nome do cliente
    }
}
