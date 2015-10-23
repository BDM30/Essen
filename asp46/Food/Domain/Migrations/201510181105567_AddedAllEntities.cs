namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAllEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        RecipeID = c.Int(nullable: false),
                        ImportanceLevel = c.Int(nullable: false),
                        ReplaceabilityLevel = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        AmountDefault = c.Int(nullable: false),
                        UnitMeasureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProcessDescription = c.String(),
                    })
                .PrimaryKey(t => t.RecipeID);
            
            CreateTable(
                "dbo.UnitMeasures",
                c => new
                    {
                        UnitMeasureID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UnitMeasureID);
            
            CreateTable(
                "dbo.UserProducts",
                c => new
                    {
                        UserProductID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ExpirationDate = c.String(),
                    })
                .PrimaryKey(t => t.UserProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProducts");
            DropTable("dbo.UnitMeasures");
            DropTable("dbo.Recipes");
            DropTable("dbo.Products");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Categories");
        }
    }
}
