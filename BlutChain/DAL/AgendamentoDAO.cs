using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlutChain.Models;
using BlutChain.Utils;

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
            return context.Agendamentos.Include("UsuarioAgendamento").Include("HemobancoAgendamento").ToList();
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

        public static List<Agendamento> HistoricoDoacaoPorUsuario(int? usuarioId)
        {
            DateTime today = DateTime.Today;
            return context.Agendamentos.Include("UsuarioAgendamento").Include("HemobancoAgendamento").Where(x => x.UsuarioAgendamento.IdUsuario == usuarioId && x.DataAgendamento < today ).ToList();
        }

        public static List<Agendamento> BuscarAgendamentoIgual(Agendamento agendamento)
        {

            return context.Agendamentos.Where(x => x.DataAgendamento == agendamento.DataAgendamento && x.HorarioAgendamento == agendamento.HorarioAgendamento).ToList();
            
        }

        internal static object AgendamentosUsuario(int idUsu)
        {
            DateTime today = DateTime.Today;
            return context.Agendamentos.Where(x => x.UsuarioAgendamento.IdUsuario == idUsu && x.DataAgendamento >= today).ToList();
        }

        internal static object AgendamentosHemobancoHistorico(int idHem)
        {
            DateTime today = DateTime.Today;
            return context.Agendamentos.Include("UsuarioAgendamento").Where(x => x.HemobancoAgendamento.IdHemobanco == idHem && x.DataAgendamento < today).ToList();
        }

        public static List<Agendamento> AgendamentosHemobancoDia(int idHem)
        {
            DateTime today = DateTime.Today;
            return context.Agendamentos.Include("UsuarioAgendamento").Where(x => x.HemobancoAgendamento.IdHemobanco == idHem && x.DataAgendamento >= today).ToList();
        }
        public static Agendamento UltimoAgendamento(int idUsuario)
        {
            return context.Agendamentos.OrderByDescending(x => x.UsuarioAgendamento.IdUsuario == idUsuario).First();
        }
    }
}