namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hemobanco", "Senha", c => c.String(nullable: false));
            AddColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Senha");
            DropColumn("dbo.Hemobanco", "Senha");
        }
    }
}
