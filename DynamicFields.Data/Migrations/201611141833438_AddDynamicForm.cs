namespace DynamicFields.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDynamicForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DynamicForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DynamicFormFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldType = c.Int(nullable: false),
                        Label = c.String(),
                        IsRequired = c.Boolean(nullable: false),
                        ShowLabel = c.Boolean(nullable: false),
                        Step = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                        FieldId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DynamicFields", t => t.FieldId)
                .ForeignKey("dbo.DynamicForms", t => t.FormId, cascadeDelete: true)
                .Index(t => t.FormId)
                .Index(t => t.FieldId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DynamicFormFields", "FormId", "dbo.DynamicForms");
            DropForeignKey("dbo.DynamicFormFields", "FieldId", "dbo.DynamicFields");
            DropIndex("dbo.DynamicFormFields", new[] { "FieldId" });
            DropIndex("dbo.DynamicFormFields", new[] { "FormId" });
            DropTable("dbo.DynamicFormFields");
            DropTable("dbo.DynamicForms");
        }
    }
}
