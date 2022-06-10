namespace BigSchool_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropColumn("dbo.Courses", "CategoryId");
            RenameColumn(table: "dbo.Courses", name: "Category_Id", newName: "CategoryId");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Courses", "CategoryId", c => c.Int());
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            RenameColumn(table: "dbo.Courses", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Courses", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
