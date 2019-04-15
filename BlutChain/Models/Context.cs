using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlutChain.Models
{
    public class Context : DbContext
    {
        public Context() : base("BlutChain") { }

        public DbSet<Hemobanco> Hemobancos { get; set; }

        public DbSet<Doacao> Doacaos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoSanguineo> TipoSanguineos { get; set; }

        public DbSet<Telefone> Telefones { get; set; }
    }
}