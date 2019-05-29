namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsuarioTelefone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "TelefoneUsuario_IdTelefone", "dbo.Telefone");
            DropIndex("dbo.Usuario", new[] { "TelefoneUsuario_IdTelefone" });
            AddColumn("dbo.Usuario", "TelefoneUsuario", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Usuario", "TipoTelefoneUsuario", c => c.String(nullable: false));
            DropColumn("dbo.Usuario", "TelefoneUsuario_IdTelefone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "TelefoneUsuario_IdTelefone", c => c.Int(nullable: false));
            DropColumn("dbo.Usuario", "TipoTelefoneUsuario");
            DropColumn("dbo.Usuario", "TelefoneUsuario");
            CreateIndex("dbo.Usuario", "TelefoneUsuario_IdTelefone");
            AddForeignKey("dbo.Usuario", "TelefoneUsuario_IdTelefone", "dbo.Telefone", "IdTelefone", cascadeDelete: true);
        }
    }
}
