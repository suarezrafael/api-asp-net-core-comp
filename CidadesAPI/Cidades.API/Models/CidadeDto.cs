using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cidades.API.Models
{
    public class CidadeDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Estado { get; set; }

    }
}
