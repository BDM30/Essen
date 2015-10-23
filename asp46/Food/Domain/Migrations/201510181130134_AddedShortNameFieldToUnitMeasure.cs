namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShortNameFieldToUnitMeasure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnitMeasures", "ShortName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnitMeasures", "ShortName");
        }
    }
}
