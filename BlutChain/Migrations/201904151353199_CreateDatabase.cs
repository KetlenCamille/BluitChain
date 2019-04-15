namespace BlutChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doacao",
                c => new
                    {
                        IdDoacao = c.Int(nullable: false, identity: true),
                        HemobancoDoacao_IdHemobanco = c.Int(),
                        TipoSanguineoDoacao_IdTipoSanguineo = c.Int(),
                    })
                .PrimaryKey(t => t.IdDoacao)
                .ForeignKey("dbo.Hemobanco", t => t.HemobancoDoacao_IdHemobanco)
                .ForeignKey("dbo.TipoSanguineo", t => t.TipoSanguineoDoacao_IdTipoSanguineo)
                .Index(t => t.HemobancoDoacao_IdHemobanco)
                .Index(t => t.TipoSanguineoDoacao_IdTipoSanguineo);
            
            CreateTable(
                "dbo.Hemobanco",
                c => new
                    {
                        IdHemobanco = c.Int(nullable: false, identity: true),
                        RazaoSocialHemobanco = c.String(),
                        NomeFantasiaHemobanco = c.String(),
                        CPNJHemobanco = c.String(),
                        EmailHemobanco = c.String(),
                        EnderecoHemobanco_IdEndereco = c.Int(),
                        TelefoneHemobanco_IdTelefone = c.Int(),
                    })
                .PrimaryKey(t => t.IdHemobanco)
                .ForeignKey("dbo.Endereco", t => t.EnderecoHemobanco_IdEndereco)
                .ForeignKey("dbo.Telefone", t => t.TelefoneHemobanco_IdTelefone)
                .Index(t => t.EnderecoHemobanco_IdEndereco)
                .Index(t => t.TelefoneHemobanco_IdTelefone);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        IdEndereco = c.Int(nullable: false, identity: true),
                        Rua = c.String(),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(),
                        CEP = c.String(),
                        Cidade = c.String(),
                    })
                .PrimaryKey(t => t.IdEndereco);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        IdTelefone = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.IdTelefone);
            
            CreateTable(
                "dbo.TipoSanguineo",
                c => new
                    {
                        IdTipoSanguineo = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdTipoSanguineo);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(),
                        CPFUsuario = c.String(),
                        DataNascimentoUsuario = c.DateTime(nullable: false),
                        EmailUsuario = c.String(),
                        PesoUsuario = c.Int(nullable: false),
                        EnderecoUsuario_IdEndereco = c.Int(),
                        TelefoneUsuario_IdTelefone = c.Int(),
                        TipoSanguineoUsuario_IdTipoSanguineo = c.Int(),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Endereco", t => t.EnderecoUsuario_IdEndereco)
                .ForeignKey("dbo.Telefone", t => t.TelefoneUsuario_IdTelefone)
                .ForeignKey("dbo.TipoSanguineo", t => t.TipoSanguineoUsuario_IdTipoSanguineo)
                .Index(t => t.EnderecoUsuario_IdEndereco)
                .Index(t => t.TelefoneUsuario_IdTelefone)
                .Index(t => t.TipoSanguineoUsuario_IdTipoSanguineo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "TipoSanguineoUsuario_IdTipoSanguineo", "dbo.TipoSanguineo");
            DropForeignKey("dbo.Usuario", "TelefoneUsuario_IdTelefone", "dbo.Telefone");
            DropForeignKey("dbo.Usuario", "EnderecoUsuario_IdEndereco", "dbo.Endereco");
            DropForeignKey("dbo.Doacao", "TipoSanguineoDoacao_IdTipoSanguineo", "dbo.TipoSanguineo");
            DropForeignKey("dbo.Doacao", "HemobancoDoacao_IdHemobanco", "dbo.Hemobanco");
            DropForeignKey("dbo.Hemobanco", "TelefoneHemobanco_IdTelefone", "dbo.Telefone");
            DropForeignKey("dbo.Hemobanco", "EnderecoHemobanco_IdEndereco", "dbo.Endereco");
            DropIndex("dbo.Usuario", new[] { "TipoSanguineoUsuario_IdTipoSanguineo" });
            DropIndex("dbo.Usuario", new[] { "TelefoneUsuario_IdTelefone" });
            DropIndex("dbo.Usuario", new[] { "EnderecoUsuario_IdEndereco" });
            DropIndex("dbo.Hemobanco", new[] { "TelefoneHemobanco_IdTelefone" });
            DropIndex("dbo.Hemobanco", new[] { "EnderecoHemobanco_IdEndereco" });
            DropIndex("dbo.Doacao", new[] { "TipoSanguineoDoacao_IdTipoSanguineo" });
            DropIndex("dbo.Doacao", new[] { "HemobancoDoacao_IdHemobanco" });
            DropTable("dbo.Usuario");
            DropTable("dbo.TipoSanguineo");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Hemobanco");
            DropTable("dbo.Doacao");
        }
    }
}
