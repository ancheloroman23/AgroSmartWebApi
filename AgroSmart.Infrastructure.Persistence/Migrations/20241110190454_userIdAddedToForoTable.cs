using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroSmart.Infraestructure.Persistence.Migrations
{
    public partial class userIdAddedToForoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Foros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Foros");
        }
    }
}
