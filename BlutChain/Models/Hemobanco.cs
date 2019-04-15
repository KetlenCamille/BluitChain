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

        public String RazaoSocialHemobanco { get; set; }

        public String NomeFantasiaHemobanco { get; set; }

        public String CPNJHemobanco { get; set; }

        public String EmailHemobanco { get; set; }

        public Endereco EnderecoHemobanco { get; set; }

        public Telefone TelefoneHemobanco { get; set; }
    }
}