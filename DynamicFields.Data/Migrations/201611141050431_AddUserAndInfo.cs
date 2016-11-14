namespace DynamicFields.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAndInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfoBankInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PropertyOwner = c.Boolean(),
                        CurrentBank = c.String(),
                        BankProduct = c.String(),
                        CustomerType = c.String(),
                        HaveChildrenSavings = c.Boolean(),
                        ChildrenSavingsInAccount = c.Int(),
                        IncomeBeforeTax = c.Decimal(precision: 18, scale: 2),
                        IncomeAfterTax = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserInfoGeneralInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NumberOfHomeLivingChildren = c.Short(),
                        NumberOfHomeLivingAdult = c.Short(),
                        Working = c.String(),
                        HouseType = c.String(),
                        HaveCar = c.Boolean(),
                        YearsHartACar = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoGeneralInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserInfoBankInfoes", "UserId", "dbo.Users");
            DropIndex("dbo.UserInfoGeneralInfoes", new[] { "UserId" });
            DropIndex("dbo.UserInfoBankInfoes", new[] { "UserId" });
            DropTable("dbo.UserInfoGeneralInfoes");
            DropTable("dbo.UserInfoBankInfoes");
            DropTable("dbo.Users");
        }
    }
}
