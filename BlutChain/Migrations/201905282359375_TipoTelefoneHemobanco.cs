namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoTelefoneHemobanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone");
            DropIndex("dbo.Hemobanco", new[] { "TelefoneHemobanco_IdTelefone" });
            AddColumn("dbo.Hemobanco", "TelefoneHemobanco", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Hemobanco", "TipoTelefoneHemobanco", c => c.String(nullable: false));
            DropColumn("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", c => c.Int());
            DropColumn("dbo.Hemobanco", "TipoTelefoneHemobanco");
            DropColumn("dbo.Hemobanco", "TelefoneHemobanco");
            CreateIndex("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone");
            AddForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone", "IdTelefone");
        }
    }
}
