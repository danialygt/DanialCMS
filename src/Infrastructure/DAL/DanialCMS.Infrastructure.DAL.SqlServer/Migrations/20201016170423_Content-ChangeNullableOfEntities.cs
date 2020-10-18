using Microsoft.EntityFrameworkCore.Migrations;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Migrations
{
    public partial class ContentChangeNullableOfEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Categories_CategoryId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_FileManager_PhotoId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Writers_FileManager_PhotoId",
                table: "Writers");

            migrationBuilder.AlterColumn<long>(
                name: "PhotoId",
                table: "Writers",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "Contents",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<long>(
                name: "PhotoId",
                table: "Contents",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Contents",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Categories_CategoryId",
                table: "Contents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_FileManager_PhotoId",
                table: "Contents",
                column: "PhotoId",
                principalTable: "FileManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_FileManager_PhotoId",
                table: "Writers",
                column: "PhotoId",
                principalTable: "FileManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Categories_CategoryId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_FileManager_PhotoId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Writers_FileManager_PhotoId",
                table: "Writers");

            migrationBuilder.AlterColumn<long>(
                name: "PhotoId",
                table: "Writers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "Contents",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PhotoId",
                table: "Contents",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Contents",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Categories_CategoryId",
                table: "Contents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_FileManager_PhotoId",
                table: "Contents",
                column: "PhotoId",
                principalTable: "FileManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_FileManager_PhotoId",
                table: "Writers",
                column: "PhotoId",
                principalTable: "FileManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
