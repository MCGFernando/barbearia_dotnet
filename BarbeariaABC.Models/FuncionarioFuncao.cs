using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class FuncionarioFuncao
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
        public int FuncaoId { get; set; }
        public Funcao? Funcao { get; set; }
    }
}
