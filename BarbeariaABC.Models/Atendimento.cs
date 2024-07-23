using BarbeariaABC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int MarcacaoId { get; set; }
        public Marcacao? Marcacao { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public double Total { get; set; } = 0.0;
        public StatusAtendimento StatusAtendimento { get; set; } = StatusAtendimento.CRIADO;
        public ICollection<ItemAtendimento>? ItemAtendimentos { get; set; }

    }
}
