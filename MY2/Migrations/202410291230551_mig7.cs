namespace MY2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Image");
        }
    }
}
