using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contatos.Models
{
    [Table("TB_CONTATO")]
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do contato é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        
        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}