using Cidades.API.DbContexts;
using Cidades.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Reflection;

namespace Cidades.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Cidades Compasso API",
                    Description = "API Asp NET Core 3.1 Entity Framework LocalDB",
                    TermsOfService = new Uri("https://github.com/suarezrafael/api-asp-net-core-compasso"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael Vieira Suarez",
                        Email = "rafael.suarez@compasso.com.br",
                        Url = new Uri("https://about.me/rafael.suarez")
                        
                    }
                });
                
            });

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;

            })
            .AddNewtonsoftJson(setupAction => {
                setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            })
            .AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(setupAction =>
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    // cria um objeto de detalhes do problema
                    var problemDetailsFactory = context.HttpContext.RequestServices
                        .GetRequiredService<ProblemDetailsFactory>();
                    var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                            context.HttpContext,
                            context.ModelState);

                    // adiciona informações adicionais com colocadas por padrão 
                    problemDetails.Detail = "Verifique o campo de erros para mais detalhes.";
                    problemDetails.Instance = context.HttpContext.Request.Path;

                    // procura o codigo de status para usar
                    var actionExecutingContext =
                          context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

                    // se o model state esta sem erro 
                    // lidando com erro de validação
                    if ((context.ModelState.ErrorCount > 0) &&
                        (actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                    {
                        problemDetails.Type = "https://cidadesapi.com/modelvalidationproblem";
                        problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                        problemDetails.Title = "Um ou mais erros de validação ocorreram.";

                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    }

                    // se uma das chaves não foi encontrada corretamente / não pôde ser analisada
                    // estamos lidando com entrada nula / não analisável
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Um ou mais erros de entrada ocorreram.";
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            }); 

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IApiRepository, ApiRepository>();

            var connectionString = this.Configuration["connectionStrings:ApiDBConnectionString"];

            services.AddDbContext<ApiContext>(db => {
                db.UseSqlServer(connectionString);
            });


            //services.AddSwaggerGen();
           // Register the Swagger generator, defining 1 or more Swagger documents

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context => {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Uma falha inesperada aconteceu. Tente mais tarde  :(  ");
                    });
                });
            }
            app.UseHttpsRedirection();

            app.UseSwagger();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
