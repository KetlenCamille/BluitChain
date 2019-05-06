using BlutChain.DAL;
using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlutChain.Controllers
{
    public class TelefoneController : Controller
    {
        // GET: Telefone
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(TelefoneDAO.ListarTodos());
        }

        public ActionResult CadastrarTelefone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarTelefone(Telefone telefone)
        {
            if (TelefoneDAO.CadastrarTelefone(telefone))
            {
                return RedirectToAction("Index", "Telefone");
            }
            ModelState.AddModelError("", "Erro ao cadastrar telefone!");
            return View(telefone);
        }

        public ActionResult RemoverTelefone(int id)
        {
            TelefoneDAO.ExcluirTelefone(TelefoneDAO.BuscarTelefonePorID(id));
            return RedirectToAction("Index", "Telefone");
        }

        public ActionResult AlterarTelefone(int id)
        {
            return View(TelefoneDAO.BuscarTelefonePorID(id));
        }

        [HttpPost]
        public ActionResult AlterarTelefone(Telefone telefoneAlterado)
        {
            Telefone telefoneOriginal = TelefoneDAO.BuscarTelefonePorID(telefoneAlterado.IdTelefone);

            telefoneOriginal.Tipo = telefoneAlterado.Tipo;
            telefoneOriginal.Numero = telefoneAlterado.Numero;

            if (ModelState.IsValid)
            {
                TelefoneDAO.AlterarTelefone(telefoneOriginal);
                return RedirectToAction("Index");

            }
            else
            {
                return View(telefoneOriginal);
            }
        }
    }
}
