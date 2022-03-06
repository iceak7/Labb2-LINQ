using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2_LINQ.Migrations
{
    public partial class InititalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elever",
                columns: table => new
                {
                    ElevId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(nullable: true),
                    Efternamn = table.Column<string>(nullable: true),
                    Klass = table.Column<string>(nullable: true),
                    Ålder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elever", x => x.ElevId);
                });

            migrationBuilder.CreateTable(
                name: "Kurser",
                columns: table => new
                {
                    KursId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursNamn = table.Column<string>(nullable: true),
                    StartDatum = table.Column<DateTime>(nullable: false),
                    SlutDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.KursId);
                });

            migrationBuilder.CreateTable(
                name: "Lärare",
                columns: table => new
                {
                    LärareId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(nullable: true),
                    Efternamn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lärare", x => x.LärareId);
                });

            migrationBuilder.CreateTable(
                name: "Ämnen",
                columns: table => new
                {
                    ÄmneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ämnen", x => x.ÄmneId);
                });

            migrationBuilder.CreateTable(
                name: "ElevKurs",
                columns: table => new
                {
                    ElevKursId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevId = table.Column<int>(nullable: true),
                    KursId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevKurs", x => x.ElevKursId);
                    table.ForeignKey(
                        name: "FK_ElevKurs_Elever_ElevId",
                        column: x => x.ElevId,
                        principalTable: "Elever",
                        principalColumn: "ElevId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElevKurs_Kurser_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurser",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LärareKurs",
                columns: table => new
                {
                    LärareKursId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LärareId = table.Column<int>(nullable: true),
                    KursId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LärareKurs", x => x.LärareKursId);
                    table.ForeignKey(
                        name: "FK_LärareKurs_Kurser_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurser",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LärareKurs_Lärare_LärareId",
                        column: x => x.LärareId,
                        principalTable: "Lärare",
                        principalColumn: "LärareId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ÄmneKurs",
                columns: table => new
                {
                    ÄmneKursId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÄmneId = table.Column<int>(nullable: true),
                    KursId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ÄmneKurs", x => x.ÄmneKursId);
                    table.ForeignKey(
                        name: "FK_ÄmneKurs_Kurser_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurser",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ÄmneKurs_Ämnen_ÄmneId",
                        column: x => x.ÄmneId,
                        principalTable: "Ämnen",
                        principalColumn: "ÄmneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElevKurs_ElevId",
                table: "ElevKurs",
                column: "ElevId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevKurs_KursId",
                table: "ElevKurs",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_LärareKurs_KursId",
                table: "LärareKurs",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_LärareKurs_LärareId",
                table: "LärareKurs",
                column: "LärareId");

            migrationBuilder.CreateIndex(
                name: "IX_ÄmneKurs_KursId",
                table: "ÄmneKurs",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_ÄmneKurs_ÄmneId",
                table: "ÄmneKurs",
                column: "ÄmneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElevKurs");

            migrationBuilder.DropTable(
                name: "LärareKurs");

            migrationBuilder.DropTable(
                name: "ÄmneKurs");

            migrationBuilder.DropTable(
                name: "Elever");

            migrationBuilder.DropTable(
                name: "Lärare");

            migrationBuilder.DropTable(
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Ämnen");
        }
    }
}
