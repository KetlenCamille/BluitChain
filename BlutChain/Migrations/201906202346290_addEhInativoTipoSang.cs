namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEhInativoTipoSang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoSanguineo", "ehInativo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoSanguineo", "ehInativo");
        }
    }
}
