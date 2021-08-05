using System;
using System.ComponentModel.DataAnnotations;

namespace Cidades.API.Models
{
    public class CidadeParaCriacaoDto
    {
        [Required(ErrorMessage = "Você deve informar um Nome.")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Você deve informar um Estado.")]
        [MaxLength(2)]
        public string Estado { get; set; }

    }
}
