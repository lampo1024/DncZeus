using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DncZeus.Api.Migrations.ProductDb
{
    public partial class _20191214aProductCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TexNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Name_en = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Name_zh = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Element = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
