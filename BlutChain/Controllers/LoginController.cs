using BlutChain.DAL;
using BlutChain.Models;
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
                    //Usuario usuarioLogin = UsuarioDAO.BuscarUsuarioLogin(CPFCNPJ, Senha);
                    if (CPFCNPJ == "admin" && Senha == "admin")
                    {
                        //FormsAuthentication.SetAuthCookie(usuarioLogin.CPFUsuario, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (usuario == 2)
                {
                    //Hemobanco hemobancoLogin = HemobancoDAO.BuscarHemobancoLogin(CPFCNPJ, Senha);
                    if (CPFCNPJ == "admin" && Senha == "admin")
                    {
                        //FormsAuthentication.SetAuthCookie(hemobancoLogin.CNPJHemobanco, false);
                        return RedirectToAction("Index", "Home");
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