namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atttelefone3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Telefone", "Tipo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Telefone", "Tipo");
        }
    }
}
