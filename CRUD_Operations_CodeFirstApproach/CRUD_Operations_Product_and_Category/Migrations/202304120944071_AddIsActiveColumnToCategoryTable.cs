namespace CRUD_Operations_Product_and_Category.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveColumnToCategoryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "IsActive");
        }
    }
}
