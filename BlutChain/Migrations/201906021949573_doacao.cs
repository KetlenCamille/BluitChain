namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doacao", "UsuarioDoacao_IdUsuario", c => c.Int());
            CreateIndex("dbo.Doacao", "UsuarioDoacao_IdUsuario");
            AddForeignKey("dbo.Doacao", "UsuarioDoacao_IdUsuario", "dbo.Usuario", "IdUsuario");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doacao", "UsuarioDoacao_IdUsuario", "dbo.Usuario");
            DropIndex("dbo.Doacao", new[] { "UsuarioDoacao_IdUsuario" });
            DropColumn("dbo.Doacao", "UsuarioDoacao_IdUsuario");
        }
    }
}
