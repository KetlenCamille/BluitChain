using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BlutChain.DAL;
using BlutChain.Models;
using Newtonsoft.Json;

namespace BlutChain.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Enderecoes
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(EnderecoDAO.ListarTodos());
        }


        // GET: Enderecoes/Create
        public ActionResult CadastrarEndereco()
        {
            return View((Endereco)TempData["Endereco"]);
        }

        [HttpPost]
        public ActionResult CadastrarEndereco([Bind(Include = "EnderecoId, Logradouro, Localidade, UF, Cep, Bairro, Numero")] Endereco endereco)
        {
            if (EnderecoDAO.CadastrarEndereco(endereco))
            {
                return RedirectToAction("Index", "Endereco");
            }
            ModelState.AddModelError("", "Erro ao cadastrar endereço!");
            return View(endereco);
        }

        [HttpPost]
        public ActionResult AlterarEndereco(Endereco enderecoAlterado)
        {
            Endereco enderecoOriginal = EnderecoDAO.BuscarEnderecoPorID(enderecoAlterado.IdEndereco);

            enderecoOriginal.Localidade = enderecoAlterado.Localidade;
            enderecoOriginal.Numero = enderecoAlterado.Numero;
            enderecoOriginal.Logradouro = enderecoAlterado.Logradouro;
            enderecoOriginal.Bairro = enderecoAlterado.Bairro;
            enderecoOriginal.CEP = enderecoAlterado.CEP;
            enderecoOriginal.Uf = enderecoAlterado.Uf;

            if (EnderecoDAO.AlterarEndereco(enderecoOriginal))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Erro ao alterar endereço!");
                return View(enderecoOriginal);
            }

        }


        public ActionResult RemoverEndereco(int id)
        {
            EnderecoDAO.ExcluirEndereco(EnderecoDAO.BuscarEnderecoPorID(id));
            return RedirectToAction("Index", "Endereco");
        }

        public ActionResult AlterarEndereco(int id)
        {
            return View(EnderecoDAO.BuscarEnderecoPorID(id));
        }

        [HttpPost]
        public ActionResult PesquisarCEP(Endereco endereco)
        {
            try
            {
                string url = "https://viacep.com.br/ws/" + endereco.CEP + "/json/ ";

                WebClient client = new WebClient();
                string json = client.DownloadString(url);
                // Converter string pra UTF-8
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);
                // Converter json para objeto
                endereco = JsonConvert.DeserializeObject<Endereco>(json);

                // Passar informação para qualquer action do controller
                TempData["Endereco"] = endereco;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP Inválido!";
            }

            return RedirectToAction("CadastrarEndereco", "Endereco");
        }
    }
}
