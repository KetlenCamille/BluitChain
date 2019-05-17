using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlutChain.Models
{
    [Table("TipoSanguineo")]
    public class TipoSanguineo
    {
        [Key]
        public int IdTipoSanguineo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(3, ErrorMessage = "Nescessário informar o Tipo Sanguíneo!")]
        [Display(Name = "Tipo Sanguíneo")]
        public char GrupoSanguineo { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o Faotr Rh!")]
        [Display(Name = "Fator Rh")]
        public char FatorRH { get; set; }
    }
}