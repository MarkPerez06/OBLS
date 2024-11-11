using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLS.Migrations
{
    public partial class allTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Application_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Application_PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Application_Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Application_Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Application_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Application_DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Application_IsGenerateBrgyClearance = table.Column<bool>(type: "bit", nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business_IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Business_TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business_OrganizationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Business_Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business_RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business_TIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business_IsFilipino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner_Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainOffice_Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainOffice_Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainOffice_CityMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainOffice_Brgy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainOffice_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainOffice_HouseBuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainOffice_BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainOffice_LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainOffice_BlockNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainOffice_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainOffice_Subdivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessOperation_BusinessActivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessOperation_OtherBusinessActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessOperation_BusinessAreaSqm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessOperation_TotalFloorArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessOperation_EmployeeMale = table.Column<int>(type: "int", nullable: true),
                    BusinessOperation_EmployeeFemale = table.Column<int>(type: "int", nullable: true),
                    BusinessOperation_TotalEmployeeWithLGU = table.Column<int>(type: "int", nullable: true),
                    BusinessOperation_TotalVanTruck = table.Column<int>(type: "int", nullable: true),
                    BusinessOperation_TotalMotorcycle = table.Column<int>(type: "int", nullable: true),
                    BusinessOperation_IsOwned = table.Column<bool>(type: "bit", nullable: false),
                    BusinessOperation_TaxDeclarationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessOperation_PropertyIdentificationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessOperation_HasTaxIncentives = table.Column<bool>(type: "bit", nullable: false),
                    BusinessOperation_PleaseSpecifyTheEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessOperation_IncentiveCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation_Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessLocation_Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessLocation_CityMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessLocation_Brgy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessLocation_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessLocation_HouseBuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation_BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation_LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation_BlockNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation_Subdivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permit_ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Permit_DateRelease = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Permit_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Permit_IsPaid = table.Column<bool>(type: "bit", nullable: true),
                    Permit_Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

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
                    WeightsAndMeasures_NoOfUnits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    UserRolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUpload = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationSignatories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSignatories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TaxesFees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxesFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "ApplicationLineBusiness");

            migrationBuilder.DropTable(
                name: "ApplicationRequirements");

            migrationBuilder.DropTable(
                name: "ApplicationSignatories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LineBusiness");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "TaxesFees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
