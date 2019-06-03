using BlutChain.DAL;
using BlutChain.Models;
using BlutChain.Utils;
using System.Web.Mvc;
using System.Web.Security;

namespace BlutChain.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "CPFCNPJ, Senha, usuario")] string CPFCNPJ, string Senha, int? usuario)
        {
            if (CPFCNPJ.Length > 0 && Senha.Length > 0 && (usuario == 1 || usuario == 2))
            {
                if (usuario == 1)
                {
                    Usuario usuarioLogin = UsuarioDAO.BuscarUsuarioLogin(CPFCNPJ, Senha);
                    if (usuarioLogin != null)
                    {
                        FormsAuthentication.SetAuthCookie(usuarioLogin.CPFUsuario, false);
                        Sessao.setarUsuario(usuarioLogin.IdUsuario);
                        return RedirectToAction("Index", "Usuario");
                    }
                }
                else if (usuario == 2)
                {
                    Hemobanco hemobancoLogin = HemobancoDAO.BuscarHemobancoLogin(CPFCNPJ, Senha);
                    if (hemobancoLogin != null)
                    {
                        FormsAuthentication.SetAuthCookie(hemobancoLogin.CNPJHemobanco, false);
                        Sessao.setarHemobanco(hemobancoLogin.IdHemobanco);
                        return RedirectToAction("Index", "Hemobanco");
                    }
                }
            }
            //if(usuario == null)
            //{
            //    ModelState.AddModelError("", "CPF/CNPJ ou senha inválidos");
            //    return View();
            //}
            ModelState.AddModelError("", "CPF/CNPJ ou senha inválidos");
            return View();
        }
    }
}