using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlutChain.DAL
{
    public class TipoSanguineoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static bool CadastrarTipoSanguineo(TipoSanguineo tipoSanguineo)
        {
            if(tipoSanguineo != null)
            {
                context.TipoSanguineos.Add(tipoSanguineo);
                context.SaveChanges();

                return true;
            }
            return false;
        }

        public static List<TipoSanguineo> ListarTodos()
        {
            return context.TipoSanguineos.ToList();
        }

        public static void AlterarTipoSanguineo (TipoSanguineo tipoSanguineo)
        {
            if(tipoSanguineo != null)
            {
                context.Entry(tipoSanguineo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void ExcluirTipoSanguineo(TipoSanguineo tipoSanguineo)
        {
            context.TipoSanguineos.Remove(BuscarTipoSanguineoPorID(tipoSanguineo.IdTipoSanguineo));
            context.SaveChanges();
        }

        public static TipoSanguineo BuscarTipoSanguineoPorID(int IDtipoSanguineo)
        {
            return context.TipoSanguineos.Find(IDtipoSanguineo);
        }
    }
}