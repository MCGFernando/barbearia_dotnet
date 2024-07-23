using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models.DTO
{
    public class AgendaFuncionarioCreateDTO
    {
        public int FuncionarioId { get; set; }
        [Range(0,6,ErrorMessage = "O dia da semana deve ser um valor válido.")]
        public int DiaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
    }
}
