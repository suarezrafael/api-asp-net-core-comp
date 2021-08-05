using System;
using System.ComponentModel.DataAnnotations;

namespace Cidades.API.Models
{
    public class ClienteParaAtualizacaoDto
    {
        [Required(ErrorMessage = "Você deve informar um Nome Completo.")]
        [MaxLength(100)]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Você deve informar um Sexo.")]
        [MaxLength(1)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Você deve informar uma Data de Nascimento.")]
        public DateTimeOffset DataDeNascimento { get; set; }

        [Required(ErrorMessage = "Você deve informar uma Cidade.")]
        public Guid CidadeId { get; set; }
    }
}
