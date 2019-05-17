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

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o Endereço!")]
        [Display(Name = "Rua")]
        public String Rua { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o Número!")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o Bairro!")]
        [Display(Name = "Bairro")]
        public String Bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o CEP!")]
        [Display(Name = "CEP")]
        public String CEP { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar a Cidade!")]
        [Display(Name = "Cidade")]
        public String Cidade { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o Estado!")]
        [Display(Name = "Estado")]
        public char Estado { get; set; }
    }
}