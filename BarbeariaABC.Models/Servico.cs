using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Duracao { get; set; }
        public decimal Preco { get; set; }
        public List<FuncionarioServico>? FuncionarioServicos { get; set; }
    }
}
