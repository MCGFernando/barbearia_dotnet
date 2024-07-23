using BarbeariaABC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }
        public string? Referencia { get; set; }
        public FormaPagamento FormaPagamento { get; set; } = FormaPagamento.DINHEIRO;
        public TipoPagamento TipoPagamento { get; set; } = TipoPagamento.A_VISTA;

        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
