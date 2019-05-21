using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Contatos.Models
{
    public class ContatoViewModel
    {
        public Int32 Id { get; set; }

        [Required(ErrorMessage = "O nome do contato é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Contato")]
        public String Nome { get; set; }

        [Display(Name = "Email do Contato")]
        public String Email { get; set; }

        [Display(Name = "Telefone do Contato")]
        public String Telefone { get; set; }
    }
}