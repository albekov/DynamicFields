namespace DynamicFields.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatesToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DynamicFields", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.DynamicFields", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.DynamicForms", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.DynamicForms", "DateUpdated", c => c.DateTime(nullable: false));

            var now = DateTime.UtcNow.ToString("yyyyMMdd");
            Sql($"update dbo.DynamicFields set DateCreated='{now}'");
            Sql($"update dbo.DynamicFields set DateUpdated='{now}'");
            Sql($"update dbo.DynamicForms set DateCreated='{now}'");
            Sql($"update dbo.DynamicForms set DateUpdated='{now}'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.DynamicForms", "DateUpdated");
            DropColumn("dbo.DynamicForms", "DateCreated");
            DropColumn("dbo.DynamicFields", "DateUpdated");
            DropColumn("dbo.DynamicFields", "DateCreated");
        }
    }
}
