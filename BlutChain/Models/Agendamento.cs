using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlutChain.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        public int IdAgendamento { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DataAgendamento { get; set; }

        [Display(Name = "Horário")]
        public String HorarioAgendamento { get; set; }

        [Display(Name = "Usuário")]
        public Usuario UsuarioAgendamento { get; set; }

        [Display(Name = "Hemobanco")]
        public Hemobanco HemobancoAgendamento { get; set; }
    }
}