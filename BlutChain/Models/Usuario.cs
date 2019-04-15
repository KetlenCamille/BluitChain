using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlutChain.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        public String NomeUsuario { get; set; }

        public String CPFUsuario { get; set; }

        public DateTime DataNascimentoUsuario { get; set; }

        public char SexoUsuario { get; set; }

        public String EmailUsuario { get; set; }

        public int PesoUsuario { get; set; }

        public TipoSanguineo TipoSanguineoUsuario { get; set; }

        public Endereco EnderecoUsuario { get; set; }

        public Telefone TelefoneUsuario { get; set; }
    }
}