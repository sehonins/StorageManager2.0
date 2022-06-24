using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorageManagerData.Migrations
{
    public partial class UpdatedEmploee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlocatedJob",
                table: "emploees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlocatedJob",
                table: "emploees");
        }
    }
}
