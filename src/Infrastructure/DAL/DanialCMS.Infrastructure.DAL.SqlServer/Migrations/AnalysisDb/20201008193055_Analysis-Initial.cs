using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Migrations.AnalysisDb
{
    public partial class AnalysisInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMSAnalysis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 15, nullable: false),
                    BrowserName = table.Column<string>(maxLength: 15, nullable: false),
                    OsName = table.Column<string>(maxLength: 15, nullable: false),
                    Path = table.Column<string>(maxLength: 100, nullable: false),
                    HttpMethod = table.Column<string>(nullable: false),
                    SatusCode = table.Column<int>(nullable: false),
                    ContentType = table.Column<string>(nullable: false),
                    Protocol = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSAnalysis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMSAnalysis");
        }
    }
}
