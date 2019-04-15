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

        public String Rua { get; set; }

        public int Numero { get; set; }
        
        public String Bairro { get; set; }

        public String CEP { get; set; }

        public String Cidade { get; set; }

        public char Estado { get; set; }
    }
}