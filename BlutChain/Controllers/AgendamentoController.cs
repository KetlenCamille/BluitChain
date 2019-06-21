using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlutChain.DAL;
using BlutChain.Models;
using BlutChain.Utils;

namespace BlutChain.Controllers
{
    public class AgendamentoController : Controller
    {
        private Context context = new Context();

        // GET: Agendamento
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(AgendamentoDAO.ListarAgendamentos());
        }

        public ActionResult RegistrarAgendamento()
        {
            ViewBag.Hemobancos = new MultiSelectList(HemobancoDAO.ListarTodosHemobancos(), "IdHemobanco", "NomeFantasiaHemobanco");
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarAgendamento([Bind(Include = "IdAgendamento,DataAgendamento,HorarioAgendamento, IdUsuario, IdHemobanco")] Agendamento agendamento, int? hemobancos)
        {
            
            ViewBag.Hemobancos = new MultiSelectList(HemobancoDAO.ListarTodosHemobancos(), "IdHemobanco", "NomeFantasiaHemobanco");
            agendamento.HemobancoAgendamento = HemobancoDAO.BuscarHemobancoPorID(hemobancos);

            agendamento.UsuarioAgendamento = UsuarioDAO.BuscarUsuarioPorId(Sessao.retornarUsuario());

            int idade = DateTime.Today.Year - agendamento.UsuarioAgendamento.DataNascimentoUsuario.Year;

            if (agendamento.UsuarioAgendamento.PesoUsuario < 50)
            {
                ModelState.AddModelError("", "Seu peso é incompatível!");
            }
            else if( idade < 16 || idade > 69 )
            {
                ModelState.AddModelError("", "Sua idade é incompatível!");
            }
            else if(agendamento.DataAgendamento < DateTime.Today)
            {
                ModelState.AddModelError("", "A data informada é inválida!");
            }

            Agendamento agendamentoPesq = new Agendamento();
            // Buscar último agendamento realizado
            agendamentoPesq = AgendamentoDAO.UltimoAgendamento(Sessao.retornarUsuario());

            if (agendamentoPesq != null)
            {
                // Data agendamento - última doação
                int dias = UsuarioDAO.CalculoDiasDoacao(agendamentoPesq.DataAgendamento, agendamento.DataAgendamento);

                if (dias != 0)
                {
                    if (agendamento.UsuarioAgendamento.SexoUsuario.Equals("Feminino") && dias < 90)
                    {
                        ModelState.AddModelError("", "Sua última doação é inferior a 90 dias!");
                    }
                    else if (agendamento.UsuarioAgendamento.SexoUsuario.Equals("Masculino") && dias < 60)
                    {
                        ModelState.AddModelError("", "Sua última doação é inferior a 60 dias!");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                if (AgendamentoDAO.BuscarAgendamentoIgual(agendamento) == false)
                {

                    if (AgendamentoDAO.CadastrarAgendamento(agendamento))
                    {
                        return RedirectToAction("Agendamentos", "Usuario");
                    }
                    ModelState.AddModelError("", "Erro ao registrar agendamento!");
                    return View(agendamento);

                }
                ModelState.AddModelError("", "Esse horário não está disponível!");
                return View(agendamento);
            }
            return View(agendamento);
        }

        public ActionResult EditarAgendamento(int? id)
        {
            return View(AgendamentoDAO.BuscarAgendamentoPorID(id));
        }

        [HttpPost]
        public ActionResult EditarAgendamento([Bind(Include = "IdAgendamento,DataAgendamento,HorarioAgendamento, IdUsuario, IdHemobanco")] Agendamento agendamentoAlterado)
        {
            Agendamento agendamentoOriginal = AgendamentoDAO.BuscarAgendamentoPorID(agendamentoAlterado.IdAgendamento);


            int idade = DateTime.Today.Year - agendamentoOriginal.UsuarioAgendamento.DataNascimentoUsuario.Year;

            if (agendamentoOriginal.UsuarioAgendamento.PesoUsuario < 50)
            {
                ModelState.AddModelError("", "Seu peso incompatível!");
            }
            else if (idade < 16 || idade > 69)
            {
                ModelState.AddModelError("", "Sua idade é incompatível!");
            }
            else if (agendamentoOriginal.DataAgendamento < DateTime.Today)
            {
                ModelState.AddModelError("", "A data informada é inválida!");
            }

            agendamentoOriginal.DataAgendamento = agendamentoAlterado.DataAgendamento;
            agendamentoOriginal.HorarioAgendamento = agendamentoAlterado.HorarioAgendamento;
            agendamentoOriginal.UsuarioAgendamento = agendamentoAlterado.UsuarioAgendamento;
            agendamentoOriginal.HemobancoAgendamento = agendamentoAlterado.HemobancoAgendamento;

            Agendamento agendamentoPesq = new Agendamento();
            // Buscar último agendamento realizado
            agendamentoPesq = AgendamentoDAO.UltimoAgendamento(Sessao.retornarUsuario());

            /*if (agendamentoPesq != null)
            {
                // Data agendamento - última doação
                int dias = UsuarioDAO.CalculoDiasDoacao(agendamentoPesq.DataAgendamento, agendamentoOriginal.DataAgendamento);

                if (dias != 0)
                {
                    if (agendamentoOriginal.UsuarioAgendamento.SexoUsuario.Equals("Feminino") && dias < 90)
                    {
                        ModelState.AddModelError("", "Sua última doação é inferior a 90 dias!");
                    }
                    else if (agendamentoOriginal.UsuarioAgendamento.SexoUsuario.Equals("Masculino") && dias < 60)
                    {
                        ModelState.AddModelError("", "Sua última doação é inferior a 60 dias!");
                    }
                }
            }*/

            if (AgendamentoDAO.EditarAgendamento(agendamentoOriginal))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Erro ao editar agendamento!");
                return View(agendamentoOriginal);
            }
        }

        public ActionResult RemoverAgendamento(int id)
        {
            AgendamentoDAO.ExcluirAgendamento(AgendamentoDAO.BuscarAgendamentoPorID(id));
            return RedirectToAction("PaginaInicial", "Usuario");
        }

        public ActionResult AgendamentoDetalhe(int id)
        {
            return View(AgendamentoDAO.BuscarAgendamentoPorID(id));
        }

    }
}