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
            if(validaCNPJ(hemobanco.CNPJHemobanco))
            {
                if(BuscarHemobancoPorCNPJ(hemobanco))
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
            else
            {
                return false;
            }
        }

        //Buscar por CNPJ
        public static bool BuscarHemobancoPorCNPJ(Hemobanco hemobanco)
        {
            if(context.Hemobancos.FirstOrDefault(x => x.CNPJHemobanco.Equals(hemobanco.CNPJHemobanco)) == null)
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
        public static Hemobanco BuscarHemobancoPorID(int? id)
        {
            return context.Hemobancos.Find(id);
        }

        // Validar CNPJ
        public static bool validaCNPJ(string cnpj)
        {
            /*int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            string cnpj = cnpj_hemo;
            cnpj = cnpj.Trim();

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto;

            if(cnpj_hemo == tempCnpj)
            {
                return true;
            }
            else
            {
                return false;
            }*/
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        //Buscar hemobanco login
        public static Hemobanco BuscarHemobancoLogin(string CPFCNPJ, string Senha)
        {
            return context.Hemobancos.FirstOrDefault(x => x.CNPJHemobanco.Equals(CPFCNPJ) && x.Senha.Equals(Senha));
        }

    }
}