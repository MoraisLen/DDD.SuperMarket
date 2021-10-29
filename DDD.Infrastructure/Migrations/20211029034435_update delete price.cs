using Microsoft.EntityFrameworkCore.Migrations;

namespace DDD.Infrastructure.Migrations
{
    public partial class updatedeleteprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
