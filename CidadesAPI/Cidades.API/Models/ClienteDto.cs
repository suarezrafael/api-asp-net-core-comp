using System;

namespace Cidades.API.Models
{
    public class ClienteDto
    {
        public Guid Id { get; set; }

        public string NomeCompleto { get; set; }

        public string Sexo { get; set; }

        public DateTimeOffset DataDeNascimento { get; set; }

        public int Idade { get; set; }

        public string Cidade { get; set; }


    }
}
