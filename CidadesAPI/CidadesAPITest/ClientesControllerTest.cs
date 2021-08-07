using AutoMapper;
using Cidades.API;
using Cidades.API.Controllers;
using Cidades.API.Models;
using Cidades.API.Profiles;
using Cidades.API.ResourcesParameters;
using Cidades.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CidadesAPITest
{
    public class ClientesControllerTest
    {
        ClientesController _controller;
        IApiRepository _service;                
        private static IMapper _mapper;
        ILogger<ClientesController> _logger;

        
        public ClientesControllerTest()
        {
            _service = new ApiRepositoryFake();

            _logger = Mock.Of<ILogger<ClientesController>>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ClientesProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _controller = new ClientesController(_logger,_service, _mapper);
        }

        [Fact]
        public void GetCliente_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetCliente(Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetClientes_WhenCalled_ReturnsByParameters()
        {
            // Act
            var okResult = _controller.GetClientes( new ClientesResourceParameters() { NomeCompleto = "Rafael Vieira Suarez"}).Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ClienteDto>>(okResult.Value);

            Assert.Single(items);
        }
    }
}
