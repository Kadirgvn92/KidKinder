using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidKinder.Migrations
{
    /// <inheritdoc />
    public partial class gallery_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Galleries",
                newName: "ImageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Galleries",
                newName: "Category");
        }
    }
}
