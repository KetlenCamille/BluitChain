namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizaçãoBanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco");
            DropForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone");
            DropIndex("dbo.Hemobanco", new[] { "EnderecoHemobanco_IdEndereco" });
            DropIndex("dbo.Hemobanco", new[] { "TelefoneHemobanco_IdTelefone" });
            AddColumn("dbo.Hemobanco", "CNPJHemobanco", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Hemobanco", "RazaoSocialHemobanco", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Hemobanco", "NomeFantasiaHemobanco", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", c => c.Int(nullable: false));
            AlterColumn("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", c => c.Int(nullable: false));
            CreateIndex("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco");
            CreateIndex("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone");
            AddForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco", "IdEndereco", cascadeDelete: true);
            AddForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone", "IdTelefone", cascadeDelete: true);
            DropColumn("dbo.Hemobanco", "CPNJHemobanco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hemobanco", "CPNJHemobanco", c => c.String());
            DropForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone");
            DropForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco");
            DropIndex("dbo.Hemobanco", new[] { "TelefoneHemobanco_IdTelefone" });
            DropIndex("dbo.Hemobanco", new[] { "EnderecoHemobanco_IdEndereco" });
            AlterColumn("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", c => c.Int());
            AlterColumn("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", c => c.Int());
            AlterColumn("dbo.Hemobanco", "NomeFantasiaHemobanco", c => c.String());
            AlterColumn("dbo.Hemobanco", "RazaoSocialHemobanco", c => c.String());
            DropColumn("dbo.Hemobanco", "CNPJHemobanco");
            CreateIndex("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone");
            CreateIndex("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco");
            AddForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone", "IdTelefone");
            AddForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco", "IdEndereco");
        }
    }
}
