using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConferenciasApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asistentes",
                columns: table => new
                {
                    asistente_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asistentes", x => x.asistente_id);
                });

            migrationBuilder.CreateTable(
                name: "conferencias",
                columns: table => new
                {
                    conferencia_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conferencias", x => x.conferencia_id);
                });

            migrationBuilder.CreateTable(
                name: "registros",
                columns: table => new
                {
                    registro_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConferenciaId = table.Column<int>(type: "integer", nullable: false),
                    AsistenteId = table.Column<int>(type: "integer", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros", x => x.registro_id);
                    table.ForeignKey(
                        name: "FK_registros_asistentes_AsistenteId",
                        column: x => x.AsistenteId,
                        principalTable: "asistentes",
                        principalColumn: "asistente_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registros_conferencias_ConferenciaId",
                        column: x => x.ConferenciaId,
                        principalTable: "conferencias",
                        principalColumn: "conferencia_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registros_AsistenteId",
                table: "registros",
                column: "AsistenteId");

            migrationBuilder.CreateIndex(
                name: "IX_registros_ConferenciaId",
                table: "registros",
                column: "ConferenciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registros");

            migrationBuilder.DropTable(
                name: "asistentes");

            migrationBuilder.DropTable(
                name: "conferencias");
        }
    }
}
