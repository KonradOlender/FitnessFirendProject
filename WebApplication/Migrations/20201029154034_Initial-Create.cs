using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoriaCwiczenia",
                columns: table => new
                {
                    id_kategorii = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriaCwiczenia", x => x.id_kategorii);
                });

            migrationBuilder.CreateTable(
                name: "kategoriaSkladnikow",
                columns: table => new
                {
                    id_kategorii = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriaSkladnikow", x => x.id_kategorii);
                });

            migrationBuilder.CreateTable(
                name: "kategoriaTreningu",
                columns: table => new
                {
                    id_kategorii = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriaTreningu", x => x.id_kategorii);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id_roli = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id_roli);
                });

            migrationBuilder.CreateTable(
                name: "uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    imie = table.Column<string>(nullable: true),
                    login = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uzytkownicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cwiczenia",
                columns: table => new
                {
                    id_cwiczenia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false),
                    opis = table.Column<string>(nullable: false),
                    spalone_kalorie = table.Column<int>(nullable: false),
                    id_kategorii = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cwiczenia", x => x.id_cwiczenia);
                    table.ForeignKey(
                        name: "FK_cwiczenia_kategoriaCwiczenia_id_kategorii",
                        column: x => x.id_kategorii,
                        principalTable: "kategoriaCwiczenia",
                        principalColumn: "id_kategorii",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skladnik",
                columns: table => new
                {
                    id_skladnika = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    waga = table.Column<int>(nullable: false),
                    kalorie = table.Column<int>(nullable: false),
                    id_kategorii = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skladnik", x => x.id_skladnika);
                    table.ForeignKey(
                        name: "FK_skladnik_kategoriaSkladnikow_id_kategorii",
                        column: x => x.id_kategorii,
                        principalTable: "kategoriaSkladnikow",
                        principalColumn: "id_kategorii",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historiaUzytkownika",
                columns: table => new
                {
                    id_uzytkownika = table.Column<int>(nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    waga = table.Column<double>(nullable: false),
                    wzrost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiaUzytkownika", x => new { x.id_uzytkownika, x.data });
                    table.ForeignKey(
                        name: "FK_historiaUzytkownika_uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posilki",
                columns: table => new
                {
                    id_posilku = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false),
                    kalorie = table.Column<int>(nullable: false),
                    opis = table.Column<string>(nullable: true),
                    id_uzytkownika = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posilki", x => x.id_posilku);
                    table.ForeignKey(
                        name: "FK_posilki_uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolaUzytkownika",
                columns: table => new
                {
                    id_uzytkownika = table.Column<int>(nullable: false),
                    id_roli = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolaUzytkownika", x => new { x.id_roli, x.id_uzytkownika });
                    table.ForeignKey(
                        name: "FK_RolaUzytkownika_role_id_roli",
                        column: x => x.id_roli,
                        principalTable: "role",
                        principalColumn: "id_roli",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolaUzytkownika_uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "treningi",
                columns: table => new
                {
                    id_treningu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false),
                    id_kategorii = table.Column<int>(nullable: false),
                    id_uzytkownika = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treningi", x => x.id_treningu);
                    table.ForeignKey(
                        name: "FK_treningi_kategoriaTreningu_id_kategorii",
                        column: x => x.id_kategorii,
                        principalTable: "kategoriaTreningu",
                        principalColumn: "id_kategorii",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_treningi_uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posilekSzczegoly",
                columns: table => new
                {
                    id_posilku = table.Column<int>(nullable: false),
                    id_skladnika = table.Column<int>(nullable: false),
                    porcja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posilekSzczegoly", x => new { x.id_posilku, x.id_skladnika });
                    table.ForeignKey(
                        name: "FK_posilekSzczegoly_posilki_id_posilku",
                        column: x => x.id_posilku,
                        principalTable: "posilki",
                        principalColumn: "id_posilku",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_posilekSzczegoly_skladnik_id_skladnika",
                        column: x => x.id_skladnika,
                        principalTable: "skladnik",
                        principalColumn: "id_skladnika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "treningSzczegoly",
                columns: table => new
                {
                    id_treningu = table.Column<int>(nullable: false),
                    id_cwiczenia = table.Column<int>(nullable: false),
                    liczba_powtorzen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treningSzczegoly", x => new { x.id_treningu, x.id_cwiczenia });
                    table.ForeignKey(
                        name: "FK_treningSzczegoly_cwiczenia_id_cwiczenia",
                        column: x => x.id_cwiczenia,
                        principalTable: "cwiczenia",
                        principalColumn: "id_cwiczenia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_treningSzczegoly_treningi_id_treningu",
                        column: x => x.id_treningu,
                        principalTable: "treningi",
                        principalColumn: "id_treningu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cwiczenia_id_kategorii",
                table: "cwiczenia",
                column: "id_kategorii");

            migrationBuilder.CreateIndex(
                name: "IX_posilekSzczegoly_id_skladnika",
                table: "posilekSzczegoly",
                column: "id_skladnika");

            migrationBuilder.CreateIndex(
                name: "IX_posilki_id_uzytkownika",
                table: "posilki",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_RolaUzytkownika_id_uzytkownika",
                table: "RolaUzytkownika",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_skladnik_id_kategorii",
                table: "skladnik",
                column: "id_kategorii");

            migrationBuilder.CreateIndex(
                name: "IX_treningi_id_kategorii",
                table: "treningi",
                column: "id_kategorii");

            migrationBuilder.CreateIndex(
                name: "IX_treningi_id_uzytkownika",
                table: "treningi",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_treningSzczegoly_id_cwiczenia",
                table: "treningSzczegoly",
                column: "id_cwiczenia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historiaUzytkownika");

            migrationBuilder.DropTable(
                name: "posilekSzczegoly");

            migrationBuilder.DropTable(
                name: "RolaUzytkownika");

            migrationBuilder.DropTable(
                name: "treningSzczegoly");

            migrationBuilder.DropTable(
                name: "posilki");

            migrationBuilder.DropTable(
                name: "skladnik");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "cwiczenia");

            migrationBuilder.DropTable(
                name: "treningi");

            migrationBuilder.DropTable(
                name: "kategoriaSkladnikow");

            migrationBuilder.DropTable(
                name: "kategoriaCwiczenia");

            migrationBuilder.DropTable(
                name: "kategoriaTreningu");

            migrationBuilder.DropTable(
                name: "uzytkownicy");
        }
    }
}
