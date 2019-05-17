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
            ViewBag.Telefones = new MultiSelectList(TelefoneDAO.ListarTodos(), "IdTelefone", "Numero");
            return View((Usuario)TempData["Usuario"]);
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario, int? Telefones)
        {
            ViewBag.Telefones = new MultiSelectList(TelefoneDAO.ListarTodos(), "IdTelefone", "Numero");
            usuario.TelefoneUsuario = TelefoneDAO.BuscarTelefonePorID(Telefones);
            /*if (ModelState.IsValid)
            {*/
                if (UsuarioDAO.CadastrarUsuario(usuario))
                {
                    ModelState.AddModelError("", "Usuário cadastrado com sucesso!");
                    return RedirectToAction("Index", "Usuario");
                }
           /* }
            ModelState.AddModelError("", "Esse usuário já existe ou o CPF está inválido!");*/
            return View(usuario);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarUsuario(Usuario usuarioAlterado)
        {
            Usuario usuarioOriginal = UsuarioDAO.BuscarUsuarioPorId(usuarioAlterado.IdUsuario);

            usuarioOriginal.NomeUsuario = usuarioAlterado.NomeUsuario;
            usuarioOriginal.CPFUsuario = usuarioAlterado.CPFUsuario;
            usuarioOriginal.DataNascimentoUsuario = usuarioAlterado.DataNascimentoUsuario;
            usuarioOriginal.SexoUsuario = usuarioAlterado.SexoUsuario;
            usuarioOriginal.EmailUsuario = usuarioAlterado.EmailUsuario;
            usuarioOriginal.PesoUsuario = usuarioAlterado.PesoUsuario;
            
            
            if (ModelState.IsValid)
            {
                UsuarioDAO.AlterarUsuario(usuarioOriginal);
                return RedirectToAction("Index");

            }
            else
            {
                return View(usuarioOriginal);
            }
        }

        public ActionResult ExcluirUsuario(int id)
        {
            UsuarioDAO.ExcluirUsuario(id);
            return RedirectToAction("Index");
        }

        public ActionResult HistoricoDoacao()
        {
            int idUsuarioSessao = Int32.Parse(Sessao.RetonarUsuarioId());
            return View(AgendamentoDAO.HistoricoDoacaoPorUsuario(idUsuarioSessao));
        }
    }
}