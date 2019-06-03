using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlutChain.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }

        [Display(Name = "Rua")]
        public String Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Numero")]
        public int Numero { get; set; }

        [Display(Name = "Bairro")]
        public String Bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(8, ErrorMessage = "O campo deve ter no máximo 8 caracteres!")]
        [Display(Name = "CEP")]
        public String CEP { get; set; }

        [Display(Name = "Cidade")]
        public String Localidade { get; set; }

        [Display(Name = "Estado")]
        public String Uf { get; set; }
    }
}