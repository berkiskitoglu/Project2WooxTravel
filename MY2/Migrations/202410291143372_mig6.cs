namespace MY2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Image");
        }
    }
}
