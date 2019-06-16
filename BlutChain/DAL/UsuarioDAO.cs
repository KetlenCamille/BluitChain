using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
           if(ValidaCPF(usuario.CPFUsuario))
            {
                if (BuscarUsuarioPorCPF(usuario))
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
            else
            {
                return false;
            }
        }


        // Buscar Usuário Por CPF
        public static bool BuscarUsuarioPorCPF(Usuario usuario)
        {
            if (context.Usuarios.FirstOrDefault(x => x.CPFUsuario.Equals(usuario.CPFUsuario)) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Validar CPF
        public static bool ValidaCPF(string CPF_usu)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2, };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
       
            string cpf = CPF_usu;
            string auxCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim(); // Remoção de espaços

            auxCpf = cpf.Substring(0, 9); //Pega os primeiros 9 numeros digitados
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                //Multiplicando e somando com o vetor
                soma += int.Parse(auxCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11; //Calculando resto da divisão

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString(); //Guarda o primeiro digito
            auxCpf = auxCpf + digito; //Passa o valor para a string auxiliar

            soma = 0;

            for (int i = 0; i < 10; i++) //Possui mais um digito
            {
                //Multiplica e soma o valor no segundo vetor
                soma += int.Parse(auxCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11; //Calculando o reto da divisao
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            auxCpf = auxCpf + resto; //Passa o último digito

            if (cpf == auxCpf)
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

        //Alterar dados usuário
        public static void AlterarUsuario(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Excluir usuário
        public static void ExcluirUsuario(int id)
        {
            context.Usuarios.Remove(BuscarUsuarioPorId(id));
            context.SaveChanges();
        }

        //Buscar usuário por ID
        public static Usuario BuscarUsuarioPorId(int? id)
        {
            return context.Usuarios.Find(id);
        }

        //Buscar usuário login
        public static Usuario BuscarUsuarioLogin(string CPFCNPJ, string Senha)
        {
            return context.Usuarios.FirstOrDefault(x => x.CPFUsuario.Equals(CPFCNPJ) && x.Senha.Equals(Senha));
        }

        //Calculando a quantos dias foi a última doação do usuário
        public static int CalculoDiasDoacao(string dataInicial)
        {
            string dataFinal = DateTime.Today.ToString();

            TimeSpan date = Convert.ToDateTime(dataFinal) - Convert.ToDateTime(dataInicial);

            return date.Days;
        }
    }
}