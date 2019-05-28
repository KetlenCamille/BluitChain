namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuarioo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco");
            DropIndex("dbo.Usuario", new[] { "EnderecoUsuario_IdEndereco" });
            DropColumn("dbo.Usuario", "EnderecoUsuario_IdEndereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "EnderecoUsuario_IdEndereco", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuario", "EnderecoUsuario_IdEndereco");
            AddForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco", "IdEndereco", cascadeDelete: true);
        }
    }
}
