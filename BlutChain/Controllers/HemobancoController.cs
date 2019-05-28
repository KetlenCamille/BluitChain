using BlutChain.DAL;
using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlutChain.Controllers
{
    public class HemobancoController : Controller
    {
        private Context db = new Context();

        // GET: Hemobanco
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(HemobancoDAO.ListarTodosHemobancos());
        }

        //[Authorize]
        public ActionResult CadastrarHemobanco()
        {
            ViewBag.Telefones = new MultiSelectList(TelefoneDAO.ListarTodos(), "IdTelefone", "Numero");
            return View();
        }

        //[Authorize]
        [HttpPost]
        public ActionResult CadastrarHemobanco(Hemobanco hemobanco, int? telefones, Endereco endereco)
        {
            /*[Bind(Include = "IdHemobanco, RazaoSocialHemobanco, NomeFantasiaHemobanco, CNPJHemobanco," +
            "EmailHemobanco, EnderecoHemobanco, TelefoneHemobanco")] Hemobanco hemobanco*/
            ViewBag.Telefones = new MultiSelectList(TelefoneDAO.ListarTodos(), "IdTelefone", "Numero");
            hemobanco.TelefoneHemobanco = TelefoneDAO.BuscarTelefonePorID(telefones);

            if (ModelState.IsValid)
            {
                if (HemobancoDAO.CadastrarHemobanco(hemobanco))
                {
                    HemobancoDAO.CadastrarHemobanco(hemobanco);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Já existe um hemobanco com este CNPJ ou o CNPJ está inválido!");
                return View(hemobanco);
            }
            else
            {
                return View(hemobanco);
            }
        }

        //[Authorize]
        public ActionResult AlterarHemobanco(int id)
        {
            return View(HemobancoDAO.BuscarHemobancoPorID(id));
        }

        //[Authorize]
        [HttpPost]
        public ActionResult AlterarHemobanco(Hemobanco hemobancoAlterado)
        {
            Hemobanco hemobancoOriginal = HemobancoDAO.BuscarHemobancoPorID(hemobancoAlterado.IdHemobanco);

            hemobancoOriginal.RazaoSocialHemobanco = hemobancoAlterado.RazaoSocialHemobanco;
            hemobancoOriginal.NomeFantasiaHemobanco = hemobancoAlterado.NomeFantasiaHemobanco;
            hemobancoOriginal.CNPJHemobanco = hemobancoAlterado.CNPJHemobanco;
            hemobancoOriginal.EmailHemobanco = hemobancoAlterado.EmailHemobanco;
            hemobancoOriginal.EnderecoHemobanco = hemobancoAlterado.EnderecoHemobanco;
            hemobancoOriginal.EmailHemobanco = hemobancoAlterado.EmailHemobanco;

            if (ModelState.IsValid)
            {
                HemobancoDAO.AlterarHemobanco(hemobancoOriginal);
                return RedirectToAction("Index");

            }
            else
            {
                return View(hemobancoOriginal);
            }
        }

        public ActionResult ExcluirHemobanco(int id)
        {
            HemobancoDAO.ExcluirHemobanco(id);
            return RedirectToAction("Index");
        }

    }
}