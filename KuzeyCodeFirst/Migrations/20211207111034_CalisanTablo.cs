using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuzeyCodeFirst.Migrations
{
    public partial class CalisanTablo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalisanId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalisanId",
                table: "SiparisDetaylari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AmirId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calisanlar_Calisanlar_AmirId",
                        column: x => x.AmirId,
                        principalTable: "Calisanlar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylari_CalisanId",
                table: "SiparisDetaylari",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_AmirId",
                table: "Calisanlar",
                column: "AmirId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisDetaylari_Siparisler_CalisanId",
                table: "SiparisDetaylari",
                column: "CalisanId",
                principalTable: "Siparisler",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiparisDetaylari_Siparisler_CalisanId",
                table: "SiparisDetaylari");

            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropIndex(
                name: "IX_SiparisDetaylari_CalisanId",
                table: "SiparisDetaylari");

            migrationBuilder.DropColumn(
                name: "CalisanId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "CalisanId",
                table: "SiparisDetaylari");
        }
    }
}
