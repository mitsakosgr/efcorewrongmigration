using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreWrongMigration.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "first");

            migrationBuilder.CreateTable(
                name: "BaseReference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Something = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseReference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherEntity",
                schema: "first",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseReferenceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherEntity_BaseReference_BaseReferenceId",
                        column: x => x.BaseReferenceId,
                        principalTable: "BaseReference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherEntity_BaseReferenceId",
                schema: "first",
                table: "OtherEntity",
                column: "BaseReferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherEntity",
                schema: "first");

            migrationBuilder.DropTable(
                name: "BaseReference");
        }
    }
}
