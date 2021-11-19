using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstEFWithFluentApi.Migrations
{
    public partial class BookMigration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    theactorofthisbook = table.Column<string>(name: "the actor of this book", nullable: false),
                    thetitleofthisbook = table.Column<string>(name: "the title of this book", nullable: false),
                    thedescriptionofthisbook = table.Column<string>(name: "the description of this book", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("#", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
