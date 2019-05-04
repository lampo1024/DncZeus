using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DncZeus.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DncIcon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Custom = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedByUserGuid = table.Column<Guid>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserGuid = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DncIcon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DncMenu",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    ParentGuid = table.Column<Guid>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false),
                    IsDefaultRouter = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedByUserGuid = table.Column<Guid>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserGuid = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true),
                    Component = table.Column<string>(maxLength: 255, nullable: true),
                    HideInMenu = table.Column<int>(nullable: true),
                    NotCache = table.Column<int>(nullable: true),
                    BeforeCloseFun = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DncMenu", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "DncRole",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedByUserGuid = table.Column<Guid>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserGuid = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true),
                    IsSuperAdministrator = table.Column<bool>(nullable: false),
                    IsBuiltin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DncRole", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DncUser",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    IsLocked = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedByUserGuid = table.Column<Guid>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserGuid = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(800)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DncUser", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "DncPermission",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MenuGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ActionCode = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    CreatedByUserGuid = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserGuid = table.Column<Guid>(nullable: true),
                    ModifiedByUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DncPermission", x => x.Code);
                    table.ForeignKey(
                        name: "FK_DncPermission_DncMenu_MenuGuid",
                        column: x => x.MenuGuid,
                        principalTable: "DncMenu",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DncUserRoleMapping",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(nullable: false),
                    RoleCode = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DncUserRoleMapping", x => new { x.UserGuid, x.RoleCode });
                    table.ForeignKey(
                        name: "FK_DncUserRoleMapping_DncRole_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "DncRole",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DncUserRoleMapping_DncUser_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "DncUser",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DncRolePermissionMapping",
                columns: table => new
                {
                    RoleCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PermissionCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DncRolePermissionMapping", x => new { x.RoleCode, x.PermissionCode });
                    table.ForeignKey(
                        name: "FK_DncRolePermissionMapping_DncPermission_PermissionCode",
                        column: x => x.PermissionCode,
                        principalTable: "DncPermission",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DncRolePermissionMapping_DncRole_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "DncRole",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DncPermission_Code",
                table: "DncPermission",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DncPermission_MenuGuid",
                table: "DncPermission",
                column: "MenuGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DncRole_Code",
                table: "DncRole",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DncRolePermissionMapping_PermissionCode",
                table: "DncRolePermissionMapping",
                column: "PermissionCode");

            migrationBuilder.CreateIndex(
                name: "IX_DncUserRoleMapping_RoleCode",
                table: "DncUserRoleMapping",
                column: "RoleCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DncIcon");

            migrationBuilder.DropTable(
                name: "DncRolePermissionMapping");

            migrationBuilder.DropTable(
                name: "DncUserRoleMapping");

            migrationBuilder.DropTable(
                name: "DncPermission");

            migrationBuilder.DropTable(
                name: "DncRole");

            migrationBuilder.DropTable(
                name: "DncUser");

            migrationBuilder.DropTable(
                name: "DncMenu");
        }
    }
}
