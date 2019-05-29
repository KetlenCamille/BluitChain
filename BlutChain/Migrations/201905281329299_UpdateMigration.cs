namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco");
            DropForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco");
            DropIndex("dbo.Hemobanco", new[] { "EnderecoHemobanco_IdEndereco" });
            DropIndex("dbo.Usuario", new[] { "EnderecoUsuario_IdEndereco" });
            AddColumn("dbo.Hemobanco", "Logradouro", c => c.String());
            AddColumn("dbo.Hemobanco", "Numero", c => c.Int(nullable: false));
            AddColumn("dbo.Hemobanco", "Bairro", c => c.String());
            AddColumn("dbo.Hemobanco", "CEP", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.Hemobanco", "Localidade", c => c.String());
            AddColumn("dbo.Hemobanco", "Uf", c => c.String());
            DropColumn("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco");
            DropColumn("dbo.Usuario", "EnderecoUsuario_IdEndereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "EnderecoUsuario_IdEndereco", c => c.Int(nullable: false));
            AddColumn("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", c => c.Int(nullable: false));
            DropColumn("dbo.Hemobanco", "Uf");
            DropColumn("dbo.Hemobanco", "Localidade");
            DropColumn("dbo.Hemobanco", "CEP");
            DropColumn("dbo.Hemobanco", "Bairro");
            DropColumn("dbo.Hemobanco", "Numero");
            DropColumn("dbo.Hemobanco", "Logradouro");
            CreateIndex("dbo.Usuario", "EnderecoUsuario_IdEndereco");
            CreateIndex("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco");
            AddForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco", "IdEndereco", cascadeDelete: true);
            AddForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco", "IdEndereco", cascadeDelete: true);
        }
    }
}
