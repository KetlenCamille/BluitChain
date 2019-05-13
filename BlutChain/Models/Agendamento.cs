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

        public DateTime DataAgendamento { get; set; }

        public DateTime HorarioAgendamento { get; set; }

        public Usuario UsuarioAgendamento { get; set; }

        public Hemobanco HemobancoAgendamento { get; set; }
    }
}