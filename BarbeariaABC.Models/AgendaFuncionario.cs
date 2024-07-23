using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class AgendaFuncionario
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
        [EnumDataType(typeof(DayOfWeek), ErrorMessage = "O dia da semana deve ser um valor válido.")]
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        
    }
}
