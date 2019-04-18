using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlutChain.DAL
{
    public class UsuarioDAO
    {
        private static Context context = SingletonContext.GetInstance();


        // Criar Usuário
        public static bool CadastrarUsuario(Usuario usuario)
        {
            if (BuscarUsuarioPorCPF(usuario) == false)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }


        // Buscar Usuário Por CPF
        public static bool BuscarUsuarioPorCPF(Usuario usuario)
        {
            if (context.Usuarios.FirstOrDefault(x => x.CPFUsuario.Equals(usuario.CPFUsuario)) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Listar Usuários
        public static List<Usuario> ListarUsuarios()
        {
            return context.Usuarios.ToList();
        }
    }
}