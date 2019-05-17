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
            if(TipoSanguineoDAO.BuscarTipoSanguineoPorNome(tipoSanguineo.GrupoSanguineo, tipoSanguineo.FatorRH) == null)
            {
                if (TipoSanguineoDAO.CadastrarTipoSanguineo(tipoSanguineo))
                {
                    return RedirectToAction("Index", "TipoSanguineo");
                }
            }
            //Apresentar Mensagem de Erro

            return View(tipoSanguineo);
        }

        public ActionResult RemoverTipoSanguineo(int id)
        {
            TipoSanguineoDAO.ExcluirTipoSanguineo(TipoSanguineoDAO.BuscarTipoSanguineoPorID(id));
            return RedirectToAction("Index", "TipoSanguineo");
        }

        public ActionResult AlterarTipoSanguineo(int id)
        {
            return View(TipoSanguineoDAO.BuscarTipoSanguineoPorID(id));
        }

        [HttpPost]
        public ActionResult AlterarTipoSanguineo(TipoSanguineo tipoSanguineoAlterado)
        {
            TipoSanguineo tipoSanguineoOriginal = TipoSanguineoDAO.BuscarTipoSanguineoPorID(tipoSanguineoAlterado.IdTipoSanguineo);

            tipoSanguineoOriginal.FatorRH = tipoSanguineoAlterado.FatorRH;
            tipoSanguineoOriginal.GrupoSanguineo = tipoSanguineoAlterado.GrupoSanguineo;

            if(TipoSanguineoDAO.AlterarTipoSanguineo(tipoSanguineoOriginal))
            {
                return RedirectToAction("Index", "TipoSanguineo");
            }

            //Adicionar mensagem de Erro

            return View(tipoSanguineoOriginal);
        }
    }
}