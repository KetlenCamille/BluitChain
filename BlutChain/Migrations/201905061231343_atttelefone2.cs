namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atttelefone2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Telefone", "Numero", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Telefone", "Numero", c => c.String());
        }
    }
}
