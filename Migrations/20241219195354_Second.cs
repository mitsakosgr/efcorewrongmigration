using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreWrongMigration.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "second");

            migrationBuilder.CreateTable(
                name: "OtherEntity",
                schema: "second",
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
                name: "IX_OtherEntity_BaseReferenceId1",
                schema: "second",
                table: "OtherEntity",
                column: "BaseReferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherEntity_BaseReference_BaseReferenceId",
                schema: "first",
                table: "OtherEntity");

            migrationBuilder.DropTable(
                name: "OtherEntity",
                schema: "second");
        }
    }
}
