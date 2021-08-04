using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cidades.API.Entities
{
    public class Cliente
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeCompleto { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public DateTimeOffset DataDeNascimento { get; set; }

        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }

        public Guid CidadeId { get; set; }

    }
}
