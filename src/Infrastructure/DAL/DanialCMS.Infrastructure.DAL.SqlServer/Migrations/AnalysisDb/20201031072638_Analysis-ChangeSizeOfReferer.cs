using Microsoft.EntityFrameworkCore.Migrations;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Migrations.AnalysisDb
{
    public partial class AnalysisChangeSizeOfReferer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Referer",
                table: "CMSAnalysis",
                maxLength: 700,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Referer",
                table: "CMSAnalysis",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 700,
                oldNullable: true);
        }
    }
}
