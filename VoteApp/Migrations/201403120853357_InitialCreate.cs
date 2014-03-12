namespace VoteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        PollId = c.Int(nullable: false),
                        Value = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.PollId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        PollId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        LastVoteDate = c.DateTime(nullable: false),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PollId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(),
                        FullName = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        Temp = c.Int(),
                        OptionId = c.Int(nullable: false),
                        VoteDate = c.DateTime(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.Options", t => t.OptionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.OptionId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Votes", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Polls", "UserId", "dbo.Users");
            DropForeignKey("dbo.Options", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Options", "PollId", "dbo.Polls");
            DropIndex("dbo.Votes", new[] { "User_UserId" });
            DropIndex("dbo.Votes", new[] { "OptionId" });
            DropIndex("dbo.Polls", new[] { "UserId" });
            DropIndex("dbo.Options", new[] { "User_UserId" });
            DropIndex("dbo.Options", new[] { "PollId" });
            DropTable("dbo.Votes");
            DropTable("dbo.Users");
            DropTable("dbo.Polls");
            DropTable("dbo.Options");
        }
    }
}
