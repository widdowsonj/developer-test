namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Viewings",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ViewingAt = c.DateTime(nullable: false),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(nullable: false),
                    BuyerUserId = c.String(nullable: false, maxLength: 128),
                    Property_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Property_Id);

            CreateIndex("dbo.Viewings", "BuyerUserId");
            AddForeignKey("dbo.Viewings", "BuyerUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "BuyerUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Viewings", new[] { "BuyerUserId" });
            DropForeignKey("dbo.Viewings", "Property_Id", "dbo.Properties");
            DropIndex("dbo.Viewings", new[] { "Property_Id" });
            DropTable("dbo.Viewings");
        }
    }
}
