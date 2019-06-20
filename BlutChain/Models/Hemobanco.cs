using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlutChain.Models
{
    [Table("Hemobanco")]
    public class Hemobanco
    {
        [Key]
        public int IdHemobanco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "O campo deve ter no máximo 150 caracteres!")]
        [Display(Name = "Razão Social")]
        public String RazaoSocialHemobanco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "O campo deve ter no máximo 150 caracteres!")]
        [Display(Name = "Nome Fantasia")]
        public String NomeFantasiaHemobanco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(14, ErrorMessage = "O campo deve ter 14 caracteres!")]
        [MaxLength(14, ErrorMessage = "O campo deve ter 14 caracteres!")]
        [Display(Name = "CNPJ")]
        public String CNPJHemobanco { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public String EmailHemobanco { get; set; }

        [Display(Name = "Rua")]
        public String Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Numero")]
        public int Numero { get; set; }

        [Display(Name = "Bairro")]
        public String Bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(10, ErrorMessage = "O campo deve ter no máximo 10 caracteres!")]
        [Display(Name = "CEP")]
        public String CEP { get; set; }

        [Display(Name = "Cidade")]
        public String Localidade { get; set; }

        [Display(Name = "Estado")]
        public String Uf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(8, ErrorMessage = "O campo deve ter no minimo 8 caracteres!")]
        [MaxLength(15, ErrorMessage = "O campo deve ter no máximo 15 caracteres!")]
        [Display(Name = "Telefone")]
        public String TelefoneHemobanco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Telefone")]
        public String TipoTelefoneHemobanco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(6, ErrorMessage = "O campo deve ter no mínimo 6 caracteres!")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        [Display(Name = "Confirmar senha")]
        [NotMapped]
        public string ConfirmacaoDaSenha { get; set; }
    }
}