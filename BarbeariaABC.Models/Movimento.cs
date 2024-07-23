using BarbeariaABC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class Movimento
    {
        public int Id { get; set; }
        public int ContaClienteId { get; set; }
        public ContaCliente? ContaCliente { get; set; }
        public int AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public TipoMovimento TipoMovimento { get; set; }
    }
}
