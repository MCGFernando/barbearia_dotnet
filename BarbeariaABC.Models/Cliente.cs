using System.ComponentModel.DataAnnotations;

namespace BarbeariaABC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o nome do cliente que pretende cadastrar")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o e-mail do cliente que pretende cadastrar")]
        [EmailAddress(ErrorMessage ="Por favor, introduza um e-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o telefone do cliente que pretende cadastrar")]
        public string Telefone { get; set; }
        public bool IsActivo { get; set; } = true;
    }
}