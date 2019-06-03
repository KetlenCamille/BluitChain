using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlutChain.DAL
{
    public class TelefoneDAO
    {

        private static Context context = SingletonContext.GetInstance();

        public static bool CadastrarTelefone(Telefone telefone)
        {
            if (telefone != null)
            {
                context.Telefones.Add(telefone);
                context.SaveChanges();

                return true;
            }
            return false;
        }

        public static List<Telefone> ListarTodos()
        {
            return context.Telefones.ToList();
        }

        public static bool AlterarTelefone(Telefone telefone)
        {
            if(telefone != null)
            {
                context.Entry(telefone).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public static void ExcluirTelefone(Telefone telefone)
        {
            context.Telefones.Remove(BuscarTelefonePorID(telefone.IdTelefone));
            context.SaveChanges();
        }

        public static Telefone BuscarTelefonePorID(int? IDtelefone)
        {
            return context.Telefones.Find(IDtelefone);
        }

        

    }
}