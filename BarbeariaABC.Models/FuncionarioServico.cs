using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class FuncionarioServico
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
        public int ServicoId { get; set; }
        public Servico? Servico { get; set; }
    }
}
