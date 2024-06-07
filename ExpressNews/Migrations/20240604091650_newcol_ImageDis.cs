using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressNews.Migrations
{
    /// <inheritdoc />
    public partial class newcol_ImageDis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageDiscription",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDiscription",
                table: "Articles");
        }
    }
}
