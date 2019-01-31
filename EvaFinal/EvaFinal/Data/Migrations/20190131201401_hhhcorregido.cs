using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EvaFinal.Data.Migrations
{
    public partial class hhhcorregido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hacer",
                columns: table => new
                {
                    hacerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExamenId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumMatricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hacer", x => x.hacerid);
                    table.ForeignKey(
                        name: "FK_Hacer_Examen_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examen",
                        principalColumn: "ExamenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hacer_Alumnos_NumMatricula",
                        column: x => x.NumMatricula,
                        principalTable: "Alumnos",
                        principalColumn: "NumMatricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hacer_ExamenId",
                table: "Hacer",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Hacer_NumMatricula",
                table: "Hacer",
                column: "NumMatricula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hacer");
        }
    }
}
