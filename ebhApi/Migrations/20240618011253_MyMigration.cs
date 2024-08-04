using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ebhApi.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ekipler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekipler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubeAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubeTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EbhBasvurulari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TalepTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IhbarSahibi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepNo1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepNo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HizmetAlacakKisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    Tckn = table.Column<long>(type: "bigint", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    EgitimDurum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdaSayi = table.Column<int>(type: "int", nullable: true),
                    BakimDurumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresTarif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IhbarDetay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkipAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcilMi = table.Column<bool>(type: "bit", nullable: false),
                    Depremzede = table.Column<bool>(type: "bit", nullable: true),
                    Soybis = table.Column<bool>(type: "bit", nullable: true),
                    Heskod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EbhBasvurulari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EbhBasvurulari_Ekipler_EkipId",
                        column: x => x.EkipId,
                        principalTable: "Ekipler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EkipSube",
                columns: table => new
                {
                    EkipSubesiId = table.Column<int>(type: "int", nullable: false),
                    SubeyeAitEkiplerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkipSube", x => new { x.EkipSubesiId, x.SubeyeAitEkiplerId });
                    table.ForeignKey(
                        name: "FK_EkipSube_Ekipler_SubeyeAitEkiplerId",
                        column: x => x.SubeyeAitEkiplerId,
                        principalTable: "Ekipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EkipSube_Subeler_EkipSubesiId",
                        column: x => x.EkipSubesiId,
                        principalTable: "Subeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullanicininEkipleriId = table.Column<int>(type: "int", nullable: true),
                    KullanicininSubesiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Ekipler_KullanicininEkipleriId",
                        column: x => x.KullanicininEkipleriId,
                        principalTable: "Ekipler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Subeler_KullanicininSubesiId",
                        column: x => x.KullanicininSubesiId,
                        principalTable: "Subeler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EbhBasvurularSube",
                columns: table => new
                {
                    EbhBasvuruYapilanSubeId = table.Column<int>(type: "int", nullable: false),
                    SubeyeYapilanBasvurularId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EbhBasvurularSube", x => new { x.EbhBasvuruYapilanSubeId, x.SubeyeYapilanBasvurularId });
                    table.ForeignKey(
                        name: "FK_EbhBasvurularSube_EbhBasvurulari_SubeyeYapilanBasvurularId",
                        column: x => x.SubeyeYapilanBasvurularId,
                        principalTable: "EbhBasvurulari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EbhBasvurularSube_Subeler_EbhBasvuruYapilanSubeId",
                        column: x => x.EbhBasvuruYapilanSubeId,
                        principalTable: "Subeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hastaliklar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastalikAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EbhBasvurularId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaliklar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hastaliklar_EbhBasvurulari_EbhBasvurularId",
                        column: x => x.EbhBasvurularId,
                        principalTable: "EbhBasvurulari",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EbhBasvurulari_EkipId",
                table: "EbhBasvurulari",
                column: "EkipId");

            migrationBuilder.CreateIndex(
                name: "IX_EbhBasvurularSube_SubeyeYapilanBasvurularId",
                table: "EbhBasvurularSube",
                column: "SubeyeYapilanBasvurularId");

            migrationBuilder.CreateIndex(
                name: "IX_EkipSube_SubeyeAitEkiplerId",
                table: "EkipSube",
                column: "SubeyeAitEkiplerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hastaliklar_EbhBasvurularId",
                table: "Hastaliklar",
                column: "EbhBasvurularId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_KullanicininEkipleriId",
                table: "Users",
                column: "KullanicininEkipleriId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_KullanicininSubesiId",
                table: "Users",
                column: "KullanicininSubesiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EbhBasvurularSube");

            migrationBuilder.DropTable(
                name: "EkipSube");

            migrationBuilder.DropTable(
                name: "Hastaliklar");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EbhBasvurulari");

            migrationBuilder.DropTable(
                name: "Subeler");

            migrationBuilder.DropTable(
                name: "Ekipler");
        }
    }
}
