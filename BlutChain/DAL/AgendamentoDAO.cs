using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlutChain.Models;

namespace BlutChain.DAL
{
    public class AgendamentoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static bool CadastrarAgendamento(Agendamento agendamento)
        {
            if (agendamento != null)
            {
                context.Agendamentos.Add(agendamento);
                context.SaveChanges();

                return true;
            }
            return false;
        }

        public static List<Agendamento> ListarAgendamentos()
        {
            return context.Agendamentos.ToList();
        }

        public static Agendamento BuscarAgendamentoPorID(int? id)
        {
            return context.Agendamentos.Find(id);
        }

        public static bool EditarAgendamento(Agendamento agendamento)
        {
            if (agendamento != null)
            {
                context.Entry(agendamento).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ExcluirAgendamento(Agendamento agendamento)
        {
            context.Agendamentos.Remove(BuscarAgendamentoPorID(agendamento.IdAgendamento));
            context.SaveChanges();
        }
    }
}