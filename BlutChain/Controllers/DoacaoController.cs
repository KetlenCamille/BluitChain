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
    public class DoacaoController : Controller
    {

        private Context context = new Context();

        // GET: Doacao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrarDoacao()
        {
            ViewBag.Hemobancos = new MultiSelectList(HemobancoDAO.ListarTodosHemobancos(), "IdHemobanco", "NomeFantasiaHemobanco");
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarDoacao(Doacao doacao, int? hemobancos, TipoSanguineo tipoSanguineo)
        {

            ViewBag.Hemobancos = new MultiSelectList(HemobancoDAO.ListarTodosHemobancos(), "IdHemobanco", "NomeFantasiaHemobanco");
            doacao.HemobancoDoacao = HemobancoDAO.BuscarHemobancoPorID(hemobancos);
            doacao.UsuarioDoacao = UsuarioDAO.BuscarUsuarioPorId(doacao.UsuarioDoacao.IdUsuario);

            if (TipoSanguineoDAO.BuscarTipoSanguineoPorNome(tipoSanguineo.GrupoSanguineo, tipoSanguineo.FatorRH) == null)
            {
                TipoSanguineoDAO.CadastrarTipoSanguineo(tipoSanguineo);
            }
            TipoSanguineo tpPesquisado = new TipoSanguineo();
            tpPesquisado = TipoSanguineoDAO.BuscarTipoSanguineoPorNome(tipoSanguineo.GrupoSanguineo, tipoSanguineo.FatorRH);

            doacao.TipoSanguineoDoacao = TipoSanguineoDAO.BuscarTipoSanguineoPorID(tpPesquisado.IdTipoSanguineo);

            if (DoacaoDAO.CadastrarDoacao(doacao))
            {
                return RedirectToAction("EmitirCertificado", "IdDoacao");
            }
            ModelState.AddModelError("", "Erro ao registrar doação!");
            return View(doacao);
        }

        public ActionResult EmitirCertificado(int idDoacao)
        {
            if (DoacaoDAO.EmitirCertificado(idDoacao) != null)
            {
                Doacao doa = DoacaoDAO.EmitirCertificado(idDoacao);
                // emitir certificado na tela ???
                return View();
            }
            return View();
            
        }

    }
}