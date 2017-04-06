namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuyerUserIdToOffers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "BuyerUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Offers", "BuyerUserId");
            AddForeignKey("dbo.Offers", "BuyerUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "BuyerUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Offers", new[] { "BuyerUserId" });
            DropColumn("dbo.Offers", "BuyerUserId");
        }
    }
}
