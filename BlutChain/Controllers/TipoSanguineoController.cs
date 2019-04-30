using BlutChain.DAL;
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
    }
}