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

        public char GrupoSanguineo { get; set; }

        public char FatorRH { get; set; }
    }
}