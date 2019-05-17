namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamento",
                c => new
                    {
                        IdAgendamento = c.Int(nullable: false, identity: true),
                        DataAgendamento = c.DateTime(nullable: false),
                        HorarioAgendamento = c.DateTime(nullable: false),
                        HemobancoAgendamento_IdHemobanco = c.Int(),
                        UsuarioAgendamento_IdUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.IdAgendamento)
                .ForeignKey("dbo.Hemobanco", t => t.HemobancoAgendamento_IdHemobanco)
                .ForeignKey("dbo.Usuario", t => t.UsuarioAgendamento_IdUsuario)
                .Index(t => t.HemobancoAgendamento_IdHemobanco)
                .Index(t => t.UsuarioAgendamento_IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamento", "UsuarioAgendamento_IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Agendamento", "HemobancoAgendamento_IdHemobanco", "dbo.Hemobanco");
            DropIndex("dbo.Agendamento", new[] { "UsuarioAgendamento_IdUsuario" });
            DropIndex("dbo.Agendamento", new[] { "HemobancoAgendamento_IdHemobanco" });
            DropTable("dbo.Agendamento");
        }
    }
}
