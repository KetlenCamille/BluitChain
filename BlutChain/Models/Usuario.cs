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



        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "O campo deve ter no máximo 150 caracteres!")]
        [Display(Name = "Nome")]
        public String NomeUsuario { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "O campo deve conter 11 Numeros sem pontuação!")]
        [Display(Name = "CPF")]
        public String CPFUsuario { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar a Data de Nascimento!")]
        [Display(Name = "Nasc.")]
        public DateTime DataNascimentoUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar uma opção!")]
        [Display(Name = "Sexo")]
        public char SexoUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar um e-mail para contato!")]
        [Display(Name = "E-Mail")]
        public String EmailUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Informe seu peso para concluir o cadastro.")]
        [Display(Name = "Peso Kg.")]
        public int PesoUsuario { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o Tipo Sanguíneo!")]
        [Display(Name = "Tipo Sanguíneo")]
        public TipoSanguineo TipoSanguineoUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o Endereço!")]
        [Display(Name = "Endereço")]
        public Endereco EnderecoUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Nescessário informar o Telefone!")]
        [Display(Name = "Telefone")]
        public Telefone TelefoneUsuario { get; set; }
    }
}