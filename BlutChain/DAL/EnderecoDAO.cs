using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlutChain.DAL
{
    public class EnderecoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static bool CadastrarEndereco(Endereco endereco)
        {
            if (endereco != null)
            {
                context.Enderecos.Add(endereco);
                context.SaveChanges();

                return true;
            }
            return false;
        }

        public static List<Endereco> ListarTodos()
        {
            return context.Enderecos.ToList();
        }

        public static bool AlterarEndereco(Endereco endereco)
        {
            if (endereco != null)
            {
                context.Entry(endereco).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void ExcluirEndereco(Endereco endereco)
        {
            context.Enderecos.Remove(BuscarEnderecoPorID(endereco.IdEndereco));
            context.SaveChanges();
        }

        public static Endereco BuscarEnderecoPorID(int IdEndereco)
        {
            return context.Enderecos.Find(IdEndereco);
        }
    }
}