namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsuarioNotDataAnnotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo");
            DropIndex("dbo.Usuario", new[] { "TipoSanguineoUsuario_IdTipoSanguineo" });
            AlterColumn("dbo.Usuario", "NomeUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "CPFUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "SexoUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "TelefoneUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "TipoTelefoneUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "Senha", c => c.String());
            AlterColumn("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", c => c.Int());
            CreateIndex("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo");
            AddForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo", "IdTipoSanguineo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo");
            DropIndex("dbo.Usuario", new[] { "TipoSanguineoUsuario_IdTipoSanguineo" });
            AlterColumn("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "TipoTelefoneUsuario", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "TelefoneUsuario", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Usuario", "SexoUsuario", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "CPFUsuario", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Usuario", "NomeUsuario", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo");
            AddForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo", "IdTipoSanguineo", cascadeDelete: true);
        }
    }
}
