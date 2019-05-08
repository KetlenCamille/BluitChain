
namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnottationTipoSanguineo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "Logradouro", c => c.String());
            AddColumn("dbo.Endereco", "Localidade", c => c.String());
            AddColumn("dbo.Endereco", "Uf", c => c.String());
            AlterColumn("dbo.Endereco", "CEP", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.TipoSanguineo", "GrupoSanguineo", c => c.String(nullable: false));
            AlterColumn("dbo.TipoSanguineo", "FatorRH", c => c.String(nullable: false));
            DropColumn("dbo.Endereco", "Rua");
            DropColumn("dbo.Endereco", "Cidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "Cidade", c => c.String());
            AddColumn("dbo.Endereco", "Rua", c => c.String());
            AlterColumn("dbo.TipoSanguineo", "FatorRH", c => c.String());
            AlterColumn("dbo.TipoSanguineo", "GrupoSanguineo", c => c.String());
            AlterColumn("dbo.Endereco", "CEP", c => c.String());
            DropColumn("dbo.Endereco", "Uf");
            DropColumn("dbo.Endereco", "Localidade");
            DropColumn("dbo.Endereco", "Logradouro");
        }
    }
}
