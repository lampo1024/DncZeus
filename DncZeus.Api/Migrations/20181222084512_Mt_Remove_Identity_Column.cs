using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DncZeus.Api.Migrations
{
    public partial class Mt_Remove_Identity_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "DncUser");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DncUser");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "DncUser");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "DncRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DncRole");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "DncRole");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "DncPermission");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DncPermission");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "DncPermission");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "DncMenu");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DncMenu");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "DncMenu");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "DncIcon");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "DncIcon");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserGuid",
                table: "DncUser",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserGuid",
                table: "DncUser",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserGuid",
                table: "DncRole",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserGuid",
                table: "DncRole",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserGuid",
                table: "DncPermission",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserGuid",
                table: "DncPermission",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserGuid",
                table: "DncMenu",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserGuid",
                table: "DncMenu",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserGuid",
                table: "DncIcon",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserGuid",
                table: "DncIcon",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserGuid",
                table: "DncUser");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserGuid",
                table: "DncUser");

            migrationBuilder.DropColumn(
                name: "CreatedByUserGuid",
                table: "DncRole");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserGuid",
                table: "DncRole");

            migrationBuilder.DropColumn(
                name: "CreatedByUserGuid",
                table: "DncPermission");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserGuid",
                table: "DncPermission");

            migrationBuilder.DropColumn(
                name: "CreatedByUserGuid",
                table: "DncMenu");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserGuid",
                table: "DncMenu");

            migrationBuilder.DropColumn(
                name: "CreatedByUserGuid",
                table: "DncIcon");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserGuid",
                table: "DncIcon");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "DncUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DncUser",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "DncUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "DncRole",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DncRole",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "DncRole",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "DncPermission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DncPermission",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "DncPermission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "DncMenu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DncMenu",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "DncMenu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "DncIcon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "DncIcon",
                nullable: false,
                defaultValue: 0);
        }
    }
}
