using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_Controllers.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Breed = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    BodyType = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Coat = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Pattern = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");
        }
    }
}
