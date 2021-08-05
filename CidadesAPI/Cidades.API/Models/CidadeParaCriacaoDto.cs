using System;

namespace Cidades.API.Models
{
    public class CidadeParaCriacaoDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Estado { get; set; }

    }
}
