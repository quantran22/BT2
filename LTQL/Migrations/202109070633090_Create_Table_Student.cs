namespace LTQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Student : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Student", newName: "Students");
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MaSinhVien = c.String(nullable: false, maxLength: 128),
                        TenSinhVien = c.String(),
                    })
                .PrimaryKey(t => t.MaSinhVien);
            
            AddColumn("dbo.Students", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Address");
            DropTable("dbo.SinhViens");
            RenameTable(name: "dbo.Students", newName: "Student");
        }
    }
}
