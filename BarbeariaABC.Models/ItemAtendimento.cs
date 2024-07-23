using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class ItemAtendimento
    {
        public int Id { get; set; }
        public int ServicoId { get; set; }
        public Servico? Servico { get; set; }
        public int AtendimentoId { get; set; }
        [JsonIgnore]
        public Atendimento? Atendimento { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; } = 1;
        public double Preco { get; set; } = 0.0;
    }
}
