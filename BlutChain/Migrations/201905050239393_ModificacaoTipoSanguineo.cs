namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacaoTipoSanguineo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoSanguineo", "GrupoSanguineo", c => c.String());
            AddColumn("dbo.TipoSanguineo", "FatorRH", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoSanguineo", "FatorRH");
            DropColumn("dbo.TipoSanguineo", "GrupoSanguineo");
        }
    }
}
