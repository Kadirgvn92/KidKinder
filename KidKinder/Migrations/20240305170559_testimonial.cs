using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidKinder.Migrations
{
    /// <inheritdoc />
    public partial class testimonial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Testimonials");
        }
    }
}
