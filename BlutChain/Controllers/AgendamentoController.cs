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
                ModelState.AddModelError("", "Seu peso incompatível!");
            }
            else if( idade < 16 || idade > 69 )
            {
                ModelState.AddModelError("", "Sua idade é incompatível!");
            }
            else if(agendamento.DataAgendamento < DateTime.Today)
            {
                ModelState.AddModelError("", "A data informada é inválida!");
            }
            if (ModelState.IsValid)
            {
                if (AgendamentoDAO.BuscarAgendamentoIgual(agendamento) != null)
                {

                    if (AgendamentoDAO.CadastrarAgendamento(agendamento))
                    {
                        return RedirectToAction("PaginaInicial", "Usuario");
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = AgendamentoDAO.BuscarAgendamentoPorID(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        [HttpPost]
        public ActionResult EditarAgendamento([Bind(Include = "IdAgendamento,DataAgendamento,HorarioAgendamento, IdUsuario, IdHemobanco")] Agendamento agendamentoAlterado)
        {
            Agendamento agendamentoOriginal = AgendamentoDAO.BuscarAgendamentoPorID(agendamentoAlterado.IdAgendamento);


            int idade = DateTime.Today.Year - agendamentoAlterado.UsuarioAgendamento.DataNascimentoUsuario.Year;

            if (agendamentoAlterado.UsuarioAgendamento.PesoUsuario < 50)
            {
                ModelState.AddModelError("", "Seu peso incompatível!");
            }
            else if (idade < 16 || idade > 69)
            {
                ModelState.AddModelError("", "Sua idade é incompatível!");
            }
            else if (agendamentoAlterado.DataAgendamento < DateTime.Today)
            {
                ModelState.AddModelError("", "A data informada é inválida!");
            }

            agendamentoOriginal.DataAgendamento = agendamentoAlterado.DataAgendamento;
            agendamentoOriginal.HorarioAgendamento = agendamentoAlterado.HorarioAgendamento;
            agendamentoOriginal.UsuarioAgendamento = agendamentoAlterado.UsuarioAgendamento;
            agendamentoOriginal.HemobancoAgendamento = agendamentoAlterado.HemobancoAgendamento;

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