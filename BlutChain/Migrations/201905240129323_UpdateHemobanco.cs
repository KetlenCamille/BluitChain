namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHemobanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone");
            DropIndex("dbo.Hemobanco", new[] { "TelefoneHemobanco_IdTelefone" });
            AlterColumn("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", c => c.Int());
            CreateIndex("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone");
            AddForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone", "IdTelefone");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone");
            DropIndex("dbo.Hemobanco", new[] { "TelefoneHemobanco_IdTelefone" });
            AlterColumn("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", c => c.Int(nullable: false));
            CreateIndex("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone");
            AddForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone", "IdTelefone", cascadeDelete: true);
        }
    }
}
