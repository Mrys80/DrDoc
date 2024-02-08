using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrDoc.Data.Migrations
{
    public partial class BpAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BP",
                schema: "dbo",
                table: "Referrals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BP",
                schema: "dbo",
                table: "Referrals");
        }
    }
}
