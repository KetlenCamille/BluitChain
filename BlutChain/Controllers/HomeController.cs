using BlutChain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlutChain.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            Sessao.setarUsuario(-1);
            Sessao.setarHemobanco(-1);

            return View();
        }
    }
}
