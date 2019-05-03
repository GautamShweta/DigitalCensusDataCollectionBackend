namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        HouseId = c.Int(nullable: false, identity: true),
                        ApartmentNumber = c.String(nullable: false),
                        StreetName = c.String(nullable: false),
                        State = c.String(nullable: false),
                        HeadName = c.String(nullable: false),
                        OwnershipStatus = c.Int(nullable: false),
                        NumberOfRooms = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HouseId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        CensusHouseNumber = c.Int(nullable: false),
                        RelToHead = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        AgeAtMarriage = c.Int(nullable: false),
                        Occupation = c.Int(nullable: false),
                        NatureOfOccupation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Houses", t => t.CensusHouseNumber, cascadeDelete: true)
                .Index(t => t.CensusHouseNumber);
            
            CreateTable(
                "dbo.MemberRequestStatus",
                c => new
                    {
                        MemberRequestStatusId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberRequestStatusId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        AadharNumber = c.String(nullable: false, maxLength: 12),
                        Image = c.String(nullable: false),
                        IsApprover = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.AadharNumber, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberRequestStatus", "MemberId", "dbo.Members");
            DropForeignKey("dbo.People", "CensusHouseNumber", "dbo.Houses");
            DropIndex("dbo.Members", new[] { "AadharNumber" });
            DropIndex("dbo.Members", new[] { "Email" });
            DropIndex("dbo.MemberRequestStatus", new[] { "MemberId" });
            DropIndex("dbo.People", new[] { "CensusHouseNumber" });
            DropTable("dbo.Members");
            DropTable("dbo.MemberRequestStatus");
            DropTable("dbo.People");
            DropTable("dbo.Houses");
        }
    }
}
