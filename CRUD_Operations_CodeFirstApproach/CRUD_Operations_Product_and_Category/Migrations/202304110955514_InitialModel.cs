namespace CRUD_Operations_Product_and_Category.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Double(nullable: true),
                        MfgDate = c.DateTime(nullable: true),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId");

        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
