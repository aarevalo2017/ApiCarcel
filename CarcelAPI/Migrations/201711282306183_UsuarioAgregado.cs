namespace CarcelAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioAgregado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "carcel.Usuarios",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserName = c.String(maxLength: 20),
                        Password = c.String(maxLength: 20),
                        Token = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("carcel.Usuarios", new[] { "UserName" });
            DropTable("carcel.Usuarios");
        }
    }
}
