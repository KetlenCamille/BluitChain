namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ehInativoHemobanco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hemobanco", "ehInativo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hemobanco", "ehInativo");
        }
    }
}
