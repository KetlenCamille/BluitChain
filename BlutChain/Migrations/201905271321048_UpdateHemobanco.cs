namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHemobanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco");
            DropIndex("dbo.Hemobanco", new[] { "EnderecoHemobanco_IdEndereco" });
            AddColumn("dbo.Hemobanco", "Logradouro", c => c.String());
            AddColumn("dbo.Hemobanco", "Numero", c => c.Int(nullable: false));
            AddColumn("dbo.Hemobanco", "Bairro", c => c.String());
            AddColumn("dbo.Hemobanco", "CEP", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.Hemobanco", "Localidade", c => c.String());
            AddColumn("dbo.Hemobanco", "Uf", c => c.String());
            DropColumn("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", c => c.Int(nullable: false));
            DropColumn("dbo.Hemobanco", "Uf");
            DropColumn("dbo.Hemobanco", "Localidade");
            DropColumn("dbo.Hemobanco", "CEP");
            DropColumn("dbo.Hemobanco", "Bairro");
            DropColumn("dbo.Hemobanco", "Numero");
            DropColumn("dbo.Hemobanco", "Logradouro");
            CreateIndex("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco");
            AddForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco", "IdEndereco", cascadeDelete: true);
        }
    }
}
