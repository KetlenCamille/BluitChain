namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabaseII : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agendamento", "HorarioAgendamento", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agendamento", "HorarioAgendamento", c => c.DateTime(nullable: false));
        }
    }
}
