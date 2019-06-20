namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEhInativoUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "EhInativo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "EhInativo");
        }
    }
}
