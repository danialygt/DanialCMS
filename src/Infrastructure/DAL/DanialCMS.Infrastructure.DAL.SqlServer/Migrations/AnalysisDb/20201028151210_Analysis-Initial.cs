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
                    Host = table.Column<string>(nullable: true),
                    RemoteIpAddress = table.Column<string>(maxLength: 15, nullable: true),
                    BrowserName = table.Column<string>(maxLength: 250, nullable: true),
                    OsName = table.Column<string>(maxLength: 400, nullable: true),
                    Path = table.Column<string>(maxLength: 700, nullable: true),
                    HttpMethod = table.Column<string>(maxLength: 10, nullable: true),
                    SatusCode = table.Column<int>(nullable: true),
                    ContentType = table.Column<string>(maxLength: 100, nullable: true),
                    ContentLength = table.Column<long>(nullable: true),
                    Scheme = table.Column<string>(maxLength: 50, nullable: true),
                    Port = table.Column<int>(maxLength: 10, nullable: true),
                    RemotePort = table.Column<int>(nullable: true),
                    Protocol = table.Column<string>(nullable: true),
                    Referer = table.Column<string>(maxLength: 200, nullable: true),
                    IsHttps = table.Column<bool>(nullable: true),
                    HasCockies = table.Column<bool>(nullable: true),
                    OSArchitecture = table.Column<string>(maxLength: 400, nullable: true)
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
