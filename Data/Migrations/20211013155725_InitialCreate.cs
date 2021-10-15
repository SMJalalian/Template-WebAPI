using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geo_Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISO2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISO3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCode = table.Column<int>(type: "int", nullable: false),
                    PhoneCode = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idn_Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idn_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Geo_Proviences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo_Proviences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geo_Proviences_Geo_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Geo_Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Idn_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idn_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idn_RoleClaims_Idn_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Idn_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Geo_Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geo_Cities_Geo_Proviences_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "Geo_Proviences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Idn_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Idn_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idn_Users_Geo_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Geo_Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idn_Users_Geo_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Geo_Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idn_Users_Geo_Proviences_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "Geo_Proviences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Idn_Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idn_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idn_Addresses_Geo_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Geo_Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idn_Addresses_Geo_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Geo_Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idn_Addresses_Geo_Proviences_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "Geo_Proviences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idn_Addresses_Idn_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Idn_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Idn_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idn_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idn_UserClaims_Idn_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Idn_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idn_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idn_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Idn_UserLogins_Idn_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Idn_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idn_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idn_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Idn_UserRoles_Idn_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Idn_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Idn_UserRoles_Idn_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Idn_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idn_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idn_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Idn_UserTokens_Idn_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Idn_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Geo_Cities_ProvienceId",
                table: "Geo_Cities",
                column: "ProvienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Geo_Proviences_CountryId",
                table: "Geo_Proviences",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_Addresses_CityId",
                table: "Idn_Addresses",
                column: "CityId",
                unique: true,
                filter: "[CityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_Addresses_CountryId",
                table: "Idn_Addresses",
                column: "CountryId",
                unique: true,
                filter: "[CountryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_Addresses_ProvienceId",
                table: "Idn_Addresses",
                column: "ProvienceId",
                unique: true,
                filter: "[ProvienceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_Addresses_UserId",
                table: "Idn_Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_RoleClaims_RoleId",
                table: "Idn_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Idn_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_UserClaims_UserId",
                table: "Idn_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_UserLogins_UserId",
                table: "Idn_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_UserRoles_RoleId",
                table: "Idn_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Idn_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_Users_CityId",
                table: "Idn_Users",
                column: "CityId",
                unique: true,
                filter: "[CityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_Users_CountryId",
                table: "Idn_Users",
                column: "CountryId",
                unique: true,
                filter: "[CountryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Idn_Users_ProvienceId",
                table: "Idn_Users",
                column: "ProvienceId",
                unique: true,
                filter: "[ProvienceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Idn_Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Idn_Addresses");

            migrationBuilder.DropTable(
                name: "Idn_RoleClaims");

            migrationBuilder.DropTable(
                name: "Idn_UserClaims");

            migrationBuilder.DropTable(
                name: "Idn_UserLogins");

            migrationBuilder.DropTable(
                name: "Idn_UserRoles");

            migrationBuilder.DropTable(
                name: "Idn_UserTokens");

            migrationBuilder.DropTable(
                name: "Idn_Roles");

            migrationBuilder.DropTable(
                name: "Idn_Users");

            migrationBuilder.DropTable(
                name: "Geo_Cities");

            migrationBuilder.DropTable(
                name: "Geo_Proviences");

            migrationBuilder.DropTable(
                name: "Geo_Countries");
        }
    }
}
