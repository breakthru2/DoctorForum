namespace SimpleChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedQuestiontoreply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Replies", "QuestionId");
            AddForeignKey("dbo.Replies", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Replies", new[] { "QuestionId" });
            DropColumn("dbo.Replies", "QuestionId");
        }
    }
}
