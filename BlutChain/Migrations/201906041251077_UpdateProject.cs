namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo");
            DropIndex("dbo.Usuario", new[] { "TipoSanguineoUsuario_IdTipoSanguineo" });
            AddColumn("dbo.Doacao", "UsuarioDoacao_IdUsuario", c => c.Int());
            AlterColumn("dbo.Usuario", "NomeUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "CPFUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "SexoUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "TelefoneUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "TipoTelefoneUsuario", c => c.String());
            AlterColumn("dbo.Usuario", "Senha", c => c.String());
            AlterColumn("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", c => c.Int());
            CreateIndex("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo");
            CreateIndex("dbo.Doacao", "UsuarioDoacao_IdUsuario");
            AddForeignKey("dbo.Doacao", "UsuarioDoacao_IdUsuario", "dbo.Usuario", "IdUsuario");
            AddForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo", "IdTipoSanguineo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo");
            DropForeignKey("dbo.Doacao", "UsuarioDoacao_IdUsuario", "dbo.Usuario");
            DropIndex("dbo.Doacao", new[] { "UsuarioDoacao_IdUsuario" });
            DropIndex("dbo.Usuario", new[] { "TipoSanguineoUsuario_IdTipoSanguineo" });
            AlterColumn("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "TipoTelefoneUsuario", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "TelefoneUsuario", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Usuario", "SexoUsuario", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "CPFUsuario", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Usuario", "NomeUsuario", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Doacao", "UsuarioDoacao_IdUsuario");
            CreateIndex("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo");
            AddForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo", "IdTipoSanguineo", cascadeDelete: true);
        }
    }
}
