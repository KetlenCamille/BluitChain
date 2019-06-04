using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlutChain.Models
{
    [Table("Doacao")]
    public class Doacao
    {
        [Key]
        public int IdDoacao { get; set; }

        public TipoSanguineo TipoSanguineoDoacao { get; set; }

        public Hemobanco HemobancoDoacao { get; set; }

        public Usuario UsuarioDoacao { get; set; }

    }
}