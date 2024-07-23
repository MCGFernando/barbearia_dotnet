using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbeariaABC.Models
{
    [Serializable]
    public class Funcao
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Por favor, forneça a descrição para a função que deseja cadastrar")]
        public string Descricao { get; set; }
        public List<FuncionarioFuncao>? FuncionarioFuncoes { get; set; }
    }
}
