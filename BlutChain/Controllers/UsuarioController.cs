using BlutChain.DAL;
using BlutChain.Models;
using BlutChain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlutChain.Controllers
{
    public class UsuarioController : Controller
    {
        private Context db = new Context();


        // GET: Usuario
        public ActionResult Index()
        { 
            return View(UsuarioDAO.ListarUsuarios());
        }

        // GET: Usuario/Create
        public ActionResult CadastrarUsuario()
        {
            if (TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }

            return View((Usuario)TempData["Usuario"]);
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario, TipoSanguineo tipoSanguineo)
        {

            if(TipoSanguineoDAO.BuscarTipoSanguineoPorNome(tipoSanguineo.GrupoSanguineo, tipoSanguineo.FatorRH) == null)
            {
                TipoSanguineoDAO.CadastrarTipoSanguineo(tipoSanguineo);
            }
            TipoSanguineo tpPesquisado = new TipoSanguineo();
            tpPesquisado = TipoSanguineoDAO.BuscarTipoSanguineoPorNome(tipoSanguineo.GrupoSanguineo, tipoSanguineo.FatorRH);
            usuario.TipoSanguineoUsuario = TipoSanguineoDAO.BuscarTipoSanguineoPorID(tpPesquisado.IdTipoSanguineo);

            usuario.EhInativo = "N";

            if (ModelState.IsValid)
            {
                if (UsuarioDAO.CadastrarUsuario(usuario))
                {
                    ModelState.AddModelError("", "Usuário cadastrado com sucesso!");
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Esse usuário já existe ou o CPF está inválido!");
            return View(usuario);
        }

        public ActionResult AlterarUsuario(int? id)
        {
            if(id == null)
            {
                id = Sessao.retornarUsuario();
            }
            return View(UsuarioDAO.BuscarUsuarioPorId(id));
        }

        //[Authorize]
        [HttpPost]
        public ActionResult AlterarUsuario(Usuario usuarioAlterado)
        {
            //if(usuarioAlterado.TipoSanguineoUsuario.FatorRH == null || usuarioAlterado.TipoSanguineoUsuario.GrupoSanguineo == null )
            //{
                //ModelState.AddModelError("", "Informe seu tipo sanguíneo!");
            //}
            //if (usuarioAlterado.Senha== null || usuarioAlterado.ConfirmacaoDaSenha == null)
            //{
                //ModelState.AddModelError("", "Informe a senha!");
            //}

            Usuario usuarioOriginal = UsuarioDAO.BuscarUsuarioPorId(usuarioAlterado.IdUsuario);

            usuarioOriginal.NomeUsuario = usuarioAlterado.NomeUsuario;
            usuarioOriginal.CPFUsuario = usuarioAlterado.CPFUsuario;
            usuarioOriginal.DataNascimentoUsuario = usuarioAlterado.DataNascimentoUsuario;
            usuarioOriginal.SexoUsuario = usuarioAlterado.SexoUsuario;
            usuarioOriginal.EmailUsuario = usuarioAlterado.EmailUsuario;
            usuarioOriginal.PesoUsuario = usuarioAlterado.PesoUsuario;
            usuarioOriginal.Senha = usuarioAlterado.Senha;
            usuarioOriginal.EhInativo = "N";
            
            
            if (ModelState.IsValid)
            {
                UsuarioDAO.AlterarUsuario(usuarioOriginal);
                return RedirectToAction("PaginaInicial", "Usuario");

            }
            else
            {
                return View(usuarioOriginal);
            }
        }

        public ActionResult ExcluirUsuario(int id)
        {
            Usuario usuarioExcluir = UsuarioDAO.BuscarUsuarioPorId(id);
            usuarioExcluir.EhInativo = "S";
            UsuarioDAO.AlterarUsuario(usuarioExcluir);
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult HistoricoDoacao()
        {
            ViewBag.Data = DateTime.Now;
            return View(AgendamentoDAO.HistoricoDoacaoPorUsuario(Sessao.retornarUsuario()));
        }

        public ActionResult ConsultaCertificado()
        {
            if (AgendamentoDAO.HistoricoDoacaoPorUsuario(Sessao.retornarUsuario()) != null)
            {
                return RedirectToAction("EmitirCertificado", "Usuario");
            }
            else
            {
                ModelState.AddModelError("", "Usuário não possui doações registradas no sistema!");
                return View();
            }
        }

        public ActionResult EmitirCertificado()
        {
            Usuario usu = UsuarioDAO.BuscarUsuarioPorId(Sessao.retornarUsuario());
            //Agendamento age = AgendamentoDAO.UltimoAgendamento(Sessao.retornarUsuario());
            //int usu = Sessao.retornarUsuario();
            return View(usu);
        }



        public ActionResult PaginaInicial()
        {
            Agendamento agendamentoPesq = new Agendamento();
            // Buscar último agendamento realizado
            agendamentoPesq = AgendamentoDAO.UltimoAgendamento(Sessao.retornarUsuario());

            if (agendamentoPesq != null)
            {
                // Data agendamento - última doação
                ViewBag.Dias = UsuarioDAO.CalculoDiasDoacao(agendamentoPesq.DataAgendamento, DateTime.Today);
            }
            return View(UsuarioDAO.BuscarUsuarioPorId(Sessao.retornarUsuario()));
        }

        public ActionResult PaginaInicialAdm()
        {
            return View();
        }
        

        public ActionResult Agendamentos()
        {
            ViewBag.Data = DateTime.Now;
            return View(AgendamentoDAO.AgendamentosUsuario(Sessao.retornarUsuario()));
        }
    }
}