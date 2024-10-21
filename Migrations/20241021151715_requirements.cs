using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLS.Migrations
{
    public partial class requirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpload",
                table: "ApplicationRequirements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserRolesId",
                table: "ApplicationRequirements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ApplicationLineBusiness",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUpload = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropColumn(
                name: "IsUpload",
                table: "ApplicationRequirements");

            migrationBuilder.DropColumn(
                name: "UserRolesId",
                table: "ApplicationRequirements");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ApplicationLineBusiness");
        }
    }
}
