using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cidades.API.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeCompleto = table.Column<string>(maxLength: 100, nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    DataDeNascimento = table.Column<DateTimeOffset>(nullable: false),
                    CidadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "RS", "Alegrete" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "RS", "Pelotas" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "RS", "Passo Fundo" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "RS", "Santa Maria" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "RS", "Porto Alegre" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), "SP", "São Paulo" },
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), "SC", "Florianópolis" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeId", "DataDeNascimento", "NomeCompleto", "Sexo" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTimeOffset(new DateTime(1989, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -2, 0, 0, 0)), "Rafael Vieira Suarez", "M" },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTimeOffset(new DateTime(1987, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "Caroline Seer Splett", "F" },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new DateTimeOffset(new DateTime(1983, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "Larissa Macedo Machado", "F" },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new DateTimeOffset(new DateTime(1991, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "Roobertchay Domingues da Rocha Filho", "M" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CidadeId",
                table: "Clientes",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
