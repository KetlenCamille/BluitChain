using BlutChain.DAL;
using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlutChain.Controllers
{
    public class TipoSanguineoController : Controller
    {
        // GET: TipoSanguineo
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(TipoSanguineoDAO.ListarTodos());
        }

        public ActionResult CadastrarTipoSanguineo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarTipoSanguineo(TipoSanguineo tipoSanguineo)
        {
            if(TipoSanguineoDAO.CadastrarTipoSanguineo(tipoSanguineo))
            {
                return RedirectToAction("Index", "TipoSanguineo");
            }

            return View(tipoSanguineo);
        }

        public ActionResult RemoverTipoSanguineo(int id)
        {
            TipoSanguineoDAO.ExcluirTipoSanguineo(TipoSanguineoDAO.BuscarTipoSanguineoPorID(id));
            return RedirectToAction("Index", "TipoSanguineo");
        }
    }
}