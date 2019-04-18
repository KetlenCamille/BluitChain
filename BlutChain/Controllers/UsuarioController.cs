using BlutChain.DAL;
using BlutChain.Models;
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
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            if (UsuarioDAO.CadastrarUsuario(usuario))
            {
                return RedirectToAction("Index", "Usuario");
            }
            ModelState.AddModelError("", "Esse usuário já existe!");
            return View(usuario);

        }
    }
}