using FluentMigrator;

namespace GmailClient.Data.Migrations
{
    /// <summary>
    /// Initial database creation
    /// </summary>
    [Migration(1)]
    public class InitialCreate : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("User").AsString(255).NotNullable()
                .WithColumn("Password").AsString(255);

            Create.Table("Accounts")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Password").AsString(255);
        }

        public override void Down()
        {
            Delete.Table("Users");
            Delete.Table("Accounts");
        }
    }
}
