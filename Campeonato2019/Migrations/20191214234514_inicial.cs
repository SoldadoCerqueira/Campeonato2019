using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Campeonato2019.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atleta",
                columns: table => new
                {
                    AtletaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Idade = table.Column<int>(nullable: false),
                    Nacionalidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleta", x => x.AtletaId);
                });

            migrationBuilder.CreateTable(
                name: "Placar",
                columns: table => new
                {
                    PlacarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtletaId = table.Column<int>(nullable: false),
                    Pontos = table.Column<long>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placar", x => x.PlacarId);
                    table.ForeignKey(
                        name: "FK_Placar_Atleta_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atleta",
                        principalColumn: "AtletaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Placar_AtletaId",
                table: "Placar",
                column: "AtletaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Placar");

            migrationBuilder.DropTable(
                name: "Atleta");
        }
    }
}
