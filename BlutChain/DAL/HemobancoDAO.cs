using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlutChain.DAL
{
    public class HemobancoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        //Cadastrar Hemobanco
        public static bool CadastrarHemobanco(Hemobanco hemobanco)
        {
            if (BuscarHemobancoPorCNPJ(hemobanco) == false)
            {
                context.Hemobancos.Add(hemobanco);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Buscar por CNPJ
        public static bool BuscarHemobancoPorCNPJ(Hemobanco hemobanco)
        {
            if(context.Hemobancos.FirstOrDefault(x => x.CNPJHemobanco.Equals(hemobanco.CNPJHemobanco)) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Listar Hemobancos
        public static List<Hemobanco> ListarTodosHemobancos()
        {
            return context.Hemobancos.ToList();
        }

        //Alterar dados Hemobanco
        public static void AlterarHemobanco(Hemobanco hemobanco)
        {
            context.Entry(hemobanco).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Excluir Hemobanco
        public static void ExcluirHemobanco(int id)
        {
            context.Hemobancos.Remove(BuscarHemobancoPorID(id));
            context.SaveChanges();
        }

        //Buscar CNPJ por Id
        public static Hemobanco BuscarHemobancoPorID(int id)
        {
            return context.Hemobancos.Find(id);
        }

    }
}