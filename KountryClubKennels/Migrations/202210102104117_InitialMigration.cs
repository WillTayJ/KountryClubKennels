namespace KountryClubKennels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        photoPath = c.String(),
                        breed = c.String(),
                        akctype = c.String(),
                        birthday = c.DateTime(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dogs");
        }
    }
}
