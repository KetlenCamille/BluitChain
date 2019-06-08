using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlutChain.Models;

namespace BlutChain.DAL
{
    public class DoacaoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static bool CadastrarDoacao(Doacao doacao)
        {
            if (doacao != null)
            {
                context.Doacaos.Add(doacao);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Doacao BuscarDoacaoPorId(int idDoacao)
        {
            return context.Doacaos.Find(idDoacao);
        }

        internal static Doacao EmitirCertificado(int idDoacao)
        {
            if (context.Doacaos.FirstOrDefault(x => x.IdDoacao.Equals(idDoacao)) != null)
            {
                return BuscarDoacaoPorId(idDoacao);
            }
            else
            {
                return null;
            }
        }
    }
}