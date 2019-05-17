namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Telefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "SexoUsuario", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "SexoUsuario");
        }
    }
}
