using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class KullaniciData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UlkeId",
                table: "Kullanici",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Maker = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Ulke = table.Column<string>(nullable: true),
                    UlkeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulke",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ulkeismi = table.Column<string>(nullable: true),
                    Kita = table.Column<string>(nullable: true),
                    Dil = table.Column<string>(nullable: true),
                    UrunId = table.Column<string>(nullable: true),
                    KullaniciId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ulke_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ulke_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_UlkeId",
                table: "Kullanici",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ulke_KullaniciId",
                table: "Ulke",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Ulke_UrunId",
                table: "Ulke",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_UlkeId",
                table: "Urun",
                column: "UlkeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanici_Ulke_UlkeId",
                table: "Kullanici",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_Ulke_UlkeId",
                table: "Urun",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanici_Ulke_UlkeId",
                table: "Kullanici");

            migrationBuilder.DropForeignKey(
                name: "FK_Ulke_Urun_UrunId",
                table: "Ulke");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Ulke");

            migrationBuilder.DropIndex(
                name: "IX_Kullanici_UlkeId",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "UlkeId",
                table: "Kullanici");
        }
    }
}
