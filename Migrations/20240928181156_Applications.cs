using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLS.Migrations
{
    public partial class Applications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationLineBusiness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineBusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfUnits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapitalInvestment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossIncomeEssential = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossIncomeNonEssential = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignageBillboard_Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignageBillboard_NoOfUnits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightsAndMeasures_Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightsAndMeasures_NoOfUnits = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLineBusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRequirements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationLineBusiness");

            migrationBuilder.DropTable(
                name: "ApplicationRequirements");
        }
    }
}
