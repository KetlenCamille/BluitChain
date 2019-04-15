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

        public char Tipo { get; set; }

        public String Numero { get; set; }
    }
}