namespace Administrator.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DeleteTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Manager.Groups",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    id_main = c.Int(nullable: false),
                    group = c.String(nullable: false, maxLength: 30, unicode: false),
                    description = c.String(maxLength: 200, unicode: false),
                    read_user = c.Boolean(nullable: false),
                    update_user = c.Boolean(nullable: false),
                    create_user = c.Boolean(nullable: false),
                    delete_user = c.Boolean(nullable: false),
                    read_group = c.Boolean(nullable: false),
                    update_group = c.Boolean(nullable: false),
                    create_group = c.Boolean(nullable: false),
                    delete_group = c.Boolean(nullable: false),
                    read_permission = c.Boolean(nullable: false),
                    update_permission = c.Boolean(nullable: false),
                    create_permission = c.Boolean(nullable: false),
                    delete_permission = c.Boolean(nullable: false),
                    status = c.Boolean(nullable: false),
                    edit_user = c.Int(),
                    edit_date = c.DateTime(),
                    generate_user = c.Int(),
                    generate_date = c.DateTime(),
                    remove_user = c.Int(),
                    remove_date = c.DateTime(),
                    remove_status = c.Boolean(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "Manager.Users",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    id_main = c.Int(nullable: false),
                    id_group = c.Int(nullable: false),
                    type = c.Int(nullable: false),
                    photo = c.String(maxLength: 60, unicode: false),
                    email = c.String(nullable: false, maxLength: 80, unicode: false),
                    password = c.String(nullable: false, maxLength: 250, unicode: false),
                    name = c.String(nullable: false, maxLength: 50, unicode: false),
                    lastnamep = c.String(nullable: false, maxLength: 30, unicode: false),
                    lastnamem = c.String(maxLength: 30, unicode: false),
                    attemp = c.Int(),
                    cycle = c.Int(),
                    status = c.Boolean(nullable: false),
                    edit_user = c.Int(),
                    edit_date = c.DateTime(),
                    generate_user = c.Int(),
                    generate_date = c.DateTime(),
                    remove_user = c.Int(),
                    remove_date = c.DateTime(),
                    remove_status = c.Boolean(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("Manager.Groups", t => t.id_group, cascadeDelete: true)
                .Index(t => t.id_group);

        }

        public override void Down()
        {
            DropForeignKey("Manager.Users", "id_group", "Manager.Groups");
            DropIndex("Manager.Users", new[] { "id_group" });
            DropTable("Manager.Users");
            DropTable("Manager.Groups");
        }
    }
}
