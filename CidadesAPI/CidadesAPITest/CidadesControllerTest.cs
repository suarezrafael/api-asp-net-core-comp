using AutoMapper;
using Cidades.API;
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
    public class CidadesControllerTest
    {
        CidadesController _controller;
        IApiRepository _service;                
        private static IMapper _mapper;
        ILogger<CidadesController> _logger;

        
        public CidadesControllerTest()
        {
            _service = new ApiRepositoryFake();

            _logger = Mock.Of<ILogger<CidadesController>>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new CidadesProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _controller = new CidadesController(_logger,_service, _mapper);
        }

        [Fact]
        public void GetCidade_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetCidade(Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetCidades_WhenCalled_ReturnsByParameters()
        {
            // Act
            var okResult = _controller.GetCidades( new CidadesResourceParameters() { Nome = "Alegrete"}).Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<CidadeDto>>(okResult.Value);

            Assert.Single(items);
        }
    }
}
