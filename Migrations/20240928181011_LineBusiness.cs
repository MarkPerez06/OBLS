using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLS.Migrations
{
    public partial class LineBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LineBusiness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignageBillboard_Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignageBillboard_NoOfUnits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightsAndMeasures_Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightsAndMeasures_NoOfUnits = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineBusiness", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineBusiness");
        }
    }
}
