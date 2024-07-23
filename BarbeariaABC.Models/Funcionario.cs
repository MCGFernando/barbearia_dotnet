using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o nome do cliente que pretende cadastrar")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o e-mail do cliente que pretende cadastrar")]
        [EmailAddress(ErrorMessage = "Por favor, introduza um e-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o telefone do cliente que pretende cadastrar")]
        public string Telefone { get; set; }
        public bool IsActivo { get; set; } = false;
        public List<FuncionarioFuncao>? FuncionarioFuncoes { get; set; }
        public List<FuncionarioServico>? FuncionarioServicos { get; set; }
        public List<AgendaFuncionario>? AgendaFuncionarios { get; set; }
        
    }
}
