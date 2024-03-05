using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidKinder.Migrations
{
    /// <inheritdoc />
    public partial class revision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DebtDescription",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondPhone",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalDebt",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KidClassID",
                table: "Kids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kids_KidClassID",
                table: "Kids",
                column: "KidClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_KidClasses_KidClassID",
                table: "Kids",
                column: "KidClassID",
                principalTable: "KidClasses",
                principalColumn: "KidClassID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_KidClasses_KidClassID",
                table: "Kids");

            migrationBuilder.DropIndex(
                name: "IX_Kids_KidClassID",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "DebtDescription",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "SecondPhone",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "TotalDebt",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "KidClassID",
                table: "Kids");
        }
    }
}
