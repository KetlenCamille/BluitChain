using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlutChain.Models
{
    [Table("Telefone")]
    public class Telefone
    {
        [Key]
        public int IdTelefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Telefone")]
        public String Tipo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(8, ErrorMessage = "O campo deve ter no minimo 8 caracteres!")]
        [MaxLength(12, ErrorMessage = "O campo deve ter no máximo 12 caracteres!")]
        [Display(Name = "Telefone")]
        public String Numero { get; set; }
    }
}