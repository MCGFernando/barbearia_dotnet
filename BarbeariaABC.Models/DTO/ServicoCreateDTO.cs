using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models.DTO
{
    public class ServicoCreateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, preencha da descrição do serviço que pretende cadastrar")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Por favor, preencha da duração do serviço que pretende cadastrar")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$", ErrorMessage = "A duração deve estar no formato hh:mm:ss")]
        public string Duracao { get; set; }
        [Required(ErrorMessage = "Por favor, preencha da preço do serviço que pretende cadastrar")]
        public decimal Preco { get; set; }

    }
}
