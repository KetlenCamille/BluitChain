namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atttelefone : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "SexoUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "SexoUsuario", c => c.String(nullable: false));
        }
    }
}
