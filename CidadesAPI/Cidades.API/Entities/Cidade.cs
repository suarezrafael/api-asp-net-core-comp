using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cidades.API.Entities
{
    public class Cidade
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        public ICollection<Cliente> Clientes { get; set; } 
            = new List<Cliente>();
    }
}
