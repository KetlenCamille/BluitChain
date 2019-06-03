namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco");
            DropForeignKey("dbo.Usuario", "TelefoneUsuario_IdTelefone", "dbo.Telefone");
            DropForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo");
            DropIndex("dbo.Usuario", new[] { "EnderecoUsuario_IdEndereco" });
            DropIndex("dbo.Usuario", new[] { "TelefoneUsuario_IdTelefone" });
            DropIndex("dbo.Usuario", new[] { "TipoSanguineoUsuario_IdTipoSanguineo" });
            AlterColumn("dbo.Usuario", "NomeUsuario", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Usuario", "CPFUsuario", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Usuario", "EnderecoUsuario_IdEndereco", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "TelefoneUsuario_IdTelefone", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuario", "EnderecoUsuario_IdEndereco");
            CreateIndex("dbo.Usuario", "TelefoneUsuario_IdTelefone");
            CreateIndex("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo");
            AddForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco", "IdEndereco", cascadeDelete: true);
            AddForeignKey("dbo.Usuario", "TelefoneUsuario_IdTelefone", "dbo.Telefone", "IdTelefone", cascadeDelete: true);
            AddForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo", "IdTipoSanguineo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo");
            DropForeignKey("dbo.Usuario", "TelefoneUsuario_IdTelefone", "dbo.Telefone");
            DropForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco");
            DropIndex("dbo.Usuario", new[] { "TipoSanguineoUsuario_IdTipoSanguineo" });
            DropIndex("dbo.Usuario", new[] { "TelefoneUsuario_IdTelefone" });
            DropIndex("dbo.Usuario", new[] { "EnderecoUsuario_IdEndereco" });
            AlterColumn("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", c => c.Int());
            AlterColumn("dbo.Usuario", "TelefoneUsuario_IdTelefone", c => c.Int());
            AlterColumn("dbo.Usuario", "EnderecoUsuario_IdEndereco", c => c.Int());
            AlterColumn("dbo.Usuario", "CPFUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "NomeUsuario", c => c.String());
            CreateIndex("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo");
            CreateIndex("dbo.Usuario", "TelefoneUsuario_IdTelefone");
            CreateIndex("dbo.Usuario", "EnderecoUsuario_IdEndereco");
            AddForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo", "IdTipoSanguineo");
            AddForeignKey("dbo.Usuario", "TelefoneUsuario_IdTelefone", "dbo.Telefone", "IdTelefone");
            AddForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco", "IdEndereco");
        }
    }
}
