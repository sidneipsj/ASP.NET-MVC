namespace _020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_TAB_CUSTOMER : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(maxLength: 50),
                        last_name = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        country = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
