using Cidades.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cidades.API.DbContexts
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed cidade
            modelBuilder.Entity<Cidade>().HasData(
                new Cidade()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Nome = "Alegrete",
                    Estado = "RS"
                },
                new Cidade()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Nome = "Pelotas",
                    Estado = "RS"
                },
                new Cidade()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Nome = "Passo Fundo",
                    Estado = "RS"
                },
                new Cidade()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Nome = "Santa Maria",
                    Estado = "RS"
                },
                new Cidade()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Nome = "Porto Alegre",
                    Estado = "RS"
                },
                new Cidade()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    Nome = "São Paulo",
                    Estado = "SP"
                },
                new Cidade()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    Nome = "Florianópolis",
                    Estado = "SC"
                }
                );

            modelBuilder.Entity<Cliente>().HasData(
               new Cliente
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   CidadeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   NomeCompleto = "Rafael Vieira Suarez",
                   DataDeNascimento = new DateTime(1989, 2, 6),
                   Sexo = "M"
               },
               new Cliente
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   CidadeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   NomeCompleto = "Caroline Seer Splett",
                   DataDeNascimento = new DateTime(1987, 7, 30),
                   Sexo = "F"
               },
               new Cliente
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   CidadeId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   NomeCompleto = "Larissa Macedo Machado",
                   DataDeNascimento = new DateTime(1983, 5, 11),
                   Sexo = "F"
               },
               new Cliente
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   CidadeId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   NomeCompleto = "Roobertchay Domingues da Rocha Filho",
                   DataDeNascimento = new DateTime(1991, 3, 2),
                   Sexo = "M"
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
