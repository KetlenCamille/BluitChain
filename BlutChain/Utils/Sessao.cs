using BlutChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlutChain.Utils
{
    public class Sessao
    { 
        public static int retornarUsuario()
        {
            return (int) HttpContext.Current.Session["Usuario"];
        }

        public static void setarUsuario(int value)
        {
            HttpContext.Current.Session["Usuario"] = value;
        }

        public static int retornarHemobanco()
        {
            return (int)HttpContext.Current.Session["Hemobanco"];
        }

        public static void setarHemobanco(int value)
        {
            HttpContext.Current.Session["Hemobanco"] = value;
        }
    }
}