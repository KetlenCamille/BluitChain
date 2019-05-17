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
        [Display(Name = "Grupo Sanguíneo")]
        public String GrupoSanguineo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Fator RH")]
        public String FatorRH { get; set; }
    }
}