using BarbeariaABC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models.DTO
{
    public class MarcacaoCreateDTO
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, selecione o cliente que pretende gerar a marcação.")]
        public int ClienteId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, selecione o funcionário que pretende atribuir a marcação.")]
        public int FuncionarioId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, selecione o serviço que pretende realizar a marcação.")]
        public int ServicoId { get; set; }
        public string Data { get; set; }
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$", ErrorMessage = "A hora deve estar no formato hh:mm:ss")]
        public string Hora { get; set; }
        public StatusMarcacao Status { get; set; } = StatusMarcacao.PENDENTE;
        public TipoMarcacao TipoMarcacao { get; set; } = TipoMarcacao.MARCADA;
        public int CriadoPor { get; set; } = 0;
        public int ActualizadoPor { get; set; } = 0;
        public int AnuladoPor { get; set; } = 0;
    }
}
