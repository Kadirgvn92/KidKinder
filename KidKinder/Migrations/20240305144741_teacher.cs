using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidKinder.Migrations
{
    /// <inheritdoc />
    public partial class teacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KidClassID",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_KidClassID",
                table: "Teachers",
                column: "KidClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_KidClasses_KidClassID",
                table: "Teachers",
                column: "KidClassID",
                principalTable: "KidClasses",
                principalColumn: "KidClassID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_KidClasses_KidClassID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_KidClassID",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "KidClassID",
                table: "Teachers");
        }
    }
}
