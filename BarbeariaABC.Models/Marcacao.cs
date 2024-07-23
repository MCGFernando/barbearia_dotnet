using BarbeariaABC.Models.CustomValidations;
using BarbeariaABC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class Marcacao
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue,ErrorMessage = "Por favor, forneça um clinete válido")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, forneça um funcionário válido")]
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, forneça um serviço válido")]
        public int ServicoId { get; set; }
        public Servico? Servico { get; set; }
        [Required(ErrorMessage = "Por favor, defina a data da marcação")]
        [FutureDate(ErrorMessage = "A data deve ser no futuro.")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Por favor, defina a hora da marcação")]
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public StatusMarcacao Status { get; set; } = StatusMarcacao.PENDENTE;
        public TipoMarcacao TipoMarcacao { get; set; } = TipoMarcacao.MARCADA;
        public DateTime? DataRegisto { get; set; }
        public DateTime? DataActualizacao { get; set; }
        public DateTime? DataAnulacao { get; set; }
        public int CriadoPor { get; set; } = 0;
        public int ActualizadoPor { get; set; } = 0;
        public int AnuladoPor { get; set; } = 0;
    }
}
